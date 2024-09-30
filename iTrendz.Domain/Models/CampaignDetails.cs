namespace iTrendz.Domain.Models;

public class CampaignDetails
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CampaignType { get; set; }
    public int CurrentCreators { get; set; }
    public int TotalCreators { get; set; }
}