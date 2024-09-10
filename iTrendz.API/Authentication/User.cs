using iTrendz.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace iTrendz.Api.Authentication;

public class User : IdentityUser<int>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Domain { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
}