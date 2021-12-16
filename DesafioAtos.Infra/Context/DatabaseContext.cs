using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly ILoggerFactory _myLoggerFactory =
            LoggerFactory.Create(builder => builder.AddConsole());

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<EmpresaColetora> EmpresasColetoras { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<CategoriaUsuario> CategoriaUsuario { get; set; } = null!;
        public DbSet<CategoriaEmpresa> CategoriaEmpresa { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new EmpresaColetoraMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new CategoriaEmpresaMap());
            modelBuilder.ApplyConfiguration(new CategoriaUsuarioMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_myLoggerFactory)
                .EnableSensitiveDataLogging()
                //.UseSqlServer("Server=127.0.0.1;Database=projeto_final;User Id=sa;Password=yourStrong(!)Password");


            // HardCode por conta do bug com as migrations
            .UseSqlServer("Data Source=TIRANITAR\\SQLEXPRESS;Database=projeto_final;Integrated Security=True;MultipleActiveResultSets=true");
        }
    }
}