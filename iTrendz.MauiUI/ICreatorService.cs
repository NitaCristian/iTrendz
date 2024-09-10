namespace iTrendz.MauiUI;

public interface ICreatorService
{
    public Task<List<Influencer>?> GetAllCreatorsAsync();
}