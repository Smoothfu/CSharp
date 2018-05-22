use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES where TABLE_TYPE='view'
select * from AdventureWorks2014.Person.vStateProvinceCountryRegion
select * from AdventureWorks2014.Sales.vStoreWithContacts
select * from AdventureWorks2014.Person.vAdditionalContactInfo

select COLUMN_NAME  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='vAdditionalContactInfo'
select COLUMN_NAME  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='vStateProvinceCountryRegion'
select COLUMN_NAME  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='vAdditionalContactInfo'