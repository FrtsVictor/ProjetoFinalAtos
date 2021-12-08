using DesafioAtos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.Property(a => a.Descricao)
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
