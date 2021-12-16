using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class UsuarioEmpresaCategoriaMap : IEntityTypeConfiguration<UsuarioEmpresaCategoria>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresaCategoria> entity)
        {
        //    entity.ToTable("Usuario_Empresa_Categoria");

        //    entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

        //    entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

        //    entity.Property(e => e.IdEmpresaColetora).HasColumnName("id_empresa_coletora");

        //    entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

        //    entity.HasOne(d => d.IdCategoriaNavigation)
        //        .WithMany(p => p.UsuarioEmpresaCategoria)
        //        .HasForeignKey(d => d.IdCategoria)
        //        .OnDelete(DeleteBehavior.SetNull)
        //        .HasConstraintName("FK__Usuario_E__id_ca__6442E2C9");

        //    entity.HasOne(d => d.IdEmpresaColetoraNavigation)
        //        .WithMany(p => p.UsuarioEmpresaCategoria)
        //        .HasForeignKey(d => d.IdEmpresaColetora)
        //        .OnDelete(DeleteBehavior.SetNull)
        //        .HasConstraintName("FK__Usuario_E__id_em__625A9A57");

        //    entity.HasOne(d => d.IdUsuarioNavigation)
        //        .WithMany(p => p.UsuarioEmpresaCategoria)
        //        .HasForeignKey(d => d.IdUsuario)
        //        .OnDelete(DeleteBehavior.SetNull)
        //        .HasConstraintName("FK__Usuario_E__id_us__634EBE90");

            entity.HasData(Seed());
        }

        private List<UsuarioEmpresaCategoria> Seed() => new List<UsuarioEmpresaCategoria>()
        {
            new UsuarioEmpresaCategoria(){ IdCategoria = 1, IdEmpresaColetora = 2},
            new UsuarioEmpresaCategoria(){ IdCategoria = 2, IdEmpresaColetora = 3},
            new UsuarioEmpresaCategoria(){ IdCategoria = 3, IdEmpresaColetora = 4},
            new UsuarioEmpresaCategoria(){ IdCategoria = 4, IdEmpresaColetora = 5},
            new UsuarioEmpresaCategoria(){ IdCategoria = 5, IdEmpresaColetora = 6},
            new UsuarioEmpresaCategoria(){ IdCategoria = 6, IdEmpresaColetora = 7},
            new UsuarioEmpresaCategoria(){ IdCategoria = 7, IdEmpresaColetora = 8},
            new UsuarioEmpresaCategoria(){ IdCategoria = 8, IdEmpresaColetora = 9},
            new UsuarioEmpresaCategoria(){ IdCategoria = 9, IdEmpresaColetora = 1},
            new UsuarioEmpresaCategoria(){ IdCategoria = 10, IdEmpresaColetora = 10},

            new UsuarioEmpresaCategoria(){ IdCategoria = 1, IdUsuario = 2},
            new UsuarioEmpresaCategoria(){ IdCategoria = 2, IdUsuario = 3},
            new UsuarioEmpresaCategoria(){ IdCategoria = 3, IdUsuario = 4},
            new UsuarioEmpresaCategoria(){ IdCategoria = 4, IdUsuario = 5},
            new UsuarioEmpresaCategoria(){ IdCategoria = 5, IdUsuario = 6},
            new UsuarioEmpresaCategoria(){ IdCategoria = 6, IdUsuario = 7},
            new UsuarioEmpresaCategoria(){ IdCategoria = 7, IdUsuario = 8},
            new UsuarioEmpresaCategoria(){ IdCategoria = 8, IdUsuario = 9},
            new UsuarioEmpresaCategoria(){ IdCategoria = 9, IdUsuario = 1},
            new UsuarioEmpresaCategoria(){ IdCategoria = 10, IdUsuario = 10}
        };
    }
}