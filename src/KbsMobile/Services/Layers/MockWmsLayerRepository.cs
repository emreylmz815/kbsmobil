using KbsMobile.Core.Models;

namespace KbsMobile.Services.Layers;

public class MockWmsLayerRepository : IWmsLayerRepository
{
    public Task<IReadOnlyList<WmsLayerDefinition>> GetLayersAsync() => Task.FromResult<IReadOnlyList<WmsLayerDefinition>>(
    [
        new() { Title = "Parsel", Url = "https://ahocevar.com/geoserver/wms", LayerName = "topp:states", IsVisible = true, Order = 0 },
        new() { Title = "Nüfus Yoğunluğu", Url = "https://ahocevar.com/geoserver/wms", LayerName = "ne:ne", IsVisible = false, Order = 1 }
    ]);
}
