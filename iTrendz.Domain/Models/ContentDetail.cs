namespace iTrendz.Domain.Models;

public class ContentDetail
{
    public ContentType ContentType { get; set; }
    public Platform Platform { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}