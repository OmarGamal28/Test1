
using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test.Services.ApartmentService
{
	public class ApartmentService : IApartmentService

	{
		private readonly ApplicationDbContext dbContext;

        public ApartmentService(ApplicationDbContext context)
        {
			dbContext = context;
            

        }

        public void Delete(Apartment apartment)
		{
			dbContext.Apartments.Remove(apartment);
			dbContext.SaveChanges();
		}

		

		

		public async  Task<Apartment> Post(Apartment apartment)
		{
			 await dbContext.Apartments.AddAsync(apartment);
			dbContext.SaveChanges();
			return apartment;
			
		}

		public Apartment Put(Apartment apartment)
		{
			dbContext.Apartments.Update(apartment);
			dbContext.SaveChanges();
			return apartment;
		}

		 public async Task <IEnumerable<Apartment>> GetByBuildingId(int id)
		{
			return await  dbContext.Apartments.Where(a => a.BuildingId == id).ToListAsync();
		}

		public async Task<Apartment> GetById(int id)
		{
			return await dbContext.Apartments.FindAsync(id);
		}
	}
}
