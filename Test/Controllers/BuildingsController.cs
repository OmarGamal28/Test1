using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Dtos;
using Test.Services.buildingservice;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BuildingsController : ControllerBase
	{
		private readonly IBuildingService buildingService;

		public BuildingsController(IBuildingService building)
		{
			this.buildingService = building;

		}
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var genre = await buildingService.getAll();
			if (genre == null)
			{
				return NotFound();
			}
			return Ok(genre);
		}

		[HttpGet(template: "{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var building = await buildingService.getById(id);
			if (building == null)
			{
				return NotFound(value:"Enter Valid Id") ;
			}
			return Ok(building);

		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateBuildingDto createBuildingDto)
		{
			var building = new Building
			{
				Name=createBuildingDto.Name,
				Address=createBuildingDto.Address,
				FloorCount=createBuildingDto.FloorCount,
				ApartmentCount=createBuildingDto.ApartmentCount,
				Number=createBuildingDto.Number,
				

			};
			await buildingService.Add(building);
			return Ok(building);
			

		}
		[HttpPut(template:"{id}")]
		public async Task<IActionResult> Update(int id , CreateBuildingDto createBuildingDto)
		{
			var building = await buildingService.getById(id);
			if(building== null)
			{
				return NotFound(value: $"{id} not found");
			}
			building.Address = createBuildingDto.Address;
			building.Number = createBuildingDto.Number;
			building.Name = createBuildingDto.Name;
			building.FloorCount = createBuildingDto.FloorCount;
			building.ApartmentCount= createBuildingDto.ApartmentCount;
			buildingService.Update(building);
			return Ok(new{ Message = "Genre updated successfully",building } );
		}
		[HttpDelete(template: "{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var building = await buildingService.getById(id);
			if(building== null)
			{
				return NotFound(value:$"{id} not found");
			}
;			buildingService.Delete(building);
			return Ok(new { Message="Deleted Scussesfully" });
		}



	}
}
