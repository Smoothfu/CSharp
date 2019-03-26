use MyDb
select * from INFORMATION_SCHEMA.TABLES

create table TestTable
(GuidId uniqueidentifier default NEWID() primary key,
id int,
name varchar(50)
)

select * from TestTable

go
if OBJECT_ID('TestProc') is not null
drop proc TestProc
go
create proc TestProc
as
declare @id int
declare @name varchar(50)
set @id=0
set @name='Fred'+CONVERT(varchar(50),@id)
while(@id<2147483647)
begin
insert into TestTable(id,name)values(@id,@name);
set @id=@id+1;
end

 exec TestProc

