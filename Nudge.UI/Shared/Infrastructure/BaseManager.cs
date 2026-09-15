using Nudge.UI.Features.Auth;
using Nudge.UI.Shared.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace Nudge.UI.Shared.Infrastructure;

public abstract class BaseManager(AuthSessionManager sessionManager, ILogger logger)
{
    private readonly System.Text.Json.JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    protected async Task SetAuthHeaderAsync(HttpClient http)
    {
        var token = await sessionManager.GetTokenAsync();
        if (!string.IsNullOrWhiteSpace(token))
            http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
    }

    protected async Task<ApiResponse<T>> HandleResponse<T>(HttpResponseMessage response)
    {
        // Read the raw body first so we can log it if parsing fails.
        // Buffering it here does not change what gets returned below.
        var raw = await response.Content.ReadAsStringAsync();

        try
        {
            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<T>>(raw, options);

            return result
                ?? new ApiResponse<T> { Status = "1", Message = "Empty response from server" };
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "HandleResponse<T> failed. StatusCode={StatusCode}. Body={Body}",
                response.StatusCode,
                raw);

            return new ApiResponse<T> { Status = "1", Message = "Server Communication Error" };
        }
    }

    protected async Task<ApiResponse> HandleResponse(HttpResponseMessage response)
    {
        var raw = await response.Content.ReadAsStringAsync();

        try
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorResult = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(raw, _jsonOptions);
                return errorResult
                    ?? new ApiResponse { Status = "1", Message = $"Server error ({response.StatusCode})" };
            }

            var result = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(raw, _jsonOptions);

            return result
                ?? new ApiResponse { Status = "0", Message = "Operation completed successfully" };
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "HandleResponse failed. StatusCode={StatusCode}. Body={Body}",
                response.StatusCode,
                raw);

            return new ApiResponse { Status = "1", Message = "Server Communication Error" };
        }
    }
}