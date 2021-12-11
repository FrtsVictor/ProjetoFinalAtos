using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class EmpresaColetoraMap : IEntityTypeConfiguration<EmpresaColeta>
    {
        public void Configure(EntityTypeBuilder<EmpresaColeta> entity)
        {
            entity.ToTable("Empresa_Coleta");

            entity.HasIndex(e => e.Telefone, "UQ__Empresa___2A16D97FC2534CA0")
                .IsUnique();

            entity.HasIndex(e => e.Cnpj, "UQ__Empresa___35BD3E48E3203960")
                .IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Empresa___AB6E616494A6D2F6")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("cnpj")
                .IsFixedLength();

            entity.Property(e => e.DataCriacao)
                .HasColumnType("smalldatetime")
                .HasColumnName("data_criacao")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.Property(e => e.Status).HasColumnName("status");

            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("telefone")
                .IsFixedLength();


            entity.HasData(Seed());
        }

        private List<EmpresaColeta> Seed() => new List<EmpresaColeta>()
        {
            new EmpresaColeta()
            {
                Id= 1,
                Cnpj = "1234567891235",
                Status = true,
                Email = "email.empresa1@gmail",
                Nome = "Empresa 1",
                Telefone = "9011s9q0990"
            },
            new EmpresaColeta()
            {
                Id = 2,
                Cnpj = "321654987789",
                Status = true,
                Email = "email.empresa2@gmail",
                Nome = "Empresa 2",
                Telefone = "91d9qw0",
            }
        };
    }
}