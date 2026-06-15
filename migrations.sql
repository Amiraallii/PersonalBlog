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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    IF SCHEMA_ID(N'Post') IS NULL EXEC(N'CREATE SCHEMA [Post];');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    IF SCHEMA_ID(N'Account') IS NULL EXEC(N'CREATE SCHEMA [Account];');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE TABLE [Post].[Posts] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(200) NOT NULL,
        [CoverImageAdd] nvarchar(max) NULL,
        [PublishDate] datetime2 NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE TABLE [Account].[Roles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE TABLE [Post].[Commnets] (
        [Id] uniqueidentifier NOT NULL,
        [PostId] uniqueidentifier NOT NULL,
        [AuthorName] nvarchar(100) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [IsApproved] bit NOT NULL DEFAULT CAST(0 AS bit),
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Commnets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Commnets_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post].[Posts] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE TABLE [Post].[PostContentBlocks] (
        [Id] uniqueidentifier NOT NULL,
        [PostId] uniqueidentifier NOT NULL,
        [Order] int NOT NULL,
        [BlockType] tinyint NOT NULL,
        [Content] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_PostContentBlocks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PostContentBlocks_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post].[Posts] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE TABLE [Account].[Users] (
        [Id] uniqueidentifier NOT NULL,
        [Email] nvarchar(100) NOT NULL,
        [UserName] nvarchar(100) NOT NULL,
        [PasswordHash] nvarchar(max) NOT NULL,
        [FullName] nvarchar(max) NULL,
        [RoleId] uniqueidentifier NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Account].[Roles] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[Account].[Roles]'))
        SET IDENTITY_INSERT [Account].[Roles] ON;
    EXEC(N'INSERT INTO [Account].[Roles] ([Id], [CreateDate], [Name])
    VALUES (''00000000-0000-0000-0000-000000000001'', ''2025-07-08T00:00:00.0000000Z'', N''User''),
    (''00000000-0000-0000-0000-000000000002'', ''2025-07-08T00:00:00.0000000Z'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[Account].[Roles]'))
        SET IDENTITY_INSERT [Account].[Roles] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Email', N'FullName', N'PasswordHash', N'RoleId', N'UserName') AND [object_id] = OBJECT_ID(N'[Account].[Users]'))
        SET IDENTITY_INSERT [Account].[Users] ON;
    EXEC(N'INSERT INTO [Account].[Users] ([Id], [CreateDate], [Email], [FullName], [PasswordHash], [RoleId], [UserName])
    VALUES (''10000000-0000-0000-0000-000000000001'', ''2025-07-08T00:00:00.0000000Z'', N''amiraliaghaei69@gmail.com'', N''Amirali'', N''$2a$11$4LXh430wl/OwVD2LZ6M81OsxLK1MHjFS1j5kS.SzvQgRzucn3FL7y'', ''00000000-0000-0000-0000-000000000002'', N''Amirali'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Email', N'FullName', N'PasswordHash', N'RoleId', N'UserName') AND [object_id] = OBJECT_ID(N'[Account].[Users]'))
        SET IDENTITY_INSERT [Account].[Users] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE INDEX [IX_Commnets_PostId] ON [Post].[Commnets] ([PostId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE INDEX [IX_PostContentBlocks_PostId] ON [Post].[PostContentBlocks] ([PostId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Users_Email] ON [Account].[Users] ([Email]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE INDEX [IX_Users_RoleId] ON [Account].[Users] ([RoleId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Users_UserName] ON [Account].[Users] ([UserName]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250725113418_InitialDb'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250725113418_InitialDb', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260224170100_fixNames'
)
BEGIN
    EXEC sp_rename N'[Post].[PostContentBlocks].[BlockType]', N'ContentType', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260224170100_fixNames'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260224170100_fixNames', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260225120256_addpostSummary'
)
BEGIN
    ALTER TABLE [Post].[Posts] ADD [Summary] nvarchar(500) NOT NULL DEFAULT N'';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260225120256_addpostSummary'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260225120256_addpostSummary', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260307164858_AddProjects'
)
BEGIN
    ALTER TABLE [Post].[Posts] ADD [AuthorId] uniqueidentifier NOT NULL DEFAULT '10000000-0000-0000-0000-000000000001';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260307164858_AddProjects'
)
BEGIN
    CREATE TABLE [Projects] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(150) NOT NULL,
        [Summary] nvarchar(1000) NOT NULL,
        [Owner] nvarchar(200) NOT NULL,
        [Link] nvarchar(max) NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260307164858_AddProjects'
)
BEGIN
    CREATE INDEX [IX_Posts_AuthorId] ON [Post].[Posts] ([AuthorId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260307164858_AddProjects'
)
BEGIN
    ALTER TABLE [Post].[Posts] ADD CONSTRAINT [FK_Posts_Users_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Account].[Users] ([Id]) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260307164858_AddProjects'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260307164858_AddProjects', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260311094646_addRefreshToken'
)
BEGIN
    ALTER TABLE [Account].[Users] ADD [RefreshToken] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260311094646_addRefreshToken'
)
BEGIN
    ALTER TABLE [Account].[Users] ADD [RefreshTokenExpireDate] datetime2 NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260311094646_addRefreshToken'
)
BEGIN
    EXEC(N'UPDATE [Account].[Users] SET [RefreshToken] = NULL, [RefreshTokenExpireDate] = NULL
    WHERE [Id] = ''10000000-0000-0000-0000-000000000001'';
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260311094646_addRefreshToken'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260311094646_addRefreshToken', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260313123152_AddPersonalInfo'
)
BEGIN
    IF SCHEMA_ID(N'Info') IS NULL EXEC(N'CREATE SCHEMA [Info];');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260313123152_AddPersonalInfo'
)
BEGIN
    CREATE TABLE [Info].[PersonalInformation] (
        [Id] tinyint NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [LastName] nvarchar(150) NOT NULL,
        [JobTitle] nvarchar(300) NOT NULL,
        [AboutMe] nvarchar(1500) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_PersonalInformation] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260313123152_AddPersonalInfo'
)
BEGIN
    CREATE TABLE [Info].[ContactInfo] (
        [Id] int NOT NULL IDENTITY,
        [PersonalInformationId] tinyint NOT NULL,
        [ContactWayType] tinyint NOT NULL,
        [ContactWay] nvarchar(100) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ContactInfo] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ContactInfo_PersonalInformation_PersonalInformationId] FOREIGN KEY ([PersonalInformationId]) REFERENCES [Info].[PersonalInformation] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260313123152_AddPersonalInfo'
)
BEGIN
    CREATE INDEX [IX_ContactInfo_PersonalInformationId] ON [Info].[ContactInfo] ([PersonalInformationId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260313123152_AddPersonalInfo'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260313123152_AddPersonalInfo', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260414075519_checkmigration'
)
BEGIN
    IF SCHEMA_ID(N'Project') IS NULL EXEC(N'CREATE SCHEMA [Project];');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260414075519_checkmigration'
)
BEGIN
    ALTER SCHEMA [Project] TRANSFER [Projects];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260414075519_checkmigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260414075519_checkmigration', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260421104201_EditDeleteBehaviorForPost'
)
BEGIN
    ALTER TABLE [Post].[PostContentBlocks] DROP CONSTRAINT [FK_PostContentBlocks_Posts_PostId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260421104201_EditDeleteBehaviorForPost'
)
BEGIN
    ALTER TABLE [Post].[PostContentBlocks] ADD CONSTRAINT [FK_PostContentBlocks_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post].[Posts] ([Id]) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260421104201_EditDeleteBehaviorForPost'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260421104201_EditDeleteBehaviorForPost', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260501100844_FixCommentTable'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Post].[Commnets]') AND [c].[name] = N'AuthorName');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Post].[Commnets] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Post].[Commnets] DROP COLUMN [AuthorName];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260501100844_FixCommentTable'
)
BEGIN
    ALTER TABLE [Post].[Commnets] ADD [AuthorId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260501100844_FixCommentTable'
)
BEGIN
    ALTER TABLE [Post].[Commnets] ADD [UserId] uniqueidentifier NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260501100844_FixCommentTable'
)
BEGIN
    CREATE INDEX [IX_Commnets_UserId] ON [Post].[Commnets] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260501100844_FixCommentTable'
)
BEGIN
    ALTER TABLE [Post].[Commnets] ADD CONSTRAINT [FK_Commnets_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Account].[Users] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260501100844_FixCommentTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260501100844_FixCommentTable', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260506083444_AddRelationForCommentAndUser'
)
BEGIN
    ALTER TABLE [Post].[Commnets] DROP CONSTRAINT [FK_Commnets_Users_UserId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260506083444_AddRelationForCommentAndUser'
)
BEGIN
    DROP INDEX [IX_Commnets_UserId] ON [Post].[Commnets];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260506083444_AddRelationForCommentAndUser'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Post].[Commnets]') AND [c].[name] = N'UserId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Post].[Commnets] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Post].[Commnets] DROP COLUMN [UserId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260506083444_AddRelationForCommentAndUser'
)
BEGIN
    CREATE INDEX [IX_Commnets_AuthorId] ON [Post].[Commnets] ([AuthorId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260506083444_AddRelationForCommentAndUser'
)
BEGIN
    ALTER TABLE [Post].[Commnets] ADD CONSTRAINT [FK_Commnets_Users_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Account].[Users] ([Id]) ON DELETE NO ACTION;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260506083444_AddRelationForCommentAndUser'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260506083444_AddRelationForCommentAndUser', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521084628_addParentId'
)
BEGIN
    ALTER TABLE [Post].[Commnets] ADD [ParentId] uniqueidentifier NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521084628_addParentId'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260521084628_addParentId', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Commnets] DROP CONSTRAINT [FK_Commnets_Posts_PostId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Commnets] DROP CONSTRAINT [FK_Commnets_Users_AuthorId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Commnets] DROP CONSTRAINT [PK_Commnets];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    DROP INDEX [IX_Commnets_PostId] ON [Post].[Commnets];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    EXEC sp_rename N'[Post].[Commnets]', N'Comments', 'OBJECT';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    EXEC sp_rename N'[Post].[Comments].[IX_Commnets_AuthorId]', N'IX_Comments_AuthorId', 'INDEX';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Comments] ADD CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    CREATE INDEX [IX_Comments_ParentId] ON [Post].[Comments] ([ParentId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    CREATE INDEX [IX_Comments_PostId_ParentId] ON [Post].[Comments] ([PostId], [ParentId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Comments] ADD CONSTRAINT [FK_Comments_Comments_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Post].[Comments] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Comments] ADD CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post].[Posts] ([Id]) ON DELETE NO ACTION;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    ALTER TABLE [Post].[Comments] ADD CONSTRAINT [FK_Comments_Users_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Account].[Users] ([Id]) ON DELETE NO ACTION;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260521091251_addSelfRefrence'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260521091251_addSelfRefrence', N'9.0.5');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260526124809_addProjectRequestTable'
)
BEGIN
    CREATE TABLE [Project].[ProjectRequests] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(150) NOT NULL,
        [Summary] nvarchar(1000) NOT NULL,
        [Location] nvarchar(150) NOT NULL,
        [PhoneNumber] nvarchar(15) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ProjectRequests] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260526124809_addProjectRequestTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260526124809_addProjectRequestTable', N'9.0.5');
END;

COMMIT;
GO

