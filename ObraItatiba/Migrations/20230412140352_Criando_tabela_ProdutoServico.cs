using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class Criando_tabela_ProdutoServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_Documentos");

            migrationBuilder.DropColumn(
                name: "ProdutoServico",
                table: "tab_notasFicais");

            migrationBuilder.CreateTable(
                name: "tab_Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroParcela = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotaId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Parcelas_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Parcelas_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Parcelas_tab_notasFicais_NotaId",
                        column: x => x.NotaId,
                        principalTable: "tab_notasFicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_ProdutosServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescricaoProdutoServico = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: false),
                    NotaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ProdutosServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_ProdutosServico_tab_notasFicais_NotaId",
                        column: x => x.NotaId,
                        principalTable: "tab_notasFicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_Parcelas_NotaId",
                table: "tab_Parcelas",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Parcelas_UsuarioAlteracaoId",
                table: "tab_Parcelas",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Parcelas_UsuarioCadastroId",
                table: "tab_Parcelas",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ProdutosServico_NotaId",
                table: "tab_ProdutosServico",
                column: "NotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_Parcelas");

            migrationBuilder.DropTable(
                name: "tab_ProdutosServico");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoServico",
                table: "tab_notasFicais",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tab_Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotaId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Documento = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Documentos_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Documentos_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_Documentos_tab_notasFicais_NotaId",
                        column: x => x.NotaId,
                        principalTable: "tab_notasFicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_Documentos_NotaId",
                table: "tab_Documentos",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Documentos_UsuarioAlteracaoId",
                table: "tab_Documentos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Documentos_UsuarioCadastroId",
                table: "tab_Documentos",
                column: "UsuarioCadastroId");
        }
    }
}
