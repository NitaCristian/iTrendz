using Bogus;
using iTrendz.Domain.Models;

namespace iTrendz.Domain.Fakers;

public sealed class CampaignFaker : Faker<Campaign>
{
    public CampaignFaker()
    {
        RuleFor(c => c.Id, f => f.IndexFaker + 1);
        RuleFor(c => c.Title, f => f.Commerce.ProductName());
        RuleFor(c => c.ImageURL, f => f.Image.PicsumUrl());
        RuleFor(c => c.Description, f => f.Lorem.Paragraph());
        RuleFor(c => c.AllocatedBudget, f => (double)f.Finance.Amount(1000, 10000));
        RuleFor(c => c.BrandId, f => f.Random.Number(1, 10)); 
        RuleFor(c => c.StartTime, f => DateOnly.FromDateTime(f.Date.Past()));
        RuleFor(c => c.DateTime, f => DateOnly.FromDateTime(f.Date.Future()));
        RuleFor(c => c.Contracts, f => new ContractFaker().Generate(3)); 
    }
}