using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Core.Models;
using KbsMobile.Services.Media;

namespace KbsMobile.Features.Media.ViewModels;

public partial class MediaCaptureViewModel(IMediaService mediaService, IExceptionHandler exceptionHandler) : BaseViewModel
{
    public ObservableCollection<RecordPhoto> Photos { get; } = [];

    [RelayCommand]
    private async Task CaptureAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            var photo = await mediaService.CaptureAsync();
            if (photo is not null) Photos.Add(photo);
        }, exceptionHandler);
    }

    [RelayCommand]
    private async Task PickAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            var photo = await mediaService.PickAsync();
            if (photo is not null) Photos.Add(photo);
        }, exceptionHandler);
    }
}
