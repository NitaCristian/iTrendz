using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface ICampaignService
{
    public Task<Campaign?> GetCampaignByIdAsync(int campaignId);
    public Task<IEnumerable<Campaign>?> GetAllCampaignsAsync();
    public Task<Campaign?> CreateCampaignAsync(Campaign newCampaign);
    public Task UpdateCampaignAsync(int campaignId, Campaign updatedCampaign);
    public Task DeleteCampaignAsync(int campaignId);
}