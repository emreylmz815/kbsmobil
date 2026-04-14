using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Core.Models;
using KbsMobile.Features.Records.Services;
using KbsMobile.Services.Location;

namespace KbsMobile.Features.Records.ViewModels;

[QueryProperty(nameof(RecordId), nameof(RecordId))]
public partial class RecordEditViewModel(IRecordService recordService, ILocationService locationService, INavigationService navigationService, IExceptionHandler exceptionHandler) : BaseViewModel
{
    [ObservableProperty] private string recordId = string.Empty;
    [ObservableProperty] private string titleInput = string.Empty;
    [ObservableProperty] private string categoryInput = "Altyapi";
    [ObservableProperty] private string descriptionInput = string.Empty;
    [ObservableProperty] private DateTime incidentDate = DateTime.Today;
    [ObservableProperty] private bool isUrgent;
    [ObservableProperty] private double latitude;
    [ObservableProperty] private double longitude;

    partial void OnRecordIdChanged(string value) => LoadCommand.Execute(null);

    [RelayCommand]
    private async Task LoadAsync()
    {
        if (string.IsNullOrWhiteSpace(RecordId)) return;

        await ExecuteSafeAsync(async () =>
        {
            var item = await recordService.GetByIdAsync(RecordId);
            if (item is null) return;

            TitleInput = item.Title;
            CategoryInput = item.Category;
            DescriptionInput = item.Description;
            IncidentDate = item.IncidentDate;
            IsUrgent = item.IsUrgent;
            Latitude = item.Latitude;
            Longitude = item.Longitude;
        }, exceptionHandler);
    }

    [RelayCommand]
    private async Task FillCurrentLocationAsync()
    {
        var location = await locationService.GetCurrentAsync();
        if (location is null) return;
        Latitude = location.Latitude;
        Longitude = location.Longitude;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(TitleInput))
        {
            ErrorMessage = "Başlık zorunludur.";
            return;
        }

        await ExecuteSafeAsync(async () =>
        {
            var item = new FieldRecord
            {
                Id = string.IsNullOrWhiteSpace(RecordId) ? Guid.NewGuid().ToString("N") : RecordId,
                Title = TitleInput,
                Category = CategoryInput,
                Description = DescriptionInput,
                IncidentDate = IncidentDate,
                IsUrgent = IsUrgent,
                Latitude = Latitude,
                Longitude = Longitude
            };

            await recordService.SaveAsync(item);
            await navigationService.GoBackAsync();
        }, exceptionHandler);
    }

    [RelayCommand]
    private Task OpenMediaAsync()
    {
        var p = new Dictionary<string, object> { ["RecordId"] = RecordId };
        return navigationService.GoToAsync(nameof(KbsMobile.Features.Media.Views.MediaCapturePage), p);
    }
}
