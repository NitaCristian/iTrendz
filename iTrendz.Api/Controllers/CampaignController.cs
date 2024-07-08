using iTrendz.Api.DataAccess.Entities;
using iTrendz.Api.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace iTrendz.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CampaignController : ControllerBase
{
    private CampaignService _campaignService;
    public CampaignController(CampaignService campaignService) {
        _campaignService = campaignService;
        
    }

    [HttpGet]

    public ActionResult<List<Campaign>> GetAll() =>
	   _campaignService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Campaign> Get(int id)
    {
        var campaign = _campaignService.Get(id);
        if (campaign == null)
            return NotFound();
        return campaign;

    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Campaign campaign)
    {
        if (id != campaign.Id)
            return BadRequest();

        var existingCampaign = _campaignService.Get(id);
        if (existingCampaign is null)
            return NotFound();
		_campaignService.Update(campaign);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var campaign = _campaignService.Get(id);
        if (campaign is null)
            return NotFound();
			_campaignService.Delete(id);
        return NoContent();
    }

}

