using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces
{
    public interface IContractRepository
    {
        IEnumerable<Contract> GetAll();
        Contract? Get(int id);
        void Add(Contract contract);
        void Delete(int id);
        void Update(Contract contract);
    }
}