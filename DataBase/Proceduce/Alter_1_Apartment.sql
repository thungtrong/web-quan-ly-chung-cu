use ManagerApartment;
go

-- chi lay ve ten va id
CREATE PROC Apartment_GetIdNameAll
AS
BEGIN
	SELECT [Apartment].[ID]
		  ,[Apartment].[name]
	  FROM [dbo].[Apartment] 

END

go

ALTER PROC Apartment_GetAll
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
END
GO

GO

ALTER PROCEDURE Apartment_GetById
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
	Where [Apartment].[ID] = @id
END
Go

GO

Alter PROCEDURE Apartment_Insert
	@name nvarchar(100),
	@floor int,
	@description nvarchar(max),
	@status bit
AS
BEGIN
	INSERT INTO [dbo].[Apartment]
           (
           [name]
		   ,[floor]
           ,[description]
		   ,[status])
     VALUES
           (
           @name
		   ,@floor
           ,@description
		   ,@status);
END

GO

ALTER PROCEDURE Apartment_EditByID
	@id int,
	@name nvarchar(100),
	@floor int,
    @description nvarchar(MAX),
	@status bit
AS
BEGIN
	
	UPDATE [dbo].[Apartment]
	SET  
		[name] = @name
		,[floor] = @floor
		,[description] = @description
		,[status] = @status
	WHERE ID = @id
END
GO