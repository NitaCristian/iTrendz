using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IInfluencerService
{
    Task<Influencer?> GetInfluencerByIdAsync(int influencerId);
    Task<IEnumerable<Influencer>?> GetAllInfluencersAsync();
    Task UpdateInfluencerAsync(int influencerId, Brand updatedInfluencer);
    Task DeleteInfluencerAsync(int influencerId);
}