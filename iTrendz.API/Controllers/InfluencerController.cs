using Microsoft.AspNetCore.Mvc;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfluencerController(IInfluencerRepository influencerRepository) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Influencer>> GetInfluencerById(int id)
    {
        // TODO: Implement this method to retrieve an influencer by ID.
        throw new NotImplementedException();
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Influencer>>> GetAllInfluencers()
    {
        // TODO: Implement this method to retrieve all influencers.
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateInfluencer(int id, Influencer influencer)
    {
        // TODO: Implement this method to update an influencer.
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInfluencer(int id)
    {
        // TODO: Implement this method to delete an influencer.
        throw new NotImplementedException();
    }
}