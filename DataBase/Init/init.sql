CREATE DATABASE ManagerApartment;
go

use ManagerApartment;
go
-- Khop nguoi thue
CREATE TABLE Apartment
(
	[ID] int IDENTITY(1, 1),
	[name] varchar(100) unique,
	[floor] int,
	[status] int,
	[description] varchar(MAX),
	[payment_per_month] int,
	Constraint PK_Apartment Primary key ([ID])
);
go

Create table Equipment
(
	[ID] int IDENTITY(1, 1),
	[name] varchar(100),
	[count] int,
	[equipment_of] int,
	Constraint PK_Equipment Primary key ([ID]),
	Constraint FK_ID_Apartment_Equipment 
			Foreign key ([equipment_of]) REFERENCES Apartment([ID]) ON DELETE CASCADE
);

go

Create table Indicator
(
	[ID] int IDENTITY (1, 1),
	[gas] int,
	[water] int,
	[eletric] int,
	[date_release] Date,
	[owner] int,
	Constraint PK_Indicator Primary key ([ID]),
	Constraint FK_ID_Apartment_Indicator Foreign key ([owner]) REFERENCES Apartment([ID]) ON DELETE CASCADE
);

go

Create table Tenant
(
	[ID] int Identity(1, 1),
	[name] varchar(100),
	[email] varchar(200),
	[phone_number] varchar(15),
	[advance_payment] int,
	[rented_apartment] int,
	Constraint PK_Tenant Primary key ([ID]),
	Constraint FK_ID_Apartment_Tenant Foreign key ([rented_apartment]) REFERENCES Apartment([ID]) ON DELETE CASCADE
);

go

Create table TenantAccount
(
	[username] varchar(100),
	[password] varchar(32),
	account_of int,
	Constraint PK_TenantAccount Primary key ([username]),
	Constraint FK_ID_Tenant_TenantAccount Foreign key ([account_of]) REFERENCES Tenant([ID]) ON DELETE CASCADE
);

go

Create table TenantComplaint
(
	[ID] int Identity(1, 1),
	[title] varchar(100),
	[date_submit] date,
	[content] varchar(MAX),
	complaint_of int,
	Constraint PK_TenantComplaint Primary key ([ID]),
	Constraint FK_ID_Tenant_TenantComplaint Foreign key ([complaint_of]) References Tenant([ID]) ON DELETE CASCADE
);

go

Create table InvoiceApartment
(
	[ID] int Identity(1, 1),
	[date_release] date,
	[date_paid] date,
	[status] bit,
	[invoice_of] int,
	Constraint PK_InvoiceApartment Primary key ([ID]),
	Constraint FK_ID_Tenant_InvoiceApartment Foreign key ([invoice_of]) References Tenant([ID]) ON DELETE CASCADE
);

go

Create table DeltailInvoice
(
	[ID] int identity(1, 1),
	[name] varchar(50),
	[amount] int,
	[detail_of] int,
	Constraint PK_DeltailInvoice Primary key ([ID]),
	Constraint FK_ID_InvoiceApartment_DeltailInvoice Foreign key ([detail_of]) References InvoiceApartment([ID]) ON DELETE CASCADE
);

go
-- Khop nhan vien
Create table Employee
(
	[ID] int Identity(1, 1),
	[name] varchar(100),
	[email] varchar(150),
	[phone_number] varchar(15),
	[address] varchar(250),
	[join_date] date,
	[position] varchar(100),
	[salary] int,
	[description] varchar(MAX),
	Constraint PK_Employee Primary key ([ID]),
);


Create table EmployeeAccount
(
	[username] varchar(100),
	[password] varchar(32),
	[account_of] int,
	Constraint PK_EmployeeAccount Primary key ([username]),
	Constraint FK_ID_Employee_EmployeeAccount Foreign key ([account_of]) REFERENCES Employee([ID]) ON DELETE CASCADE
);

go

Create table EmployeeComplaint
(
	[ID] int Identity(1, 1),
	[title] varchar(100),
	[date_submit] date,
	[content] varchar(MAX),
	[complaint_of] int,
	Constraint PK_EmployeeComplaint Primary key ([ID]),
	Constraint FK_ID_Employee_EmployeeComplaint Foreign key ([complaint_of]) References Employee([ID]) ON DELETE CASCADE
);

GO

Create table EmployeeForm
(
	[ID] int IDENTITY(1, 1),
	[form_title] VARCHAR(1000),
	[date_submit] date,
	[status] int,
	[desciption] VARCHAR(MAX),
	[form_of] int,
	CONSTRAINT PK_EmlpoyeeForm PRIMARY KEY ([ID]),
	CONSTRAINT FK_ID_Employee_EmployeeForm FOREIGN KEY ([form_of]) REFERENCES Employee([ID]) ON DELETE CASCADE
);
go
-- Khop ADMIN
CREATE TABLE [Admin](
	[ID] int IDENTITY(1, 1),
	[name] VARCHAR(100),
	[email] VARCHAR(200),
	[phone_number] VARCHAR(15),
	[authority] int,
	CONSTRAINT PK_Admin PRIMARY KEY ([ID])
);

GO

Create TABLE [AdminAccount](
	[username] VARCHAR(100),
	[password] VARCHAR(32),
	[account_of] INT,
	CONSTRAINT PK_AdminAccount PRIMARY KEY([username]),
	CONSTRAINT FK_ID_Admin_AdminAccount Foreign KEY ([account_of]) REFERENCES [Admin] ([ID]) ON DELETE CASCADE
);

GO

Create table AdminComplaint
(
	[ID] int Identity(1, 1),
	[title] varchar(100),
	[date_submit] date,
	[content] varchar(MAX),
	[complaint_of] int,
	Constraint PK_AdminComplaint Primary key ([ID]),
	Constraint FK_ID_Admin_AdminComplaint Foreign key ([complaint_of]) References [Admin]([ID]) ON DELETE CASCADE
);

GO

Create TABLE [Notification](
	[ID] int IDENTITY(1, 1),
	[title] VARCHAR(200),
	[content] VARCHAR(MAX),
	[date_release] DATE,
	[creator] int,
	CONSTRAINT PK_Notification PRIMARY KEY ([ID]),
	CONSTRAINT FK_ID_Admin_Notification FOREIGN KEY ([creator]) REFERENCES [Admin]([ID]) ON DELETE CASCADE
);

GO

Create table [Maintenance](
	[ID] int IDENTITY(1, 1),
	[title] VARCHAR(200),
	[date_create] DATE,
	[amount] int,
	[status] int,
	[description] VARCHAR(MAX),
	[creator] INT,
	CONSTRAINT PK_Maintenance PRIMARY KEY ([ID]),
	CONSTRAINT FK_Admin_Mainteance FOREIGN KEY ([creator]) REFERENCES [Admin]([ID]) ON DELETE CASCADE
);
GO

Create TABLE [InvoiceBuilding](
	[ID] int IDENTITY(1,1),
	[title] VARCHAR(200),
	[date_create] DATE,
	[amount] int,
	[status] int,
	[description] VARCHAR(MAX),
	[creator] INT,
	CONSTRAINT PK_InvoiceBuilding PRIMARY KEY ([ID]),
	CONSTRAINT FK_Admin_InvoiceBuilding FOREIGN KEY ([creator]) REFERENCES [Admin]([ID]) ON DELETE CASCADE
);