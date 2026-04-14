using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KbsMobile.Core.Abstractions;

namespace KbsMobile.Features.Dashboard.ViewModels;

public partial class DashboardViewModel(INavigationService navigationService) : BaseViewModel
{
    [ObservableProperty] private string welcomeMessage = "KBS Mobil'e hoş geldiniz.";

    [RelayCommand] private Task OpenMapAsync() => navigationService.GoToAsync("//main/map");
    [RelayCommand] private Task OpenRecordsAsync() => navigationService.GoToAsync("//main/records");
    [RelayCommand] private Task OpenLayersAsync() => navigationService.GoToAsync(nameof(Features.Layers.Views.LayerManagementPage));
}
