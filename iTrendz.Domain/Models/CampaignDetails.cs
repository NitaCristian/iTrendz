namespace iTrendz.Domain.Models;

public class CampaignDetails
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CampaignType { get; set; }
    public int CurrentCreators { get; set; }
    public int TotalCreators { get; set; }
    public int TotalPosts { get; set; }
    public double[] DemographicData { get; set; }
    public string[] DemographicLabels { get; set; }
    public double[] AgeGroupData { get; set; }
    public string[] AgeGroupCategories { get; set; }
}