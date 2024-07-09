namespace iTrendz.API.Entities;

public class Contract
{
    public int Id { get; set; }
    public int InfluencerId { get; set; }
    Influencer Influencer { get; set; }
    public int CampaignId { get; set; }
    private Campaign Campaign { get; set; }
    DateOnly SignedDate { get; set; }
}