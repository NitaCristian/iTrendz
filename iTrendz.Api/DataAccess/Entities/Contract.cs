namespace iTrendz.Api.DataAccess.Entities;

public class Contract
{ 
	public int Id { get; set; }
	public string Name { get; set; }
	Influencer influencer { get; set; }
	Firma firma { get; set; }
	public string Conditii {  get; set; }
	DateOnly date { get; set; }
	public int salariu { get; set; }


}
