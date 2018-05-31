select * from Inventory
create proc spGetCarByColorandCarID
@MinCId int,
@MaxCId int,
@CColor varchar(100)
as
select CarId,make,color,PetName from Inventory where CarId between @MinCId and @MaxCId and color=@CColor

exec sp_rename 'spGetCarByColorandCarID','spGetCarByCarIDColor'

exec spGetCarByCarIDColor 10,13,'Black'