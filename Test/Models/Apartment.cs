
namespace Test.Models
{
	public class Apartment
	{
		public int Id { get; set; }
		[MaxLength(250)]
		public string? Name { get; set; }
		public int BuildingId {  get; set; }
		public Building? Building { get; set; }

	}
}
