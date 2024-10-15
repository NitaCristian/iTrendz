using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using System.Net.Http.Json;

namespace iTrendz.MauiUI.Services;

public class ContractService(HttpClient httpClient) : IContractService
{
    public async Task<IEnumerable<Contract>> GetAllContractsAsync()
    {

		var response = await httpClient.GetAsync("contract/all");
		if (!response.IsSuccessStatusCode) return new List<Contract>();
		return await response.Content.ReadFromJsonAsync<List<Contract>>();
	}

    public async Task<Contract> GetContractByIdAsync(int contractId)
    {
		var response = await httpClient.GetAsync($"brand/{contractId}");
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Contract>();
	}

    public async Task<Contract> AddContractAsync(Contract contract)
    {
		var response= await httpClient.PostAsJsonAsync("brand",contract);
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Contract>();
		
	}

    public async Task<Contract> UpdateContractAsync(int contractId, Contract updatedContract)
    {
		var response = await httpClient.PutAsJsonAsync($"brand/{contractId}", updatedContract);

		if (!response.IsSuccessStatusCode)
			throw new Exception($"faild to upadate influencer");
		return await response.Content.ReadFromJsonAsync<Contract>();
	}

    public async Task<bool> DeleteContractAsync(int contractId)
    {
		var response = await httpClient.DeleteAsync($"brand/{contractId}");

		
		return response.IsSuccessStatusCode;
	}
}