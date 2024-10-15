using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using System.Diagnostics.Contracts;
using System.Net.Http.Json;

namespace iTrendz.MauiUI.Services;

public class BrandService(HttpClient httpClient) : IBrandService
{
	public async Task<Brand?> GetBrandByIdAsync(int brandId)
	{
		var response = await httpClient.GetAsync($"brand/{brandId}");
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Brand>();
	}

	public async Task<IEnumerable<Brand>?> GetAllBrandsAsync()
	{
		var response = await httpClient.GetAsync("brand/all");
		if (!response.IsSuccessStatusCode) return new List<Brand>();
		return await response.Content.ReadFromJsonAsync<List<Brand>>();
	}

	public async Task UpdateBrandAsync(int brandId, Brand updatedBrand)
	{
		var response = await httpClient.PutAsJsonAsync($"brand/{brandId}", updatedBrand);
		if (!response.IsSuccessStatusCode)
			throw new Exception($"Failed to upadate brand.");
	}

	public async Task DeleteBrandAsync(int brandId)
	{
		var response = await httpClient.DeleteAsync($"brand/{brandId}");
		if (!response.IsSuccessStatusCode)
			throw new Exception($"Failed to delete brand.");
	}
}