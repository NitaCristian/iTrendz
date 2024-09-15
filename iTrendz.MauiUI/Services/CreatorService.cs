using System.Net.Http.Json;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class CreatorService(HttpClient httpClient) : ICreatorService
{
    public async Task<List<Influencer>?> GetAllCreatorsAsync()
    {
        var response = await httpClient.GetAsync("creator/all");
        if (!response.IsSuccessStatusCode) return new List<Influencer>();
        return await response.Content.ReadFromJsonAsync<List<Influencer>>();
    }
}