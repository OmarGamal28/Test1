namespace Test.Services.ApartmentService
{
	public interface IApartmentService
	{
		
		Task<IEnumerable<Apartment>> GetByBuildingId(int id);
		Task<Apartment> Post(Apartment apartment);
		Task<Apartment> GetById(int id);
		Apartment Put(Apartment apartment);

		void Delete(Apartment apartment);
		

	}
}
