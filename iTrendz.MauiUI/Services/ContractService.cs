using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using System.Net.Http.Json;

namespace iTrendz.MauiUI.Services;

public class ContractService(HttpClient httpClient) : IContractService
{
	public async Task<IEnumerable<Contract>?> GetAllContractsAsync()
	{
		var response = await httpClient.GetAsync("contract/all");
		if (!response.IsSuccessStatusCode) return new List<Contract>();
		return await response.Content.ReadFromJsonAsync<List<Contract>>();
	}

	public async Task<Contract?> GetContractByIdAsync(int contractId)
	{
		var response = await httpClient.GetAsync($"contract/{contractId}");
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Contract>();
	}

	public async Task<Contract?> AddContractAsync(Contract contract)
	{
		var response = await httpClient.PostAsJsonAsync("contract", contract);
		if (!response.IsSuccessStatusCode) return null;
		return await response.Content.ReadFromJsonAsync<Contract>();
	}

	public async Task UpdateContractAsync(int contractId, Contract updatedContract)
	{
		var response = await httpClient.PutAsJsonAsync($"contract/{contractId}", updatedContract);
		if (!response.IsSuccessStatusCode)
			throw new Exception($"Failed to upadate contract");
	}

	public async Task DeleteContractAsync(int contractId)
	{
		var response = await httpClient.DeleteAsync($"contract/{contractId}");
		if (!response.IsSuccessStatusCode)
			throw new Exception($"Failed to delete contract");
	}
}