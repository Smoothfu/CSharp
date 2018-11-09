use AdventureWorks2017
select * from INFORMATION_SCHEMA.TABLES



select top(20) * from INFORMATION_SCHEMA.tables where TABLE_NAME not in(
select top(10) TABLE_NAME from INFORMATION_SCHEMA.TABLES order by TABLE_NAME) order by TABLE_NAME
  

  select SYSDATETIME() 
  select GETDATE()