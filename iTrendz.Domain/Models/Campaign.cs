namespace iTrendz.Domain.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public Brand Brand { get; set; }

    public decimal Budget { get; set; }
    public ICollection<Transaction> Transactions { get; set; }

    public CampaignType Type { get; set; }
    public CampaignState State { get; set; }

    public DateTime ApplicationDeadline { get; set; }
    public Period Period { get; set; }

    public int? CreatorLimit { get; set; }
    public QualificationCriteria Criteria { get; set; }
    public ICollection<Contract> Contracts { get; set; }

    public ICollection<ContentRequirement> Requirements { get; set; }

    public ICollection<Niche> Niches { get; set; }
    public ICollection<ActionLog> Logs { get; set; }
    public Metrics Metrics { get; set; }
}