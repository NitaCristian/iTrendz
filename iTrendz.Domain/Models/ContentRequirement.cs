namespace iTrendz.Domain.Models;

public class ContentRequirement : ContentDetail
{
    public int Id { get; set; }
    public Campaign Campaign { get; set; }
}