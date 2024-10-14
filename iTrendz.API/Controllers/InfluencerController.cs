using Microsoft.AspNetCore.Mvc;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using iTrendz.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfluencerController(IInfluencerRepository influencerRepository) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Influencer>> GetInfluencerById(int id)
    {
		var influencer = influencerRepository.Get(id);
		if (influencer == null)
			return NotFound();

		return influencer;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Influencer>>> GetAllInfluencers()
    {
        return Ok(influencerRepository.GetAll());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateInfluencer(int id, Influencer influencer)
    {
        if(id!= influencer.Id)
            return BadRequest();

        var existingInfluencer = influencerRepository.Get(id);
        if( existingInfluencer == null)
            return NotFound();

        influencerRepository.Update(influencer);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInfluencer(int id)
    {
       var influencer= influencerRepository.Get(id);
        if (influencer == null)
            return NotFound();
        influencerRepository.Delete(id);
        return NoContent();
    }
}