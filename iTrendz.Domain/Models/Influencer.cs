namespace iTrendz.Domain.Models;

public class Influencer : User
{
    public int Rating { get; set; }
    public int Price { get; set; }
    public ICollection<Contract> Contracts { get; } = new List<Contract>();
}