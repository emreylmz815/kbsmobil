namespace KbsMobile.Core.Models;

public class WmsLayerDefinition
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string LayerName { get; set; } = string.Empty;
    public string Format { get; set; } = "image/png";
    public bool IsVisible { get; set; } = true;
    public int Order { get; set; }
}
