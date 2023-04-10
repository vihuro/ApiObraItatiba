using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class CriadoColunaTipoExportacao_tabela_NotasFiscais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoExportacao",
                table: "tab_notasFicais",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoExportacao",
                table: "tab_notasFicais");
        }
    }
}
