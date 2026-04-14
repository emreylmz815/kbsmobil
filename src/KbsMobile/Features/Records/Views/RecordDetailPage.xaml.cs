using KbsMobile.Features.Records.ViewModels;

namespace KbsMobile.Features.Records.Views;

public partial class RecordDetailPage : ContentPage
{
    private readonly RecordDetailViewModel _viewModel;

    public RecordDetailPage(RecordDetailViewModel viewModel)
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
