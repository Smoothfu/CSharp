use Accounting
create table Orders
(
OrderID int identity not null primary key,
CustomerNo int not null foreign key References Customers(CustomerNo),
OrderDate date not null,
EmployeeID int not null
);

exec sp_help Orders

exec sp_helpconstraint orders

alter table Orders
add constraint FK_EmployeeCreatesOrder
Foreign key(EmployeeID) references Employees(EmployeeID)

exec sp_helpconstraint orders

insert into Employees
(FirstName,
LastName,
Title,
SSN,
Salary,
PriorSalary,
HireDate,
ManagerEmpID,
Department
)
values
(
'Billy Bob',
'Boson',
'Head Cook & Bottle Washed',
'123-45-6789',
100000,
80000,
'1990-01-01',
1,
'Cooking and Bottling'
);

select * from Employees

alter table Employees
add constraint FK_EmployeeHasManager
foreign key(ManagerEmpID) references Employees(EmployeeID);

create table OrderDetails
(
OrderID int not null,
PartNo varchar(10) not null,
Description varchar(25) not null,
UnitPrice money not null,
Qty int not null,
Constraint PK_OrderDetails primary key (OrderID,PartNo),
constraint PK_OrderContainsDetails foreign key (OrderID)
References Orders(OrderID)
ON UPDATE NO ACTION
ON DELETE CASCADE
);

exec sp_help OrderDetails

--insert into OrderDetails
--values
--(1,'4X4525','THIS IS A PART',25.00,2);

select * from Customers
INSERT INTO Customers
VALUES
('BILLY Bob''s shoes',
'123 Main St.',
' ',
'Vancouver',
'WA',
'98685',
'Billy Bob',
'(360)555-1234',
'931234567',
GETDATE()
);

insert into Orders
(CustomerNo,OrderDate,EmployeeID)
values
(1,GETDATE(),1);

select * from Orders

insert into OrderDetails
values
(1,'4X4525','This is a part',25.00,2)

insert into OrderDetails
values
(1,'0R2400','This is another part',50.00,2);

select * from OrderDetails