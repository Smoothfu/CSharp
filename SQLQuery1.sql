if OBJECT_ID('Purchasing.uspVendorAllInfo', 'P') is not null
drop procedure AdventureWorks2014.Purchasing.uspVendorAllInfo
go
create proc Purchasing.spuspVendorAllInfo
with execute as caller
as 
set nocount on;
select v.Name as VName,p.Name as PName
from AdventureWorks2014.Purchasing.Vendor v
inner join AdventureWorks2014.Purchasing.ProductVendor pv
on v.BusinessEntityID=pv.BusinessEntityID
inner join AdventureWorks2014.Production.Product p
on pv.ProductID=p.ProductID
order by v.Name asc
 
 exec Purchasing.spuspVendorAllInfo

 alter proc Purchasing.spuspVendorAllInfo
 @productName varchar(25)
 as 
 set nocount on;
 select left(v.Name,25) as vendor,left(pp.Name,25) as 'Product Name',

 'Rating'= CASE v.CreditRating
 When 1 then 'Superior'
 When 2 then 'Excellent'
 WHEN 3 then 'Above average'
 WHEN 4 then 'Average'
 WHEN 5 then 'Below Average'
 else 'No rating'
 end,
 availibity=CASE v.activeflag
 when 1 then 'yes'
 else 'no'
 end 
 from AdventureWorks2014.Purchasing.Vendor v
 inner join AdventureWorks2014.Purchasing.ProductVendor pv
 on v.BusinessEntityID=pv.BusinessEntityID
 inner join AdventureWorks2014.Production.Product as pp
 on pv.ProductID=pp.ProductID
 where pp.Name like @productName
 order by v.Name asc;