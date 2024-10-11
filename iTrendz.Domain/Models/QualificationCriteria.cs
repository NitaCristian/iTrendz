namespace iTrendz.Domain.Models;

public class QualificationCriteria
{
    public int MinFollowerCount { get; set; }
    public int AverageViews { get; set; }
    public int MinEngagementRate { get; set; }
    public AudienceType Audience { get; set; }
    public Location TargetLocation { get; set; }
}