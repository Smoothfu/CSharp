use MyDb
 create table tb
(GuidId uniqueidentifier default NEWID() primary key,
id int,
name varchar(50)
)


if OBJECT_ID('insertProc') is not null
drop proc insertProc
go
create proc insertProc
as
declare @id int
declare @name varchar(50)
set @id=0
set @name='Fred'
while(@id<2147483647)
begin
insert into tb(id,name)values(@id,@name);
set @id=@id+1;
set @name='Fred'+CONVERT(varchar(50),@id)
end

 exec insertProc