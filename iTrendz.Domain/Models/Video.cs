namespace iTrendz.Domain.Models;

public class Video
{
	public Video()
	{
	}

	public Video(int id, string? title, string? videoUrl, string? posterUrl)
	{
		Id = id;
		Title = title;
		VideoUrl = videoUrl;
		PosterUrl = posterUrl;
	}

	public int Id { get; set; }	
	public string? Title {  get; set; }	
	public string? VideoUrl { get; set; }
	public string? PosterUrl { get; set; }
}
