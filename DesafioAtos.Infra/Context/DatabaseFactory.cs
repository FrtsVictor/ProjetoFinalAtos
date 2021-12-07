using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace DesafioAtos.Infra.Context;
public class DatabaseFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DesafioAtos.Application"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AppDb");
        var dbKey = configuration["cryptography:AppDbKey"];
        var cryptography = new Cryptography();
        var dbContextBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        dbContextBuilder.UseSqlServer(connectionString);

        return new DatabaseContext(dbContextBuilder.Options);
    }
}
