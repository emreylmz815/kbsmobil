using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;
using KbsMobile.Features.Auth.Services;

namespace KbsMobile.Features.Auth.ViewModels;

public partial class LoginViewModel(
    IAuthService authService,
    INavigationService navigationService,
    IExceptionHandler exceptionHandler) : BaseViewModel
{
    [ObservableProperty] private string username = string.Empty;
    [ObservableProperty] private string password = string.Empty;
    [ObservableProperty] private bool keepSignedIn = true;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Kullanıcı adı ve şifre zorunludur.";
            return;
        }

        await ExecuteSafeAsync(async () =>
        {
            var result = await authService.LoginAsync(Username, Password, KeepSignedIn);
            if (!result.IsSuccess)
            {
                ErrorMessage = result.Message;
                return;
            }

            await navigationService.GoToAsync("//main/dashboard");
        }, exceptionHandler);
    }
}
