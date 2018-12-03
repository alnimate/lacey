USE [master]

-- Delete database
IF EXISTS (SELECT * FROM [master].[dbo].[sysdatabases] WHERE name = 'MedusaYoutube')
BEGIN    
	ALTER DATABASE [MedusaYoutube] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [MedusaYoutube];    
END


-- Delete login
IF EXISTS 
    (SELECT [name]
     FROM [sys].[server_principals]
     WHERE [name] = 'Medusa')
BEGIN
	DROP LOGIN [Medusae]
END 
GO