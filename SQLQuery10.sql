USE [AdventureWorks2014]
GO

/****** Object:  StoredProcedure [dbo].[GetStoreByNameBeginWith]    Script Date: 5/31/2018 16:09:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetStoreByNameBeginWith]
@SName varchar(200) 
as
set nocount off
select BusinessEntityID,Name,SalesPersonID,rowguid,ModifiedDate from AdventureWorks2014.sales.Store where Name like  @SName+'%'
GO

 
