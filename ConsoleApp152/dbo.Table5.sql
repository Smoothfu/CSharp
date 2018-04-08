CREATE TABLE [dbo].[mt] 
(
	[CarId] INT IDENTITY(1,1) not null, 
    [Make] NVARCHAR(50) NULL, 
    [Color] NVARCHAR(50) NULL, 
    [PetName] NVARCHAR(50) NULL,
	PRIMARY KEY CLUSTERED ([CarID] ASC)    
)
