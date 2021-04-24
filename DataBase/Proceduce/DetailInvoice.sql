use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- Alter date: 21/04/2021
-- Description:	Proceduce cho modul quản lý thông báo
-- =============================================
CREATE PROC DetailInvoice_GetByDetailOf
@detail_of int
AS
BEGIN

	SELECT [ID]
		  ,[name]
		  ,[amount]
	FROM [dbo].[DeltailInvoice]
	WHERE [detail_of] = @detail_of


END

GO

CREATE PROC DetailInvoice_EditById
@id int,
@name nvarchar(50),
@amount int
AS
BEGIN
	Update DeltailInvoice
	SET [name] = @name,
		[amount] = @amount
	WHERE [ID] = @id
END

GO

CREATE PROC DetailInvoice_Create
@detail_of int,
@name nvarchar(50),
@amount int
AS
BEGIN

	INSERT INTO [dbo].[DeltailInvoice]
			   ([name]
			   ,[amount]
			   ,[detail_of])
		 VALUES
			   (@name,
			   @amount,
			   @detail_of)
	
END

GO

CREATE PROC DetailInvoice_DeleteByIdDetailOf
@id int,
@detail_of int
AS
BEGIN
	DELETE FROM DeltailInvoice
	WHERE [ID] = @id and [detail_of] = @detail_of
END