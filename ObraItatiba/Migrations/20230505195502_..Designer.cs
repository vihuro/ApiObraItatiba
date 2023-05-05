﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ObraItatiba.Context;

#nullable disable

namespace ObraItatiba.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20230505195502_.")]
    partial class _
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ObraItatiba.Models.Claims.ClaimsForUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClaimId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tab_ClaimsForUser");
                });

            modelBuilder.Entity("ObraItatiba.Models.Claims.ClaimsTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraCadasto")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_claimsType");
                });

            modelBuilder.Entity("ObraItatiba.Models.Claims.ListClaimsForUserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClaimsId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tab_ClaimsForUserUsuario");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.ConhecimentoObraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Autorizador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodigoTransportadora")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHotaAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumeroDocumento")
                        .HasColumnType("integer");

                    b.Property<int>("TimeId")
                        .HasColumnType("integer");

                    b.Property<string>("Transpotadora")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_ConhecimentosObra");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.NotasConhecimentoObraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConhecimentoObraId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Fornecedor")
                        .HasColumnType("text");

                    b.Property<int>("NumeroNota")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConhecimentoObraId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_NotasConhecimentoObra");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.ParcelasConhecimentoObraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConhecimentoObraId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumeroParcela")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorParcela")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ConhecimentoObraId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_ParcelaConhecimentoObra");
                });

            modelBuilder.Entity("ObraItatiba.Models.Fornecedores.Fornecedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeFornecedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_fornecedores");
                });

            modelBuilder.Entity("ObraItatiba.Models.Fornecedores.TimesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_time");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.NotasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Autorizador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AvulsoFinalidade")
                        .HasColumnType("text");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescricaoProdutoServico")
                        .HasColumnType("text");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroNota")
                        .HasColumnType("integer");

                    b.Property<int>("TimeId")
                        .HasColumnType("integer");

                    b.Property<string>("TipoExportacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorTotalNota")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_notasFicais");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.ParcelasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NotaId")
                        .HasColumnType("integer");

                    b.Property<string>("NumeroParcela")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioAlteracaoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCadastroId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("NotaId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_Parcelas");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.ProdutoServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DescricaoProdutoServico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NotaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NotaId");

                    b.ToTable("tab_ProdutosServico");
                });

            modelBuilder.Entity("ObraItatiba.Models.Usuarios.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_Usuario");
                });

            modelBuilder.Entity("ObraItatiba.Models.Claims.ClaimsForUser", b =>
                {
                    b.HasOne("ObraItatiba.Models.Claims.ClaimsTypeModel", "Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "Usuario")
                        .WithMany("Claims")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Claim");

                    b.Navigation("Usuario");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Claims.ClaimsTypeModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Claims.ListClaimsForUserModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Claims.ClaimsForUser", "Claims")
                        .WithMany("ListClaimsForUser")
                        .HasForeignKey("ClaimsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Claims");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.ConhecimentoObraModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Fornecedores.TimesModel", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Time");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.NotasConhecimentoObraModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Conhecimentos.Obra.ConhecimentoObraModel", "ConhecimentoObra")
                        .WithMany("Notas")
                        .HasForeignKey("ConhecimentoObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConhecimentoObra");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.ParcelasConhecimentoObraModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Conhecimentos.Obra.ConhecimentoObraModel", "ConhecimentoObra")
                        .WithMany("Parcelas")
                        .HasForeignKey("ConhecimentoObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConhecimentoObra");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Fornecedores.Fornecedores", b =>
                {
                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Fornecedores.TimesModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.NotasModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Fornecedores.TimesModel", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Time");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.ParcelasModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Notas.NotasModel", "Nota")
                        .WithMany("Parcelas")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraItatiba.Models.Usuarios.UsuarioModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nota");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.ProdutoServicoModel", b =>
                {
                    b.HasOne("ObraItatiba.Models.Notas.NotasModel", "Nota")
                        .WithMany("ProdutosServico")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("ObraItatiba.Models.Claims.ClaimsForUser", b =>
                {
                    b.Navigation("ListClaimsForUser");
                });

            modelBuilder.Entity("ObraItatiba.Models.Conhecimentos.Obra.ConhecimentoObraModel", b =>
                {
                    b.Navigation("Notas");

                    b.Navigation("Parcelas");
                });

            modelBuilder.Entity("ObraItatiba.Models.Notas.NotasModel", b =>
                {
                    b.Navigation("Parcelas");

                    b.Navigation("ProdutosServico");
                });

            modelBuilder.Entity("ObraItatiba.Models.Usuarios.UsuarioModel", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}
