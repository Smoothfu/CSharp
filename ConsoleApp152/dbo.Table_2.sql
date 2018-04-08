CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT  IDENTITY(1,1) not null, 
    [CustId] INT NOT NULL, 
    [CarId] INT NOT NULL, 
	primary key clustered ([OrderId] asc),
    CONSTRAINT [FK_Orders_MT] FOREIGN KEY ([CarId]) REFERENCES [mt]([CarId]), 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustId]) REFERENCES [Customers]([CustId]),	
)
