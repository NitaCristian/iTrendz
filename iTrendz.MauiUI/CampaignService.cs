using System.Net.Http.Json;

namespace iTrendz.MauiUI;

public class CampaignService(HttpClient httpClient) : ICampaignService
{
    public async Task<IEnumerable<Campaign>?> GetCampaignsAsync()
    {
        var response = await httpClient.GetAsync("https://localhost:7061/campaign");
        if (!response.IsSuccessStatusCode) return new List<Campaign>();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Campaign>>();
    }

    public async Task<bool> DeleteCampaignAsync(int campaignId)
    {
        var response = await httpClient.DeleteAsync($"https://localhost:7061/campaigns/{campaignId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> TogglePinCampaignAsync(int campaignId)
    {
        var response = await httpClient.PutAsync($"https://localhost:7061/campaigns/{campaignId}/pin", null);
        return response.IsSuccessStatusCode;
    }
}