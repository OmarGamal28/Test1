
using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test.Services.ExpensesCategoryService
{
	public class ExpensesCategoryService : IExpensesCategoryService
	{
		private readonly ApplicationDbContext dbContext;
        public ExpensesCategoryService(ApplicationDbContext context)
        {
            dbContext = context;

        }
        public async Task<ExpenseCategory> Add(ExpenseCategory expense)
		{
			 await dbContext.ExpenseCategories.AddAsync(expense);
			dbContext.SaveChanges();
			return expense;
			
		}

		public void Delete(ExpenseCategory expense)
		{
			dbContext.Remove(expense); 
			dbContext.SaveChanges();
		}

		public async Task<IEnumerable<ExpenseCategory>> GetByBuildingId(int id)
		{
			return await dbContext.ExpenseCategories.Where(e=>e.BuildingId==id).Include(m=>m.Building).ToListAsync();
		}

		public async Task<ExpenseCategory> GetById(int id)
		{
			return await dbContext.ExpenseCategories.FindAsync(id);
		}

		public  ExpenseCategory Update(ExpenseCategory expense)
		{
			 dbContext.ExpenseCategories.Update(expense);
			dbContext.SaveChanges();
			return expense;
		}
	}
}
