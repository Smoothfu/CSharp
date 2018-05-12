 create table [dbo].[Orders]
 (
 [OrderId] int not null primary key identity,
 [CustId] int not null,
 [CarId] int not null
 );

 use AutoLol

 select * from sysobjects where xtype='u'

 select column_name from INFORMATION_SCHEMA.COLUMNS where table_name='orders' order by COLUMN_NAME

 insert into dbo.Orders
 (CustId,CarId)
 values
 (1,1),
 (1,2),
 (2,1),
 (2,2),
 (3,1),
 (3,2),
 (4,1),
 (4,2),
 (5,3),
 (5,4),
 (6,2),
 (6,3)


 select * from dbo.Orders