namespace Test.Models
{
	public class Receipt
	{
		public int Id { get; set; }
		public DateTime TransfareDate { get; set; }
		public int TransfareAmount { get; set; }
		public string? Note { get; set; }
		public int BuildingId { get; set; }
		public Building? Building { get; set;}
		public int ApartmentId { get; set; }
		public Apartment? Apartment { get; set; }
		public int ResidentInfoId { get; set; }
		public ResidentInfo? ResidentInfo  { get; set; }

	}
}
