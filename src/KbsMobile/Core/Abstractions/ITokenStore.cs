namespace KbsMobile.Core.Abstractions;

public interface ITokenStore
{
    Task SaveTokenAsync(string token);
    Task<string?> GetTokenAsync();
    Task ClearAsync();
}
