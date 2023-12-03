using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Dtos;
using Test.Services.ApartmentService;
using Test.Services.buildingservice;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApartmentsController : ControllerBase
	{
		private readonly IApartmentService service;
		private readonly IBuildingService buildingService;
		[ActivatorUtilitiesConstructor]
		public ApartmentsController(IApartmentService apartmentService,IBuildingService building)
        {
			service = apartmentService;
            buildingService = building;
        }
		[HttpPost]
		public async Task<IActionResult> Post(CreateApartmentDto createApartemntDto)
		{
			var isValidId = await buildingService.IsValidBuilding(createApartemntDto.BuildingId);
			if (isValidId == false)
			{
				return NotFound("Enter Valid Building Id");

			}
			var apartment = new Apartment
			{
				Name = createApartemntDto.Name,
				BuildingId = createApartemntDto.BuildingId,
			};
			await service.Post(apartment);

			return Ok(apartment);

		}
		[HttpGet (template: "GetByBuildingId")]
		public async Task<IActionResult> GetByBuildingId(int buildingId)
		{
			

			var apartments=await service.GetByBuildingId(buildingId);
			if(apartments == null)
			{
				return NotFound("Enter Valid BuildingId");

			}
			return Ok(apartments);

		}

		[HttpDelete(template:"{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var apartment = await service.GetById(id);
			if (apartment == null)
			{
				return NotFound(value: $"{id} not found");
			}
			service.Delete(apartment);
			return Ok(new {Message="DELETED Successfully"});

		}
		[HttpPut(template:"{id}")]
		public async Task<IActionResult> Update(int id,CreateApartmentDto createApartmentDto)
		{
			var apartment = await service.GetById(id);
			apartment.Name = createApartmentDto.Name;
			return Ok(new { Message = "Genre updated successfully", apartment });


		}
    }
}
