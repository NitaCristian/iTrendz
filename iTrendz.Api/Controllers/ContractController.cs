using iTrendz.API.Repositories;
using iTrendz.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace iTrendz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractController(ContractRepository contractRepository) : ControllerBase
{
    [HttpGet("all")]
    public ActionResult<List<Contract>> GetAll() => Ok(contractRepository.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Contract> Get(int id)
    {
        var contract = contractRepository.Get(id);
        if (contract == null)
            return NotFound();
        return contract;
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Contract contract)
    {
        if (id != contract.Id)
            return BadRequest();

        var existing = contractRepository.Get(id);
        if (existing is null)
            return NotFound();

        contractRepository.Update(contract);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var contract = contractRepository.Get(id);
        if (contract == null)
            return NotFound();

        contractRepository.Delete(id);
        return NoContent();
    }
}