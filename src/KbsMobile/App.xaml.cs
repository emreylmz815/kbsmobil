using KbsMobile.Core.Abstractions;

namespace KbsMobile;

public partial class App : Application
{
    public App(AppShell shell, IExceptionHandler exceptionHandler)
    {
        InitializeComponent();
        MainPage = shell;
        AppDomain.CurrentDomain.UnhandledException += (_, args) =>
            exceptionHandler.Handle(args.ExceptionObject as Exception ?? new Exception("Unknown app domain error"));
        TaskScheduler.UnobservedTaskException += (_, args) =>
        {
            exceptionHandler.Handle(args.Exception);
            args.SetObserved();
        };
    }
}
