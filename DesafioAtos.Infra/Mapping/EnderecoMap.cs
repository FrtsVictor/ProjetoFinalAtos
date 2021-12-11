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
            new Endereco() { Id = 1, Bairro = "cccc", Rua = "ccccc",Status =true,Numero = "asd", Cep= "123123", Cidade = "Cidade4", Complemento = "compsasd", Estado = "RJ", IdEmpresaColeta = 1 },
            new Endereco() {Bairro = "123", Rua = "bbbb",Status =true,Numero = "123", Cep= "123123", Cidade = "Cidade1", Complemento = "comp", Estado = "RJ",  IdEmpresaColeta = 1 },
            new Endereco() {Bairro = "321", Rua = "aaaa",Status =true,Numero = "123123", Cep= "1515", Cidade = "Cidade2", Complemento = "asd", Estado = "RJ",  IdEmpresaColeta = 2 }
        };

    }
}