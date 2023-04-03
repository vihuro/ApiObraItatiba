using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoColunasTabelaNotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "tab_notasFicais",
                newName: "AvulsoFinalidade");

            migrationBuilder.AddColumn<string>(
                name: "Autorizador",
                table: "tab_notasFicais",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "tab_notasFicais",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tab_notasFicais_TimeId",
                table: "tab_notasFicais",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_notasFicais_tab_time_TimeId",
                table: "tab_notasFicais",
                column: "TimeId",
                principalTable: "tab_time",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_notasFicais_tab_time_TimeId",
                table: "tab_notasFicais");

            migrationBuilder.DropIndex(
                name: "IX_tab_notasFicais_TimeId",
                table: "tab_notasFicais");

            migrationBuilder.DropColumn(
                name: "Autorizador",
                table: "tab_notasFicais");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "tab_notasFicais");

            migrationBuilder.RenameColumn(
                name: "AvulsoFinalidade",
                table: "tab_notasFicais",
                newName: "NumeroDocumento");
        }
    }
}
