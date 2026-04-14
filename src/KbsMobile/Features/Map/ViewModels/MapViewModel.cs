using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Services.Layers;
using KbsMobile.Services.Location;
using KbsMobile.Features.Map.Services;

namespace KbsMobile.Features.Map.ViewModels;

public partial class MapViewModel(
    IMapLayerService layerService,
    ILocationService locationService,
    IMapBridgeService mapBridgeService,
    INavigationService navigationService,
    IExceptionHandler exceptionHandler) : BaseViewModel
{
    [ObservableProperty] private string mapHtml = "<html><body>Loading...</body></html>";

    [RelayCommand]
    public async Task LoadMapAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            var layers = await layerService.GetAsync();
            var location = await locationService.GetCurrentAsync();
            MapHtml = mapBridgeService.BuildHtml(layers, location?.Latitude, location?.Longitude);
        }, exceptionHandler);
    }

    [RelayCommand] public Task OpenLayerPanelAsync() => navigationService.GoToAsync(nameof(Features.Layers.Views.LayerManagementPage));
}
