--<Start-QueryVersion-001>--

/*Start: Shiwa-31Aug2024-Created Tables:SystemRole,MST_Users, MST_Domains,MST_Keywords,MST_Hyperlinks,MAP_Links_Keywords*/
USE [master]
GO 
IF DB_ID('EDUQuest') IS NOT NULL
BEGIN 
	ALTER DATABASE [EDUQuest] SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
	DROP DATABASE [EDUQuest]
END
GO
CREATE DATABASE EDUQuest
GO
USE [EDUQuest]
GO

GO
CREATE TABLE SystemRoles(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	RoleName VARCHAR(40) NOT NULL,
	IsActive BIT NOT NULL
)

GO
CREATE TABLE MST_Users(
	UserId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	UserName VARCHAR(50) NOT NULL,
	Password VARCHAR(250) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	Address VARCHAR(100)  NOT NULL,
	Contact INT NOT NULL,
	RoleId UNIQUEIDENTIFIER CONSTRAINT FK_mst_users_SystemRole_Id FOREIGN KEY (RoleId)  REFERENCES SystemRoles(Id),
	CreatedOn DATETIMEOFFSET NOT NULL,
	LastUpdated DATETIMEOFFSET,
	IsActive BIT NOT NULL
)

GO
CREATE TABLE MST_Domains(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	DomainName VARCHAR(100) CONSTRAINT UQ_Mst_Domains_DomainName UNIQUE(DomainName),
	Link VARCHAR(2050),
	CreatedBy UNIQUEIDENTIFIER 
		CONSTRAINT FK_Mst_domains_Mst_users_UserId FOREIGN KEY (CreatedBy) REFERENCES MST_Users(UserId),
	CreatedOn DATETIMEOFFSET NOT NULL,
	LastUpdated DATETIMEOFFSET,
	IsActive BIT,
)

GO
CREATE TABLE MST_Hyperlinks(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	Link VARCHAR(2050) NOT NULL,
	DomainId UNIQUEIDENTIFIER CONSTRAINT FK_mst_Hyperlinks_Mst_Domains_Id
		FOREIGN KEY (DomainId) REFERENCES MST_Domains(Id),
	CreatedBy UNIQUEIDENTIFIER CONSTRAINT FK_mst_Hyperlinks_MST_Users_UserId
		FOREIGN KEY (CreatedBy) REFERENCES MST_Users(UserId),
	CreatedOn DATETIMEOFFSET NOT NULL,
	LastUpdated DATETIMEOFFSET
)

GO
CREATE TABLE MST_Keywords(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	KeywordName VARCHAR(100) CONSTRAINT UQ_MST_Keywords_KeywordName UNIQUE NOT NULL,
)

GO
CREATE TABLE MAP_Links_Keywords(
	TrackId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	KeywordId UNIQUEIDENTIFIER CONSTRAINT FK_MAP_Links_Keywords_Mst_Keywords_Id
		FOREIGN KEY (KeywordId) REFERENCES MST_Keywords(Id),
	HyperlinkId UNIQUEIDENTIFIER CONSTRAINT FK_MAP_Links_Keywords_MST_Hyperlinks_Id
		FOREIGN KEY (HyperlinkId) REFERENCES MST_Hyperlinks(Id)
)
GO

/*End: Shiwa-31Aug2024-Created Tables:SystemRole,MST_Users, MST_Domains,MST_Keywords,MST_Hyperlinks,MAP_Links_Keywords*/


/*Start: 
	-Shiwa-4Sept2024-Added new column Email to MST_Users,
	-Rename URL to Url in MST_Hyperlinks
	-Rename LINK to Url in MST_Domains*/
GO
ALTER TABLE MST_Users
ADD Email VARCHAR(50) NOT NULL
GO
EXEC sp_rename 'MST_Hyperlinks.Link','Url','COLUMN'
GO
EXEC sp_rename 'MST_Domains.Link','Url','COLUMN'

/*End: 
	-Shiwa-4Sept2024-Added new column Email to MST_Users,
	-Rename URL to Url in MST_Hyperlinks
	-Rename LINK to Url in MST_Domains*/