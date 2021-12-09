using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class EmpresaColetoraMap : IEntityTypeConfiguration<EmpresaColetora>
    {
        public void Configure(EntityTypeBuilder<EmpresaColetora> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(c => c.Nome)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();    

            builder.Property(c => c.Telefone)
            .HasColumnType("CHAR(11)")
            .IsRequired();

            builder.HasIndex(b => b.Cnpj)
            .IsUnique();

            builder.Property(c => c.Cnpj)
            .HasColumnType("CHAR(12)")
            
            .IsFixedLength()
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