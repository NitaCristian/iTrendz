namespace iTrendz.Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Media> Media { get; set; }
    public Contract Contract { get; set; }
}