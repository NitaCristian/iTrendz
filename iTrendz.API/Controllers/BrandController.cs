using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace iTrendz.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController(IBrandRepository brandRepository) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Brand>> GetBrandById(int id)
    {
        // TODO: Use the repository to get the brand by ID, and return NotFound if null.
        throw new NotImplementedException();
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
    {
        // TODO: Use the repository to get all brands and return them.
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand([FromBody] Brand brand)
    {
        // TODO: Call the repository to add the brand and return appropriate status.
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBrand(int id, [FromBody] Brand brand)
    {
        // TODO: Call the repository to update the brand by ID and handle errors.
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        // TODO: Call the repository to delete the brand by ID and handle errors.
        throw new NotImplementedException();
    }
}