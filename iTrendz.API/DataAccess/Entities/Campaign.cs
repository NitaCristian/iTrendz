namespace  iTrendz.Api.DataAccess.Entities;

public class Campaign
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public List<Influencer> Influencers { get; set; }

	public DateTime Datefinalization { get; set; }
	/// trebuie sa scadem din data  la care trebuie finalizat contractul data curenta 
	/// cum iau data la care trebuie finalizat contractul <summary>
	/// trebuie sa scadem din data  la care trebuie finalizat contractul data curenta 
	public int TimpRamas()
	{
		return (Datefinalization - DateTime.Now).Days;
	}
	public bool Isfinalizat { get; set; }
}
