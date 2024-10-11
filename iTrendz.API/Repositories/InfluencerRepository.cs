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
                .Include(i =>i.Contracts)
                .Include(i =>i.Pricings)
                .ToList();
        }

        public Influencer? Get(int id)
        {
            // TODO: Retrieve a specific influencer by ID from the database.
            throw new NotImplementedException();
        }

        public void Update(Influencer influencer)
        {
			
				try
				{
					// Găsim influencer-ul în baza de date
					var existingInfluencer = dbContext.Influencers.Find(influencer.Id);

					// Verificăm dacă există influencerul
					if (existingInfluencer == null)
					{
						throw new ArgumentException("Influencer not found.");
					}

					// Actualizăm influencerul existent cu noile valori
					dbContext.Entry(existingInfluencer).CurrentValues.SetValues(influencer);

					// Salvăm modificările
					dbContext.SaveChanges();
				}
				catch (Exception ex)
				{
					// Tratarea erorilor
					throw new Exception($"Error updating influencer: {ex.Message}");
				}
			

		}

		public void Delete(int id)
        {
			try
			{
				// Găsim influencer-ul în baza de date după ID
				var influencer = dbContext.Influencers.Find(id);

				// Verificăm dacă influencer-ul există
				if (influencer == null)
				{
					throw new ArgumentException("Influencer not found.");
				}

				// Ștergem influencer-ul din context
				dbContext.Influencers.Remove(influencer);

				// Salvăm modificările în baza de date
				dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				// Tratarea erorilor
				throw new Exception($"Error deleting influencer: {ex.Message}");
			}

		}
    }
}