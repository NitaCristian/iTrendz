using iTrendz.Api.DataAccess.Context;
using iTrendz.Api.DataAccess.Entities;
namespace iTrendz.Api.DataAccess.Services;

public  class CampaignService
{
	private readonly TrendzDbContext _trendzDbContext;
	
    public CampaignService(TrendzDbContext dbContext )
    {
        _trendzDbContext = dbContext;
    }
    public  List<Campaign> GetAll() => _trendzDbContext.Campaigns.ToList();

	public  Campaign? Get(int id )=> _trendzDbContext.Campaigns.FirstOrDefault(p =>p.Id == id);
	public  void Add(Campaign campaign)
	{

		_trendzDbContext.Campaigns.Add(campaign);
		_trendzDbContext.SaveChanges();
	}
	public  void Delete(int id)
	{
		var campaign = Get(id);
		if (campaign is null)
			return;
		_trendzDbContext.Campaigns.Remove(campaign);
		_trendzDbContext.SaveChanges();
	}
	public void Update(Campaign campaign)
	{
		_trendzDbContext.Campaigns.Update(campaign);
		_trendzDbContext.SaveChanges();
	}
}
