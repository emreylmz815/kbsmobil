using KbsMobile.Core.Abstractions;
using KbsMobile.Core.DTOs;
using KbsMobile.Core.Models;

namespace KbsMobile.Features.Auth.Services;

public class MockAuthService(ITokenStore tokenStore) : IAuthService
{
    public async Task<ApiResponse<UserSession>> LoginAsync(string username, string password, bool keepSignedIn)
    {
        await Task.Delay(350);
        if (username != "admin" || password != "123456")
            return ApiResponse<UserSession>.Fail("Kullanıcı adı veya şifre hatalı.");

        var session = new UserSession
        {
            UserId = "1",
            FullName = "Saha Personeli",
            Role = "Admin",
            Token = $"mock-token-{Guid.NewGuid():N}",
            ExpiresAtUtc = DateTime.UtcNow.AddHours(8)
        };

        if (keepSignedIn)
            await tokenStore.SaveTokenAsync(session.Token);

        return ApiResponse<UserSession>.Success(session);
    }

    public Task LogoutAsync() => tokenStore.ClearAsync();

    public async Task<bool> IsSessionAliveAsync() => !string.IsNullOrWhiteSpace(await tokenStore.GetTokenAsync());
}
