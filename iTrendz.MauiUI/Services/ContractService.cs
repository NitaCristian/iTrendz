using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;

namespace iTrendz.MauiUI.Services;

public class ContractService(HttpClient httpClient) : IContractService
{
    public Task<Contract> GetContractAsync(int contractId)
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
}