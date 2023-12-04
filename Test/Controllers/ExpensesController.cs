using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Dtos;
using Test.Services.buildingservice;
using Test.Services.ExpensesCategoryService;
using Test.Services.NewFolder;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpensesController : ControllerBase
	{
		private readonly IExpensesService service;
		private readonly IBuildingService buildingService;
		[ActivatorUtilitiesConstructor]
		public ExpensesController(IExpensesService expenses, IBuildingService building)
		{
			service = expenses;
			buildingService = building;

		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateExpenseDto createExpenseDto)
		{
			var isValidId = await buildingService.IsValidBuilding(createExpenseDto.BuildingId);
			if (isValidId == false)
			{
				return NotFound("Enter Valid Building Id");

			}
			var expense = new Expenses
			{
				BuildingId = createExpenseDto.BuildingId,
				Name = createExpenseDto.Name,
				ExpensesCategoryId= createExpenseDto.ExpensesCategoryId,
				TransfareAmount=createExpenseDto.TransfareAmount,
				TransfareDate=createExpenseDto.TransfareDate,
				note=createExpenseDto.note
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
		[HttpPut(template: "{id}")]
		public async Task<IActionResult> Update(int id, CreateExpenseDto createExpenseDto)
		{
			var expense = await service.GetById(id);
			expense.TransfareDate = createExpenseDto.TransfareDate;
			expense.note = createExpenseDto.note;
			expense.ExpensesCategoryId = createExpenseDto.ExpensesCategoryId;
			expense.TransfareAmount = createExpenseDto.TransfareAmount;

			service.Update(expense);
			return Ok(new { Message = "Update Successfully", expense });

		}


	}
}
