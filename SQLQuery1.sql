use AdventureWorks2014
select * from sys.procedures

if exists(select name from sys.procedures where name='spGetStoreById')
drop proc spGetStoreById

if OBJECT_ID('spGetStoreById','P') is not null
drop proc spGetStoreById
go
create proc spGetStoreById
@bEID int
as
select BusinessEntityID BEID,Name, SalesPersonID SPID,rowguid,ModifiedDate from AdventureWorks2014.Sales.Store where BusinessEntityID=@bEID

select * from AdventureWorks2014.Sales.Store
select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='store'

exec spGetStoreById 292

select BusinessEntityID BEID,Name, SalesPersonID SPID,rowguid,ModifiedDate from AdventureWorks2014.Sales.Store

if OBJECT_ID('spRetriveStores','p') is not null
drop proc spRetriveStores
go
create proc spRetriveStores
as select BusinessEntityID BEID,Name, SalesPersonID SPID,rowguid,ModifiedDate from AdventureWorks2014.Sales.Store

exec spRetriveStores
