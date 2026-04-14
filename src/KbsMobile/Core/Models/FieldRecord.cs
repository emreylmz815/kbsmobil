namespace KbsMobile.Core.Models;

public class FieldRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = "Altyapi";
    public string Description { get; set; } = string.Empty;
    public DateTime IncidentDate { get; set; } = DateTime.UtcNow;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsUrgent { get; set; }
    public string Status { get; set; } = "Open";
    public List<RecordPhoto> Photos { get; set; } = [];
}

public class RecordPhoto
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string FileName { get; set; } = string.Empty;
    public string LocalPath { get; set; } = string.Empty;
    public string? RemoteUrl { get; set; }
}
