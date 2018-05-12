select * from sysobjects where xtype='u'

select column_name from INFORMATION_SCHEMA.COLUMNS where table_name='Iventory'

select column_name from INFORMATION_SCHEMA.COLUMNS where table_name='Product'

select * from iventory

set IDENTITY_INSERT [dbo].[Iventory] off

insert into [dbo].[Iventory] 
(Make,Color,PetName,Founder)
values
('Tesla','Black','Tesla','Elon Musk'),
('Auqi','Black','Auqi','Auqi'),
('Toyto','Black','Toyto','Toyto')


CREATE PROCEDURE GetPetName
@carID int,
@petName char(10) output
AS
SELECT @petName = PetName from Inventory where CarId = @carID
