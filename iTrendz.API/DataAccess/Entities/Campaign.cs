using iTrendz.Api.Authentication;

namespace iTrendz.Api.DataAccess.Entities;

public class Campaign
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    public int BrandId { get; set; }
    public TrendzUser Brand { get; set; }
}