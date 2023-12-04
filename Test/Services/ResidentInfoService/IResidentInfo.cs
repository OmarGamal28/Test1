namespace Test.Services.ResidentInfoService
{
	public interface IResidentInfo
	{
		Task<IEnumerable<ResidentInfo>> GetByBuildingId(int id);
		Task<ResidentInfo> Post(ResidentInfo residentInfo);
		Task<ResidentInfo> GetById(int id);
		ResidentInfo Put(ResidentInfo residentInfo);

		void Delete(ResidentInfo residentInfo);
	}
}
