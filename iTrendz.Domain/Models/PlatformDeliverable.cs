namespace iTrendz.Domain.Models;

public class PlatformDeliverable
{
    public Platform Platform { get; set; }
    public List<ContentRequirement> ContentRequirements { get; set; }
}