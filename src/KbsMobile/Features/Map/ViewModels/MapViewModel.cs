using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Core.Models;
using KbsMobile.Features.Auth.Services;
using KbsMobile.Features.Map.Services;
using KbsMobile.Features.Records.Services;
using KbsMobile.Services.Layers;
using KbsMobile.Services.Location;

namespace KbsMobile.Features.Map.ViewModels;

public partial class MapViewModel(
    IMapLayerService layerService,
    ILocationService locationService,
    IMapBridgeService mapBridgeService,
    IRecordService recordService,
    IAuthService authService,
    INavigationService navigationService,
    IExceptionHandler exceptionHandler) : BaseViewModel
{
    public ObservableCollection<FieldRecord> Records { get; } = [];

    [ObservableProperty] private HtmlWebViewSource mapHtmlSource = new() { Html = "<html><body>Loading...</body></html>" };
    [ObservableProperty] private bool isLeftMenuOpen;
    [ObservableProperty] private bool isRightMenuOpen;
    [ObservableProperty] private FieldRecord? selectedRecord;
    [ObservableProperty] private bool hasSelectedRecord;

    public event Func<double, double, Task>? FocusRequested;

    [RelayCommand]
    public async Task LoadMapAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            var layers = await layerService.GetAsync();
            var location = await locationService.GetCurrentAsync();
            MapHtmlSource = new HtmlWebViewSource
            {
                Html = mapBridgeService.BuildHtml(layers, location?.Latitude ?? 40.8428, location?.Longitude ?? 31.1565)
            };

            Records.Clear();
            foreach (var item in await recordService.GetAsync())
                Records.Add(item);
        }, exceptionHandler);
    }

    [RelayCommand] private void ToggleLeftMenu() => IsLeftMenuOpen = !IsLeftMenuOpen;
    [RelayCommand] private void ToggleRightMenu() => IsRightMenuOpen = !IsRightMenuOpen;

    partial void OnSelectedRecordChanged(FieldRecord? value) => HasSelectedRecord = value is not null;

    [RelayCommand]
    private void OpenRecordCard(FieldRecord record)
    {
        SelectedRecord = record;
    }

    [RelayCommand]
    private async Task ShowRecordOnMapAsync()
    {
        if (SelectedRecord is null) return;
        IsLeftMenuOpen = false;
        IsRightMenuOpen = false;
        await (FocusRequested?.Invoke(SelectedRecord.Latitude, SelectedRecord.Longitude) ?? Task.CompletedTask);
    }

    [RelayCommand] public Task OpenLayerPanelAsync() => navigationService.GoToAsync(nameof(Features.Layers.Views.LayerManagementPage));
    [RelayCommand] public Task OpenProfileAsync() => navigationService.GoToAsync("//main/settings");

    [RelayCommand]
    public async Task LogoutAsync()
    {
        await authService.LogoutAsync();
        await navigationService.GoToAsync("//login");
    }
}
