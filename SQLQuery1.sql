use AdventureWorks2014
select * from sys.tables 
select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='production'
select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP from AdventureWorks2014.Production.Product

if OBJECT_ID('spGetProductByPID','p') is not null
drop proc spGetProductByPID
go
create proc spGetProductByPID
@PID int
as
if @PID=0
select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP,
Size,SizeUnitMeasureCode SUMC,WeightUnitMeasureCode WUMC,Weight,DaysToManufacture DTM,ProductLine PL,class,style,ProductSubcategoryID PSID,ProductModelID PMID,
SellStartDate SSD,SellEndDate SED,DiscontinuedDate DD,rowguid RG,ModifiedDate MD
from AdventureWorks2014.Production.Product
else
select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP,
Size,SizeUnitMeasureCode SUMC,WeightUnitMeasureCode WUMC,Weight,DaysToManufacture DTM,ProductLine PL,class,style,ProductSubcategoryID PSID,ProductModelID PMID,
SellStartDate SSD,SellEndDate SED,DiscontinuedDate DD,rowguid RG ,ModifiedDate MD
from AdventureWorks2014.Production.Product where ProductID=@PID
 
 select  COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='Product'
  select count(*) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='Product'




select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP 
from AdventureWorks2014.Production.Product


select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP,
Size,SizeUnitMeasureCode SUMC,WeightUnitMeasureCode WUMC,Weight,DaysToManufacture DTM,ProductLine PL,class,style,ProductSubcategoryID PSID,ProductModelID PMID,
SellStartDate SSD,SellEndDate SED,DiscontinuedDate DD,rowguid RG,ModifiedDate MD
from AdventureWorks2014.Production.Product where ProductID=1

exec spGetProductByPID 1

select COLUMN_NAME,DATA_TYPE  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='product'


select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='product'

select * from INFORMATION_SCHEMA.CHECK_CONSTRAINTS where CONSTRAINT_NAME='CK_Product_Weight'

EXEC sp_MSforeachtable @command1="ALTER TABLE ? NOCHECK CONSTRAINT ALL"