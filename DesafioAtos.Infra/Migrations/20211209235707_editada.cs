using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAtos.Infra.Migrations
{
    public partial class editada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensDeColetas");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "EmpresasColetoras",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EmpresasColetoras",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Coletas",
                newName: "Observacao");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmpresasColetoras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Coletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemDeColeta",
                table: "Coletas",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Coletas");

            migrationBuilder.DropColumn(
                name: "ItemDeColeta",
                table: "Coletas");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "EmpresasColetoras",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "EmpresasColetoras",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Coletas",
                newName: "Descricao");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "VARCHAR(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "EmpresasColetoras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ItensDeColetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    ColetaId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ItensDeColetas_ColetaId",
                table: "ItensDeColetas",
                column: "ColetaId");
        }
    }
}
