use [ManagerApartment];
go


ALTER PROC AdminAccount_GetByUserNamePassword
@username varchar(100),
@password varchar(32),
@authority int
AS
BEGIN
	SELECT 
		[ID]
		,[name]
		,[email]
		,[phone_number] as phoneNumber
	From [Admin] join [AdminAccount]
	On [account_of] = [ID]
	Where username = @username 
	AND [password] = @password
	AND [authority] = @authority
END
GO

ALTER PROC EmployeeAccount_GetByUserNamePassword
@username varchar(100),
@password varchar(32)
AS
BEGIN
	SELECT 
		[ID]
		,[name]
		,[email]
		,[phone_number] as phoneNumber
	From [Employee] join [EmployeeAccount]
	On [account_of] = [ID]
	Where username = @username and [password] = @password
END
GO

ALTER PROC TenantAccount_GetByUserNamePassword
@username varchar(100),
@password varchar(32)
AS
BEGIN
	SELECT 
		[ID]
		,[name]
		,[email]
		,[phone_number] as phoneNumber
	From [Tenant] join [TenantAccount]
	On [account_of] = [ID]
	Where username = @username and [password] = @password
END
GO



-- Set password mặt định là 123456
GO
Update [AdminAccount]
SET [password] = 'e10adc3949ba59abbe56e057f20f883e'

GO

Update [TenantAccount]
SET [password] = 'e10adc3949ba59abbe56e057f20f883e'

GO
Update [EmployeeAccount]
SET [password] = 'e10adc3949ba59abbe56e057f20f883e'
