namespace Test.Models
{
	public class ExpenseCategory
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string? Name { get; set; }
		public int BuildingId { get; set; }
		public Building? Building { get; set; }

	}
}
