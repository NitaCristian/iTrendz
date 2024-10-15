using System.Diagnostics.Contracts;
using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class CampaignService(HttpClient httpClient) : ICampaignService
{
    public async Task<Campaign> GetCampaignByIdAsync(int campaignId)
    {
		var response = await httpClient.GetAsync($"campaign/{campaignId}");
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Campaign>();
	}

    public async Task<IEnumerable<Campaign>?> GetAllCampaignsAsync()
    {
        var response = await httpClient.GetAsync("campaign/all");
        if (!response.IsSuccessStatusCode) return new List<Campaign>();
        return await response.Content.ReadFromJsonAsync<List<Campaign>>();
    }

    public async Task<Campaign> CreateCampaignAsync(Campaign newCampaign)
    {
		var response = await httpClient.PostAsJsonAsync("campaig", newCampaign);
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Campaign>();
	}

    public async Task<Campaign> UpdateCampaignAsync(int campaignId, Campaign updatedCampaign)
    {
		var response = await httpClient.PutAsJsonAsync($"campaign/{campaignId}", updatedCampaign);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"faild to upadate influencer");
		return await response.Content.ReadFromJsonAsync<Campaign>();
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