namespace iTrendz.Domain.Models;

public class Niche
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Campaign> Campaigns { get; set; }
}