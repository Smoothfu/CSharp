 create table [dbo].[Customers]
 ([CustId] int identity(1,1) not null,
 [FirstName] nvarchar(50) null,
 [LastName] nvarchar(50) null,
 primary key clustered ([CustId] ASC)
 );