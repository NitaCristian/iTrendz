using iTrendz.Api.Authentication;

namespace iTrendz.Api.DataAccess.Entities;

public class Campaign
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int BrandId { get; set; }
    public required ApplicationUser Brand { get; set; }
}