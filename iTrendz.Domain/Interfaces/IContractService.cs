using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IContractService
{
    Task<IEnumerable<Contract>> GetAllContractsAsync();
    Task<Contract> GetContractByIdAsync(int contractId);
    Task<Contract> AddContractAsync(Contract contract);
    Task<Contract> UpdateContractAsync(int contractId, Contract updatedContract);
    Task<bool> DeleteContractAsync(int contractId);
}