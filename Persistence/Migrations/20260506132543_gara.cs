using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class gara : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GaraId",
                table: "Partecipanti",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gare_Categorie_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gare_Discipline_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partecipanti_GaraId",
                table: "Partecipanti",
                column: "GaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Gare_CategoriaId",
                table: "Gare",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gare_DisciplinaId",
                table: "Gare",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partecipanti_Gare_GaraId",
                table: "Partecipanti",
                column: "GaraId",
                principalTable: "Gare",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partecipanti_Gare_GaraId",
                table: "Partecipanti");

            migrationBuilder.DropTable(
                name: "Gare");

            migrationBuilder.DropIndex(
                name: "IX_Partecipanti_GaraId",
                table: "Partecipanti");

            migrationBuilder.DropColumn(
                name: "GaraId",
                table: "Partecipanti");
        }
    }
}
