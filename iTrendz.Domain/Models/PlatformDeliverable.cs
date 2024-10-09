namespace iTrendz.Domain.Models;

public class PlatformDeliverable
{
    public Platform Platform { get; set; }
    public ICollection<ContentRequirement> ContentRequirements { get; set; }
}