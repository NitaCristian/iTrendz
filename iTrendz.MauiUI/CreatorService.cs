using System.Net.Http.Json;

namespace iTrendz.MauiUI;

public class CreatorService(HttpClient httpClient) : ICreatorService
{
    public async Task<List<Influencer>?> GetAllCreatorsAsync()
    {
        var response = await httpClient.GetAsync("https://localhost:7061/creators");
        if (!response.IsSuccessStatusCode) return new List<Influencer>();
        return await response.Content.ReadFromJsonAsync<List<Influencer>>();
    }
}