using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IBrandService
{
    Task<Brand?> GetBrandAsync(int brandId);
}