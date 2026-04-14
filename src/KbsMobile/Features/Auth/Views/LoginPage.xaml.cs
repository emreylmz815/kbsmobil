using KbsMobile.Features.Auth.ViewModels;

namespace KbsMobile.Features.Auth.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
