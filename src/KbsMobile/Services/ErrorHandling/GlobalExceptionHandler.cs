using KbsMobile.Core.Abstractions;
using KbsMobile.Services.Logging;

namespace KbsMobile.Services.ErrorHandling;

public class GlobalExceptionHandler(IAppLogger logger) : IExceptionHandler
{
    public void Handle(Exception exception) => logger.LogError("Unhandled exception", exception);
}
