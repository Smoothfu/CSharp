CREATE table [dbo].[Customers]
([CustId] int identity(1,1) not null,
[FirstName] nvarchar (50) null,
[LastName] nvarchar(50) null,
primary key clustered ([CustId] ASC)
)

insert into dbo.Customers
(FirstName,lastName)
values
('Fred','Fu'),
('Floomberg','Fu'),
('Michael','Bloomberg'),
('Bill','Gates'),
('Jeff','Bezos'),
('Elon','Musk'),
('Larry','Ellison'),
('Larry','Page'),
('Sergey','Brin'),
('Mark','Zuckerberg')

select * from Customers