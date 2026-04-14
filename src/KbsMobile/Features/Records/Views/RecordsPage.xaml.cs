using KbsMobile.Features.Records.ViewModels;

namespace KbsMobile.Features.Records.Views;

public partial class RecordsPage : ContentPage
{
    private readonly RecordsViewModel _viewModel;

    public RecordsPage(RecordsViewModel viewModel)
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
