use ManagerApartment;
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghiêm Minh Ti?n	
-- Alter date: 23/04/2021
-- Description:	Proceduce cho modul qu?n lý t?ng

CREATE PROC Floor_GetAll
AS
BEGIN
	SELECT * From [dbo].[Floor]
END
GO

CREATE PROCEDURE Floor_GetById
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Floor]
	Where [Floor].[ID] = @id
END
GO

CREATE PROCEDURE Floor_Insert
	@name nvarchar(10),
	@description nvarchar(max)
AS
BEGIN
	INSERT INTO [dbo].[Floor]
           ([name]
           ,[description])
     VALUES
           (@name
           ,@description);
END
GO

CREATE PROC Floor_DeleteByID
@id int
AS
BEGIN
	DELETE FROM [dbo].[Floor]
	WHERE ID = @id
END
GO

CREATE PROCEDURE Floor_EditByID
	@id int,
    @name nvarchar(10),
    @description nvarchar(MAX)
AS
BEGIN
	
	UPDATE [dbo].[Floor]
	SET  [name] = @name
		,[description] = @description
	WHERE ID = @id
END
GO

