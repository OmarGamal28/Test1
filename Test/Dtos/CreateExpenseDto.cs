namespace Test.Dtos
{
	public class CreateExpenseDto
	{
		public string? Name { get; set; }
		public DateTime TransfareDate { get; set; }
		public int TransfareAmount { get; set; }
		[MaxLength(60)]
		public string? note { get; set; }
		public int ExpensesCategoryId { get; set; }
		public int BuildingId { get; set; }
	}
}
