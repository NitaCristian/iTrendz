using iTrendz.Api.DataAccess.Context;
using iTrendz.Api.DataAccess.Entities;

namespace iTrendz.Api.DataAccess.Services;

public class ContractService
{
    private readonly TrendzDbContext _trendzDbContext;

    public ContractService(TrendzDbContext dbContext)
    {
        _trendzDbContext = dbContext;
    }

    public List<Contract> GetAll() => _trendzDbContext.Contracts.ToList();
    public Contract? Get(int id) => _trendzDbContext.Contracts.FirstOrDefault(p => p.Id == id);

    public void Add(Contract contract)
    {
        _trendzDbContext.Contracts.Add(contract);
        _trendzDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var contract = Get(id);
        if (contract is null)
            return;

        _trendzDbContext.Contracts.Remove(contract);
        _trendzDbContext.SaveChanges();
    }

    public void Update(Contract contract)
    {
        _trendzDbContext.Contracts.Update(contract);
        _trendzDbContext.SaveChanges();
    }
}