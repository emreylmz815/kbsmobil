using KbsMobile.Core.Models;

namespace KbsMobile.Services.Layers;

public class MapLayerService(IWmsLayerRepository repository) : IMapLayerService
{
    private List<WmsLayerDefinition>? _cache;

    public async Task<IReadOnlyList<WmsLayerDefinition>> GetAsync() => _cache ??= (await repository.GetLayersAsync()).ToList();

    public Task<IReadOnlyList<WmsLayerDefinition>> SaveStateAsync(IEnumerable<WmsLayerDefinition> layers)
    {
        _cache = layers.OrderBy(x => x.Order).ToList();
        return Task.FromResult<IReadOnlyList<WmsLayerDefinition>>(_cache);
    }
}
