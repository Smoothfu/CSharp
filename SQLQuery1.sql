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
select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP 
from AdventureWorks2014.Production.Product 
else
select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP 
from AdventureWorks2014.Production.Product where ProductID=@PID
 
if OBJECT_ID('spGetAllProducts','p') is not null
drop proc spGetAllProducts
go
create proc spGetAllProducts
as
select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP 
from AdventureWorks2014.Production.Product

exec spGetProductByPID 1


select ProductID PID,Name,ProductNumber PNO,MakeFlag MF,FinishedGoodsFlag FGF,color,safetystocklevel SSL,ReorderPoint ROP,standardcost SC,ListPrice LP 
from AdventureWorks2014.Production.Product

declare
@PID int
exec spGetProductByPID @PId=352