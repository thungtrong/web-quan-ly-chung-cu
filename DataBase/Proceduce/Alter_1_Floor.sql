use [ManagerApartment];
go
ALTER PROCEDURE Floor_Insert
	@name nvarchar(10),
	@description nvarchar(max)
AS
BEGIN
	INSERT INTO [dbo].[Floor]
           ([name]
           ,[description])
     VALUES
           (@name
           ,@description);
END
GO