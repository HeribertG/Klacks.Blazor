using Klacks.Blazor.Models;

namespace Klacks.Blazor.Services;

public interface IApiService
{
    Task<ApiResponse<string>> ResetPasswordAsync(ResetPasswordRequest request);
    Task<ApiResponse<bool>> ValidateTokenAsync(string token);
}