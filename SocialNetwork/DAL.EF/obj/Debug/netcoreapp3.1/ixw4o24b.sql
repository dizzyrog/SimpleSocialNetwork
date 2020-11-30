IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [User1Id] nvarchar(max) NULL,
    [User2Id] nvarchar(max) NULL,
    [TimeSent] datetime2 NOT NULL,
    [MessageText] nvarchar(max) NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserIdentityId] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [UserName] nvarchar(450) NULL,
    [Email] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [University] nvarchar(max) NULL,
    [AboutMe] nvarchar(max) NULL,
    [Age] int NOT NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Friendships] (
    [UserId] nvarchar(450) NOT NULL,
    [FriendId] int NOT NULL,
    [Id] int NOT NULL,
    CONSTRAINT [PK_Friendships] PRIMARY KEY ([FriendId], [UserId]),
    CONSTRAINT [FK_Friendships_Users_FriendId] FOREIGN KEY ([FriendId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Users_UserId] ON [Users] ([UserId]);

GO

CREATE UNIQUE INDEX [IX_Users_UserName] ON [Users] ([UserName]) WHERE [UserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201122224335_message storage add', N'3.1.10');

GO

