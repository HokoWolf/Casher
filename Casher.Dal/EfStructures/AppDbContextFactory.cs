using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Casher.Dal.EfStructures
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			var connectionString = "Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Trusted_Connection=True;Initial Catalog=Casher";
			optionsBuilder.UseSqlServer(connectionString);
			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
