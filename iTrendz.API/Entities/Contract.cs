namespace iTrendz.API.Entities;

public class Contract
{
    public int Id { get; set; }
    public int InfluencerId { get; set; }
    public Influencer Influencer { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public DateOnly SignedDate { get; set; }
}