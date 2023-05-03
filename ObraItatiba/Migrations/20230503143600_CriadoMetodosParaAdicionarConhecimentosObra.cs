using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class CriadoMetodosParaAdicionarConhecimentosObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEmissao",
                table: "tab_NotasConhecimentoObra",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEmissao",
                table: "tab_NotasConhecimentoObra");
        }
    }
}
