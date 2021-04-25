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

CREATE PROC Employee_Add
@title nvarchar(200),
@date_create date,
@amount int,
@status int,
@description nvarchar(max),
@creator int
AS
BEGIN
	INSERT INTO [dbo].[Employee]
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

CREATE PROC Employee_EditById
@id int,
@title nvarchar(200),
@date_create date,
@amount int,
@status int,
@description varchar(max)
AS
BEGIN
	UPDATE [dbo].[Employee]
	   SET [title] = @title
		  ,[date_create] = @date_create
		  ,[amount] = @amount
		  ,[status] = @status
		  ,[description] = @description
	 WHERE [Employee].[ID] = @id
END
GO
CREATE PROC Employee_EditStatusById
@id int,
@status int
AS
BEGIN
	UPDATE [dbo].[Employee]
	   SET [status] = @status
	 WHERE [ID] = @id
END
GO

CREATE PROC Employee_DeleteById
@id int
AS
BEGIN
	DELETE FROM [dbo].[Employee]
    WHERE [ID] = @id
END

GO
CREATE PROC Employee_GetAll
AS
BEGIN
	SELECT [Employee].[ID]
		  ,[title]
		  ,[date_create] as [dateCreate]
		  ,[amount]
		  ,[status]
		  ,[description]
		  ,[Admin].[name] as [creator]
	FROM [dbo].[Employee] inner join [dbo].[Admin]
	ON [Admin].[ID] = [Employee].[creator]
	ORDER BY [date_create] DESC
END
GO

CREATE PROC Employee_GetById
@id int
AS
BEGIN
	SELECT [Employee].[ID]
		  ,[title]
		  ,[date_create] as [dateCreate]
		  ,[amount]
		  ,[status]
		  ,[description]
		  ,[Admin].[name] as [creator]
	FROM [dbo].[Employee] inner join [dbo].[Admin]
	ON [Admin].[ID] = [Employee].[creator]
    WHERE [Employee].[ID] = @id
END
GO
CREATE PROC Employee_GetByRowNum
@start int,
@end int
AS 
BEGIN
	With work_tmp as (
		SELECT 
			ROW_NUMBER() OVER(ORDER BY [date_create] DESC) as row#
			,[Employee].[ID]
			,[title]
			,[date_create]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
		FROM [dbo].[Employee] inner join [dbo].[Admin]
		ON [Admin].[ID] = [Employee].[creator]
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
CREATE PROC Employee_GetRowCount
AS
BEGIN
	SELECT COUNT([ID]) as [count]
	FROM [dbo].[Employee] 
END
