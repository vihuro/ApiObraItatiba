using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class CriadoTabelaTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_time", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_time_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_time_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_time_UsuarioAlteracaoId",
                table: "tab_time",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_time_UsuarioCadastroId",
                table: "tab_time",
                column: "UsuarioCadastroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_time");
        }
    }
}
