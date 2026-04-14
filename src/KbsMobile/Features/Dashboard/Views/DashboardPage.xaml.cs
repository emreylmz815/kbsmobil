using KbsMobile.Features.Dashboard.ViewModels;

namespace KbsMobile.Features.Dashboard.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
