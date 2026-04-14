namespace KbsMobile.Core.Abstractions;

public interface IExceptionHandler
{
    void Handle(Exception exception);
}
