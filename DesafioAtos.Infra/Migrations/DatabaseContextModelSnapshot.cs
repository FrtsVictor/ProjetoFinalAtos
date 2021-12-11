﻿// <auto-generated />
using System;
using DesafioAtos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioAtos.Infra.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_criacao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("nome");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Categoria 1"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Categoria 2"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Categoria 3"
                        });
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.EmpresaColeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("char(14)")
                        .HasColumnName("cnpj")
                        .IsFixedLength();

                    b.Property<DateTime?>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_criacao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("nome");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("telefone")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Telefone" }, "UQ__Empresa___2A16D97FC2534CA0")
                        .IsUnique();

                    b.HasIndex(new[] { "Cnpj" }, "UQ__Empresa___35BD3E48E3203960")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Empresa___AB6E616494A6D2F6")
                        .IsUnique();

                    b.ToTable("Empresa_Coleta", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cnpj = "1234567891235",
                            Email = "email.empresa1@gmail",
                            Nome = "Empresa 1",
                            Status = true,
                            Telefone = "9011s9q0990"
                        },
                        new
                        {
                            Id = 2,
                            Cnpj = "321654987789",
                            Email = "email.empresa2@gmail",
                            Nome = "Emp3resa 2",
                            Status = true,
                            Telefone = "91d9qw0"
                        });
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("complemento");

                    b.Property<DateTime?>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_criacao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("estado");

                    b.Property<int?>("IdEmpresaColeta")
                        .HasColumnType("int")
                        .HasColumnName("id_empresa_coletora");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("numero");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("rua");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresaColeta");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_criacao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("login");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("senha");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Login" }, "UQ__Usuario__7838F27200D08C37")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCriacao = new DateTime(2021, 12, 10, 21, 27, 52, 47, DateTimeKind.Local).AddTicks(2549),
                            Login = "MyUsername 1",
                            Role = 1,
                            Senha = "asudasu",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            DataCriacao = new DateTime(2021, 12, 10, 21, 27, 52, 47, DateTimeKind.Local).AddTicks(2574),
                            Login = "MyUsername 2",
                            Role = 1,
                            Senha = "asudasu",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            DataCriacao = new DateTime(2021, 12, 10, 21, 27, 52, 47, DateTimeKind.Local).AddTicks(2579),
                            Login = "MyUsername 3",
                            Role = 1,
                            Senha = "asudasu",
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            DataCriacao = new DateTime(2021, 12, 10, 21, 27, 52, 47, DateTimeKind.Local).AddTicks(2582),
                            Login = "MyUsername 4",
                            Role = 1,
                            Senha = "asudasu",
                            Status = true
                        },
                        new
                        {
                            Id = 5,
                            DataCriacao = new DateTime(2021, 12, 10, 21, 27, 52, 47, DateTimeKind.Local).AddTicks(2585),
                            Login = "MyUsername 5",
                            Role = 1,
                            Senha = "asudasu",
                            Status = true
                        });
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.UsuarioEmpresaCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    b.Property<int?>("IdEmpresaColetora")
                        .HasColumnType("int")
                        .HasColumnName("id_empresa_coletora");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdEmpresaColetora");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Usuario_Empresa_Categoria", (string)null);
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.Endereco", b =>
                {
                    b.HasOne("DesafioAtos.Domain.Entidades.EmpresaColeta", "IdEmpresaColetaNavigation")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdEmpresaColeta")
                        .HasConstraintName("FK__Endereco__id_emp__5CA1C101");

                    b.Navigation("IdEmpresaColetaNavigation");
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.UsuarioEmpresaCategoria", b =>
                {
                    b.HasOne("DesafioAtos.Domain.Entidades.Categoria", "IdCategoriaNavigation")
                        .WithMany("UsuarioEmpresaCategoria")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Usuario_E__id_ca__6442E2C9");

                    b.HasOne("DesafioAtos.Domain.Entidades.EmpresaColeta", "IdEmpresaColetoraNavigation")
                        .WithMany("UsuarioEmpresaCategoria")
                        .HasForeignKey("IdEmpresaColetora")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Usuario_E__id_em__625A9A57");

                    b.HasOne("DesafioAtos.Domain.Entidades.Usuario", "IdUsuarioNavigation")
                        .WithMany("UsuarioEmpresaCategoria")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Usuario_E__id_us__634EBE90");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdEmpresaColetoraNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.Categoria", b =>
                {
                    b.Navigation("UsuarioEmpresaCategoria");
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.EmpresaColeta", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("UsuarioEmpresaCategoria");
                });

            modelBuilder.Entity("DesafioAtos.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("UsuarioEmpresaCategoria");
                });
#pragma warning restore 612, 618
        }
    }
}
