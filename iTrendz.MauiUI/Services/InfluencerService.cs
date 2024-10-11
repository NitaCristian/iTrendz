using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class InfluencerService(HttpClient httpClient) : IInfluencerService
{
    public Task<Influencer?> GetInfluencerByIdAsync()
    {
        // TODO: Call the API to get a specific influencer by ID.
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Influencer>?> GetAllInfluencersAsync()
    {
        var response = await httpClient.GetAsync("creator/all");
        if (!response.IsSuccessStatusCode) return new List<Influencer>();
        return await response.Content.ReadFromJsonAsync<List<Influencer>>();
    }

    public Task UpdateInfluencerAsync(int influencerId, Brand updatedInfluencer)
    {
        // TODO: Call the API to update an existing influencer.
        throw new NotImplementedException();
    }

    public Task DeleteInfluencerAsync(int influencerId)
    {
        // TODO: Call the API to delete an influencer by ID.
        throw new NotImplementedException();
    }
}