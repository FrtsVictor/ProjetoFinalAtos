using DesafioAtos.Domain.Entities;
using DesafioAtos.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> b)
    {
        b.HasKey(u => u.Id);

        b.Property(u => u.Id)
               .IsRequired();

        b.HasIndex(b => b.Name)
        .IsUnique();
        b.Property(c => c.Name)
        .HasColumnType("VARCHAR(10)")
        .IsRequired();

        b.Property(c => c.CreatedAt)
        .HasColumnType("smalldatetime")
        .IsRequired();

        b.HasData(CreateSeed());
    }

    private List<Role> CreateSeed() => new List<Role>
    {
        new Role { Id = 1, Name = ERole.User.ToString() },
        new Role() { Id = 2, Name = ERole.Admin.ToString() }
    };
}
