CREATE TABLE [dbo].[MOLMenus]
(
	MenuID int NOT NULL, 
	MenuTOPLevel nvarchar(255),
	MenuTOPLevel_LL nvarchar(255),
	MenuSecondLevel  nvarchar(255),
	MenuSecondLevel_LL nvarchar(255),
	MenuName nvarchar(255) not NULL,
	MenuName_LL nvarchar(255) not NULL,
	MenuType char not NULL,
	MenuLink varchar(255),
	MenuFormGroup varchar(255),
	MenuFormFile varchar(255),
	TableList varchar(255)
)
