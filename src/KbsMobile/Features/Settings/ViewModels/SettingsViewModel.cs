using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Features.Auth.Services;

namespace KbsMobile.Features.Settings.ViewModels;

public partial class SettingsViewModel(IAuthService authService, INavigationService navigationService) : BaseViewModel
{
    [RelayCommand]
    private async Task LogoutAsync()
    {
        await authService.LogoutAsync();
        await navigationService.GoToAsync("//login");
    }
}
