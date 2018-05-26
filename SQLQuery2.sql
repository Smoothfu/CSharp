use my_db
select * from sys.databases
select * from sysobjects where xtype='u'
select * from Persons 

exec sp_helpconstraint @objname='Persons'

alter table persons
drop constraint UQ__Persons__B770B53F09223666
