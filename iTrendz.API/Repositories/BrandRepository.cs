using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Repositories;

public class BrandRepository(TrendzDbContext dbContext) : IBrandRepository
{
    public IEnumerable<Brand> GetAll()
    {
        return dbContext.Brands
            .Include(b => b.Campaigns)
            .ToList();
    }

    public Brand? GetById(int id)=> dbContext.Brands.FirstOrDefault(p => p.Id == id);
  

    public void Update(Brand brand)
    {
		dbContext.Brands.Update(brand);
		dbContext.SaveChanges();
	}

    public void Delete(int id)
    {
        var brand  = GetById(id);
        if (brand == null)
            return;
        dbContext.Brands.Remove(brand);
		dbContext.SaveChanges();
	}
	public void Add(Brand brand)
	{
		dbContext.Brands.Add(brand);
		dbContext.SaveChanges();
	}
}