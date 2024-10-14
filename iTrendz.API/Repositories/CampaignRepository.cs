using iTrendz.Domain.Context;
using iTrendz.Domain.Models;
using iTrendz.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Repositories
{
	public class CampaignRepository(TrendzDbContext dbContext) : ICampaignRepository
	{
		public IEnumerable<Campaign> GetAll() => dbContext.Campaigns
			.Include(c => c.Brand)
			.Include(c => c.Transactions)
			.Include(c => c.Contracts)
			.Include(c => c.Requirements)
			.Include(c => c.Niches)
			.Include(c => c.Logs)
			.ToList();

		public Campaign? GetById(int id) => dbContext.Campaigns
			.Include(c => c.Brand)
			.Include(c => c.Transactions)
			.Include(c => c.Contracts)
			.Include(c => c.Requirements)
			.Include(c => c.Niches)
			.Include(c => c.Logs)
			.FirstOrDefault(p => p.Id == id);

		public void Add(Campaign campaign)
		{
			dbContext.Campaigns.Add(campaign);
			dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var campaign = GetById(id);
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