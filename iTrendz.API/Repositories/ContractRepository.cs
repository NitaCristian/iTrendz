using iTrendz.Domain.Context;
using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Repositories
{
	public class ContractRepository(TrendzDbContext dbContext) : IContractRepository
	{
		public IEnumerable<Contract> GetAll() => dbContext.Contracts
			.Include(c => c.Influencer)
			.Include(c => c.Campaign)
			.Include(c => c.Posts)
			.Include(c => c.AgreedContent);

		public Contract? Get(int id) => dbContext.Contracts
			.Include(c => c.Influencer)
			.Include(c => c.Campaign)
			.Include(c => c.Posts)
			.Include(c => c.AgreedContent)
			.FirstOrDefault(p => p.Id == id);

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