use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- CREATE date: 22/04/2021
-- Description:	Proceduce cho modul quản lý chi phí bảo trì
-- =============================================

CREATE PROC Maintenance_Add
@title nvarchar(200),
@date_create date,
@amount int,
@status int,
@description nvarchar(max),
@creator int
AS
BEGIN
	INSERT INTO [dbo].[Maintenance]
           ([title]
           ,[date_create]
           ,[amount]
           ,[status]
           ,[description]
           ,[creator])
     VALUES
           (
		   @title,
           @date_create ,
           @amount,
           @status,
           @description ,
           @creator)
END
GO

CREATE PROC Maintenance_EditById
@id int,
@title nvarchar(200),
@date_create date,
@amount int,
@status int,
@description varchar(max)
AS
BEGIN
	UPDATE [dbo].[Maintenance]
	   SET [title] = @title
		  ,[date_create] = @date_create
		  ,[amount] = @amount
		  ,[status] = @status
		  ,[description] = @description
	 WHERE [Maintenance].[ID] = @id
END
GO
CREATE PROC Maintenance_EditStatusById
@id int,
@status int
AS
BEGIN
	UPDATE [dbo].[Maintenance]
	   SET [status] = @status
	 WHERE [ID] = @id
END
GO

CREATE PROC Maintenance_DeleteById
@id int
AS
BEGIN
	DELETE FROM [dbo].[Maintenance]
    WHERE [ID] = @id
END

GO
CREATE PROC Maintenance_GetAll
AS
BEGIN
	SELECT [Maintenance].[ID]
		  ,[title]
		  ,[date_create] as [dateCreate]
		  ,[amount]
		  ,[status]
		  ,[description]
		  ,[Admin].[name] as [creator]
	FROM [dbo].[Maintenance] inner join [dbo].[Admin]
	ON [Admin].[ID] = [Maintenance].[creator]
	ORDER BY [date_create] DESC
END
GO

CREATE PROC Maintenance_GetById
@id int
AS
BEGIN
	SELECT [Maintenance].[ID]
		  ,[title]
		  ,[date_create] as [dateCreate]
		  ,[amount]
		  ,[status]
		  ,[description]
		  ,[Admin].[name] as [creator]
	FROM [dbo].[Maintenance] inner join [dbo].[Admin]
	ON [Admin].[ID] = [Maintenance].[creator]
    WHERE [Maintenance].[ID] = @id
END
GO
CREATE PROC Maintenance_GetByRowNum
@start int,
@end int
AS 
BEGIN
	With work_tmp as (
		SELECT 
			ROW_NUMBER() OVER(ORDER BY [date_create] DESC) as row#
			,[Maintenance].[ID]
			,[title]
			,[date_create]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
		FROM [dbo].[Maintenance] inner join [dbo].[Admin]
		ON [Admin].[ID] = [Maintenance].[creator]
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
	Where row# >= @start and row# < @end
END

GO
CREATE PROC Maintenance_GetRowCount
AS
BEGIN
	SELECT COUNT([ID]) as [count]
	FROM [dbo].[Maintenance] 
END
