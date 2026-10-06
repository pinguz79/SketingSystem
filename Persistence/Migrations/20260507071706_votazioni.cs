using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class votazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GaraId",
                table: "Giudici",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Votazioni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GaraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartecipanteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GiudiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tecnica = table.Column<double>(type: "REAL", nullable: false),
                    Interpretazione = table.Column<double>(type: "REAL", nullable: false),
                    Show = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votazioni_Gare_GaraId",
                        column: x => x.GaraId,
                        principalTable: "Gare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votazioni_Giudici_GiudiceId",
                        column: x => x.GiudiceId,
                        principalTable: "Giudici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votazioni_Partecipanti_PartecipanteId",
                        column: x => x.PartecipanteId,
                        principalTable: "Partecipanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giudici_GaraId",
                table: "Giudici",
                column: "GaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Votazioni_GaraId",
                table: "Votazioni",
                column: "GaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Votazioni_GiudiceId",
                table: "Votazioni",
                column: "GiudiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Votazioni_PartecipanteId",
                table: "Votazioni",
                column: "PartecipanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Giudici_Gare_GaraId",
                table: "Giudici",
                column: "GaraId",
                principalTable: "Gare",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Giudici_Gare_GaraId",
                table: "Giudici");

            migrationBuilder.DropTable(
                name: "Votazioni");

            migrationBuilder.DropIndex(
                name: "IX_Giudici_GaraId",
                table: "Giudici");

            migrationBuilder.DropColumn(
                name: "GaraId",
                table: "Giudici");
        }
    }
}
