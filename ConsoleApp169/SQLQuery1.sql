CREATE TABLE [dbo].[Customers](
[CustId] int identity(1,1) not null,
[FirstName] nvarchar(50) null,
[LastName] nvarchar(50) null,
primary key clustered ([CustId] ASC)
);

insert into Customers 
(FirstName,LastName)
values
('Floomberg','Fu'),
('Michael','Bloomberg'),
('Elon','Musk'),
('Bill','Gates'),
('Jeff','Bezos'),
('Larry','Ellison'),
('Larry','Page'),
('Sergey','Brin'),
('Mark','Zuckerberg'),
('Steve','Jobs')

select * from customers

CREATE TABLE [dbo].[Orders]
(
[OrderId] int not null primary key identity,
[CustId] int not null,
[CarId] int not null
)

select * from sysobjects where xtype='u'

select * from Inventory
select * from orders

insert into orders(CustId,CarId)
values
(1,2),
(2,3),
(3,1),
(4,3),
(5,5),
(6,2),
(7,5),
(8,6),
(9,7),
(10,7)

 alter table orders
 add constraint [FK_Orders_Inventory] foreign key([CarId]) references [Inventory]([CarId])

 alter table orders
 add constraint [FK_Orders_Customers] foreign key([CustId]) references [dbo].[Customers]([CustId])

