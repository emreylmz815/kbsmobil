using KbsMobile.Core.DTOs;
using KbsMobile.Core.Models;

namespace KbsMobile.Features.Auth.Services;

public interface IAuthService
{
    Task<ApiResponse<UserSession>> LoginAsync(string username, string password, bool keepSignedIn);
    Task LogoutAsync();
    Task<bool> IsSessionAliveAsync();
}
