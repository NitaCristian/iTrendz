using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class BrandService(HttpClient httpClient) : IBrandService
{
    public Task<Brand?> GetBrandAsync(int brandId)
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
}