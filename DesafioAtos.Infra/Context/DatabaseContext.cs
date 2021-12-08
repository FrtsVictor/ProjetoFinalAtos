using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Customer> Customers { get; set; }
        //    DbSet<Address> Addresses { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        private readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Injetando log para queries SQL
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();

            // HardCode por conta do bug com as migrations
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=projeto_final;User Id=sa;Password=yourStrong(!)Password;");
        }
    }
}