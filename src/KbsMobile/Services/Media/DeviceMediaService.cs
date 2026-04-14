using KbsMobile.Core.Models;

namespace KbsMobile.Services.Media;

public class DeviceMediaService : IMediaService
{
    public async Task<RecordPhoto?> CaptureAsync()
    {
        if (!MediaPicker.Default.IsCaptureSupported)
            return null;

        var file = await MediaPicker.Default.CapturePhotoAsync();
        return await SaveLocally(file);
    }

    public async Task<RecordPhoto?> PickAsync()
    {
        var file = await MediaPicker.Default.PickPhotoAsync();
        return await SaveLocally(file);
    }

    private static async Task<RecordPhoto?> SaveLocally(FileResult? file)
    {
        if (file is null) return null;
        var localPath = Path.Combine(FileSystem.CacheDirectory, $"{Guid.NewGuid():N}_{file.FileName}");

        await using var source = await file.OpenReadAsync();
        await using var destination = File.OpenWrite(localPath);
        await source.CopyToAsync(destination);

        return new RecordPhoto { FileName = file.FileName, LocalPath = localPath };
    }
}
