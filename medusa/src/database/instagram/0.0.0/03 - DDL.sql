USE [MedusaInstagram]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Channels
IF OBJECT_ID (N'Channels', N'U') IS NULL 
BEGIN
	CREATE TABLE [dbo].[Channels](
		[Id] INT IDENTITY(1,1) NOT NULL,		
		[ChannelId] NVARCHAR(50) NOT NULL,
		[OriginalChannelId] NVARCHAR(50) NOT NULL,
		[Title] NVARCHAR(MAX) NULL,
		[Description] NVARCHAR(MAX) NULL,
		[PublishedAt] DATETIME NULL,
		[CreatedAt] DATETIME NOT NULL
CONSTRAINT [PK_Channels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)	

-- Unique constraint for ChannelId
ALTER TABLE [dbo].[Channels]
	ADD CONSTRAINT UQ_Channels_ChannelId
	UNIQUE([ChannelId], [OriginalChannelId])	

-- Default value for CreatedAt column
ALTER TABLE [dbo].[Channels]
	ADD CONSTRAINT DF_Channels_CreatedAt
	DEFAULT GETUTCDATE() FOR [CreatedAt] 

END
GO

-- Media
IF OBJECT_ID (N'Medias', N'U') IS NULL 
BEGIN
	CREATE TABLE [dbo].[Medias](
		[Id] INT IDENTITY(1,1) NOT NULL,		
		[MediaId] NVARCHAR(50) NOT NULL,
		[OriginalMediaId] NVARCHAR(50) NOT NULL,
		[Title] NVARCHAR(MAX) NULL,
		[Description] NVARCHAR(MAX) NULL,
		[PublishedAt] DATETIME NULL,
		[ChannelId] INT NOT NULL,
		[CreatedAt] DATETIME NOT NULL
CONSTRAINT [PK_Medias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)	

ALTER TABLE [dbo].[Medias] WITH CHECK ADD CONSTRAINT [FK_Medias_Channels_ChannelId] FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channels] ([Id])

-- Unique constraint for MediaId
ALTER TABLE [dbo].[Medias]
	ADD CONSTRAINT UQ_Medias_MediaId
	UNIQUE([MediaId], [OriginalMediaId])	

-- Default value for CreatedAt column
ALTER TABLE [dbo].[Medias]
	ADD CONSTRAINT DF_Medias_CreatedAt
	DEFAULT GETUTCDATE() FOR [CreatedAt] 

END
GO
