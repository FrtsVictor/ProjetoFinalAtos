using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Usuario> Users { get; set; }
        public DbSet<Coleta> Coletas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<EmpresaColetora> EmpresasColetoras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        private readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ColetaMap());
            modelBuilder.ApplyConfiguration(new EmpresaColetoraMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Injetando log para queries SQL
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();

            // HardCode por conta do bug com as migrations
            optionsBuilder.UseSqlServer("Data Source=TIRANITAR\\SQLEXPRESS;Initial Catalog=DesafioAtos;Integrated Security=True;MultipleActiveResultSets=true");
        }
    }
}