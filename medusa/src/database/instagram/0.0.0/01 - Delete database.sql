USE [master]

-- Delete database
IF EXISTS (SELECT * FROM [master].[dbo].[sysdatabases] WHERE name = 'MedusaInstagram')
BEGIN    
	ALTER DATABASE [MedusaInstagram] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [MedusaInstagram];    
END

/*
-- Delete login
IF EXISTS 
    (SELECT [name]
     FROM [sys].[server_principals]
     WHERE [name] = 'Medusa')
BEGIN
	DROP LOGIN [Medusa]
END 
GO
*/