using KbsMobile.Features.Map.ViewModels;

namespace KbsMobile.Features.Map.Views;

public partial class MapPage : ContentPage
{
    private readonly MapViewModel _viewModel;

    public MapPage(MapViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _viewModel.FocusRequested += FocusToAsync;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadMapCommand.Execute(null);
    }

    private async Task FocusToAsync(double lat, double lon)
    {
        try
        {
            await MapWebView.EvaluateJavaScriptAsync($"focusTo({lat.ToString(System.Globalization.CultureInfo.InvariantCulture)},{lon.ToString(System.Globalization.CultureInfo.InvariantCulture)});");
        }
        catch
        {
            // WebView henüz hazır değilse yoksay
        }
    }
}
