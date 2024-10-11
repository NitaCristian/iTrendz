using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class ContractService(HttpClient httpClient) : IContractService
{
    public Task<IEnumerable<Contract>> GetAllContractsAsync()
    {
        // TODO: Call the API to retrieve all contracts.
        throw new NotImplementedException();
    }

    public Task<Contract> GetContractByIdAsync(int contractId)
    {
        // TODO: Implement this method to retrieve a specific contract by ID.
        throw new NotImplementedException();
    }

    public Task<Contract> AddContractAsync(Contract contract)
    {
        // TODO: Implement this method to add a new contract via the API.
        throw new NotImplementedException();
    }

    public Task<Contract> UpdateContractAsync(int contractId, Contract updatedContract)
    {
        // TODO: Implement this method to update an existing contract via the API.
        throw new NotImplementedException();
    }

    public Task<bool> DeleteContractAsync(int contractId)
    {
        // TODO: Implement this method to delete a contract by ID via the API.
        throw new NotImplementedException();
    }
}