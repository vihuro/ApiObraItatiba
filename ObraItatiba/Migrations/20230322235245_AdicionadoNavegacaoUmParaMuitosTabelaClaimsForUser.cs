using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoNavegacaoUmParaMuitosTabelaClaimsForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaimsForUserId",
                table: "tab_Usuario",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_Usuario_ClaimsForUserId",
                table: "tab_Usuario",
                column: "ClaimsForUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_ClaimsForUserId",
                table: "tab_Usuario",
                column: "ClaimsForUserId",
                principalTable: "tab_ClaimsForUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_ClaimsForUserId",
                table: "tab_Usuario");

            migrationBuilder.DropIndex(
                name: "IX_tab_Usuario_ClaimsForUserId",
                table: "tab_Usuario");

            migrationBuilder.DropColumn(
                name: "ClaimsForUserId",
                table: "tab_Usuario");
        }
    }
}
