namespace iTrendz.Domain.Models;

public class ContentPricing : ContentDetail
{
    public int Id { get; set; }
    public Influencer Influencer { get; set; }
}