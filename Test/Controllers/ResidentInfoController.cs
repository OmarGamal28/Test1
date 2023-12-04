using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Dtos;
using Test.Services.buildingservice;
using Test.Services.ResidentInfoService;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResidentInfoController : ControllerBase
	{
		private readonly IResidentInfo service;
		private readonly IBuildingService buildingService;
		[ActivatorUtilitiesConstructor]
		public ResidentInfoController(IResidentInfo resident, IBuildingService building)
		{
			service = resident;
			buildingService = building;

		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateResidentDto createResidentDto)
		{
			var isValidId = await buildingService.IsValidBuilding(createResidentDto.BuildingId);
			if (isValidId == false)
			{
				return NotFound("Enter Valid Building Id");

			}
			var resident = new ResidentInfo
			{
				Name= createResidentDto.Name,
				PhoneNumber= createResidentDto.PhoneNumber,
				BuildingId= createResidentDto.BuildingId,
				ApartmentId=createResidentDto.ApartmentId

			};
			await service.Post(resident);
			return Ok(resident);

		}



		[HttpGet(template: "{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var resident = await service.GetById(id);
			if (resident == null)
			{
				return NotFound($"{id} Not Found");
			}
			return Ok(resident);
		}

		[HttpGet(template: "GetByBuildingId")]
		public async Task<IActionResult> GetByBuildingId(int id)
		{
			var recipt = await service.GetByBuildingId(id);
			if (recipt == null)
			{
				return NotFound("Enter Valid BuildingId");
			}
			return Ok(recipt);


		}

		[HttpDelete(template: "{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var residnet = await service.GetById(id);
			if (residnet == null)
			{
				return NotFound("Enter Valid ResidentId");
			}
			return Ok(new { Message = "Deleted Successfully" });

		}

		[HttpPut(template: "{id}")]
		public async Task<IActionResult> Update(int id, CreateResidentDto createResidentDto)
		{
			var resident = await service.GetById(id);
			resident.Name=createResidentDto.Name;
			resident.PhoneNumber=createResidentDto.PhoneNumber;


			service.Put(resident);
			return Ok(new { Message = "Update Successfully", resident });

		}
	}
}
