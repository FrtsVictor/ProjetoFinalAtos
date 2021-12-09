using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAtos.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresasColetoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cnpj = table.Column<string>(type: "CHAR(12)", fixedLength: true, nullable: false),
                    Phone = table.Column<string>(type: "CHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasColetoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorias = table.Column<int>(type: "int", nullable: false),
                    EmpresaColetoraId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_EmpresasColetoras_EmpresaColetoraId",
                        column: x => x.EmpresaColetoraId,
                        principalTable: "EmpresasColetoras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    EmpresaColetoraId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coletas_EmpresasColetoras_EmpresaColetoraId",
                        column: x => x.EmpresaColetoraId,
                        principalTable: "EmpresasColetoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "VARCHAR(12)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Rua = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    EmpresaColetoraId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_EmpresasColetoras_EmpresaColetoraId",
                        column: x => x.EmpresaColetoraId,
                        principalTable: "EmpresasColetoras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensDeColetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    ColetaId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensDeColetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensDeColetas_Coletas_ColetaId",
                        column: x => x.ColetaId,
                        principalTable: "Coletas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name", "Status" },
                values: new object[] { 1, new DateTime(2021, 12, 8, 22, 47, 8, 391, DateTimeKind.Local).AddTicks(1544), "User", true });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name", "Status" },
                values: new object[] { 2, new DateTime(2021, 12, 8, 22, 47, 8, 391, DateTimeKind.Local).AddTicks(1636), "Admin", true });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EmpresaColetoraId",
                table: "Categorias",
                column: "EmpresaColetoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Coletas_EmpresaColetoraId",
                table: "Coletas",
                column: "EmpresaColetoraId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasColetoras_Cnpj",
                table: "EmpresasColetoras",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EmpresaColetoraId",
                table: "Enderecos",
                column: "EmpresaColetoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensDeColetas_ColetaId",
                table: "ItensDeColetas",
                column: "ColetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "ItensDeColetas");

            migrationBuilder.DropTable(
                name: "Coletas");

            migrationBuilder.DropTable(
                name: "EmpresasColetoras");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
