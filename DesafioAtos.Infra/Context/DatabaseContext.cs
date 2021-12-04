using DesafioAtos.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    DbSet<Customer> Customers { get; set; }
    //    DbSet<Address> Addresses { get; set; }
    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory
        .Create(builder =>
        {
            builder.AddConsole();
        });

    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Injetando log para queries SQL
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();


        // Adicionando mapeamento para obter connection string do appSetting do projeto Application
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DesafioAtos.Application"))
            .AddJsonFile("appsettings.json").Build();

        var connectionString = configuration.GetConnectionString("AppDb");
        optionsBuilder.UseSqlServer(connectionString);
    }
}