using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.CadastroDeClientes.Infrastructure.Database.Entities.Migrations
{
    public partial class GenerateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerRefac");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CustomerRefac",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    DataDeNascimento = table.Column<string>(type: "text", nullable: false),
                    Documento = table.Column<long>(type: "bigint", nullable: false),
                    Endereco = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    DataDoCadastro = table.Column<string>(type: "text", nullable: false),
                    ClienteAtivo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CustomerRefac");
        }
    }
}
