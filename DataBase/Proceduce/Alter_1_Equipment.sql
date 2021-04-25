Use ManagerApartment;
go

ALTER PROC Equipment_GetAll
AS
BEGIN
	SELECT [ID]
      ,[name]
      ,[count]
      ,[equipment_of] as [equipmentOf]
  FROM [dbo].[Equipment]
END
GO

ALTER PROCEDURE Equipment_GetById
	@id int
AS
BEGIN
	SELECT [ID]
      ,[name]
      ,[count]
      ,[equipment_of] as [eqiupmentOf]
  FROM [dbo].[Equipment]
	Where [Equipment].[ID] = @id
END
