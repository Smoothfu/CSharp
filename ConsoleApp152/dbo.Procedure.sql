CREATE PROCEDURE GetPetName
@carID int,
@petName char(10) output
AS
select @petName=PetName from mt where CarId=@carID