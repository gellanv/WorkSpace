
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [Photo]                NVARCHAR (MAX)     NULL,
    [Company]              NVARCHAR (MAX)     NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (450) NOT NULL,
    [Name]          NVARCHAR (450) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [Name] ASC),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[WorkSpaces] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [DateCreate] DATETIME2 (7)  NOT NULL,
    [UserId]     NVARCHAR (450) NULL,
    CONSTRAINT [PK_WorkSpaces] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkSpaces_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[Pages] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [DateCreate]   DATETIME2 (7)  NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [PersonalPage] BIT            NOT NULL,
    [Favourite]    BIT            NOT NULL,
    [Deleted]      BIT            NOT NULL,
    [WorkSpaceId]  INT            NOT NULL,
    CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pages_WorkSpaces_WorkSpaceId] FOREIGN KEY ([WorkSpaceId]) REFERENCES [dbo].[WorkSpaces] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[Blocks] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Title]  NVARCHAR (MAX) NULL,
    [Style]  NVARCHAR (MAX) NULL,
    [X]      INT            NOT NULL,
    [Y]      INT            NOT NULL,
    [Height] INT            NOT NULL,
    [Width]  INT            NOT NULL,
    [PageId] INT            NOT NULL,
    CONSTRAINT [PK_Blocks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Blocks_Pages_PageId] FOREIGN KEY ([PageId]) REFERENCES [dbo].[Pages] ([Id]) ON DELETE CASCADE
);


    CREATE TABLE [dbo].[Templates] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Templates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[BlockTemplate] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (MAX) NULL,
    [Style]      NVARCHAR (MAX) NULL,
    [X]          INT            NOT NULL,
    [Y]          INT            NOT NULL,
    [Height]     INT            NOT NULL,
    [Width]      INT            NOT NULL,
    [TemplateId] INT            NOT NULL,
    CONSTRAINT [PK_BlockTemplate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlockTemplate_Templates_TemplateId] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[Templates] ([Id]) ON DELETE CASCADE
);


    CREATE TABLE [dbo].[Elements] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ContentHtml] NVARCHAR (MAX) NULL,
    [BlockId]     INT            NOT NULL,
    [Position]    INT            NOT NULL,
    CONSTRAINT [PK_Elements] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Elements_Blocks_BlockId] FOREIGN KEY ([BlockId]) REFERENCES [dbo].[Blocks] ([Id]) ON DELETE CASCADE
);


 INSERT INTO "AspNetUsers" ("Id", "Photo", "Company", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount")
      VALUES('d8d984e5-b878-494f-964f-9e5096fdbe4a', NULL, NULL, 'string', 'STRING', 'user@example.com', 'USER@EXAMPLE.COM', 'False', 'AQAAAAEAACcQAAAAEKg8XMCC9L1uejuMcGi1yriRGwXSO2mOnZQGaauDVnh5n5y25qtoUOO4oQ7abCGKzg==', 'CPXCS4L7KWLSEAZTAORGILLA2GJIWFGZ', '9745a59-568f-4e2b-9195-8d7c8b8377d8', NULL, 'FALSE', 'FALSE', NULL, 'TRUE', 0 )

INSERT INTO "WorkSpaces"
VALUES ('WorkSpace1','2022-02-28','d8d984e5-b878-494f-964f-9e5096fdbe4a'),
       ('WorkSpace2','2022-03-10','d8d984e5-b878-494f-964f-9e5096fdbe4a')
--Delete From "WorkSpaces" where Id=4
INSERT INTO "Pages"
VALUES ('Page1','2022-07-17','Description1-WorkSpace1-Page1','FALSE','FALSE','FALSE',1),
		('Page2','2022-07-17','Description2-WorkSpace1-Page2-Favorite(true)','FALSE','TRUE','FALSE',1),
		('Page3','2022-07-17','Description3-WorkSpace1 - Page3-DELETED(true)','FALSE','FALSE','TRUE',1),
		('Page4','2022-07-17','Description4-WorkSpace2-Page4','FALSE','FALSE','FALSE',2),
		('Page5','2022-07-17','Description5-WorkSpace2-Page4-Favorite(true)','FALSE','TRUE','FALSE',2),
		('Page6','2022-07-17','Description6-WorkSpace2 - Page4-DELETED(true)','FALSE','FALSE','TRUE',2)
--DELETE FROM Pages Where Id=1
INSERT INTO "Blocks"
VALUES ('Block1 - Page1','Block STYLE',1,1,100,100,1),
	   ('Block2 - Page1','Block STYLE',2,2,100,100,1),
	   ('Block3 - Page2','Block STYLE',1,1,100,100,2),
	   ('Block4 - Page2','Block STYLE',2,2,200,200,2),
	   ('Block5 - Page3','Block STYLE',1,1,100,100,3),
	   ('Block6 - Page3','Block STYLE',1,1,100,100,3),
	   ('Block7 - Page4','Block STYLE',1,1,100,100,4),
	   ('Block8 - Page4','Block STYLE',1,1,100,100,4),
	   ('Block9 - Page5','Block STYLE',1,1,100,100,5),
	   ('Block10 - Page5','Block STYLE',1,1,100,100,5),
	   ('Block11 - Page6','Block STYLE',1,1,100,100,6),
	   ('Block12 - Page6','Block STYLE',1,1,100,100,6);
INSERT INTO "Elements"
VALUES ('Element1-Block1-Page1',1,1),
	   ('Element2-Block2-Page1',1,2),
	   ('Element3-Block3-Page2',2,1),
	   ('Element4-Block4-Page2',2,2),
	   ('Element5-Block5-Page3',3,1),
	   ('Element6-Block6-Page3',3,2),
	   ('Element7-Block7-Page4',4,1),
	   ('Element8-Block8-Page4',4,2),
	   ('Element9-Block9-Page5',5,1),
	   ('Element10-Block10-Page5',5,2),
	   ('Element11-Block11-Page6',6,1),
	   ('Element12-Block12-Page6',6,2);

INSERT INTO "Templates"
VALUES ('Blank'),('Grid 2x2'),('Column +2'),('2+ Column');

INSERT INTO "BlockTemplate"
VALUES ('Untitled','No Style',1,1,100,100,2),
	   ('Untitled','No Style',1,2,100,100,2),
	   ('Untitled','No Style',2,1,100,100,2),
	   ('Untitled','No Style',2,2,100,100,2),
		   ('Untitled','No Style',1,1,200,100,3),
		   ('Untitled','No Style',1,2,100,100,3),
		   ('Untitled','No Style',2,2,100,100,3),
			   ('Untitled','No Style',1,1,100,100,4),
			   ('Untitled','No Style',1,2,100,100,4),
			   ('Untitled','No Style',2,2,200,100,4);