IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Enderecos] (
    [Id] int NOT NULL IDENTITY,
    [Cep] nvarchar(max) NULL,
    [Logradouro] nvarchar(200) NULL,
    [Numero] nvarchar(10) NULL,
    [Complemento] nvarchar(10) NULL,
    [Bairro] nvarchar(50) NULL,
    [Cidade] nvarchar(50) NULL,
    [Uf] nvarchar(2) NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Cpf] nvarchar(14) NULL,
    [Nome] nvarchar(200) NOT NULL,
    [Rg] nvarchar(9) NULL,
    [DataExpedicao] datetime2 NOT NULL,
    [OrgaoExpedicao] nvarchar(max) NULL,
    [EnderecoId] int NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Genero] nvarchar(1) NOT NULL,
    [EstadoCivil] nvarchar(max) NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clientes_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Enderecos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Clientes_EnderecoId] ON [Clientes] ([EnderecoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220624034758_InitialCreate', N'6.0.6');
GO

COMMIT;
GO