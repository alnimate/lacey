USE [master]

-- Create database
IF NOT EXISTS (SELECT * FROM [master].[dbo].[sysdatabases] WHERE name = 'MedusaInstagram')
BEGIN    
    CREATE DATABASE [MedusaInstagram]
    COLLATE SQL_Latin1_General_CP1_CI_AS;      
END
GO


-- Create login
IF NOT EXISTS 
    (SELECT [name]
     FROM [sys].[server_principals]
     WHERE [name] = 'Medusa')
BEGIN
	CREATE LOGIN [Medusa] 
		WITH PASSWORD=N'DbPassword!234', 
		DEFAULT_DATABASE=[MedusaInstagram], 
		DEFAULT_LANGUAGE=[us_english], 
		CHECK_EXPIRATION=OFF, 
		CHECK_POLICY=OFF
END 
GO

USE [MedusaInstagram]
GO

-- Create user
IF NOT EXISTS 
    (SELECT [name]
     FROM [sys].[database_principals]
     WHERE [name] = 'Medusa')
BEGIN
	CREATE USER [Medusa] FOR LOGIN [Medusa] WITH DEFAULT_SCHEMA=[dbo]
	
	EXEC sp_addrolemember N'db_owner', N'Medusa'
END
GO

