namespace iTrendz.Domain.Models;

public class Influencer : User
{
    public int Age { get; set; }
    public Metrics Metrics { get; set; }
    public ICollection<ContentPricing> Pricings { get; set; }
    public ICollection<Contract> Contracts { get; } = new List<Contract>();
}