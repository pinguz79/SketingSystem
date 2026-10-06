using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Iscrizione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplinaPartecipante",
                columns: table => new
                {
                    DisciplineId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartecipantiId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaPartecipante", x => new { x.DisciplineId, x.PartecipantiId });
                    table.ForeignKey(
                        name: "FK_DisciplinaPartecipante_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaPartecipante_Partecipanti_PartecipantiId",
                        column: x => x.PartecipantiId,
                        principalTable: "Partecipanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaPartecipante_PartecipantiId",
                table: "DisciplinaPartecipante",
                column: "PartecipantiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaPartecipante");
        }
    }
}
