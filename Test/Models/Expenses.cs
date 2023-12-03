namespace Test.Models
{
	public class Expenses
	{
		public int Id { get; set; }
		[MaxLength(60)]
		public string? Name { get; set; }
		public DateTime TransfareDate { get; set; }
		public int TransfareAmount { get; set; }
		[MaxLength(60)]
		public string? note {  get; set; }
		public int ExpensesCategoryId { get; set; }
		public ExpenseCategory? ExpenseCategory { get; set; }
		public int BuildingId { get; set; }
		public Building? Building {  get;set;  }

	}
}
