using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class criadoTabelasParaConhecimentosObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_ConhecimentosObra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroDocumento = table.Column<int>(type: "integer", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CodigoTransportadora = table.Column<string>(type: "text", nullable: false),
                    Transpotadora = table.Column<string>(type: "text", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "numeric", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHotaAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ConhecimentosObra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_ConhecimentosObra_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ConhecimentosObra_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_NotasConhecimentoObra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroNota = table.Column<int>(type: "integer", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: true),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    ConhecimentoObraId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_NotasConhecimentoObra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_NotasConhecimentoObra_tab_ConhecimentosObra_Conheciment~",
                        column: x => x.ConhecimentoObraId,
                        principalTable: "tab_ConhecimentosObra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_NotasConhecimentoObra_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_NotasConhecimentoObra_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_ParcelaConhecimentoObra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroParcela = table.Column<string>(type: "text", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "numeric", nullable: false),
                    ConhecimentoObraId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ParcelaConhecimentoObra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_ParcelaConhecimentoObra_tab_ConhecimentosObra_Conhecime~",
                        column: x => x.ConhecimentoObraId,
                        principalTable: "tab_ConhecimentosObra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ParcelaConhecimentoObra_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ParcelaConhecimentoObra_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_ConhecimentosObra_UsuarioAlteracaoId",
                table: "tab_ConhecimentosObra",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ConhecimentosObra_UsuarioCadastroId",
                table: "tab_ConhecimentosObra",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_NotasConhecimentoObra_ConhecimentoObraId",
                table: "tab_NotasConhecimentoObra",
                column: "ConhecimentoObraId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_NotasConhecimentoObra_UsuarioAlteracaoId",
                table: "tab_NotasConhecimentoObra",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_NotasConhecimentoObra_UsuarioCadastroId",
                table: "tab_NotasConhecimentoObra",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ParcelaConhecimentoObra_ConhecimentoObraId",
                table: "tab_ParcelaConhecimentoObra",
                column: "ConhecimentoObraId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ParcelaConhecimentoObra_UsuarioAlteracaoId",
                table: "tab_ParcelaConhecimentoObra",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ParcelaConhecimentoObra_UsuarioCadastroId",
                table: "tab_ParcelaConhecimentoObra",
                column: "UsuarioCadastroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_NotasConhecimentoObra");

            migrationBuilder.DropTable(
                name: "tab_ParcelaConhecimentoObra");

            migrationBuilder.DropTable(
                name: "tab_ConhecimentosObra");
        }
    }
}
