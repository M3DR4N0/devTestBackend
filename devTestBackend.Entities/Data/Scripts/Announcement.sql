USE [master]
GO

CREATE DATABASE [DevTestBackend]
GO

USE [DevTestBackend]
GO

CREATE TABLE [dbo].[Announcement](
	[Id] [int] PRIMARY KEY IDENTITY,
	[Link] [varchar](max) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Content] [varchar](max) NOT NULL,
	[Date] [datetime] NOT NULL
) 
GO



