use AdventureWorks2014
select * from INFORMATION_SCHEMA.TABLES

if OBJECT_ID('spGetAllTables','p') is not null
drop proc spGetAllTables
go
create proc spGetAllTables
as 
select * from INFORMATION_SCHEMA.TABLES