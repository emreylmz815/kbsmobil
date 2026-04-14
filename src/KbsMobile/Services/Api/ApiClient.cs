using System.Net.Http.Json;
using KbsMobile.Core.DTOs;

namespace KbsMobile.Services.Api;

public class ApiClient(HttpClient httpClient) : IApiClient
{
    public async Task<ApiResponse<T>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync(endpoint, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return ApiResponse<T>.Fail($"Request failed: {(int)response.StatusCode}");

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<T>>(cancellationToken: cancellationToken);
        return result ?? ApiResponse<T>.Fail("Empty API response");
    }

    public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync(endpoint, request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return ApiResponse<TResponse>.Fail($"Request failed: {(int)response.StatusCode}");

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>(cancellationToken: cancellationToken);
        return result ?? ApiResponse<TResponse>.Fail("Empty API response");
    }
}
