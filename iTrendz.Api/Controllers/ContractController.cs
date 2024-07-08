using model.Models;
using model.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace iTrendz.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController
{
    public ContractController() { }

    [HttpGet]
    public ActionResult<List<Contract>> GetAll() =>
        ContractService.GetAll();
    [HttpGet("{id}")]
    public ActionResult<Contract> Get(int id)
    {
        var contract = ContractService.Get(id);
        if (contract == null)
            return NotFound();
        return contract;
    }
    [HttpPost]
    public IActionResult Create(Contract contract)
    {
        ContractService.Add(contract);
        return CreatedAction(nameof(Get), new { id == contract.Id }, contract);
    }
    [HttpPost]
    public IActionResult Update(int id, Contract contract)
    {
        if (id != contract.Id)
            return BadRequest();
        var existing = ContractService.Get(id);
        if (existing is null)
            return NotFound();
        PizzaService.Update(contract);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var contract = ContractService.Get(id);
        if (contract == null)
            return NotFound();
        ContractService.Delete(id);
        return NoContent();
    }

}
