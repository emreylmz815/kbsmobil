using KbsMobile.Features.Auth.Views;
using KbsMobile.Features.Layers.Views;
using KbsMobile.Features.Media.Views;
using KbsMobile.Features.Records.Views;

namespace KbsMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(LayerManagementPage), typeof(LayerManagementPage));
        Routing.RegisterRoute(nameof(RecordDetailPage), typeof(RecordDetailPage));
        Routing.RegisterRoute(nameof(RecordEditPage), typeof(RecordEditPage));
        Routing.RegisterRoute(nameof(MediaCapturePage), typeof(MediaCapturePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }
}
