namespace KbsMobile.Core.Models;

public class LayerHitResult
{
    public string LayerTitle { get; set; } = string.Empty;
    public string FeatureId { get; set; } = string.Empty;
    public Dictionary<string, string> Attributes { get; set; } = [];
}
