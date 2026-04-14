using KbsMobile.Features.Media.ViewModels;

namespace KbsMobile.Features.Media.Views;

public partial class MediaCapturePage : ContentPage
{
    public MediaCapturePage(MediaCaptureViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
