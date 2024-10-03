namespace iTrendz.Domain.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double AllocatedBudget { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public DateOnly StartTime { get; set; }
    public DateOnly DateTime { get; set; }
    public int Views { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }
    public int Shares { get; set; }

    public int Reach { get; set; }
    public int Engagement { get; set; }
    public ICollection<Contract> Contracts { get; } = new List<Contract>();

    public int ComputeOrganicReach()
    {
        return Reach / Views;
    }

    public int ComputeOrganicEngagement()
    {
        return Engagement / Views;
    }

    public List<TimelineEvent>? TimelineEvents { get; set; }
}