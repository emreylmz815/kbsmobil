using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Core.Models;
using KbsMobile.Features.Records.Services;

namespace KbsMobile.Features.Records.ViewModels;

[QueryProperty(nameof(RecordId), nameof(RecordId))]
public partial class RecordDetailViewModel(IRecordService recordService, INavigationService navigationService, IExceptionHandler exceptionHandler) : BaseViewModel
{
    [ObservableProperty] private string recordId = string.Empty;
    [ObservableProperty] private FieldRecord? record;

    partial void OnRecordIdChanged(string value) => LoadCommand.Execute(null);

    [RelayCommand]
    private async Task LoadAsync()
    {
        await ExecuteSafeAsync(async () => Record = await recordService.GetByIdAsync(RecordId), exceptionHandler);
    }

    [RelayCommand]
    private Task EditAsync()
    {
        var p = new Dictionary<string, object> { ["RecordId"] = RecordId };
        return navigationService.GoToAsync(nameof(Views.RecordEditPage), p);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            await recordService.DeleteAsync(RecordId);
            await navigationService.GoBackAsync();
        }, exceptionHandler);
    }
}
