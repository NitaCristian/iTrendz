using iTrendz.Api.DataAccess.Context;
using iTrendz.Api.DataAccess.Entities;

namespace iTrendz.Api.DataAccess.Repositories;

public class SqliteCampaignRepository : ICampaignRepository
{
    private readonly TrendzDbContext _trendzDbContext;


    public SqliteCampaignRepository(TrendzDbContext trendzDbContext)
    {
        _trendzDbContext = trendzDbContext;
    }

    public IQueryable<Campaign> AllReviews => _trendzDbContext.Campaigns;

    public void Create(Campaign campaign) => _trendzDbContext.Campaigns.Add(campaign);

    public void Remove(Campaign campaign) => _trendzDbContext.Remove(campaign);

    public void SaveChanges() => _trendzDbContext.SaveChanges();
}