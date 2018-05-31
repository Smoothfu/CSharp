use AdventureWorks2014

select * from sysobjects where xtype='u'

select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='Sales'
select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNs where table_name='store'
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store

if exists(select * from sysobjects where name='spGetStoreByBusinessEntityID')
drop procedure spGetStoreByBusinessEntityID

create procedure spGetStoreByBusinessEntityID
@bEntityId int 
as 
set nocount on;
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store where BusinessEntityID=@bEntityId 

exec spGetStoreByBusinessEntityID @bEntityId='292'


create procedure spGetStoreBySalesPersonID
@sPersonID int
as
set nocount on;
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store where SalesPersonID=@sPersonID

exec spGetStoreBySalesPersonID @sPersonID ='276'


create proc spGetStoreByBEIDAndSalesPersonID
@bEID int,
@sPID int
as 
set nocount on;
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store where BusinessEntityID=@bEID and SalesPersonID=@sPID

exec spGetStoreByBEIDAndSalesPersonID @beid='294', @sPID='276'


create proc spGetStoreByGreaterBID
@bEID int
as 
set nocount on;
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store where BusinessEntityID>@bEID 

exec spGetStoreByGreaterBID @beid='1000'


create proc GetStoreByNameBeginWith
@SName varchar(200) 
as
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store where Name like  @SName+'%'

exec GetStoreByNameBeginWith @sName='Y'