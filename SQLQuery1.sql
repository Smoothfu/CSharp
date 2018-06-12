use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='sales'

select * from sales.vStoreWithContacts

if OBJECT_ID('spGetSalesStoreByBID','p') is not null
drop proc spGetSalesStoreByBID
go
create proc spGetSalesStoreByBID
@BID int
as 
select BusinessEntityID BEID,Name,ContactType CT,Title,FirstName FN,MiddleName MN,LastName LN,Suffix,PhoneNumber PN,PhoneNumberType PNT,EmailAddress EA,EmailAddress EP  from AdventureWorks2014.Sales.vStoreWithContacts
where BusinessEntityID=@BID

exec spGetSalesStoreByBID 300
