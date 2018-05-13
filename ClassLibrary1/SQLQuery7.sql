select * from Iventory
Delete from iventory where CarId='7'

alter table Orders
drop CONSTRAINT FK__Orders__CarId__173876EA

CREATE TABLE [dbo].[CreditRisks] (
    [CustId]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CustId] ASC)
);

insert into CreditRisks(FirstName,LastName)
values('Homer','Simpson')

select * from CreditRisks