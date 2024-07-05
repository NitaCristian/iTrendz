using Microsoft.AspNetCore.Identity;

namespace iTrendz.Api.Authentication;

public class ApplicationUser : IdentityUser
{
    public string Description { get; set; } = string.Empty;
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
}