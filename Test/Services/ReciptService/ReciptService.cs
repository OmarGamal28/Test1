
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Services.ReciptService
{
	public class ReciptService : IReciptService
	{
		private readonly ApplicationDbContext dbContext;
		public ReciptService(ApplicationDbContext context)
		{
			dbContext = context;

		}
		public async Task<Receipt> Add(Receipt receipt)
		{
			await dbContext.Receipts.AddAsync(receipt);
			dbContext.SaveChanges();
			return receipt;
		}

		public void Delete(Receipt receipt)
		{
			dbContext.Remove(receipt);
			dbContext.SaveChanges();
		}

		public async Task<Receipt> GetById(int id)
		{
			return await dbContext.Receipts.FindAsync(id);
		}

		public async Task<IEnumerable<Receipt>> GetByResidentId(int id)
		{
			return await dbContext.Receipts.Where(e => e.ResidentInfoId == id).ToListAsync();

		}

		public Receipt Update(Receipt receipt)
		{
			dbContext.Receipts.Update(receipt);
			dbContext.SaveChanges();
			return receipt;
		}
	}
}
