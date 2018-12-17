use adventureworks2017
select * from information_schema.tables where table_schema='sales'
select ss.BusinessEntityID from sales.salesperson sp 
left join  sales.store ss
on sp.businessentityid=ss.businessentityid

select * from sales.salesperson sp 
select * from sales.store ss

select sp.BusinessEntityID,st.TerritoryID from sales.salesperson sp
left join sales.SalesTerritory st on sp.TerritoryID=st.TerritoryID