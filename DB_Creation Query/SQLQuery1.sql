CREATE TABLE [dbo].[Category] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (60) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Coins] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Value]    INT            NOT NULL,
    [Quantity] INT            NOT NULL,
    [IsValue]  BIT            NOT NULL,
    [ImageUrl] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[News] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (100) NOT NULL,
    [Quantity]   INT            NOT NULL,
    [Price]      INT            NOT NULL,
    [Content]    TEXT           NOT NULL,
    [Date]       DATETIME       NOT NULL,
    [PosterUrl]  NVARCHAR (255) NULL,
    [CategoryId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

