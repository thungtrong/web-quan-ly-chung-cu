use ManagerApartment;
go

--  Editor : Nghiêm Minh Tiến
--	Edit time : 23/04/2021
--  Description : Bổ sung table Floor và khóa ngoại của apartment
-- Edit: Nhan Pham
-- Cot id không có Identity(), Thêm Identity
-- Xoa bang cua va tạo lại bảng mới
Create TABLE [Floor](
	[ID] int identity(1,1),
	[name] nvarchar(10),
	[description] nvarchar(MAX),
	CONSTRAINT PK_Floor PRIMARY KEY ([ID]),
);
go

Alter TABLE [Apartment] ADD Constraint FK_ID_Floor_Apartment
Foreign key ([floor]) REFERENCES [Floor]([ID]) ON DELETE CASCADE