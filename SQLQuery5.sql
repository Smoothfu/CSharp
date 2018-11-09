use Accounting
--First,look at the rows in both tables
select * from Orders
select * from orderdetails

--Now delete the order record
DELETE Orders
where orderid=1;

CREATE TABLE SHIPPERS
(ShippersID int identity not null primary key,
ShipperName varchar(30) not null,
Address varchar(30) not null,
City varchar(25) not null,
State char(2) not null,
Zip varchar(10) not null,
PhoneNo varchar(14) not null unique
);

select * from SHIPPERS

exec sp_helpconstraint Customers

alter table Employees
add constraint AK_EmployeeSSN
UNIQUE(SSN);

alter table Customers
add constraint CN_CustomerDateInSystem
CHECK
(DATEINSystem<=GETDATE());

insert into Customers
(CustomerName,Address1,Address2,City,State,Zip,Contact,Phone,FedIdNo,DateInSystem)
values
('Customer1','Address1','Add2','MyCity','NY','55555',
'No Contact','553-1212','930984954','12-31-2009')

if OBJECT_ID('Shippers') is not null
drop table SHIPPERS
go
create table Shippers
(ShipperID int IDENTITY NOT NULL PRIMARY KEY,
ShipperName varchar(30) not null,
DateInSystem smalldatetime not null default GETDATE()
);
select * from Shippers

exec sp_helpconstraint Shippers

insert into Shippers
(ShipperName)
values
('United Parcel Service');

alter table Customers
add constraint CN_CustomerDefaultDateInSystem
DEFAULT GETDATE() for DateInSystem;

exec sp_helpconstraint Customers

alter table customers
add constraint CN_CustomersAddress
default 'UNKNOWN' for address1;