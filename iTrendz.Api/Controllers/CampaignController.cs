using iTrendz.API.Repositories;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace iTrendz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampaignController(ICampaignRepository campaignRepository) : ControllerBase
{
    [HttpGet("all")]
    public ActionResult<IEnumerable<Campaign>> GetAll() => Ok(campaignRepository.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Campaign> Get(int id)
    {
        var campaign = campaignRepository.Get(id);
        if (campaign == null)
            return NotFound();

        return campaign;
    }

    [HttpPost]
    public IActionResult Create(Campaign newCampaign)
    {
        // TODO: Add validation for the incoming campaign object (e.g., required fields)
        // TODO: Call the repository to add the campaign, then return a CreatedAtAction result with the new campaign's ID
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Campaign campaign)
    {
        if (id != campaign.Id)
            return BadRequest();

        var existingCampaign = campaignRepository.Get(id);
        if (existingCampaign is null)
            return NotFound();

        campaignRepository.Update(campaign);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var campaign = campaignRepository.Get(id);
        if (campaign is null)
            return NotFound();

        campaignRepository.Delete(id);
        return NoContent();
    }
}