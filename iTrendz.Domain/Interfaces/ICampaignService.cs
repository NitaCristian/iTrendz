using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface ICampaignService
{
    public Task<IEnumerable<Campaign>?> GetCampaignsAsync();
    public Task<bool> DeleteCampaignAsync(int campaignId);
    public Task<bool> TogglePinCampaignAsync(int campaignId);
}