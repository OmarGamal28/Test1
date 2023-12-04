
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Services.ResidentInfoService
{
	public class ResidentInfoService : IResidentInfo
	{
		private readonly ApplicationDbContext dbContext;

		public ResidentInfoService(ApplicationDbContext context)
		{
			dbContext = context;


		}
		public void Delete(ResidentInfo residentInfo)
		{
			dbContext.ResidentInfo.Remove(residentInfo);
			dbContext.SaveChanges();
		}

		public async Task<IEnumerable<ResidentInfo>> GetByBuildingId(int id)
		{
			return await dbContext.ResidentInfo.Where(e => e.BuildingId == id).Include(e => e.Building).ToListAsync();

		}

		public async Task<ResidentInfo> GetById(int id)
		{
			return await dbContext.ResidentInfo.FindAsync(id);
		}

		public async Task<ResidentInfo> Post(ResidentInfo residentInfo)
		{
			await dbContext.ResidentInfo.AddAsync(residentInfo);
			dbContext.SaveChanges();
			return residentInfo;
		}

		public ResidentInfo Put(ResidentInfo residentInfo)
		{
			dbContext.ResidentInfo.Update(residentInfo);
			dbContext.SaveChanges();
			return residentInfo;
		}
	}
}
