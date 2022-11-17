using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class incluindoid_usuarioemdocumentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Documentos",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Documentos");
        }
    }
}
