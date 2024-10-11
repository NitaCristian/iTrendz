using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IInfluencerRepository
{
    IEnumerable<Influencer> GetAll();

    Influencer? Get(int id);

    void Update(Influencer influencer);

    void Delete(int id);
}