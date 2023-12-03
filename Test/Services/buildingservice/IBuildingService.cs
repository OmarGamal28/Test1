using Test.Models;

namespace Test.Services.buildingservice
{
	public interface IBuildingService
	{
		Task<IEnumerable<Building>> getAll();
		Task <Building> Add(Building building);
		Task<Building> getById(int id);
		Building Update(Building building);
		void Delete(Building building);
		Task<bool> IsValidBuilding(int id);
	}
}
