using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace iTrendz.Domain.Models;

public class User : IdentityUser<int>
{
    public string? ImageUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? ContactEmail { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }
    public Location Location { get; set; }
    public ICollection<Niche> Niches { get; set; }
    public ICollection<Platform> Platforms { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
}