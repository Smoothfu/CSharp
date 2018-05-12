CREATE TABLE [dbo].[Inventory]
(
	[CarId] INT IDENTITY(1,1) NOT NULL,
	[Make] NVARCHAR(50) null,
	[Color] NVARCHAR(50) null,
	[PetName] NVARCHAR(50) null,
	[Comment] NVARCHAR(3000) null,
	primary key clustered ([CarId] ASC)
);
