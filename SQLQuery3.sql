create database Accounting
on
(NAME='Accounting',
FILENAME='d:\c\ConsoleApp279\AccountingData.mdf',
SIZE=10,
MAXSIZE=50,
FILEGROWTH=5)
LOG ON
(NAME='AccountingLog',
FILENAME='d:\c\ConsoleApp279\AccountingLog.ldf',
SIZE=5MB,
MAXSIZE=25MB,
FILEGROWTH=5MB);
go

exec sp_helpdb 'Accounting'