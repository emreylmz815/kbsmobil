using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Core.Models;
using KbsMobile.Features.Records.Services;

namespace KbsMobile.Features.Records.ViewModels;

public partial class RecordsViewModel(IRecordService recordService, INavigationService navigationService, IExceptionHandler exceptionHandler) : BaseViewModel
{
    public ObservableCollection<FieldRecord> Items { get; } = [];
    [ObservableProperty] private string searchText = string.Empty;

    [RelayCommand]
    private async Task LoadAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            Items.Clear();
            foreach (var item in await recordService.GetAsync(SearchText))
                Items.Add(item);
        }, exceptionHandler);
    }

    [RelayCommand] private Task OpenCreateAsync() => navigationService.GoToAsync(nameof(Views.RecordEditPage));

    [RelayCommand]
    private Task OpenDetailAsync(FieldRecord record)
    {
        var p = new Dictionary<string, object> { ["RecordId"] = record.Id };
        return navigationService.GoToAsync(nameof(Views.RecordDetailPage), p);
    }
}
