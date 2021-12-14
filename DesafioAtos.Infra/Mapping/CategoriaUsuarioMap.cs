using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class CategoriaUsuarioMap : IEntityTypeConfiguration<CategoriaUsuario>
    {
        public void Configure(EntityTypeBuilder<CategoriaUsuario> entity)
        {
            entity.ToTable("Categoria_Usuario");
            entity.HasKey(e => e.Id);


            entity.Property(e => e.IdCategoria)
                .HasColumnName("id_categoria");

            entity.Property(e => e.IdUsuario)
                .HasColumnName("id_usuario");

            entity.HasOne(d => d.Usuario)
                .WithMany(p => p.CategoriaUsuarios)
                .HasForeignKey(d => d.IdUsuario)
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