﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE "tab_Usuario" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Nome" text NOT NULL,
        "Apelido" text NOT NULL,
        "Senha" text NOT NULL,
        CONSTRAINT "PK_tab_Usuario" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE "tab_claimsType" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Nome" text NOT NULL,
        "Valor" text NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadasto" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_claimsType" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_claimsType_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE tab_fornecedores (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "NomeFornecedor" text NOT NULL,
        "Cnpj" text NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_fornecedores" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_fornecedores_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE tab_time (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Time" text NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" integer NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_time" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_time_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_time_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE "tab_ClaimsForUser" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "ClaimId" integer NOT NULL,
        "UsuarioId" integer NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" integer NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_ClaimsForUser" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_ClaimsForUser_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_ClaimsForUser_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_ClaimsForUser_tab_Usuario_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_ClaimsForUser_tab_claimsType_ClaimId" FOREIGN KEY ("ClaimId") REFERENCES "tab_claimsType" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE "tab_notasFicais" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "NumeroNota" integer NOT NULL,
        "Fornecedor" text NOT NULL,
        "ValorTotalNota" numeric NOT NULL,
        "Cnpj" text NOT NULL,
        "DescricaoProdutoServico" text NOT NULL,
        "AvulsoFinalidade" text NULL,
        "Autorizador" text NOT NULL,
        "ProdutoServico" text NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" integer NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        "TimeId" integer NOT NULL,
        CONSTRAINT "PK_tab_notasFicais" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_notasFicais_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_notasFicais_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_notasFicais_tab_time_TimeId" FOREIGN KEY ("TimeId") REFERENCES tab_time ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE "tab_ClaimsForUserUsuario" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "ClaimsId" integer NOT NULL,
        "UsuarioId" integer NOT NULL,
        CONSTRAINT "PK_tab_ClaimsForUserUsuario" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_ClaimsForUserUsuario_tab_ClaimsForUser_ClaimsId" FOREIGN KEY ("ClaimsId") REFERENCES "tab_ClaimsForUser" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_ClaimsForUserUsuario_tab_Usuario_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE TABLE "tab_Documentos" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Documento" text NOT NULL,
        "Status" text NOT NULL,
        "NotaId" integer NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" integer NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_Documentos" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_Documentos_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_Documentos_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_Documentos_tab_notasFicais_NotaId" FOREIGN KEY ("NotaId") REFERENCES "tab_notasFicais" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_ClaimsForUser_ClaimId" ON "tab_ClaimsForUser" ("ClaimId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_ClaimsForUser_UsuarioAlteracaoId" ON "tab_ClaimsForUser" ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_ClaimsForUser_UsuarioCadastroId" ON "tab_ClaimsForUser" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_ClaimsForUser_UsuarioId" ON "tab_ClaimsForUser" ("UsuarioId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_ClaimsForUserUsuario_ClaimsId" ON "tab_ClaimsForUserUsuario" ("ClaimsId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_ClaimsForUserUsuario_UsuarioId" ON "tab_ClaimsForUserUsuario" ("UsuarioId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_claimsType_UsuarioCadastroId" ON "tab_claimsType" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_Documentos_NotaId" ON "tab_Documentos" ("NotaId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_Documentos_UsuarioAlteracaoId" ON "tab_Documentos" ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_Documentos_UsuarioCadastroId" ON "tab_Documentos" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_fornecedores_UsuarioCadastroId" ON tab_fornecedores ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_notasFicais_TimeId" ON "tab_notasFicais" ("TimeId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_notasFicais_UsuarioAlteracaoId" ON "tab_notasFicais" ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_notasFicais_UsuarioCadastroId" ON "tab_notasFicais" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_time_UsuarioAlteracaoId" ON tab_time ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    CREATE INDEX "IX_tab_time_UsuarioCadastroId" ON tab_time ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404182837_AtualizacaoTabela') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230404182837_AtualizacaoTabela', '7.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230404184732_NovaAtualizacao') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230404184732_NovaAtualizacao', '7.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230410173616_CriadoColunaTipoExportacao_tabela_NotasFiscais') THEN
    ALTER TABLE "tab_notasFicais" ADD "TipoExportacao" text NOT NULL DEFAULT '';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230410173616_CriadoColunaTipoExportacao_tabela_NotasFiscais') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230410173616_CriadoColunaTipoExportacao_tabela_NotasFiscais', '7.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230410174248_PossivelNuloDescricaoProdutoServico_tabelaNotas') THEN
    ALTER TABLE "tab_notasFicais" ALTER COLUMN "DescricaoProdutoServico" DROP NOT NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230410174248_PossivelNuloDescricaoProdutoServico_tabelaNotas') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230410174248_PossivelNuloDescricaoProdutoServico_tabelaNotas', '7.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    DROP TABLE "tab_Documentos";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    ALTER TABLE "tab_notasFicais" DROP COLUMN "ProdutoServico";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    CREATE TABLE "tab_Parcelas" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "NumeroParcela" text NOT NULL,
        "Status" text NOT NULL,
        "Vencimento" timestamp with time zone NOT NULL,
        "NotaId" integer NOT NULL,
        "UsuarioCadastroId" integer NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" integer NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_Parcelas" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_Parcelas_tab_Usuario_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_Parcelas_tab_Usuario_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES "tab_Usuario" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_Parcelas_tab_notasFicais_NotaId" FOREIGN KEY ("NotaId") REFERENCES "tab_notasFicais" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    CREATE TABLE "tab_ProdutosServico" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "DescricaoProdutoServico" text NOT NULL,
        "Complemento" text NOT NULL,
        "NotaId" integer NOT NULL,
        CONSTRAINT "PK_tab_ProdutosServico" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_ProdutosServico_tab_notasFicais_NotaId" FOREIGN KEY ("NotaId") REFERENCES "tab_notasFicais" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    CREATE INDEX "IX_tab_Parcelas_NotaId" ON "tab_Parcelas" ("NotaId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    CREATE INDEX "IX_tab_Parcelas_UsuarioAlteracaoId" ON "tab_Parcelas" ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    CREATE INDEX "IX_tab_Parcelas_UsuarioCadastroId" ON "tab_Parcelas" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    CREATE INDEX "IX_tab_ProdutosServico_NotaId" ON "tab_ProdutosServico" ("NotaId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230412140352_Criando_tabela_ProdutoServico') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230412140352_Criando_tabela_ProdutoServico', '7.0.4');
    END IF;
END $EF$;
COMMIT;

