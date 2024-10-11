using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.API.Repositories;

public class BrandRepository(TrendzDbContext dbContext) : IBrandRepository
{
    public IEnumerable<Brand> GetAll()
    {
        // TODO: Query the database and return all brands.
        throw new NotImplementedException();
    }

    public Brand? Get(int id)
    {
        // TODO: Query the database to find a brand by its ID and return it.
        throw new NotImplementedException();
    }

    public void Update(Brand brand)
    {
        // TODO: Update the existing brand in the database and save changes.
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        // TODO: Find the brand by ID, remove it from the database, and save changes.
        throw new NotImplementedException();
    }
}