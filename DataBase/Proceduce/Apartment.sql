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

Create PROCEDURE Apartment_GetById
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Apartment]
	Where [Apartment].[ID] = @id
END
GO

Create PROCEDURE Apartment_Insert
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

Create PROCEDURE Apartment_EditByID
	@id int,
    @status int,
    @description nvarchar(MAX)
AS
BEGIN
	
	UPDATE [dbo].[Apartment]
	SET  [status] = @status
		,[description] = @description
	WHERE ID = @id
END
GO

