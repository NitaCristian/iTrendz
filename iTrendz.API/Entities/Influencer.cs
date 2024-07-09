namespace iTrendz.API.Entities;

public class Influencer
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public List<Video> Videos { get; set; }=new List<Video>();
	public List<Poza> Poza { get; set; } =new List<Poza>();
}
