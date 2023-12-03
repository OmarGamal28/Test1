using Microsoft.EntityFrameworkCore;

namespace Test.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions< ApplicationDbContext> options):base(options)
        {
            

        }
		
		public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
		public DbSet<Expenses> Expenses { get; set; }
		public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
		public DbSet<Receipt> Receipts { get; set; }
		public DbSet<ResidentInfo>ResidentInfo { get; set; }


	}
}
