using iTrendz.Api.DataAccess.Context;
using iTrendz.Api.DataAccess.Entities;

namespace iTrendz.Api.DataAccess.Repositories;

public class SqliteCampaignRepository : ICampaignRepository
{
    private readonly ApplicationContext _applicationContext;


    public SqliteCampaignRepository(ApplicationContext applicationContext, IQueryable<Campaign> allReviews)
    {
        _applicationContext = applicationContext;
    }

    public IQueryable<Campaign> AllReviews => _applicationContext.Campaigns;

    public void Create(Campaign campaign) => _applicationContext.Campaigns.Add(campaign);

    public void Remove(Campaign campaign) => _applicationContext.Remove(campaign);

    public void SaveChanges() => _applicationContext.SaveChanges();
}