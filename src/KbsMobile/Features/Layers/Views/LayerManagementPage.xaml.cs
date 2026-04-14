using KbsMobile.Features.Layers.ViewModels;

namespace KbsMobile.Features.Layers.Views;

public partial class LayerManagementPage : ContentPage
{
    private readonly LayerManagementViewModel _viewModel;

    public LayerManagementPage(LayerManagementViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadCommand.Execute(null);
    }
}
