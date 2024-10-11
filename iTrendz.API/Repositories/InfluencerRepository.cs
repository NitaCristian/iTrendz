using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.API.Repositories
{
    public class InfluencerRepository(TrendzDbContext dbContext) : IInfluencerRepository
    {
        public IEnumerable<Influencer> GetAll()
        {
            // TODO: Retrieve all influencers from the database.
            throw new NotImplementedException();
        }

        public Influencer? Get(int id)
        {
            // TODO: Retrieve a specific influencer by ID from the database.
            throw new NotImplementedException();
        }

        public void Update(Influencer influencer)
        {
            // TODO: Update an existing influencer's details in the database.
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            // TODO: Delete an influencer from the database by ID.
            throw new NotImplementedException();
        }
    }
}