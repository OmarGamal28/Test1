using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Dtos;
using Test.Models;
using Test.Services.buildingservice;
using Test.Services.NewFolder;
using Test.Services.ReciptService;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReciptController : ControllerBase
	{
		private readonly IReciptService service;
		private readonly IBuildingService buildingService;
		[ActivatorUtilitiesConstructor]
		public ReciptController(IReciptService reciptService ,IBuildingService building)
		{
			service = reciptService;
			buildingService = building;

		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateReciptDto createReciptDto)
		{
			var isValidId = await buildingService.IsValidBuilding(createReciptDto.BuildingId);
			if (isValidId == false)
			{
				return NotFound("Enter Valid Building Id");

			}
			var recipt = new Receipt
			{
				TransfareAmount = createReciptDto.TransfareAmount,
				TransfareDate =createReciptDto.TransfareDate,
				Note= createReciptDto.Note,
				BuildingId = createReciptDto.BuildingId,
				ApartmentId =createReciptDto.BuildingId,
				ResidentInfoId=createReciptDto.ResidentInfoId
				
			};
			await service.Add(recipt);
			return Ok(recipt);

		}



		[HttpGet(template: "{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var recipt = await service.GetById(id);
			if (recipt == null)
			{
				return NotFound($"{id} Not Found");
			}
			return Ok(recipt);
		}

		[HttpGet(template: "GetByResidentId")]
		public async Task<IActionResult> GetByResidentId(int id)
		{
			var recipt = await service.GetByResidentId(id);
			if (recipt == null)
			{
				return NotFound("Enter Valid ResidentId");
			}
			return Ok(recipt);


		}
		[HttpDelete(template: "{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var recipt = await service.GetById(id);
			if (recipt == null)
			{
				return NotFound("Enter Valid ReciptId");
			}
			return Ok(new { Message = "Deleted Successfully" });

		}
		[HttpPut(template: "{id}")]
		public async Task<IActionResult> Update(int id, CreateReciptDto createReciptDto)
		{
			var recipt = await service.GetById(id);
			recipt.TransfareAmount = createReciptDto.TransfareAmount;
				recipt.TransfareDate = createReciptDto.TransfareDate;
				recipt.Note = createReciptDto.Note;
				
			
			service.Update(recipt);
			return Ok(new { Message = "Update Successfully", recipt });

		}
	}
}
