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
        return Ok(influencerRepository.Update);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInfluencer(int id)
    {
         influencerRepository.Delete(id);
       
    }
}