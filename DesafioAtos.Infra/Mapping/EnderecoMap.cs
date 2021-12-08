using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(a => a.Cidade)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();    

            builder.Property(a => a.Estado)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();

            builder.Property(b => b.Complemento)
              .HasColumnType("VARCHAR(100)");

            builder.Property(b => b.Bairro)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(b => b.Cep)
                .HasColumnType("VARCHAR(8)")
                .IsRequired();

            builder.Property(b => b.Numero)
              .HasColumnType("VARCHAR(12)")
           .IsRequired();

            builder.Property(b => b.Rua)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnType("bit")
                .IsRequired();
        }

    }
}