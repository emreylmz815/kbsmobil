using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace KbsMobile.Core.Abstractions;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string? title;
    [ObservableProperty] private string? errorMessage;

    protected async Task ExecuteSafeAsync(Func<Task> action, IExceptionHandler exceptionHandler)
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            ErrorMessage = null;
            await action();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            exceptionHandler.Handle(ex);
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    private void ClearError() => ErrorMessage = null;
}
