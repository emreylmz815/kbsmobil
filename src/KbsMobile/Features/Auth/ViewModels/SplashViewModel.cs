using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Features.Auth.Services;

namespace KbsMobile.Features.Auth.ViewModels;

public partial class SplashViewModel(
    IAuthService authService,
    INavigationService navigationService,
    IExceptionHandler exceptionHandler) : BaseViewModel
{
    [RelayCommand]
    private async Task InitializeAsync()
    {
        await ExecuteSafeAsync(async () =>
        {
            await Task.Delay(1200);
            var isAlive = await authService.IsSessionAliveAsync();
            await navigationService.GoToAsync(isAlive ? "//main/dashboard" : "//login");
        }, exceptionHandler);
    }
}
