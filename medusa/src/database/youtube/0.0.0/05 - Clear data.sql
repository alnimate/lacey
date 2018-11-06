USE [MedusaYoutube]
GO

TRUNCATE TABLE [dbo].[Videos]; 
GO

DELETE FROM [dbo].[Channels]; 
DBCC CHECKIDENT ([Channels], RESEED, 1);
GO
