using DesafioAtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAtos.Infra.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> entity)
        {
            entity.ToTable("Endereco");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

            entity.Property(e => e.Bairro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bairro");

            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("cep");

            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cidade");

            entity.Property(e => e.Complemento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("complemento");

            entity.Property(e => e.DataCriacao)
                .HasColumnType("smalldatetime")
                .HasColumnName("data_criacao")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");

            entity.Property(e => e.IdEmpresaColeta).HasColumnName("id_empresa_coletora");

            entity.Property(e => e.Numero)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("numero");

            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rua");

            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdEmpresaColetaNavigation)
                .WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.IdEmpresaColeta)
                .HasConstraintName("FK__Endereco__id_emp__5CA1C101");
        }

        private void Seed() => new List<Endereco>()
        {
            new Endereco()
            {
                Id = 1,
                Bairro = "Alto",
                Rua = "Rua das palmeiras",
                Status = true,
                Numero = "135",
                Cep= "25964369",
                Cidade = "Teresópolis",
                Complemento = "Casa",
                Estado = "RJ",
                IdEmpresaColeta = 1
            },
            new Endereco()
            {
                Id = 2,
                Bairro = "Santa Clara",
                Rua = "Av Rio Branco",
                Status = true,
                Numero = "2698",
                Cep= "69864598",
                Cidade = "Rio de janeiro",
                Complemento = "Apt 101",
                Estado = "RJ",
                IdEmpresaColeta = 2
            },
            new Endereco()
            {
                Id = 3,
                Bairro = "Vargem Grande",
                Rua = "Rua Tupinambás",
                Status = true,
                Numero = "280",
                Cep= "29684598",
                Cidade = "São Paulo",
                Complemento = "Casa",
                Estado = "SP",
                IdEmpresaColeta = 3
            },
            new Endereco()
            {
                Id = 4,
                Bairro = "Salaco",
                Rua = "Estrada das Rosas",
                Status = true,
                Numero = "980",
                Cep= "69875364",
                Cidade = "Teresópolis",
                Complemento = "Apt 101",
                Estado = "RJ",
                IdEmpresaColeta = 4
            },
            new Endereco()
            {
                Id = 5,
                Bairro = "Sebastiana",
                Rua = "Estrada Grande Rota",
                Status = true,
                Numero = "01",
                Cep= "69874563",
                Cidade = "São Tomé",
                Complemento = "Casa 01",
                Estado = "MG",
                IdEmpresaColeta = 5
            },
            new Endereco()
            {
                Id = 6,
                Bairro = "Rosário",
                Rua = "Rua Santo Antônio",
                Status = true,
                Numero = "01",
                Cep= "69874563",
                Cidade = "São Tomé",
                Complemento = "Casa 01",
                Estado = "MG",
                IdEmpresaColeta = 5
            },
            new Endereco()
            {
                Id = 7,
                Bairro = "Rosário",
                Rua = "Rua Primeiro de Maio",
                Status = true,
                Numero = "01",
                Cep= "69874563",
                Cidade = "São Tomé",
                Complemento = "Casa 01",
                Estado = "MG",
                IdEmpresaColeta = 5
            },
            new Endereco()
            {
                Id = 6,
                Bairro = "Rosário",
                Rua = "Rua Paraíba",
                Status = true,
                Numero = "01",
                Cep= "69874563",
                Cidade = "São Tomé",
                Complemento = "Casa 01",
                Estado = "MG",
                IdEmpresaColeta = 5
            },
            new Endereco()
            {
                Id = 6,
                Bairro = "Rosário",
                Rua = "Rua Santa Rita",
                Status = true,
                Numero = "01",
                Cep= "69874563",
                Cidade = "São Tomé",
                Complemento = "Casa 01",
                Estado = "MG",
                IdEmpresaColeta = 5
            },
            new Endereco()
            {
                Id = 6,
                Bairro = "Rosário",
                Rua = "Rua Mato Grosso",
                Status = true,
                Numero = "01",
                Cep= "69874563",
                Cidade = "São Tomé",
                Complemento = "Casa 01",
                Estado = "MG",
                IdEmpresaColeta = 5
            },

        };

    }
}