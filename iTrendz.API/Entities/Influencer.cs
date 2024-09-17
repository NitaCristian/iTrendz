using iTrendz.Api.Authentication;

namespace iTrendz.API.Entities;

public class Influencer : User
{
	double Price { get; set; }
	int Followers { get; set; }
	string Location { get; set; } = string.Empty;
	public ICollection<Contract> Contracts { get; set; }
}