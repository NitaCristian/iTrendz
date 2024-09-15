using iTrendz.Domain.Context;
using iTrendz.Domain.Models;
using iTrendz.Domain.Interfaces;

namespace iTrendz.API.Repositories
{
    public class CampaignRepository(TrendzDbContext dbContext) : ICampaignRepository
    {
        public IEnumerable<Campaign> GetAll() => dbContext.Campaigns;

        public Campaign? Get(int id) => dbContext.Campaigns.FirstOrDefault(p => p.Id == id);

        public void Add(Campaign campaign)
        {
            dbContext.Campaigns.Add(campaign);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var campaign = Get(id);
            if (campaign is null)
                return;

            dbContext.Campaigns.Remove(campaign);
            dbContext.SaveChanges();
        }

        public void Update(Campaign campaign)
        {
            dbContext.Campaigns.Update(campaign);
            dbContext.SaveChanges();
        }
    }
}