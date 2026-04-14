using KbsMobile.Core.DTOs;

namespace KbsMobile.Services.Api;

public interface IApiClient
{
    Task<ApiResponse<T>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
    Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default);
}
