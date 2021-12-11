using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class EmpresaColetoraMap : IEntityTypeConfiguration<EmpresaColetora>
    {
        public void Configure(EntityTypeBuilder<EmpresaColetora> entity)
        {
            entity.ToTable("Empresa_Coleta");

            entity.HasIndex(e => e.Telefone, "UQ__Empresa___2A16D97FC2534CA0")
                .IsUnique();

            entity.HasIndex(e => e.Cnpj, "UQ__Empresa___35BD3E48E3203960")
                .IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Empresa___AB6E616494A6D2F6")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id")
            .ValueGeneratedOnAdd();

            entity.Property(e => e.Role).HasColumnName("role");

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

            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("telefone")
                .IsFixedLength();


            entity.HasData(Seed());
        }

        private List<EmpresaColetora> Seed() => new List<EmpresaColetora>()
        {
            new EmpresaColetora()
            {
                Id = 1,
                Nome = "Recicla Mais",
                Email = "reciclaMais@gmail.com",
                Cnpj = "12345678912351",
                Telefone = "21968645988",
            },
            new EmpresaColetora()
            {
                Id = 2,
                Nome = "E-Colleta",
                Email = "e-colleta@gmail.com",
                Cnpj = "23345678912351",
                Telefone = "21968645223",
            },
            new EmpresaColetora()
            {
                Id = 3,
                Nome = "Serra-Plast",
                Email = "serra-plast@gmail.com",
                Cnpj = "35454267891235",
                Telefone = "21991478963",
            },
            new EmpresaColetora()
            {
                Id = 4,
                Nome = "Atos",
                Email = "atos.net@atos.com",
                Cnpj = "33475567708295",
                Telefone = "21984896849",
            },
            new EmpresaColetora()
            {
                Id = 6,
                Nome = "Santos Reciclaveis",
                Email = "santos@gmail.com",
                Cnpj = "19273546516573",
                Telefone = "21928495826",
            },
            new EmpresaColetora()
            {
                Id = 7,
                Nome = "Mega Reciclaveis",
                Email = "mega-reciclaveis@gmail.com",
                Cnpj = "59677586910513",
                Telefone = "21465567728",
            },
            new EmpresaColetora()
            {
                Id = 8,
                Nome = "New Reciclaveis",
                Email = "new-reciclaveis@gmail.com",
                Cnpj = "49576576819503",
                Telefone = "21162547526",
            },
            new EmpresaColetora()
            {
                Id = 9,
                Nome = "SuperCollect",
                Email = "super-collect@gmail.com",
                Cnpj = "19273546516321",
                Telefone = "21948192846",
            },
            new EmpresaColetora()
            {
                Id = 10,
                Nome = "NiceCollect",
                Email = "nice-collect@gmail.com",
                Cnpj = "19273455678848",
                Telefone = "21948596876",
            }
        };
    }
}