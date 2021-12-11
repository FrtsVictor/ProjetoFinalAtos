using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Infra.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.DataCriacao)
                .HasColumnType("smalldatetime")
                .HasColumnName("data_criacao")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.Property(e => e.Status).HasColumnName("status");
            
            entity.HasData(Seed());
        }

        private List<Categoria> Seed() => new List<Categoria>()
        {
            new Categoria() { Id = 1, Nome = "Categoria 1" },
            new Categoria() { Id = 2, Nome = "Categoria 2" },
            new Categoria() { Id = 3, Nome = "Categoria 3" }
        };
    }
}