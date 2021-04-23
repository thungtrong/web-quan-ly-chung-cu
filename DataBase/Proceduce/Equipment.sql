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

CREATE PROC Equipment_GetAll
AS
BEGIN
	SELECT * From [dbo].[Equipment]
END
GO

Create PROCEDURE Equipment_GetById
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Equipment]
	Where [Equipment].[ID] = @id
END
GO

Create PROCEDURE Equipment_Insert
	@name nvarchar(100),
	@count int,
	@equipment_of int
AS
BEGIN
	INSERT INTO [dbo].[Equipment]
           ([name]
		   ,[count]
           ,[equipment_of])
     VALUES
           (@name
		   ,@count
           ,@equipment_of);
END
GO

CREATE PROC Equipment_DeleteByID
@id int
AS
BEGIN
	DELETE FROM [dbo].[Equipment]
	WHERE ID = @id
END
GO

Create PROCEDURE Equipment_EditByID
	@id int,
    @name nvarchar(100),
	@count int,
    @equipment_of int
AS
BEGIN
	
	UPDATE [dbo].[Equipment]
	SET  [name] = @name
		,[count] = @count
		,[equipment_of]=@equipment_of
	WHERE ID = @id
END
GO

