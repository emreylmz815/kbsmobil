using KbsMobile.Core.Models;

namespace KbsMobile.Services.Layers;

public interface IMapLayerService
{
    Task<IReadOnlyList<WmsLayerDefinition>> GetAsync();
    Task<IReadOnlyList<WmsLayerDefinition>> SaveStateAsync(IEnumerable<WmsLayerDefinition> layers);
}
