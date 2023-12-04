using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Dtos;
using Test.Services.buildingservice;
using Test.Services.ExpensesCategoryService;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseCategoriesController : ControllerBase
	{
		private readonly IExpensesCategoryService service;
		private readonly IBuildingService buildingService;
		[ActivatorUtilitiesConstructor]
		public ExpenseCategoriesController(IExpensesCategoryService expenses, IBuildingService building)
		{
			service = expenses;
			buildingService = building;

		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateExpensesCategoryDto createExpensesCategoryDto)
		{
			var isValidId = await buildingService.IsValidBuilding(createExpensesCategoryDto.BuildingId);
			if (isValidId == false)
			{
				return NotFound("Enter Valid Building Id");

			}
			var expense = new ExpenseCategory
			{
				BuildingId = createExpensesCategoryDto.BuildingId,
				Name = createExpensesCategoryDto.Name,
			};
			await service.Add(expense);
			return Ok(expense);

		}
		[HttpGet(template: "{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var expense = await service.GetById(id);
			if (expense == null)
			{
				return NotFound($"{id} Not Found");
			}
			return Ok(expense);
		}

		[HttpGet(template: "GetByBuildingId")]
		public async Task<IActionResult> GetByBuildingId(int id)
		{
			var expense = await service.GetByBuildingId(id);
			if (expense == null)
			{
				return NotFound("Enter Valid BuildingId");
			}
			return Ok(expense);


		}
		[HttpDelete(template: "{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var expense = await service.GetById(id);
			if (expense == null)
			{
				return NotFound("Enter Valid BuildingId");
			}
			return Ok(new { Message = "Deleted Successfully" });

		}
		[HttpPut(template:"{id}")]
		public async Task<IActionResult> Update(int id,CreateExpensesCategoryDto createExpensesCategoryDto)
		{
			var expense = await service.GetById(id);
			expense.Name = createExpensesCategoryDto.Name;
			service.Update(expense);
			return Ok(new {Message="Update Successfully" ,expense });

		}
	}
}
