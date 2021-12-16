using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DesafioAtos.Infra.Context
{
    public class FabricaDatabase : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DesafioAtos.Application"))
                .AddJsonFile("appsettings.json")
                .Build();
            var dbContextBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            return new DatabaseContext(dbContextBuilder.Options);
        }
    }
}