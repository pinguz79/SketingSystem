using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class gara_partecipanti_as_calculated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partecipanti_Gare_GaraId",
                table: "Partecipanti");

            migrationBuilder.DropIndex(
                name: "IX_Partecipanti_GaraId",
                table: "Partecipanti");

            migrationBuilder.DropColumn(
                name: "GaraId",
                table: "Partecipanti");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GaraId",
                table: "Partecipanti",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partecipanti_GaraId",
                table: "Partecipanti",
                column: "GaraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partecipanti_Gare_GaraId",
                table: "Partecipanti",
                column: "GaraId",
                principalTable: "Gare",
                principalColumn: "Id");
        }
    }
}
