CREATE TABLE [dbo].[Customers]
(
	[CustId] INT  IDENTITY(1,1) not null, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL,
	PRIMARY KEY Clustered ([CustID] ASC)
)
