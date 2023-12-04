
using Microsoft.EntityFrameworkCore;


namespace Test.Services.NewFolder
{
	public class ExpensesService : IExpensesService
	{
		private readonly ApplicationDbContext dbContext;
		public ExpensesService(ApplicationDbContext context)
		{
			dbContext = context;

		}
		public async Task<Expenses> Add(Expenses expense)
		{
			await dbContext.Expenses.AddAsync(expense);
			dbContext.SaveChanges();
			return expense;
		}

		public void Delete(Expenses expense)
		{
			dbContext.Expenses.Remove(expense); 
			dbContext.SaveChanges();
		}

		public async Task<IEnumerable<Expenses>> GetByBuildingId(int id)
		{
			return await dbContext.Expenses.Where(e => e.BuildingId == id).Include(e=>e.Building).Include(e=>e.ExpenseCategory).ToListAsync();
		}

		public async Task<Expenses> GetById(int id)
		{
			return await dbContext.Expenses.FindAsync(id);
		}

		public Expenses Update(Expenses expense)
		{
			dbContext.Expenses.Update(expense);
			dbContext.SaveChanges();
			return expense;
		}

		
	}
}
