using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class InfluencerService(HttpClient httpClient) : IInfluencerService
{
    public async Task<Influencer?> GetInfluencerByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"creator/{id}");
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<Influencer>();  
    }

    public async Task<IEnumerable<Influencer>?> GetAllInfluencersAsync()
    {
        var response = await httpClient.GetAsync("creator/all");
        if (!response.IsSuccessStatusCode) return new List<Influencer>();
        return await response.Content.ReadFromJsonAsync<List<Influencer>>();
    }

    public async Task UpdateInfluencerAsync(int influencerId, Brand updatedInfluencer)
    {
        var response = await httpClient.PutAsJsonAsync($"creator/{influencerId}",updatedInfluencer);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"faild to upadate influencer");
       
    }

    public async Task DeleteInfluencerAsync(int influencerId)
    {
        var response = await httpClient.DeleteAsync($"creator/{influencerId}");
		if (!response.IsSuccessStatusCode)
			throw new Exception($"faild to upadate influencer");


	}
}