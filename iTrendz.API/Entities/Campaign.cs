using System.Collections;
using iTrendz.Api.Authentication;

namespace iTrendz.API.Entities;

public class Campaign
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    // Buget alocat pentru acest campaign
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public DateOnly StartTime { get; set; }
    public DateOnly DateTime { get; set; }
    public ICollection<Contract>? Contracts { get; set; }
}