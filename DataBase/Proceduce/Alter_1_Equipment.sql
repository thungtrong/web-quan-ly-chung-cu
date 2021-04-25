Use ManagerApartment;
go

ALTER PROC Equipment_GetAll
AS
BEGIN
	SELECT [Equipment].[ID]
      ,[Equipment].[name]
      ,[count]
      ,[equipment_of] as [equipmentOf]
	  ,[Apartment].[name] as [apartmentName]
  FROM [dbo].[Equipment] join [Apartment]
  ON [equipment_of] = [Apartment].[ID]
END
GO

ALTER PROCEDURE Equipment_GetById
	@id int
AS
BEGIN
	SELECT [Equipment].[ID]
		  ,[Equipment].[name]
		  ,[count]
		  ,[equipment_of] as [equipmentOf]
		  ,[Apartment].[name] as [apartmentName]
	FROM [dbo].[Equipment] join [Apartment]
	ON [equipment_of] = [Apartment].[ID]
	Where [Equipment].[ID] = @id
END
