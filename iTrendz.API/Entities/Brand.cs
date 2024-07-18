using System.Collections;
using iTrendz.Api.Authentication;

namespace iTrendz.API.Entities;

public class Brand : User
{
    public ICollection<Campaign> Campaigns { get; set; }
}