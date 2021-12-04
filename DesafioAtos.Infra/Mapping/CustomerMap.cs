using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(c => c.Name)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();    

            builder.HasIndex(b => b.Username)
            .IsUnique();
            builder.Property(c => c.Username)
            .HasColumnType("VARCHAR(10)")
            .IsRequired();

            builder.Property(c => c.Password)
            .HasColumnType("VARCHAR(30)")
            .IsRequired();

            builder.Property(c => c.Phone)
            .HasColumnType("CHAR(11)")
            .IsRequired();

            builder.HasIndex(b => b.Cpf)
            .IsUnique();
            builder.Property(c => c.Cpf)
            .HasColumnType("CHAR(11)")
            
            .IsFixedLength()
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