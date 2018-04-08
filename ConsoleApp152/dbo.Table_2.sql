CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustId] INT NOT NULL, 
    [CarId] INT NOT NULL, 
    CONSTRAINT [FK_Orders_MT] FOREIGN KEY ([CarId]) REFERENCES [mt]([CarId]), 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustId]) REFERENCES [Customers]([CustId]),
	
)
