using iTrendz.Domain.Models;

namespace iTrendz.Domain.Interfaces;

public interface IContractService
{
    Task<Contract> GetContractAsync(int contractId);
}