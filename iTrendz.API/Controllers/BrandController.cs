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
	public async Task<ActionResult<Brand>> GetById(int id)
	{
		var brand = brandRepository.GetById(id);
		if (brand == null)
			return NotFound();

		return brand;
	}

	[HttpGet("all")]
	public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
	{
		return Ok(brandRepository.GetAll());

	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, [FromBody] Brand brand)
	{
		if (id != brand.Id)
			return BadRequest();

		var existingBrand = brandRepository.GetById(id);
		if (existingBrand == null)
			return NotFound();

		brandRepository.Update(brand);
		return NoContent();
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		var brand = brandRepository.GetById(id);
		if (brand == null)
			return NotFound();

		brandRepository.Delete(id);
		return NoContent();

	}
}