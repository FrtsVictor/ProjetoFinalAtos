using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Login, "UQ__Usuario__7838F27200D08C37")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.Role).HasColumnName("role");

            entity.Property(e => e.DataCriacao)
                .HasColumnType("smalldatetime")
                .HasColumnName("data_criacao")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Login)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("login");

            entity.Property(e => e.Senha)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("senha");

            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasData(Seed());
        }

        private List<Usuario> Seed() => new List<Usuario>()
        {
            new Usuario(){Id = 1, DataCriacao = DateTime.Now, Role = Domain.Enums.ERole.Usuario, Login = "MyUsername 1", Senha = "asudasu", Status = true},
            new Usuario(){Id = 2, DataCriacao = DateTime.Now, Role = Domain.Enums.ERole.Usuario, Login = "MyUsername 2", Senha = "asudasu", Status = true},
            new Usuario(){Id = 3, DataCriacao = DateTime.Now, Role = Domain.Enums.ERole.Usuario, Login = "MyUsername 3", Senha = "asudasu", Status = true},
            new Usuario(){Id = 4, DataCriacao = DateTime.Now, Role = Domain.Enums.ERole.Usuario, Login = "MyUsername 4", Senha = "asudasu", Status = true},
            new Usuario(){Id = 5, DataCriacao = DateTime.Now, Role = Domain.Enums.ERole.Usuario, Login = "MyUsername 5", Senha = "asudasu", Status = true}
        };
    }
}