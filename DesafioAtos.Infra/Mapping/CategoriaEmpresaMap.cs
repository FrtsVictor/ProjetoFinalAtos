using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class CategoriaEmpresaMap : IEntityTypeConfiguration<CategoriaEmpresa>
    {
        public void Configure(EntityTypeBuilder<CategoriaEmpresa> entity)
        {
            entity.ToTable("Categoria_Empresa");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.IdCategoria)
                .HasColumnName("id_categoria");

            entity.Property(e => e.IdEmpresaColetora)
                .HasColumnName("id_empresa_coletora");

            entity.HasOne(d => d.EmpresaColetora)
                .WithMany(p => p.CategoriaEmpresa)
                .HasForeignKey(d => d.IdEmpresaColetora)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Usuario_E__id_ca__6442E2C9");

            entity.HasOne(d => d.Categoria)
                .WithMany()
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Usuario_E__id_em__625A9A57");


            //entity.HasData(Seed());
        }
    }
}