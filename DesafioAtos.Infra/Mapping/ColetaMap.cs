using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class ColetaMap : IEntityTypeConfiguration<Coleta>
    {
        public void Configure(EntityTypeBuilder<Coleta> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(a => a.ItemDeColeta)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();


            builder.Property(a => a.Observacao)
                .HasColumnType("VARCHAR(100)")
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
