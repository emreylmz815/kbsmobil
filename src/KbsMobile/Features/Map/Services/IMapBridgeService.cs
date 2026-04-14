using KbsMobile.Core.Models;

namespace KbsMobile.Features.Map.Services;

public interface IMapBridgeService
{
    string BuildHtml(IEnumerable<WmsLayerDefinition> layers, double? latitude = null, double? longitude = null);
}
