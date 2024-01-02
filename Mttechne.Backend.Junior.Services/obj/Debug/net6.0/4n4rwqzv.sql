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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231231162918_Migration_Tabela')
BEGIN
    CREATE TABLE [Produto] (
        [Id] INT NOT NULL IDENTITY,
        [Nome] VARCHAR(100) NOT NULL,
        [Valor] Int NOT NULL,
        CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231231162918_Migration_Tabela')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231231162918_Migration_Tabela', N'6.0.25');
END;
GO

COMMIT;
GO

