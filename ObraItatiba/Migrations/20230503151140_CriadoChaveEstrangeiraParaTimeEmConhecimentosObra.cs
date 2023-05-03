using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class CriadoChaveEstrangeiraParaTimeEmConhecimentosObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "tab_ConhecimentosObra",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tab_ConhecimentosObra_TimeId",
                table: "tab_ConhecimentosObra",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_ConhecimentosObra_tab_time_TimeId",
                table: "tab_ConhecimentosObra",
                column: "TimeId",
                principalTable: "tab_time",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_ConhecimentosObra_tab_time_TimeId",
                table: "tab_ConhecimentosObra");

            migrationBuilder.DropIndex(
                name: "IX_tab_ConhecimentosObra_TimeId",
                table: "tab_ConhecimentosObra");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "tab_ConhecimentosObra");
        }
    }
}
