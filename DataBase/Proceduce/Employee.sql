use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Phạm Thành Nhân
-- CREATE date: 25/04/2021
-- Description:	Proceduce cho modul Employee
-- =============================================
USE [ManagerApartment]
GO


CREATE PROC Employee_CREATE
@name nvarchar(100),
@email varchar(150),
@phone_number varchar(15),
@address nvarchar(250),
@join_date date,
@salary int,
@description nvarchar(max)
AS
BEGIN
	INSERT INTO [dbo].[Employee]
           ([name]
           ,[email]
           ,[phone_number]
           ,[address]
           ,[join_date] 
           ,[salary]
           ,[description])
     VALUES
           (
		   @name,
           @email,
           @phone_number,
           @address,
           @join_date,
           @salary,
           @description)
END
GO

CREATE PROC Employee_EditById
@id int,
@name nvarchar(100),
@email varchar(150),
@phone_number varchar(15),
@address nvarchar(250),
@join_date date,
@salary int,
@description nvarchar(max)
AS
BEGIN
	UPDATE [dbo].[Employee]
	   SET [name] = @name
           ,[email] = @email
           ,[phone_number] = @phone_number
           ,[address] = @address
           ,[join_date] = @join_date
           ,[salary] = @salary
           ,[description] = @description
	 WHERE [Employee].[ID] = @id
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
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[address]
           ,[join_date] as [joinDate]
           ,[salary]
           ,[description]
	FROM [dbo].[Employee]
END
GO

CREATE PROC Employee_GetById
@id int
AS
BEGIN
	SELECT [Employee].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[address]
           ,[join_date] as [joinDate]
           ,[salary]
           ,[description]
	FROM [dbo].[Employee]
    WHERE [Employee].[ID] = @id
END
GO