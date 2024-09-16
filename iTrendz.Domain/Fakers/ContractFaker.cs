using Bogus;
using iTrendz.Domain.Models;

namespace iTrendz.Domain.Fakers;

public sealed class ContractFaker : Faker<Contract>
{
    public ContractFaker()
    {
        RuleFor(c => c.Id, f => f.IndexFaker + 1);
        RuleFor(c => c.InfluencerId, f => f.Random.Number(1, 100));
        RuleFor(c => c.CampaignId, f => f.Random.Number(1, 50));
        RuleFor(c => c.SignedDate, f => DateOnly.FromDateTime(f.Date.Past()));
    }
}