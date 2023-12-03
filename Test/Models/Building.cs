namespace Test.Models
{
	public class Building
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public string Address { get; set; }
		public int ApartmentCount { get; set; }
		public int FloorCount { get; set; }
		public ICollection<Expenses> Expenses { get; set; }=new List<Expenses>();
		public ICollection<Apartment>Apartment { get; set; } = new List<Apartment>();

	}
}
