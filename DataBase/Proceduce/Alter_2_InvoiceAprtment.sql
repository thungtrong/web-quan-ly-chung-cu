Use ManagerApartment
GO
CREATE PROC InvoiceApartment_GetAllByTenantId
@tenantId int
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
		WHERE [invoice_of] = @tenantId
		Order by [date_release] DESC DESC, [InvoiceApartment].[ID]
END