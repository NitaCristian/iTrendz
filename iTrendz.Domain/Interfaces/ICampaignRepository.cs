using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface ICampaignRepository
{
    IEnumerable<Campaign> GetAll();
    Campaign? GetById(int id);
    void Add(Campaign campaign);
    void Delete(int id);
    void Update(Campaign campaign);
}