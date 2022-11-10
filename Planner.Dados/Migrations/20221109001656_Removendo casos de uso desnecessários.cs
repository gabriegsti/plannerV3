using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class Removendocasosdeusodesnecessários : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotacao_Aula_AulaId",
                table: "Anotacao");

            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Anotacao_AulaId",
                table: "Anotacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    Id_Aula = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data_Hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Id_Materia = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MateriaId_Materia = table.Column<int>(type: "integer", nullable: true),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.Id_Aula);
                    table.ForeignKey(
                        name: "FK_Aula_Materia_MateriaId_Materia",
                        column: x => x.MateriaId_Materia,
                        principalTable: "Materia",
                        principalColumn: "Id_Materia");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id_Avaliacao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventoId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false),
                    Data_Hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Nota = table.Column<double>(type: "double precision", nullable: true),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id_Avaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id_Evento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id_Materia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anotacao_AulaId",
                table: "Anotacao",
                column: "AulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aula_MateriaId_Materia",
                table: "Aula",
                column: "MateriaId_Materia");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_EventoId",
                table: "Avaliacao",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_MateriaId",
                table: "Avaliacao",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacao_Aula_AulaId",
                table: "Anotacao",
                column: "AulaId",
                principalTable: "Aula",
                principalColumn: "Id_Aula");
        }
    }
}
