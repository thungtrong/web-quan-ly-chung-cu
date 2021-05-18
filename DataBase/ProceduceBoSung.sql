USE [ManagerApartment]
GO
/****** Object:  StoredProcedure [dbo].[Equipment_GetAll]    Script Date: 18/5/2021 11:34:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Equipment_GetByApartmentId]
@apartment_id int
AS
BEGIN
	SELECT [Equipment].[ID]
      ,[Equipment].[name]
      ,[count]
      ,[equipment_of] as [equipmentOf]
	  ,[Apartment].[name] as [apartmentName]
  FROM [dbo].[Equipment] join [Apartment]
  ON [equipment_of] = [Apartment].[ID]
  WHERE [equipment_of] = @apartment_id
END

go

CREATE PROC [dbo].[Apartment_GetByFloorId]
@id int
AS
BEGIN
	SELECT [Apartment].[ID]
		  ,[Apartment].[name]
		  ,[floor]
		  ,[status]
		  ,[Apartment].[description]
		  ,[payment_per_month] as [paymentPerMonth]
		  ,[Floor].[name] as [floorName]
	  FROM [dbo].[Apartment] join [Floor]
	  ON [floor] = [FLOOR].[ID]
	  WHERE [floor] = @id
END
