select sp.BusinessEntityID,st.TerritoryID from sales.salesperson sp
left join sales.SalesTerritory st on sp.TerritoryID=st.TerritoryID