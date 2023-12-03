
using Test.Data;
using Microsoft.EntityFrameworkCore;


namespace Test.Services.buildingservice
{
	public class BuildingService : IBuildingService

	{
		private readonly ApplicationDbContext dbcontext;
        public BuildingService(ApplicationDbContext context)
        {
			dbcontext = context;
            
        }

        public async Task<Building> Add(Building building)

		{
			
			await dbcontext.Buildings.AddAsync(building);
			dbcontext.SaveChanges();
			return building;
			
		}

		public void Delete(Building building)
		{
			dbcontext.Remove(building);
			dbcontext.SaveChanges();
		}

		public async Task<IEnumerable<Building>> getAll()
		{
			return await dbcontext.Buildings.OrderBy(b => b.Name).ToListAsync();
		}

		public async Task<Building> getById(int id)
		{
			return await dbcontext.Buildings.FindAsync(id);
			
		}

		public Building Update(Building building)
		{
			dbcontext.Buildings.Update(building);
			dbcontext.SaveChanges();
			return building;
		}
		public async Task<bool> IsValidBuilding(int id)
		{
			return await dbcontext.Buildings.AnyAsync(b=>b.Id==id);


		}
	}
}
