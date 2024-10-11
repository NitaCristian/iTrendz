using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class BrandService(HttpClient httpClient) : IBrandService
{
    public Task<Brand?> GetBrandByIdAsync(int brandId)
    {
        // TODO: Call the API to get a specific brand by ID.
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Brand>> GetAllBrandsAsync()
    {
        // TODO: Call the API to get all brands.
        throw new NotImplementedException();
    }

    public Task UpdateBrandAsync(int brandId, Brand updatedBrand)
    {
        // TODO: Call the API to update an existing brand.
        throw new NotImplementedException();
    }

    public Task DeleteBrandAsync(int brandId)
    {
        // TODO: Call the API to delete a brand by ID.
        throw new NotImplementedException();
    }
}