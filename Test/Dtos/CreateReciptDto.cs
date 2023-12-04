namespace Test.Dtos
{
	public class CreateReciptDto
	{
		public DateTime TransfareDate { get; set; }
		public int TransfareAmount { get; set; }
		public string? Note { get; set; }
		public int BuildingId { get; set; }
		public int ApartmentId { get; set; }
		public int ResidentInfoId { get; set; }
	}
}
