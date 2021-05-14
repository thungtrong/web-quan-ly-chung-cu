Use ManagerApartment
go
CREATE PROC Complaint_Employee_GetAll
AS
BEGIN
	SELECT * From [dbo].[EmployeeComplaint]
END
GO

CREATE PROC Complaint_Tenant_GetAll
AS
BEGIN
	SELECT * From [dbo].[TenantComplaint]
END
GO

CREATE PROCEDURE Complaint_Employee_GetById
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[EmployeeComplaint]
	Where [EmployeeComplaint].[ID] = @id
END
GO

CREATE PROCEDURE Complaint_Tenant_GetById
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[TenantComplaint]
	Where [TenantComplaint].[ID] = @id
END
GO

CREATE PROC Complaint_Employee_Insert
    @title nvarchar(200),
    @content nvarchar(MAX),
    @date_release date,
    @creator int
AS
BEGIN
	INSERT INTO [dbo].[EmployeeComplaint]
           ([title]
           ,[content]
           ,[date_submit]
           ,[complaint_of])
     VALUES
           (@title
           ,@content
           ,@date_release
           ,@creator);
END
GO

CREATE PROC Complaint_Tenant_Insert
    @title nvarchar(200),
    @content nvarchar(MAX),
    @date_release date,
    @creator int
AS
BEGIN
	INSERT INTO [dbo].[TenantComplaint]
           ([title]
           ,[content]
           ,[date_submit]
           ,[complaint_of])
     VALUES
           (@title
           ,@content
           ,@date_release
           ,@creator);
END
GO

CREATE PROC Complaint_Tenant_DeleteByID
@id int
AS
BEGIN
	DELETE FROM [dbo].[TenantComplaint]
	WHERE ID = @id
END

GO

CREATE PROC Complaint_Employee_DeleteByID
@id int
AS
BEGIN
	DELETE FROM [dbo].[EmployeeComplaint]
	WHERE ID = @id
END

GO
