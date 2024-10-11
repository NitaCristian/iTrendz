using iTrendz.API.Repositories;
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
		var brand = brandRepository.Get(id);
		if (brand == null)
			return NotFound();

		return brand;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
    {
        return Ok(brandRepository.GetAll());
        
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand([FromBody] Brand brand)
    {
        
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBrand(int id, [FromBody] Brand brand)
    {
        return Ok(brandRepository.Update);

		throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        // TODO: Call the repository to delete the brand by ID and handle errors.
        throw new NotImplementedException();
    }
}