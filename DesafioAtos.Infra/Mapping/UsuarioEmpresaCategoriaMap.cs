using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class UsuarioEmpresaCategoriaMap : IEntityTypeConfiguration<UsuarioEmpresaCategoria>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresaCategoria> entity)
        {
            entity.ToTable("Usuario_Empresa_Categoria");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

            entity.Property(e => e.IdEmpresaColetora).HasColumnName("id_empresa_coletora");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany(p => p.UsuarioEmpresaCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Usuario_E__id_ca__6442E2C9");

            entity.HasOne(d => d.IdEmpresaColetoraNavigation)
                .WithMany(p => p.UsuarioEmpresaCategoria)
                .HasForeignKey(d => d.IdEmpresaColetora)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Usuario_E__id_em__625A9A57");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuarioEmpresaCategoria)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Usuario_E__id_us__634EBE90");

            // builder.HasData(Seed());
        }

        private List<Usuario> Seed() => new List<Usuario>()
        {

        };
    }
}