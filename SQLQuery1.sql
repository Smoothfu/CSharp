use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES order by TABLE_NAME
select * from sales.vStoreWithContacts
 
select column_name from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='vStoreWithContacts' order by COLUMN_NAME

SELECT  * FROM HumanResources.Employee where NationalIDNumber='695256908'

select * from HumanResources.Employee where NationalIDNumber>811994146

select * from HumanResources.employee where (BusinessEntityID>100 or NationalIDNumber>509647174) and OrganizationLevel>2 order by NationalIDNumber asc, BusinessEntityID asc
select * from HumanResources.employee where BusinessEntityID>100 and NationalIDNumber>509647174 order by NationalIDNumber desc

select top 50 percent * from  HumanResources.employee

select * from Person.Person where FirstName like '%k%' and LastName like'%s'
select * from Person.Person p
left join HumanResources.employee e
on p.BusinessEntityID=e.BusinessEntityID
where p.FirstName like 'F%'

select * from Person.Person where firstname like 'F__d'
select * from Person.Person where firstname not like '[FRE]%'

select * from Person.Person where FirstName not between 'Fred' and 'Michael' order by FirstName

select  * from Person.Person p
full join HumanResources.Employee e
on  p.BusinessEntityID=e.BusinessEntityID 

select  FirstName fn,LastName ln from Person.Person

select top(2)* from person.Person
select top(2)* from HumanResources.Employee

select BusinessEntityID,rowguid,ModifiedDate
from HumanResources.Employee e
union
select BusinessEntityID,rowguid,ModifiedDate
from Person.Person p

select e.BusinessEntityID,e.rowguid,e.ModifiedDate,p.FirstName,p.LastName
from HumanResources.Employee e
left join
Person.Person p
on e.BusinessEntityID=p.BusinessEntityID

select * into  HumanResources.Employee_backup
from HumanResources.Employee

drop table HumanResources.Employee_backup

select * from HumanResources.Employee

select  e.BirthDate,e.BusinessEntityID EBID,p.AdditionalContactInfo,p.FirstName,p.LastName,p.BusinessEntityID
into HumanResources.Employeebackup
from HumanResources.Employee as  e
inner join person.person as  p
on e.BusinessEntityID=p.BusinessEntityID

use AutoLol

select * from sys.databases


create database my_db
select * from sys.databases

use my_db

