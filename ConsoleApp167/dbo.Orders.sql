CREATE TABLE [dbo].[Orders] (
    [OrderId] INT IDENTITY (1, 1) NOT NULL,
    [CustId]  INT NOT NULL,
    [CarId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC), 
    CONSTRAINT [FK_Orders_Iventory] FOREIGN KEY ([CarId]) REFERENCES [IVentory]([CarId]), 
    CONSTRAINT [FK_Orders_Customer] FOREIGN KEY ([CustId]) REFERENCES [Customers]([CustId])
);

 