-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AdminAccount_EditPassword 
	@password varchar(32),
	@newpassword varchar(32),
	@account_of int
AS
BEGIN
	DECLARE @return_value int = (SELECT COUNT(*)
			FROM AdminAccount 
			WHERE [password] = @password and account_of = @account_of);
	
	IF @return_value = 0
		SELECT *
		FROM AdminAccount1

	UPDATE [dbo].[AdminAccount]
	SET 
      [password] = @newpassword
	WHERE [password] = @password and account_of = @account_of;
END
GO
CREATE PROCEDURE EmployeeAccount_EditPassword 
	@password varchar(32),
	@newpassword varchar(32),
	@account_of int
AS
BEGIN
	DECLARE @return_value int = (SELECT COUNT(*)
			FROM EmployeeAccount 
			WHERE [password] = @password and account_of = @account_of);
	
	IF @return_value = 0
		SELECT *
		FROM AdminAccount1

	UPDATE [dbo].[EmployeeAccount]
	SET 
      [password] = @newpassword
	WHERE [password] = @password and account_of = @account_of;
END
GO

GO
CREATE PROCEDURE TenantAccount_EditPassword 
	@password varchar(32),
	@newpassword varchar(32),
	@account_of int
AS
BEGIN
	DECLARE @return_value int = (SELECT COUNT(*)
			FROM TenantAccount 
			WHERE [password] = @password and account_of = @account_of);
	
	IF @return_value = 0
		SELECT *
		FROM AdminAccount1

	UPDATE [dbo].[TenantAccount]
	SET 
      [password] = @newpassword
	WHERE [password] = @password and account_of = @account_of;
END
GO