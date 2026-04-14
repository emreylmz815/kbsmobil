using Microsoft.Extensions.Logging;

namespace KbsMobile.Services.Logging;

public class AppLogger(ILogger<AppLogger> logger) : IAppLogger
{
    public void LogInfo(string message) => logger.LogInformation(message);
    public void LogWarning(string message) => logger.LogWarning(message);
    public void LogError(string message, Exception? exception = null) => logger.LogError(exception, message);
}
