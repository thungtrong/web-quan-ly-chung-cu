use ManagerApartment;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- CREATE date: 21/04/2021
-- Description:	Proceduce cho modul quản lý thông báo
-- =============================================

CREATE PROC InvoiceApartment_Create
@date_release date,
@date_paid date,
@status bit,
@invoice_of int
as
BEGIN
	INSERT INTO [dbo].[InvoiceApartment]
			   ([date_release]
			   ,[date_paid]
			   ,[status]
			   ,[invoice_of])
		 VALUES
			   (@date_release,
			   @date_paid,
			   @status,
			   @invoice_of)
	SELECT SCOPE_IDENTITY() as [0];
END
GO
CREATE PROC InvoiceApartment_EditById
@id int,
@date_release date,
@date_paid date,
@status bit
AS
BEGIN
	UPDATE [dbo].[InvoiceApartment]
	   SET [date_release] = @date_release
		  ,[date_paid] = @date_paid
		  ,[status] = @status
	 WHERE [ID] = @id
END

GO
CREATE PROC InvoiceApartment_EditStatusById
@id int,
@status bit
AS
BEGIN
	UPDATE [dbo].[InvoiceApartment]
	SET [status] = @status
	WHERE [ID] = @id
END
GO

CREATE PROC InvoiceApartment_DeleteById
@id int
AS
BEGIN
	DELETE FROM InvoiceApartment
	WHERE [ID] = @id
END

GO
-- Lấy tất cả Invoice
CREATE PROC InvoiceApartment_GetAll
AS
BEGIN
	
	with work_tmp as (
		SELECT [detail_of], SUM([amount]) as amount
		FROM [dbo].[DeltailInvoice]
		Group BY [detail_of]
	)
	
	SELECT [InvoiceApartment].[ID]
      ,[date_release] as dateRelease
      ,[date_paid] as datePaid
      ,[status]
      ,[Tenant].[name] as [owner]
	  ,amount
	  ,[invoice_of] as [invoiceOf]
	FROM [dbo].[InvoiceApartment] inner join [Tenant] on [invoice_of] = [Tenant].ID
		Join work_tmp on [InvoiceApartment].[ID] = [detail_of]
	Order by [date_release] DESC DESC, [InvoiceApartment].[ID]
END

GO

-- Phan trang, lấy từ start đến end - 1
CREATE PROC InvoiceApartment_GetByRowNumber
@start int,
@end int
AS
BEGIN
	With work_tmp as (
		SELECT 
			ROW_NUMBER() OVER (ORDER BY [date_release] DESC, [InvoiceApartment].[ID]) as row#
			,[InvoiceApartment].[ID] as [ID]
			,[date_release]
			,[date_paid]
			,[status]
			,[Tenant].[name] as [owner]
		FROM [dbo].[InvoiceApartment] inner join [Tenant] on [invoice_of] = [Tenant].ID
	)
	SELECT 
			[ID]
			,[date_release] as dateRelease
			,[date_paid] as datePaid
			,[status]
			,[owner]
	FROM work_tmp
	Where row# >= @start and row# < @end
	Order by row#
END
GO

-- Lấy Invoice có id = @id
CREATE PROC InvoiceApartment_GetById
@id int
AS
BEGIN
	SELECT [InvoiceApartment].[ID]
      ,[date_release] as dateRelease
      ,[date_paid] as datePaid
      ,[status]
      ,[Tenant].[name] as [owner]
	  ,[invoice_of] as [invoiceOf]
	FROM [dbo].[InvoiceApartment] inner join [Tenant] on [invoice_of] = [Tenant].ID
	WHERE [InvoiceApartment].[ID] = @id
END
GO

-- Lấy tất cả Invoice của Tenant có id = @id
CREATE PROC InvoiceApartment_GetByTenantId
@id int
AS
BEGIN
	SELECT [InvoiceApartment].[ID]
      ,[date_release] as dateRelease
      ,[date_paid] as datePaid
      ,[status]
      ,[Tenant].[name] as [owner]
	FROM [dbo].[InvoiceApartment] inner join [Tenant] on [invoice_of] = [Tenant].[ID]
	WHERE [Tenant].[ID] = @id
	ORDER BY date_release DESC
END
GO

-- Dung để phân trang cho tai khoan tentant
CREATE PROC InvoiceApartment_GetByTenantIdRowNumber
@id int,
@start int,
@end int
AS
BEGIN
	With work_tmp as (
		SELECT 
			ROW_NUMBER() OVER (ORDER BY [date_release] DESC, [InvoiceApartment].[ID]) as row#
			,[InvoiceApartment].[ID]
			,[date_release]
			,[date_paid]
			,[status]
			,[Tenant].[name] as [owner]
			FROM [dbo].[InvoiceApartment] inner join [Tenant] on [invoice_of] = [Tenant].[ID]
			WHERE [Tenant].[ID] = @id
	)
	SELECT 
			[ID]
			,[date_release] as dateRelease
			,[date_paid] as datePaid
			,[status]
			,[owner]
	FROM work_tmp
	Where row# >= 2 and row# < 4
	Order by row#
END
GO

CREATE PROC InvoiceApartment_GetRowCount
@tenantId int
AS
BEGIN
	IF @tenantId > 0
		Select COUNT(id) as [count]
		From [InvoiceApartment]
		Where [invoice_of] = @tenantId
	else
		Select COUNT(id) as [count]
		From [InvoiceApartment]
END


GO


CREATE PROC Tenant_GetIdNameAll
AS
BEGIN
	SELECT ID, name
	From [Tenant]
END