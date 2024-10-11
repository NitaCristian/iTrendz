using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Repositories;

public class BrandRepository(TrendzDbContext dbContext) : IBrandRepository
{
    public IEnumerable<Brand> GetAll()
    {
        // TODO: Query the database and return all brands.
        return dbContext.Brands
            .Include(b => b.Campaigns)
            .ToList();
    }

    public Brand? Get(int id)
    {
        // TODO: Query the database to find a brand by its ID and return it.
        throw new NotImplementedException();
    }

    public void Update(Brand brand)
    {
		try
		{
			// Găsim influencer-ul în baza de date
			var existingBrand = dbContext.Influencers.Find(brand.Id);

			// Verificăm dacă există influencerul
			if (existingBrand == null)
			{
				throw new ArgumentException("Brand not found.");
			}

			// Actualizăm influencerul existent cu noile valori
			dbContext.Entry(existingBrand).CurrentValues.SetValues(brand);

			// Salvăm modificările
			dbContext.SaveChanges();
		}
		catch (Exception ex)
		{
			// Tratarea erorilor
			throw new Exception($"Error updating influencer: {ex.Message}");
		}
		throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        // TODO: Find the brand by ID, remove it from the database, and save changes.
        throw new NotImplementedException();
    }
}