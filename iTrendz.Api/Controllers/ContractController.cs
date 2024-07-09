using iTrendz.Api.DataAccess.Entities;
using iTrendz.Api.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace iTrendz.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController : ControllerBase
{
    private ContractService _contractService;

    public ContractController(ContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public ActionResult<List<Contract>> GetAll() => _contractService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Contract> Get(int id)
    {
        var contract = _contractService.Get(id);
        if (contract == null)
            return NotFound();
        return contract;
    }

    // [HttpPost]
    // public IActionResult Create(Contract contract)
    // {
    //     _contractService.Add(contract);
    //     return CreatedAction(nameof(Get), new { id == contract.Id }, contract);
    // }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Contract contract)
    {
        if (id != contract.Id)
            return BadRequest();

        var existing = _contractService.Get(id);
        if (existing is null)
            return NotFound();

        _contractService.Update(contract);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var contract = _contractService.Get(id);
        if (contract == null)
            return NotFound();

        _contractService.Delete(id);
        return NoContent();
    }
}