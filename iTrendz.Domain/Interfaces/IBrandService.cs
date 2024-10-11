using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IBrandService
{
    Task<Brand?> GetBrandByIdAsync(int brandId);
    Task<IEnumerable<Brand>> GetAllBrandsAsync();
    Task UpdateBrandAsync(int brandId, Brand updatedBrand);
    Task DeleteBrandAsync(int brandId);
}