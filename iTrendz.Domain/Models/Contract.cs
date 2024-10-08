namespace iTrendz.Domain.Models;

public class Contract
{
    public int Id { get; set; }
    public int InfluencerId { get; set; }
    public Influencer Influencer { get; set; }
    public ContractState State { get; set; }
    public ICollection<Post> Posts { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public DateOnly SignedDate { get; set; }
}

public enum ContractState
{
    Pending,
    Approved,
    Rejected
}

public class Post
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Media Media { get; set; }
}

public class Media
{
    public string Title { get; set; }

    public string Url { get; set; }
}