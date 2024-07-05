using iTrendz.Api.DataAccess.Entities;

namespace iTrendz.Api.DataAccess.Repositories;

public interface ICampaignRepository
{
    public IQueryable<Campaign> AllReviews { get; }
    void Create(Campaign campaign);
    void Remove(Campaign campaign);
    void SaveChanges();
}