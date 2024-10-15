using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class InfluencerService(HttpClient httpClient) : IInfluencerService
{
	public async Task<Influencer?> GetInfluencerByIdAsync(int influencerId)
	{
		var response = await httpClient.GetAsync($"influencer/{influencerId}");
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Influencer>();
	}

	public async Task<IEnumerable<Influencer>?> GetAllInfluencersAsync()
	{
		var response = await httpClient.GetAsync("influencer/all");
		if (!response.IsSuccessStatusCode) return new List<Influencer>();
		return await response.Content.ReadFromJsonAsync<List<Influencer>>();
	}

	public async Task UpdateInfluencerAsync(int influencerId, Brand updatedInfluencer)
	{
		var response = await httpClient.PutAsJsonAsync($"influencer/{influencerId}", updatedInfluencer);
		if (!response.IsSuccessStatusCode)
			throw new Exception($"Failed to upadate influencer");
	}

	public async Task DeleteInfluencerAsync(int influencerId)
	{
		var response = await httpClient.DeleteAsync($"influencer/{influencerId}");
		if (!response.IsSuccessStatusCode)
			throw new Exception($"Failed to delete influencer");
	}
}