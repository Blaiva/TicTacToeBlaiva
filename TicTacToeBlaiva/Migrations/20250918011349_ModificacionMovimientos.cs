using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeBlaiva.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Partidas_PartidaId",
                table: "Movimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Partidas_PartidaId",
                table: "Movimientos",
                column: "PartidaId",
                principalTable: "Partidas",
                principalColumn: "PartidaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Partidas_PartidaId",
                table: "Movimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Partidas_PartidaId",
                table: "Movimientos",
                column: "PartidaId",
                principalTable: "Partidas",
                principalColumn: "PartidaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
