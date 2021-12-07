using DesafioAtos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
        .ValueGeneratedOnAdd()
        .IsRequired();

        builder.HasIndex(b => b.Username)
        .IsUnique();
        builder.Property(c => c.Username)
        .HasColumnType("VARCHAR(10)")
        .IsRequired();

        builder.Property(c => c.Password)
        .HasColumnType("VARCHAR(30)")
        .IsRequired();

        builder.Property(c => c.CreatedAt)
        .HasColumnType("smalldatetime")
        .IsRequired();

        builder.Property(c => c.Status)
        .HasColumnType("bit")
        .IsRequired();
    }

}
