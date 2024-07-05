using iTrendz.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace iTrendz.Api.Authentication;

public class TrendzUser : IdentityUser<int>
{
    public string Description { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
    public ICollection<Campaign> Campaigns { get; set; }
}