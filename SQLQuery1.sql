use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='Sales'
select * from AdventureWorks2014.sales.vStoreWithContacts

select BusinessEntityID,Name,SalesPersonID,rowguid, ModifiedDate from AdventureWorks2014.Sales.Store

if exists(select * from sysobjects where name='sp_GetStoreByBusinessEntityID')
drop procedure sp_GetStoreByBusinessEntityID

create procedure sp_GetStoreByBusinessEntityID
@bEntityID int
as
select BusinessEntityID,Name,SalesPersonID,rowguid, ModifiedDate from AdventureWorks2014.Sales.Store where BusinessEntityID=''+@bEntityID+''
go
 

 exec sp_GetStoreByBusinessEntityID 