namespace KbsMobile.Services.Location;

public interface ILocationService
{
    Task<Location?> GetCurrentAsync();
}
