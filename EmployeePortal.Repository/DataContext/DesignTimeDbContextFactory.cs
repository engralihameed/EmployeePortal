using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EmployeePortal.Repository.DataContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmployeeDbContext>
	{
		public EmployeeDbContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
			var builder = new DbContextOptionsBuilder<EmployeeDbContext>();
			var connectionString = configuration["Data:DefaultConnection"];
			builder.UseSqlite(connectionString);
			return new EmployeeDbContext(builder.Options);
		}
	}
}
