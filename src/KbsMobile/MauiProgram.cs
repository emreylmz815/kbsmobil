using CommunityToolkit.Maui;
using KbsMobile.Core.Abstractions;
using KbsMobile.Features.Auth.Services;
using KbsMobile.Features.Auth.ViewModels;
using KbsMobile.Features.Auth.Views;
using KbsMobile.Features.Dashboard.ViewModels;
using KbsMobile.Features.Dashboard.Views;
using KbsMobile.Features.Layers.ViewModels;
using KbsMobile.Features.Layers.Views;
using KbsMobile.Features.Map.Services;
using KbsMobile.Features.Map.ViewModels;
using KbsMobile.Features.Map.Views;
using KbsMobile.Features.Media.ViewModels;
using KbsMobile.Features.Media.Views;
using KbsMobile.Features.Records.Services;
using KbsMobile.Features.Records.ViewModels;
using KbsMobile.Features.Records.Views;
using KbsMobile.Features.Settings.ViewModels;
using KbsMobile.Features.Settings.Views;
using KbsMobile.Repositories;
using KbsMobile.Services.Api;
using KbsMobile.Services.Auth;
using KbsMobile.Services.Connectivity;
using KbsMobile.Services.ErrorHandling;
using KbsMobile.Services.Layers;
using KbsMobile.Services.Location;
using KbsMobile.Services.Logging;
using KbsMobile.Services.Media;
using Microsoft.Extensions.Logging;
using Polly.Extensions.Http;

namespace KbsMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => { });

        builder.Services.AddSingleton<IAppLogger, AppLogger>();
        builder.Services.AddSingleton<IExceptionHandler, GlobalExceptionHandler>();
        builder.Services.AddSingleton<ITokenStore, SecureTokenStore>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
        builder.Services.AddSingleton<IConnectivityService, ConnectivityService>();
        builder.Services.AddSingleton<ILocationService, DeviceLocationService>();
        builder.Services.AddSingleton<IMediaService, DeviceMediaService>();
        builder.Services.AddSingleton<IMapBridgeService, MapBridgeService>();
        builder.Services.AddSingleton<IMapLayerService, MapLayerService>();
        builder.Services.AddSingleton<IAuthService, MockAuthService>();
        builder.Services.AddSingleton<IRecordRepository, MockRecordRepository>();
        builder.Services.AddSingleton<IRecordService, RecordService>();
        builder.Services.AddSingleton<IWmsLayerRepository, MockWmsLayerRepository>();

        builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.placeholder.local/");
                client.Timeout = TimeSpan.FromSeconds(20);
            })
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retry => TimeSpan.FromMilliseconds(250 * retry)));

        builder.Services.AddTransient<SplashViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<MapViewModel>();
        builder.Services.AddTransient<LayerManagementViewModel>();
        builder.Services.AddTransient<RecordsViewModel>();
        builder.Services.AddTransient<RecordDetailViewModel>();
        builder.Services.AddTransient<RecordEditViewModel>();
        builder.Services.AddTransient<MediaCaptureViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();

        builder.Services.AddTransient<SplashPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<MapPage>();
        builder.Services.AddTransient<LayerManagementPage>();
        builder.Services.AddTransient<RecordsPage>();
        builder.Services.AddTransient<RecordDetailPage>();
        builder.Services.AddTransient<RecordEditPage>();
        builder.Services.AddTransient<MediaCapturePage>();
        builder.Services.AddTransient<SettingsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
