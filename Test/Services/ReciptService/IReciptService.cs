namespace Test.Services.ReciptService
{
	public interface IReciptService
	{
		Task<Receipt> Add(Receipt	receipt	);
		Task<Receipt> GetById(int id);
		Task<IEnumerable<Receipt>> GetByResidentId(int id);
		Receipt Update(Receipt receipt);
		void Delete(Receipt receipt);
	}
}
