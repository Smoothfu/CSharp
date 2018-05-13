CREATE TABLE [dbo].[Orders] (
    [OrderId] INT IDENTITY (1, 1) NOT NULL,
    [CustId]  INT NOT NULL,
    [CarId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC), 
    CONSTRAINT [FK_Orders_ToTable] FOREIGN KEY ([Column]) REFERENCES [ToTable]([ToTableColumn])
);

