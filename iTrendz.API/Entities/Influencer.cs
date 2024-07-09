using iTrendz.Api.Authentication;

namespace iTrendz.API.Entities;

public class Influencer : User
{
    public ICollection<Contract> Contracts { get; set; }
}