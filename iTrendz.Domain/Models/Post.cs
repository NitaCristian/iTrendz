namespace iTrendz.Domain.Models;

public class Post
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Media Media { get; set; }
}