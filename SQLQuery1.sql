select pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as fullName,pp.BusinessEntityID as PPBEID,sc.PersonID
from person.Person pp
inner join sales.Customer sc
on pp.BusinessEntityID=sc.PersonID

select CAST(LastName+','+FirstName as varchar(55)) as FullName,AccountNumber
from Person.Person pp
inner join sales.Customer sc
on pp.BusinessEntityID=sc.PersonID

select CAST(LastName+','+FirstName as varchar(55)) as FullName,AccountNumber
from Person.Person pp
left join sales.Customer sc
on pp.BusinessEntityID=sc.PersonID

select CAST(LastName+','+FirstName as varchar(55)) as FullName,AccountNumber
from Person.Person pp
right join sales.Customer sc
on pp.BusinessEntityID=sc.PersonID