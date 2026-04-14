using KbsMobile.Core.Models;

namespace KbsMobile.Services.Media;

public interface IMediaService
{
    Task<RecordPhoto?> CaptureAsync();
    Task<RecordPhoto?> PickAsync();
}
