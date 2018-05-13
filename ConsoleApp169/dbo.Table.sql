 CREATE  PROCEDURE GetPetName
 @carID int,
 @petName char(50) output
 AS
 select @petName=PetName from Inventory where CarID=@carID


