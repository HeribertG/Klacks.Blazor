using Klacks.Blazor.Models;
using System.Text.Json;
using System.Text;

namespace Klacks.Blazor.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("KlacksApi");
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<ApiResponse<string>> ResetPasswordAsync(ResetPasswordRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync("/api/v1/backend/accounts/ResetPassword", content);
            
            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse<string> { Success = true, Data = "Password reset successful" };
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse<string> { Success = false, ErrorMessage = "Failed to reset password" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, ErrorMessage = ex.Message };
        }
    }

    public async Task<ApiResponse<bool>> ValidateTokenAsync(string token)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/v1/backend/accounts/ValidatePasswordResetToken?token={token}");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var isValid = JsonSerializer.Deserialize<bool>(content, _jsonOptions);
                return new ApiResponse<bool> { Success = true, Data = isValid };
            }
            else
            {
                return new ApiResponse<bool> { Success = false, Data = false, ErrorMessage = "Token validation failed" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool> { Success = false, Data = false, ErrorMessage = ex.Message };
        }
    }
}