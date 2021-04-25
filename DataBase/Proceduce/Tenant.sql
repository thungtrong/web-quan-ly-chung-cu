use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Phạm Thành Nhân
-- CREATE date: 25/04/2021
-- Description:	Proceduce cho modul Tenant
-- =============================================
USE [ManagerApartment]
GO


CREATE PROC Tenant_Create
@name nvarchar(100), 
@email varchar(150), 
@phoneNumber varchar(15), 
@advancePayment int


AS
BEGIN
	INSERT INTO [dbo].[Tenant]
           ([name]
           ,[email]
           ,[phone_number]
           ,[advance_payment]
           )
     VALUES
           (
		   @name,
           @email,
           @phoneNumber,
           @advancePayment
           )
END
GO

CREATE PROC Tenant_EditById
@id int,
@name nvarchar(100), 
@email varchar(150), 
@phoneNumber varchar(15), 
@advancePayment int
AS
BEGIN
	UPDATE [dbo].[Tenant]
	   SET [name] = @name
           ,[email] = @email
           ,[phone_number] = @phoneNumber
           ,[advance_payment] = @advancePayment
           
	 WHERE [Tenant].[ID] = @id
END
GO


CREATE PROC Tenant_DeleteById
@id int
AS
BEGIN
	DELETE FROM [dbo].[Tenant]
    WHERE [ID] = @id
END

GO
CREATE PROC Tenant_GetAll
AS
BEGIN
	SELECT [Tenant].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[advance_payment] as [advancePayment]
           
	FROM [dbo].[Tenant]
END
GO

CREATE PROC Tenant_GetById
@id int
AS
BEGIN
	SELECT [Tenant].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[advance_payment] as [advancePayment]
           
	FROM [dbo].[Tenant]
    WHERE [Tenant].[ID] = @id
END
GO