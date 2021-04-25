use ManagerApartment;
go

ALTER PROC Apartment_GetAll
AS
BEGIN
	SELECT [ID]
		  ,[name]
		  ,[floor]
		  ,[status]
		  ,[description]
		  ,[payment_per_month] as [paymentPerMonth]
	  FROM [dbo].[Apartment]
END

GO

ALTER PROCEDURE Apartment_GetById
	@id int
AS
BEGIN
	SELECT [ID]
		  ,[name]
		  ,[floor]
		  ,[status]
		  ,[description]
		  ,[payment_per_month] as [paymentPerMonth]
	FROM [dbo].[Apartment]
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