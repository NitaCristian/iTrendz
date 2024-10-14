using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Repositories
{
	public class InfluencerRepository(TrendzDbContext dbContext) : IInfluencerRepository
	{
		public IEnumerable<Influencer> GetAll()
		{
			return dbContext.Influencers
				.Include(i => i.Contracts)
				.Include(i => i.Pricings)
				.ToList();
		}

		public Influencer? Get(int id) => dbContext.Influencers
			.Include(i => i.Contracts)
			.Include(i => i.Pricings)
			.FirstOrDefault(p => p.Id == id);


		public void Update(Influencer influencer)
		{
			dbContext.Influencers.Update(influencer);
			dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var brand = Get(id);
			if (brand is null)
				return;
			dbContext.Influencers.Remove(brand);
			dbContext.SaveChanges();

		}
	}
}