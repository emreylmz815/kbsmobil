using KbsMobile.Core.Models;

namespace KbsMobile.Services.Layers;

public interface IWmsLayerRepository
{
    Task<IReadOnlyList<WmsLayerDefinition>> GetLayersAsync();
}
