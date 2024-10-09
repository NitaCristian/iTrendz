using iTrendz.Domain.Models;
using Bogus;

namespace iTrendz.Domain.Fakers;

public sealed class BrandFaker : Faker<Brand>
{
    public BrandFaker(UniqueIdGenerator uniqueIdGenerator)
    {
        RuleFor(u => u.Id, f => uniqueIdGenerator.GetNextId());
        RuleFor(u => u.UserName, f => f.Internet.UserName());
        RuleFor(u => u.NormalizedUserName, (f, u) => u.UserName.ToUpper());
        RuleFor(u => u.Email, f => f.Internet.Email());
        RuleFor(u => u.NormalizedEmail, (f, u) => u.Email.ToUpper());
        RuleFor(u => u.Description, f => f.Lorem.Sentence());
        // RuleFor(u => u.Domain,
            // f => f.PickRandom(new[] { "Tech", "Fashion", "Sports", "Lifestyle", "Health", "Entertainment" }));
        RuleFor(u => u.WebsiteUrl, f => f.Internet.Url());
        RuleFor(u => u.ImageUrl, f => f.Internet.Avatar());
        RuleFor(u => u.RefreshToken, f => f.Random.String2(32));
        RuleFor(u => u.RefreshTokenExpiry, f => f.Date.Future());
        RuleFor(u => u.PasswordHash, f => f.Internet.Password());
        RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());

        RuleFor(b => b.Campaigns, f => new CampaignFaker().Generate(3));
    }
}