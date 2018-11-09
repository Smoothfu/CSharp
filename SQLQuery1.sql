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