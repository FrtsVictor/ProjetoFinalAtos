using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.HasIndex(b => b.Login)
            .IsUnique();
            builder.Property(c => c.Login)
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

            builder.Property(c => c.Senha)
            .HasColumnType("VARCHAR(30)")
            .IsRequired();

            builder.Property(c => c.DataCriacao)
            .HasColumnType("smalldatetime")
            .IsRequired();

            builder.Property(c => c.Status)
            .HasColumnType("bit")
            .IsRequired();
        }
    }
}