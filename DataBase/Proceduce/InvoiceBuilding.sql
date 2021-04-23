use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- CREATE date: 22/04/2021
-- Description:	Proceduce cho modul quản lý hoá đơn toà nhà
-- =============================================
CREATE PROC InvoiceBuilding_Add
@title nvarchar(200),
@date_create date,
@amount int,
@status bit,
@description nvarchar(max),
@creator int
AS
BEGIN
	INSERT INTO [dbo].[InvoiceBuilding]
			   ([title]
			   ,[date_create]
			   ,[amount]
			   ,[status]
			   ,[description]
			   ,[creator])
		 VALUES
			   (@title,
			   @date_create,
			   @amount,
			   @status,
			   @description,
			   @creator)
END
GO

CREATE PROC InvoiceBuilding_EditById
@id int,
@title nvarchar(200),
@date_create date,
@amount int,
@status bit,
@description nvarchar(max),
@creator int
AS
BEGIN

	UPDATE [dbo].[InvoiceBuilding]
	   SET [title] = @title
		  ,[date_create] = @date_create
		  ,[amount] = @amount
		  ,[status] = @status
		  ,[description] = @description
		  ,[creator] = @creator
	 WHERE [ID] = @id
END

GO

CREATE PROC InvoiceBuilding_DeleteById
@id int
AS
BEGIN
	DELETE FROM [InvoiceBuilding]
	WHERE [ID] = @id
END
GO

CREATE PROC InvoiceBuilding_EditStatusById
@id int,
@status bit
AS
BEGIN
	UPDATE	[dbo].[InvoiceBuilding]
	SET		[status] = @status
	WHERE	[ID] = @id
END
GO


CREATE PROC InvoiceBuilding_GetAll
AS
BEGIN
	SELECT [InvoiceBuilding].[ID]
			,[title]
			,[date_create] as [dateCreate]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
	FROM [dbo].[InvoiceBuilding] inner join [dbo].[Admin]
		ON [Admin].[ID] = [InvoiceBuilding].[creator]
	ORDER BY [date_create] DESC, [InvoiceBuilding].ID
END
GO


CREATE PROC InvoiceBuilding_GetById
@id int
AS
BEGIN
	SELECT [InvoiceBuilding].[ID]
			,[title]
			,[date_create] as [dateCreate]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
	FROM [dbo].[InvoiceBuilding] inner join [dbo].[Admin]
		ON [Admin].[ID] = [InvoiceBuilding].[creator]
	WHERE [InvoiceBuilding].[ID] = @id
END
GO


CREATE PROC InvoiceBuilding_GetByRowNum
@start int,
@end int
AS
BEGIN
	WITH work_tmp AS (
		SELECT 
			ROW_NUMBER() OVER (ORDER BY [date_create] DESC, [InvoiceBuilding].[ID]) as row#
			,[InvoiceBuilding].[ID]
			,[title]
			,[date_create]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
		FROM [dbo].[InvoiceBuilding] inner join [dbo].[Admin]
		ON [Admin].[ID] = [InvoiceBuilding].[creator]
	)
	SELECT 
		[ID]
		,[title]
		,[date_create] as [dateCreate]
		,[amount]
		,[status]
		,[description]
		,[creator]
	FROM work_tmp
	WHERE row# >= @start and row# < @end
END
GO


CREATE PROC InvoiceBuilding_GetRowCount
AS
BEGIN
	SELECT COUNT(ID) as [count]
	FROM InvoiceBuilding
END
GO