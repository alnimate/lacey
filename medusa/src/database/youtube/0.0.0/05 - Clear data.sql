USE [MedusaYoutube]
GO

TRUNCATE TABLE [dbo].[PlaylistsVideos]; 
GO

DELETE FROM [dbo].[Playlists]; 
DBCC CHECKIDENT ([Playlists], RESEED, 1);
GO

DELETE FROM [dbo].[Videos]; 
DBCC CHECKIDENT ([Videos], RESEED, 1);
GO

DELETE FROM [dbo].[Channels]; 
DBCC CHECKIDENT ([Channels], RESEED, 1);
GO
