namespace iTrendz.MauiUI;

public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double AllocatedBudget { get; set; }
    public int BrandId { get; set; }
    public DateOnly StartTime { get; set; }
    public DateOnly DateTime { get; set; }
}