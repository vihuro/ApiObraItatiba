﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ObraItatiba.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Apelido = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_claimsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadasto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_claimsType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_claimsType_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeFornecedor = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_fornecedores_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "tab_ClaimsForUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaimId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ClaimsForUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsForUser_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsForUser_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsForUser_tab_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsForUser_tab_claimsType_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "tab_claimsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_notasFicais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroNota = table.Column<int>(type: "integer", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: false),
                    ValorTotalNota = table.Column<decimal>(type: "numeric", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    DescricaoProdutoServico = table.Column<string>(type: "text", nullable: false),
                    AvulsoFinalidade = table.Column<string>(type: "text", nullable: true),
                    Autorizador = table.Column<string>(type: "text", nullable: false),
                    ProdutoServico = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_notasFicais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_notasFicais_tab_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_notasFicais_tab_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_notasFicais_tab_time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "tab_time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_ClaimsForUserUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaimsId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ClaimsForUserUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsForUserUsuario_tab_ClaimsForUser_ClaimsId",
                        column: x => x.ClaimsId,
                        principalTable: "tab_ClaimsForUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_ClaimsForUserUsuario_tab_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tab_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Documento = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    NotaId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "IX_tab_ClaimsForUser_ClaimId",
                table: "tab_ClaimsForUser",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsForUser_UsuarioAlteracaoId",
                table: "tab_ClaimsForUser",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsForUser_UsuarioCadastroId",
                table: "tab_ClaimsForUser",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsForUser_UsuarioId",
                table: "tab_ClaimsForUser",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsForUserUsuario_ClaimsId",
                table: "tab_ClaimsForUserUsuario",
                column: "ClaimsId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_ClaimsForUserUsuario_UsuarioId",
                table: "tab_ClaimsForUserUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_claimsType_UsuarioCadastroId",
                table: "tab_claimsType",
                column: "UsuarioCadastroId");

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

            migrationBuilder.CreateIndex(
                name: "IX_tab_fornecedores_UsuarioCadastroId",
                table: "tab_fornecedores",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_notasFicais_TimeId",
                table: "tab_notasFicais",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_notasFicais_UsuarioAlteracaoId",
                table: "tab_notasFicais",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_notasFicais_UsuarioCadastroId",
                table: "tab_notasFicais",
                column: "UsuarioCadastroId");

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
                name: "tab_ClaimsForUserUsuario");

            migrationBuilder.DropTable(
                name: "tab_Documentos");

            migrationBuilder.DropTable(
                name: "tab_fornecedores");

            migrationBuilder.DropTable(
                name: "tab_ClaimsForUser");

            migrationBuilder.DropTable(
                name: "tab_notasFicais");

            migrationBuilder.DropTable(
                name: "tab_claimsType");

            migrationBuilder.DropTable(
                name: "tab_time");

            migrationBuilder.DropTable(
                name: "tab_Usuario");
        }
    }
}
