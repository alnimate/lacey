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
		[OriginalChannelId] NVARCHAR(30) NOT NULL,
		[Title] NVARCHAR(MAX) NOT NULL,
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
	UNIQUE([ChannelId], [OriginalChannelId])	

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
		[Id] INT IDENTITY(1,1) NOT NULL,		
		[VideoId] NVARCHAR(30) NOT NULL,
		[OriginalVideoId] NVARCHAR(30) NOT NULL,
		[Title] NVARCHAR(MAX) NOT NULL,
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

-- Unique constraint for VideoId
ALTER TABLE [dbo].[Videos]
	ADD CONSTRAINT UQ_Videos_VideoId
	UNIQUE([VideoId], [OriginalVideoId])	

-- Default value for CreatedAt column
ALTER TABLE [dbo].[Videos]
	ADD CONSTRAINT DF_Videos_CreatedAt
	DEFAULT GETUTCDATE() FOR [CreatedAt] 

END
GO

-- Playlists
IF OBJECT_ID (N'Playlists', N'U') IS NULL 
BEGIN
	CREATE TABLE [dbo].[Playlists](
		[Id] INT IDENTITY(1,1) NOT NULL,		
		[PlaylistId] NVARCHAR(30) NOT NULL,
		[OriginalPlaylistId] NVARCHAR(30) NOT NULL,
		[Title] NVARCHAR(MAX) NOT NULL,
		[Description] NVARCHAR(MAX) NULL,
		[PublishedAt] DATETIME NOT NULL,
		[ChannelId] INT NOT NULL,
		[CreatedAt] DATETIME NOT NULL
CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)	

ALTER TABLE [dbo].[Playlists] WITH CHECK ADD CONSTRAINT [FK_Playlists_Channels_ChannelId] FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channels] ([Id])

-- Unique constraint for PlaylistId
ALTER TABLE [dbo].[Playlists]
	ADD CONSTRAINT UQ_Playlists_PlaylistId
	UNIQUE([PlaylistId], [OriginalPlaylistId])	

-- Default value for CreatedAt column
ALTER TABLE [dbo].[Playlists]
	ADD CONSTRAINT DF_Playlists_CreatedAt
	DEFAULT GETUTCDATE() FOR [CreatedAt] 

END
GO

-- Playlists-Videos relations
IF OBJECT_ID (N'PlaylistsVideos', N'U') IS NULL 
BEGIN
	CREATE TABLE [dbo].[PlaylistsVideos](
		[PlaylistId] INT NOT NULL,
		[VideoId] INT NOT NULL,
CONSTRAINT [PK_PlaylistsVideos] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC,
	[VideoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PlaylistsVideos] WITH CHECK ADD CONSTRAINT [FK_PlaylistsVideos_Playlists_PlaylistId] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlists] ([Id])

ALTER TABLE [dbo].[PlaylistsVideos] WITH CHECK ADD CONSTRAINT [FK_PlaylistsVideos_Videos_VideoId] FOREIGN KEY([VideoId])
REFERENCES [dbo].[Videos] ([Id])

END
GO