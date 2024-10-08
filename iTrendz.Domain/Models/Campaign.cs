namespace iTrendz.Domain.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public CampaignDetails CampaignDetails { get; set; }
    public BudgetStatistics BudgetStatistics { get; set; }
    public CampaignMetrics CampaignMetrics { get; set; }
    public ICollection<Contract> Contracts { get; } = new List<Contract>();
    public InfluencerRequirements? InfluencerRequirements;
    public List<PlatformDeliverable>? Deliverables;
    public CampaignState State { get; set; }
    public List<TimelineEvent>? TimelineEvents { get; set; }
}

public enum CampaignState
{
    Draft,
    Pending,
    Active,
    Completed,
    Cancelled,
    Closed
}