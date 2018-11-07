USE [MedusaYoutube]
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
		[ChannelId] NVARCHAR(30) NOT NULL,
		[Title] NVARCHAR(30) NOT NULL,
		[Description] NVARCHAR(MAX) NULL,
		[CreatedAt] DATETIME NOT NULL
CONSTRAINT [PK_Channels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)	

-- Unique constraint for ChannelId
ALTER TABLE [dbo].[Channels]
	ADD CONSTRAINT UQ_Channels_ChannelId
	UNIQUE([ChannelId])	

-- Default value for CreatedAt column
ALTER TABLE [dbo].[Channels]
	ADD CONSTRAINT DF_Channels_CreatedAt
	DEFAULT GETUTCDATE() FOR [CreatedAt] 

END
GO

-- Videos
IF OBJECT_ID (N'Videos', N'U') IS NULL 
BEGIN
	CREATE TABLE [dbo].[Videos](
		[Id] INT NOT NULL,	
		[VideoId] NVARCHAR(30) NOT NULL,
		[Title] NVARCHAR(30) NOT NULL,
		[Description] NVARCHAR(MAX) NULL,
		[PublishedAt] DATETIME NOT NULL,
		[ChannelId] INT NOT NULL,
		[CreatedAt] DATETIME NOT NULL
CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)	

ALTER TABLE [dbo].[Videos] WITH CHECK ADD CONSTRAINT [FK_Videos_Channels_ChannelId] FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channels] ([Id])

-- Unique constraint for ChannelId
ALTER TABLE [dbo].[Videos]
	ADD CONSTRAINT UQ_Videos_VideoId
	UNIQUE([VideoId])	

-- Default value for CreatedAt column
ALTER TABLE [dbo].[Videos]
	ADD CONSTRAINT DF_Videos_CreatedAt
	DEFAULT GETUTCDATE() FOR [CreatedAt] 

END
GO

