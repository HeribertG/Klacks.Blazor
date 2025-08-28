using System.ComponentModel.DataAnnotations;

namespace Klacks.Blazor.Models;

public class ResetPasswordRequest
{
    public string Token { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; } = string.Empty;
}