using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.API.Repositories
{
    public class ContractRepository(TrendzDbContext dbContext) : IContractRepository
    {
        public IEnumerable<Contract> GetAll() => dbContext.Contracts;

        public Contract? Get(int id) => dbContext.Contracts.FirstOrDefault(p => p.Id == id);

        public void Add(Contract contract)
        {
            dbContext.Contracts.Add(contract);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var contract = Get(id);
            if (contract is null)
                return;

            dbContext.Contracts.Remove(contract);
            dbContext.SaveChanges();
        }

        public void Update(Contract contract)
        {
            dbContext.Contracts.Update(contract);
            dbContext.SaveChanges();
        }
    }
}