use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES
select * from AdventureWorks2014.sales.vStoreWithContacts

if OBJECT_ID('spGetStoreByBEID','p') is not null
drop proc spGetStoreByBEID
go
create proc spGetStoreByBEID
@BEID int
as
select BusinessEntityID BEID,Name,ContactType CT,Title,FirstName FN,
MiddleName MN,Suffix,PhoneNumber PN,PhoneNumberType PNT,EmailAddress EA, 
EmailPromotion EP from AdventureWorks2014.Sales.vStoreWithContacts where BusinessEntityID=@BEID
go

if OBJECT_ID('spGetAllStores','p') is not null
drop proc spGetAllStores
go
create proc spGetAllStores
as
select BusinessEntityID BEID,Name,ContactType CT,Title,FirstName FN,
MiddleName MN,Suffix,PhoneNumber PN,PhoneNumberType PNT,EmailAddress EA, 
EmailPromotion EP from AdventureWorks2014.Sales.vStoreWithContacts 
go


exec spGetStoreByBEID 292

exec sp_helptext 'spGetStoreByBEID'