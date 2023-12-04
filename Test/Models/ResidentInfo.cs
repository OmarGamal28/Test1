namespace Test.Models
{
	public class ResidentInfo
	{
		public int Id { get; set; }
		[MaxLength(20)]
		public string? Name { get; set; }
		public string PhoneNumber {  get; set; }
		public int BuildingId { get; set; }
		public Building? Building { get; set; }
		public int ApartmentId { get; set; }
		public Apartment? Apartment { get; set; }
		public ICollection<Receipt> Receipts { get; set; }=new List<Receipt>();

	}
}
