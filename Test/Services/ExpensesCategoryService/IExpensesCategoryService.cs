namespace Test.Services.ExpensesCategoryService
{
	public interface IExpensesCategoryService
	{
		Task<ExpenseCategory> Add(ExpenseCategory expense);
		Task<ExpenseCategory> GetById(int id);
		Task<IEnumerable<ExpenseCategory>> GetByBuildingId(int id);
		ExpenseCategory Update(ExpenseCategory expense);
		void Delete(ExpenseCategory expense);
	}
}
