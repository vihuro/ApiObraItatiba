using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHoraCadstro",
                table: "tab_ClaimsForUser",
                newName: "DataHoraCadastro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHoraCadastro",
                table: "tab_ClaimsForUser",
                newName: "DataHoraCadstro");
        }
    }
}
