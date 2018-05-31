USE [AdventureWorks2014]
GO

/****** Object:  StoredProcedure [dbo].[GetStoreByNameBeginWith]    Script Date: 5/31/2018 16:11:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter proc [dbo].[GetStoreByNameBeginWith]
@sName varchar(50)
as 
set nocount on
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.store where Name like  @sName+'%'
GO

select * from INFORMATION_SCHEMA.TABLES

exec [GetStoreByNameBeginWith] 'A'