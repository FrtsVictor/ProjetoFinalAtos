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

            entity.Property(e => e.Nome).HasColumnName("nome")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DataCriacao)
                .HasColumnType("smalldatetime")
                .HasColumnName("data_criacao")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Login)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("login");

            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("senha");

            entity.HasData(Seed());
        }

        private IEnumerable<Usuario> Seed() => new List<Usuario>()
        {
            new Usuario() {Id = 1, Nome = "Joao", Login = "JoaoUsername 1", Senha = "asudasu"},
            new Usuario() {Id = 2, Nome = "Pedro", Login = "PedroUsername 2", Senha = "asudasu"},
            new Usuario() {Id = 3, Nome = "Maria", Login = "MariaUsername 3", Senha = "asudasu"},
            new Usuario() {Id = 4, Nome = "Cecília", Login = "CecíliaUsername 4", Senha = "asudasu"},
            new Usuario() {Id = 5, Nome = "Eva", Login = "EvaUsername 5", Senha = "asudasu"}
        };
    }
}