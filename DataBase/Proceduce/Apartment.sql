use ManagerApartment;
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghiêm Minh Ti?n	
-- Alter date: 23/04/2021
-- Description:	Proceduce cho modul qu?n lý can ho

CREATE PROC Apartment_GetAll
AS
BEGIN
	SELECT * From [dbo].[Apartment]
END
GO

CREATE PROCEDURE Apartment_GetById
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Apartment]
	Where [Apartment].[ID] = @id
END
GO

CREATE PROCEDURE Apartment_Insert
	@id int,
	@name nvarchar(10),
	@floor int,
	@description nvarchar(max),
	@status int
AS
BEGIN
	INSERT INTO [dbo].[Apartment]
           ([ID]
           ,[name]
		   ,[floor]
           ,[description]
		   ,[status])
     VALUES
           (@id
           ,@name
		   ,@floor
           ,@description
		   ,@status);
END
GO

CREATE PROC Apartment_DeleteByID
@id int
AS
BEGIN
	DELETE FROM [dbo].[Apartment]
	WHERE ID = @id
END
GO

CREATE PROCEDURE Apartment_EditByID
	@id int,
	@name nvarchar(10),
	@floor int,
	@status int,
	@pay_per_month int,
	@description nvarchar(max)
AS
BEGIN
	
	UPDATE [dbo].[Apartment]
	SET  [status] = @status
		,[description] = @description
		,[payment_per_month] = @pay_per_month
	WHERE ID = @id
END
GO

