using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class Adicionandocontenttypeemdocumentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Documentos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Documentos");
        }
    }
}
