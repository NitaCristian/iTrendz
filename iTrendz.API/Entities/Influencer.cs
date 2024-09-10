using iTrendz.Api.Authentication;

namespace iTrendz.API.Entities;

public class Influencer : User
{
    public int Rating { get; set; }
    public int Price { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}