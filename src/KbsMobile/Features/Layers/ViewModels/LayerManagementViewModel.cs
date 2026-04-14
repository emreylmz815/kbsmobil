using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Core.Models;
using KbsMobile.Services.Layers;

namespace KbsMobile.Features.Layers.ViewModels;

public partial class LayerManagementViewModel(IMapLayerService layerService, IExceptionHandler exceptionHandler) : BaseViewModel
{
    public ObservableCollection<WmsLayerDefinition> Layers { get; } = [];

    [RelayCommand]
    private async Task LoadAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            Layers.Clear();
            foreach (var item in await layerService.GetAsync())
                Layers.Add(item);
        }, exceptionHandler);
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            for (var i = 0; i < Layers.Count; i++) Layers[i].Order = i;
            await layerService.SaveStateAsync(Layers);
            await Shell.Current.DisplayAlert("Bilgi", "Katman ayarları kaydedildi.", "Tamam");
        }, exceptionHandler);
    }
}
