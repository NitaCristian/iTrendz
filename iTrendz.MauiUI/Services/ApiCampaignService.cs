using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class ApiCampaignService(HttpClient httpClient) : ICampaignService
{
    public Task<Campaign> GetCampaignAsync(int campaignId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Campaign>?> GetCampaignsAsync()
    {
        var response = await httpClient.GetAsync("campaign/all");
        if (!response.IsSuccessStatusCode) return new List<Campaign>();
        return await response.Content.ReadFromJsonAsync<List<Campaign>>();
    }

    public async Task<bool> DeleteCampaignAsync(int campaignId)
    {
        var response = await httpClient.DeleteAsync($"campaign/{campaignId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> TogglePinCampaignAsync(int campaignId)
    {
        var response = await httpClient.PutAsync($"campaign/{campaignId}/pin", null);
        return response.IsSuccessStatusCode;
    }
}