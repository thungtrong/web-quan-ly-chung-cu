﻿use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- Alter date: 21/04/2021
-- Description:	Proceduce cho modul quản lý thông báo
-- =============================================
Alter PROCEDURE Notification_Add
    @title nvarchar(200),
    @content nvarchar(MAX),
    @date_release date,
    @creator int
AS
BEGIN
	INSERT INTO [dbo].[Notification]
           ([title]
           ,[content]
           ,[date_release]
           ,[creator])
     VALUES
           (@title
           ,@content
           ,@date_release
           ,@creator);
END
GO

Alter PROCEDURE Notification_EditByID
	@ID int,
    @title nvarchar(200),
    @content nvarchar(MAX),
    @date_release date
AS
BEGIN
	
	UPDATE [dbo].[Notification]
	SET  [title] = @title
		,[content] = @content
	    ,[date_release] = @date_release
	WHERE [ID] = @ID
END
GO

CREATE PROC Notidication_GetAll
AS
BEGIN
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[content]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Order by date_release DESC
END

GO
Create PROCEDURE Notification_GetById
	@id int
AS
BEGIN
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[content]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Where [Notification].[ID] = @id
END
GO

CREATE PROC Notification_GetByCreatorId
@creatorId int
AS
Begin
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[content]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Where [Admin].ID = @creatorId
	Order by date_release DESC
end

GO

CREATE PROCEDURE Notification_GetByRowNumber
	@start int,
	@end int
AS
BEGIN
	
	With work_tmp as (
		SELECT 
		ROW_NUMBER() Over (Order by [date_release])  as row#
		,[Notification].[ID] as ID
		,[title]
		,[content]
		,[date_release]
		,[Admin].[name] as creator
		FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	)
	Select [ID]
		,[title]
		,[content]
		,[date_release]
		,creator
	From work_tmp
	Where row# >= @start and row# < @end
	Order by date_release DESC
END
GO

CREATE PROC Notification_GetByCreatorIdRowNumber
@creatorId int,
@start int,
@end int
AS
Begin
	WITH work_tmp as (
		SELECT 
			ROW_NUMBER() Over (Order by [date_release])  as row#
			,[Notification].[ID] as ID
			,[title]
			,[content]
			,[date_release]
			,[Admin].[name] as creator
		FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
		Where [Admin].ID = @creatorId
	)
	Select [ID]
		,[title]
		,[content]
		,[date_release]
		,creator
	From work_tmp
	Where row# >= @start and row# < @end
	Order by date_release DESC
end

GO

CREATE PROC Notification_DeleteByID
@id int
AS
BEGIN
	DELETE FROM [dbo].[Notification]
	WHERE ID = @id
END

GO

-- Proceduce đếm số dòng trong bảng table
-- Nếu creator > 0  thì sẽ đếm số thông báo do creator tạo
CREATE PROC Notification_GetRowCount
@creatorId int
AS
BEGIN
	IF @creatorId > 0
		Select COUNT(id) as [count]
		From [Notification]
		Where creator = @creatorId
	else
		Select COUNT(id) as [count]
		From [Notification]
END

-- Edit Proceduce
-- 22/4/2021 
-- Loại bỏ dữ liệu thừa
GO
use ManagerApartment;
GO
Alter PROC Notidication_GetAll
AS
BEGIN
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Order by date_release DESC
END

GO
Alter PROCEDURE Notification_GetById
	@id int
AS
BEGIN
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Where [Notification].[ID] = @id
END
GO

Alter PROC Notification_GetByCreatorId
@creatorId int
AS
Begin
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Where [Admin].ID = @creatorId
	Order by date_release DESC
end

GO

Alter PROCEDURE Notification_GetByRowNumber
	@start int,
	@end int
AS
BEGIN
	
	With work_tmp as (
		SELECT 
		ROW_NUMBER() Over (Order by [date_release])  as row#
		,[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
		FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	)
	Select [ID]
		,[title]
		,[date_release]
		,creator
	From work_tmp
	Where row# >= @start and row# < @end
	Order by date_release DESC

END
GO

Alter PROC Notification_GetByCreatorIdRowNumber
@creatorId int,
@start int,
@end int
AS
Begin
	WITH work_tmp as (
		SELECT 
			ROW_NUMBER() Over (Order by [date_release])  as row#
			,[Notification].[ID] as ID
			,[title]
			,[date_release]
			,[Admin].[name] as creator
		FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
		Where [Admin].ID = @creatorId
	)
	Select [ID]
		,[title]
		,[date_release]
		,creator
	From work_tmp
	Where row# >= @start and row# < @end
	Order by date_release DESC
end

GO