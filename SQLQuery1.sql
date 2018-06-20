use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA ='production'
select * from AdventureWorks2014.Production.ProductModel

if OBJECT_ID('spGetProductModelByPMID','p') is not null
drop proc spGetProductModelByPMID
go
create proc spGetProductModelByPMID
@PMID int
as
select ProductModelID PMID,Name,CatalogDescription CD,Instructions,rowguid rg,ModifiedDate md  from AdventureWorks2014.Production.ProductModel where ProductModelID=@PMID

exec spGetProductModelByPMID 1