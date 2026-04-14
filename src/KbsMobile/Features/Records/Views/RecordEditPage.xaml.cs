using KbsMobile.Features.Records.ViewModels;

namespace KbsMobile.Features.Records.Views;

public partial class RecordEditPage : ContentPage
{
    private readonly RecordEditViewModel _viewModel;

    public RecordEditPage(RecordEditViewModel viewModel)
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
