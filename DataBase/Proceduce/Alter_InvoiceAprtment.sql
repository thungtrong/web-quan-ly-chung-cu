-- =============================================
-- Author:		Trần Hưng Trọng	
-- CREATE date: 21/04/2021
-- Description:	Sửa đổi proceduce của bảng InvoiceApartment
-- =============================================

-- Sửa đổi để tính tổng giá trị của hoá đơn
Alter PROC InvoiceApartment_GetAll
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
	FROM [dbo].[InvoiceApartment] inner join [Tenant] on [invoice_of] = [Tenant].ID
		Join work_tmp on [InvoiceApartment].[ID] = [detail_of]
	Order by [date_release] DESC, [InvoiceApartment].[ID]
END