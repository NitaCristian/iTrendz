namespace iTrendz.Domain.Models;

public class Brand : User
{
    public ICollection<Campaign> Campaigns { get; } = new List<Campaign>();

    public IEnumerable<Campaign> GetPastCampaigns()
    {
        // TODO: Return campaigns where campaign state is Completed.
        throw new NotImplementedException();
    }
}