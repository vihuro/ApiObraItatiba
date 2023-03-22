using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class CorrigoNomeChaveEstrangeiraClimsTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioCadatroId",
                table: "tab_claimsType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioCadatroId",
                table: "tab_claimsType",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
