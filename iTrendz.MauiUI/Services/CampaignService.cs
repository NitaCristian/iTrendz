using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class CampaignService(HttpClient httpClient) : ICampaignService
{
    public Task<Campaign> GetCampaignByIdAsync(int campaignId)
    {
        // TODO: Call the API to get a campaign by its ID
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Campaign>?> GetAllCampaignsAsync()
    {
        var response = await httpClient.GetAsync("campaign/all");
        if (!response.IsSuccessStatusCode) return new List<Campaign>();
        return await response.Content.ReadFromJsonAsync<List<Campaign>>();
    }

    public Task<Campaign> CreateCampaignAsync(Campaign newCampaign)
    {
        // TODO: Call the API to create a new campaign
        throw new NotImplementedException();
    }

    public Task<Campaign> UpdateCampaignAsync(int campaignId, Campaign updatedCampaign)
    {
        // TODO: Call the API to update an existing campaign by ID
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCampaignAsync(int campaignId)
    {
        var response = await httpClient.DeleteAsync($"campaign/{campaignId}");
        return response.IsSuccessStatusCode;
    }

    public Task<IEnumerable<Campaign>> GetCampaignsByBrandIdAsync(int brandId)
    {
        // TODO: Call the API to get all campaigns of a specific brand by brandId
        throw new NotImplementedException();
    }
}