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
            entity.ToTable("Categoria");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasData(Seed());
        }

        private List<Categoria> Seed() => new List<Categoria>()
        {
            new Categoria() {Id = 1, Nome = ECategoria.Metal.ToString()},
            new Categoria() {Id = 2, Nome = ECategoria.PapelPapelao.ToString()},
            new Categoria() {Id = 3, Nome = ECategoria.Plastico.ToString()},
            new Categoria() {Id = 4, Nome = ECategoria.Vidro.ToString()},
            new Categoria() {Id = 5, Nome = ECategoria.Madeira.ToString()},
            new Categoria() {Id = 6, Nome = ECategoria.LixoOrganico.ToString()},
            new Categoria() {Id = 7, Nome = ECategoria.ResiduoPerigoso.ToString()},
            new Categoria() {Id = 8, Nome = ECategoria.ResiduoHospitalar.ToString()},
            new Categoria() {Id = 9, Nome = ECategoria.LixoRadioativo.ToString()},
            new Categoria() {Id = 10, Nome = ECategoria.LixoNaoReciclavel.ToString()},
        };
    }
}