using KbsMobile.Features.Settings.ViewModels;

namespace KbsMobile.Features.Settings.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
