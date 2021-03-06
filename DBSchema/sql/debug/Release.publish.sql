﻿/*
Deployment script for MOLLJD

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MOLLJD"
:setvar DefaultFilePrefix "MOLLJD"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
/*
The column [dbo].[MOLMenus].[TT] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[MOLMenus])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[aspnet_Users].[missing_index_21255_21254]...';


GO
DROP INDEX [missing_index_21255_21254]
    ON [dbo].[aspnet_Users];


GO
PRINT N'Dropping [dbo].[aspnet_Users].[missing_index_21257_21256]...';


GO
DROP INDEX [missing_index_21257_21256]
    ON [dbo].[aspnet_Users];


GO
PRINT N'Dropping [dbo].[aspnet_Users].[missing_index_21260_21259]...';


GO
DROP INDEX [missing_index_21260_21259]
    ON [dbo].[aspnet_Users];


GO
PRINT N'Dropping [dbo].[aspnet_Users].[missing_index_6481_6480]...';


GO
DROP INDEX [missing_index_6481_6480]
    ON [dbo].[aspnet_Users];


GO
PRINT N'Dropping unnamed constraint on [dbo].[MOLImages]...';


GO
ALTER TABLE [dbo].[MOLImages] DROP CONSTRAINT [DF__MOLImages__Creat__592635D8];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_Membership]...';


GO
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__Appli__7E77B618];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_Membership]...';


GO
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__7F6BDA51];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_Paths]...';


GO
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK__aspnet_Pa__Appli__5DEAEAF5];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_PersonalizationAllUsers]...';


GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP CONSTRAINT [FK__aspnet_Pe__PathI__5EDF0F2E];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_PersonalizationPerUser]...';


GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__PathI__5FD33367];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_PersonalizationPerUser]...';


GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__UserI__60C757A0];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_Profile]...';


GO
ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__61BB7BD9];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_Roles]...';


GO
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK__aspnet_Ro__Appli__62AFA012];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_Users]...';


GO
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK__aspnet_Us__Appli__63A3C44B];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_UsersInRoles]...';


GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__6497E884];


GO
PRINT N'Dropping unnamed constraint on [dbo].[aspnet_UsersInRoles]...';


GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__658C0CBD];


GO
PRINT N'Altering [aspnet_Membership_BasicAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Membership_BasicAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Membership_FullAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Membership_FullAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Membership_ReportingAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Membership_ReportingAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Personalization_BasicAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Personalization_BasicAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Personalization_FullAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Personalization_FullAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Personalization_ReportingAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Personalization_ReportingAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Profile_BasicAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Profile_BasicAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Profile_FullAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Profile_FullAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Profile_ReportingAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Profile_ReportingAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Roles_BasicAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Roles_BasicAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Roles_FullAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Roles_FullAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_Roles_ReportingAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_Roles_ReportingAccess]
    TO [dbo];


GO
PRINT N'Altering [aspnet_WebEvent_FullAccess]...';


GO
ALTER AUTHORIZATION
    ON ROLE::[aspnet_WebEvent_FullAccess]
    TO [dbo];


GO
PRINT N'Starting rebuilding table [dbo].[MOLImages]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_MOLImages] (
    [RowID]            INT           IDENTITY (1, 1) NOT NULL,
    [ImageID]          VARCHAR (50)  NULL,
    [CreatedBy]        VARCHAR (50)  NULL,
    [CreatedOn]        DATETIME      DEFAULT getdate() NULL,
    [IPadd]            VARCHAR (50)  NULL,
    [MacID]            VARCHAR (50)  NULL,
    [FormID]           INT           NOT NULL,
    [TransactionID]    VARCHAR (50)  NOT NULL,
    [ImageCategory]    VARCHAR (50)  NOT NULL,
    [ImageFileName]    VARCHAR (255) NOT NULL,
    [ImageType]        VARCHAR (20)  NOT NULL,
    [ImageContent]     IMAGE         NULL,
    [ImageDescription] VARCHAR (255) NULL,
    [FormSection]      VARCHAR (255) NULL,
    [FormFLD]          VARCHAR (255) NULL
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[MOLImages])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_MOLImages] ON;
        INSERT INTO [dbo].[tmp_ms_xx_MOLImages] ([RowID], [ImageID], [CreatedBy], [CreatedOn], [IPadd], [MacID], [FormID], [TransactionID], [ImageCategory], [ImageFileName], [ImageType], [ImageContent], [ImageDescription], [FormFLD], [FormSection])
        SELECT [RowID],
               [ImageID],
               [CreatedBy],
               [CreatedOn],
               [IPadd],
               [MacID],
               [FormID],
               [TransactionID],
               [ImageCategory],
               [ImageFileName],
               [ImageType],
               [ImageContent],
               [ImageDescription],
               [FormFLD],
               [FormSection]
        FROM   [dbo].[MOLImages];
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_MOLImages] OFF;
    END

DROP TABLE [dbo].[MOLImages];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_MOLImages]', N'MOLImages';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[MOLMenus]...';


GO
ALTER TABLE [dbo].[MOLMenus] DROP COLUMN [TT];


GO
PRINT N'Creating [dbo].[aspnet_Applications].[aspnet_Applications_Index]...';


GO
CREATE CLUSTERED INDEX [aspnet_Applications_Index]
    ON [dbo].[aspnet_Applications]([LoweredApplicationName] ASC);


GO
PRINT N'Creating [dbo].[aspnet_Membership].[aspnet_Membership_index]...';


GO
CREATE CLUSTERED INDEX [aspnet_Membership_index]
    ON [dbo].[aspnet_Membership]([ApplicationId] ASC, [LoweredEmail] ASC);


GO
PRINT N'Creating [dbo].[aspnet_Paths].[aspnet_Paths_index]...';


GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_Paths_index]
    ON [dbo].[aspnet_Paths]([ApplicationId] ASC, [LoweredPath] ASC);


GO
PRINT N'Creating [dbo].[aspnet_PersonalizationPerUser].[aspnet_PersonalizationPerUser_index1]...';


GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_PersonalizationPerUser_index1]
    ON [dbo].[aspnet_PersonalizationPerUser]([PathId] ASC, [UserId] ASC);


GO
PRINT N'Creating [dbo].[aspnet_PersonalizationPerUser].[aspnet_PersonalizationPerUser_ncindex2]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [aspnet_PersonalizationPerUser_ncindex2]
    ON [dbo].[aspnet_PersonalizationPerUser]([UserId] ASC, [PathId] ASC)
    ON [PRIMARY];


GO
PRINT N'Creating [dbo].[aspnet_Roles].[aspnet_Roles_index1]...';


GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_Roles_index1]
    ON [dbo].[aspnet_Roles]([ApplicationId] ASC, [LoweredRoleName] ASC);


GO
PRINT N'Creating [dbo].[aspnet_Users].[aspnet_Users_Index]...';


GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_Users_Index]
    ON [dbo].[aspnet_Users]([ApplicationId] ASC, [LoweredUserName] ASC);


GO
PRINT N'Creating [dbo].[aspnet_Users].[aspnet_Users_Index2]...';


GO
CREATE NONCLUSTERED INDEX [aspnet_Users_Index2]
    ON [dbo].[aspnet_Users]([ApplicationId] ASC, [LastActivityDate] ASC)
    ON [PRIMARY];


GO
PRINT N'Creating [dbo].[aspnet_UsersInRoles].[aspnet_UsersInRoles_index]...';


GO
CREATE NONCLUSTERED INDEX [aspnet_UsersInRoles_index]
    ON [dbo].[aspnet_UsersInRoles]([RoleId] ASC)
    ON [PRIMARY];


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
PRINT N'Update complete.';


GO
