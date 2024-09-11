namespace iTrendz.Domain.Models;

public class Brand : User
{
    public ICollection<Campaign> Campaigns { get; } = new List<Campaign>();
}