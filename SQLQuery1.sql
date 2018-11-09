select pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as fullName,pp.BusinessEntityID as PPBEID,sc.PersonID
from person.Person pp
inner join sales.Customer sc
on pp.BusinessEntityID=sc.PersonID

select sso.SpecialOfferID,Description,DiscountPct,ProductID
from sales.SpecialOffer sso
join sales.SpecialOfferProduct ssop
on sso.SpecialOfferID=ssop.SpecialOfferID
where sso.SpecialOfferID!=1

select sso.SpecialOfferID,Description,DiscountPct,ProductID
from sales.SpecialOffer sso
left join sales.SpecialOfferProduct ssop
on sso.SpecialOfferID=ssop.SpecialOfferID
where sso.SpecialOfferID!=1


select sso.SpecialOfferID,Description,DiscountPct,ProductID
from sales.SpecialOfferProduct ssop
right join sales.SpecialOffer sso
on ssop.SpecialOfferID=sso.SpecialOfferID
where sso.SpecialOfferID!=1

select sso.SpecialOfferID,Description,DiscountPct,ProductID
from sales.SpecialOffer sso
right join sales.SpecialOfferProduct ssop
on sso.SpecialOfferID=ssop.SpecialOfferID
where sso.SpecialOfferID!=1

select Description
from sales.SpecialOfferProduct ssop
right outer join sales.SpecialOffer sso
on ssop.SpecialOfferID=sso.SpecialOfferID
where sso.SpecialOfferID!=1
and ssop.SpecialOfferID is null

if(null=null)
print 'it does'
else
print 'it does not'

select pbe.BusinessEntityID,hre.JobTitle,pp.FirstName,pp.LastName
from Person.BusinessEntity pbe
inner join HumanResources.Employee hre
on pbe.BusinessEntityID=hre.BusinessEntityID
inner join Person.Person pp
on pbe.BusinessEntityID =pp.BusinessEntityID
where hre.BusinessEntityID<4

select count(*) from Person.BusinessEntity

select pp.BusinessEntityID,pp.FirstName,pp.LastName
from person.Person pp
left join HumanResources.Employee hre
on pp.BusinessEntityID=hre.BusinessEntityID
where hre.BusinessEntityID is null

select pp.BusinessEntityID,pp.FirstName,pp.LastName
from HumanResources.Employee hre
right join Person.Person pp
on pp.BusinessEntityID=hre.BusinessEntityID
where hre.BusinessEntityID is null


select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like 'v%' 
select * from Purchasing.Vendor

select v.AccountNumber
from Purchasing.Vendor v

select distinct v.Name
from Purchasing.Vendor v
left join Purchasing.ProductVendor pv
on v.BusinessEntityID=pv.BusinessEntityID

select * from Purchasing.vVendorWithAddresses

select v.Name
from Purchasing.Vendor v
left join Purchasing.vVendorWithAddresses va
on v.BusinessEntityID=va.BusinessEntityID

select v.Name,va.BusinessEntityID
from Purchasing.Vendor v
left join Purchasing.vVendorWithAddresses va
on v.BusinessEntityID=va.BusinessEntityID

select v.name
from Purchasing.Vendor v
cross join Purchasing.vVendorWithAddresses va

select * from Purchasing.Vendor
select * from Purchasing.vVendorWithAddresses

select 104*104
 

 select *
 from Person.Person
 join HumanResources.Employee
 on Person.BusinessEntityID=HumanResources.Employee.BusinessEntityID

 select *
 from Person.Person,HumanResources.Employee
 where Person.BusinessEntityID=HumanResources.Employee.BusinessEntityID
 
 select sso.SpecialOfferID,Description,DiscountPct,ProductID
 from sales.SpecialOffer sso
 left join sales.SpecialOfferProduct ssop
 on sso.SpecialOfferID=ssop.SpecialOfferID
 where sso.SpecialOfferID!=1

 select sso.SpecialOfferID,Description,DiscountPct,ProductID
 from sales.SpecialOffer sso,
 sales.SpecialOfferProduct ssop

 select v.Name,va.AddressLine1
 from Purchasing.Vendor v,Purchasing.vVendorWithAddresses va

 select FirstName+' '+LastName as FullName,pe.EmailAddress PEEmailAddress
 from Person.Person pp
 join Person.EmailAddress pe
 on pp.BusinessEntityID=pe.BusinessEntityID
 join sales.Customer sc
 on pp.BusinessEntityID=sc.CustomerID
 union
select FirstName+' '+LastName as FullName,pe.EmailAddress as VendorEmailAddress 
from Person.Person pp
join Person.EmailAddress pe
on pp.BusinessEntityID =pe.BusinessEntityID
join Purchasing.Vendor pv
on pp.BusinessEntityID=pv.BusinessEntityID


select pp.ProductNumber
from Production.Product PP
join Production.ProductInventory PPI
on PPI.ProductID=pp.ProductID
where ppi.Quantity<100
union
select pp.ProductNumber 
from Production.Product pp
join Sales.SpecialOfferProduct ssop
on pp.ProductID=ssop.ProductID
where ssop.SpecialOfferID>1

select pp.ProductNumber,ppi.ProductID
from Production.Product pp
join Production.ProductInventory PPI
on PPI.ProductID=pp.ProductID
where PPI.Quantity<100
union all
select pp.ProductNumber,ssop.ProductID
from Production.Product pp
join sales.SpecialOfferProduct ssop
on pp.ProductID=ssop.ProductID
join sales.SpecialOffer so
on so.SpecialOfferID=ssop.SpecialOfferID
where ssop.SpecialOfferID>1


select *
from Purchasing.Vendor v
cross join Purchasing.vVendorWithAddresses va

select * from Purchasing.Vendor
select * from Purchasing.vVendorWithAddresses

select hre.NationalIDNumber,pp.FirstName,pp.LastName,hre.NationalIDNumber
from HumanResources.Employee hre
inner join
Person.Person pp
on pp.BusinessEntityID =hre.BusinessEntityID
inner join
Person.BusinessEntityAddress pbea on pp.BusinessEntityID=pbea.BusinessEntityID
inner join
person.Address pa on pa.AddressID=pbea.AddressID