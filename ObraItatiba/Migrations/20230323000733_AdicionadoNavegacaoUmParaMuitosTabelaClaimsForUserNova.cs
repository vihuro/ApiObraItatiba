using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoNavegacaoUmParaMuitosTabelaClaimsForUserNova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_ClaimsForUserId",
                table: "tab_Usuario");

            migrationBuilder.RenameColumn(
                name: "ClaimsForUserId",
                table: "tab_Usuario",
                newName: "tab_Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_tab_Usuario_ClaimsForUserId",
                table: "tab_Usuario",
                newName: "IX_tab_Usuario_tab_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_tab_Usuario",
                table: "tab_Usuario",
                column: "tab_Usuario",
                principalTable: "tab_ClaimsForUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_tab_Usuario",
                table: "tab_Usuario");

            migrationBuilder.RenameColumn(
                name: "tab_Usuario",
                table: "tab_Usuario",
                newName: "ClaimsForUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tab_Usuario_tab_Usuario",
                table: "tab_Usuario",
                newName: "IX_tab_Usuario_ClaimsForUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_ClaimsForUserId",
                table: "tab_Usuario",
                column: "ClaimsForUserId",
                principalTable: "tab_ClaimsForUser",
                principalColumn: "Id");
        }
    }
}
