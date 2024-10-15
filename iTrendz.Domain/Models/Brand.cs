namespace iTrendz.Domain.Models;

public class Brand : User
{
	public ICollection<Campaign> Campaigns { get; } = new List<Campaign>();

	public IEnumerable<Campaign> GetPastCampaigns()
	{
		return Campaigns.Where(c => c.State == CampaignState.Completed);
	}
}