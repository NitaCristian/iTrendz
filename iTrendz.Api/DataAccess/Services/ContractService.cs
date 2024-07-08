using model.Models;
namespace model.Services;

	public static class ContractService
	{
	static List<Contract> Contracts { get;  }
	static int nextId = 3;
	static ContractService()
	{
		Contracts = new List<Contract>();
	}
	public static List<Contract> GetAll() => Contracts;
	public static Contract? Get(int id) => Contracts.FirstOrDefault(p => p.Id == id);
	public static void Add(Contract contract)
	{
		contract.Id = nextId++;
		Contracts.Add(contract);
	}
	public static void Delete(int id)
	{
		var contract = Get(id);
		if (contract is null)
			return;
		Contracts.Remove(contract);
	}
	public static void Update(Contract contract)
	{
		var index = Contracts.FindIndex(p => p.Id == contract.Id);
		if (index == -1)
			return;
		Contracts[index] = contract;
	}
	}

