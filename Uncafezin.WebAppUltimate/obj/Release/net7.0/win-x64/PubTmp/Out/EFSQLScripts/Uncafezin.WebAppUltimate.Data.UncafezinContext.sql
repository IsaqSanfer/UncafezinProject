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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121025030_Initial')
BEGIN
    CREATE TABLE [CategoryTab] (
        [CategoryId] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_CategoryTab] PRIMARY KEY ([CategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121025030_Initial')
BEGIN
    CREATE TABLE [ProductTab] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Price] decimal(8,2) NOT NULL,
        [Description] nvarchar(255) NOT NULL,
        [Stock] int NOT NULL,
        [ImgUrl] nvarchar(max) NULL,
        [CategoryId] int NOT NULL,
        [CategoryName] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductTab] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductTab_CategoryTab_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [CategoryTab] ([CategoryId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121025030_Initial')
BEGIN
    CREATE INDEX [IX_ProductTab_CategoryId] ON [ProductTab] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121025030_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231121025030_Initial', N'7.0.14');
END;
GO

COMMIT;
GO

