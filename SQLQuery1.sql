use AutoLot
select * from sysobjects where xtype='u'
select * from Inventory
select * from Customers
select * from Orders


USE [AutoLot]
GO

/****** Object:  StoredProcedure [dbo].[GetPetName]    Script Date: 5/23/2018 18:32:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPetName]
@carID int,
@petName char(10) output
AS
SELECT @petName = PetName from Inventory where CarId = @carID
GO


