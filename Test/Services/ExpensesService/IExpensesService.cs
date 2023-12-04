namespace Test.Services.NewFolder
{
	public interface IExpensesService
	{
		Task<Expenses> Add(Expenses expense);
		Task<Expenses> GetById(int id);
		Task<IEnumerable<Expenses>> GetByBuildingId(int id);
		Expenses Update(Expenses expense);
		void Delete(Expenses expense);
	}
}
