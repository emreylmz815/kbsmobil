using KbsMobile.Core.Abstractions;

namespace KbsMobile.Services.Auth;

public class SecureTokenStore : ITokenStore
{
    private const string TokenKey = "auth_token";

    public Task SaveTokenAsync(string token) => SecureStorage.SetAsync(TokenKey, token);

    public async Task<string?> GetTokenAsync()
    {
        try { return await SecureStorage.GetAsync(TokenKey); }
        catch { return null; }
    }

    public Task ClearAsync()
    {
        SecureStorage.Remove(TokenKey);
        return Task.CompletedTask;
    }
}
