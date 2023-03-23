using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoNavegacaoEntidadeClaimsForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_tab_Usuario",
                table: "tab_Usuario");

            migrationBuilder.DropIndex(
                name: "IX_tab_Usuario_tab_Usuario",
                table: "tab_Usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tab_Usuario",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_Usuario_UsuarioId",
                table: "tab_Usuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_UsuarioId",
                table: "tab_Usuario",
                column: "UsuarioId",
                principalTable: "tab_ClaimsForUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_UsuarioId",
                table: "tab_Usuario");

            migrationBuilder.DropIndex(
                name: "IX_tab_Usuario_UsuarioId",
                table: "tab_Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tab_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Usuario_tab_Usuario",
                table: "tab_Usuario",
                column: "tab_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_Usuario_tab_ClaimsForUser_tab_Usuario",
                table: "tab_Usuario",
                column: "tab_Usuario",
                principalTable: "tab_ClaimsForUser",
                principalColumn: "Id");
        }
    }
}
