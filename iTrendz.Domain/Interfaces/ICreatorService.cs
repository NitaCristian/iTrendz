using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface ICreatorService
{
    public Task<List<Influencer>?> GetAllCreatorsAsync();
}