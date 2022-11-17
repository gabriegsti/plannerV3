using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AulaId",
                table: "Anotacao",
                newName: "Id_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "Anotacao",
                newName: "AulaId");
        }
    }
}
