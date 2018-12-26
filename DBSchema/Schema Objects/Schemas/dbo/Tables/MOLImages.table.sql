CREATE TABLE [dbo].[MOLImages]
(
	RowID int identity, 
	ImageID varchar(50),
	CreatedBy varchar(50),
	CreatedOn datetime default getdate(),
	IPadd varchar(50),
	MacID varchar(50),
	FormID int not null,
	TransactionID varchar(50) not NULL,
	ImageCategory varchar(50) not null,
	ImageFileName varchar (255) not null,
	ImageType varchar(20) not null,
	ImageContent Image,
	ImageDescription varchar(255),
	FormSection varchar(255),
	FormFLD varchar(255)
)
