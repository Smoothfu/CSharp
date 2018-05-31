 use AdventureWorks2014
 select * from INFORMATION_SCHEMA.TABLES where table_schema ='sales'
 select * from AdventureWorks2014.sales.Store

 select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.Sales.Store

 create proc spGetStoreByIDName
 @bEID int,
 @Name varchar(100),
 @SPID int
 as
  select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.Sales.Store where 