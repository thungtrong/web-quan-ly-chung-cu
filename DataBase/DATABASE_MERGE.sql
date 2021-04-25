USE [ManagerApartment]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [varchar](200) NULL,
	[phone_number] [varchar](15) NULL,
	[authority] [int] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminAccount]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccount](
	[username] [varchar](100) NOT NULL,
	[password] [varchar](32) NULL,
	[account_of] [int] NULL,
 CONSTRAINT [PK_AdminAccount] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminComplaint]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminComplaint](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[date_submit] [date] NULL,
	[content] [nvarchar](max) NULL,
	[complaint_of] [int] NULL,
 CONSTRAINT [PK_AdminComplaint] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[floor] [int] NULL,
	[status] [bit] NULL,
	[description] [nvarchar](max) NULL,
	[payment_per_month] [int] NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeltailInvoice]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeltailInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[amount] [int] NULL,
	[detail_of] [int] NULL,
 CONSTRAINT [PK_DeltailInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [varchar](150) NULL,
	[phone_number] [varchar](15) NULL,
	[address] [nvarchar](250) NULL,
	[join_date] [date] NULL,
	[salary] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAccount]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAccount](
	[username] [varchar](100) NOT NULL,
	[password] [varchar](32) NULL,
	[account_of] [int] NULL,
 CONSTRAINT [PK_EmployeeAccount] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeComplaint]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeComplaint](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[date_submit] [date] NULL,
	[content] [nvarchar](max) NULL,
	[complaint_of] [int] NULL,
 CONSTRAINT [PK_EmployeeComplaint] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeForm]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeForm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[form_title] [nvarchar](1000) NULL,
	[date_submit] [date] NULL,
	[status] [int] NULL,
	[desciption] [varchar](max) NULL,
	[form_of] [int] NULL,
 CONSTRAINT [PK_EmlpoyeeForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[count] [int] NULL,
	[equipment_of] [int] NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Floor]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Floor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicator]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicator](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[gas] [int] NULL,
	[water] [int] NULL,
	[eletric] [int] NULL,
	[date_release] [date] NULL,
	[owner] [int] NULL,
 CONSTRAINT [PK_Indicator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceApartment]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceApartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[date_release] [date] NULL,
	[date_paid] [date] NULL,
	[status] [bit] NULL,
	[invoice_of] [int] NULL,
 CONSTRAINT [PK_InvoiceApartment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceBuilding]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceBuilding](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NULL,
	[date_create] [date] NULL,
	[amount] [int] NULL,
	[status] [bit] NULL,
	[description] [nvarchar](max) NULL,
	[creator] [int] NULL,
 CONSTRAINT [PK_InvoiceBuilding] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maintenance]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintenance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NULL,
	[date_create] [date] NULL,
	[amount] [int] NULL,
	[status] [int] NULL,
	[description] [nvarchar](max) NULL,
	[creator] [int] NULL,
 CONSTRAINT [PK_Maintenance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NULL,
	[content] [nvarchar](max) NULL,
	[date_release] [date] NULL,
	[creator] [int] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [varchar](200) NULL,
	[phone_number] [varchar](15) NULL,
	[advance_payment] [int] NULL,
	[rented_apartment] [int] NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenantAccount]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantAccount](
	[username] [varchar](100) NOT NULL,
	[password] [varchar](32) NULL,
	[account_of] [int] NULL,
 CONSTRAINT [PK_TenantAccount] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenantComplaint]    Script Date: 25/4/2021 6:12:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantComplaint](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[date_submit] [date] NULL,
	[content] [nvarchar](max) NULL,
	[complaint_of] [int] NULL,
 CONSTRAINT [PK_TenantComplaint] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([ID], [name], [email], [phone_number], [authority]) VALUES (1, N'Trần Hưng Trọng', N'tranhungtrong@gmail.com', N'0939943056', 0)
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
INSERT [dbo].[AdminAccount] ([username], [password], [account_of]) VALUES (N'tranhungtrong', N'123456', 1)
GO
SET IDENTITY_INSERT [dbo].[Apartment] ON 

INSERT [dbo].[Apartment] ([ID], [name], [floor], [status], [description], [payment_per_month]) VALUES (1, N'Can Ho 1A', 1, 1, N'True', 1000000)
INSERT [dbo].[Apartment] ([ID], [name], [floor], [status], [description], [payment_per_month]) VALUES (2, N'Apartment2B', 2, 1, NULL, 1000000)
INSERT [dbo].[Apartment] ([ID], [name], [floor], [status], [description], [payment_per_month]) VALUES (4, N'Can ho 3A', 3, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Apartment] OFF
GO
SET IDENTITY_INSERT [dbo].[DeltailInvoice] ON 

INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (1, N'Water', 200000, 1)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (2, N'Electric', 300000, 1)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (3, N'Gas', 100000, 1)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (4, N'Water', 279128, 2)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (5, N'Electric', 123461, 2)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (6, N'Gas', 63822, 2)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (10, N'Water', 35324, 4)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (11, N'Electric', 15562, 4)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (12, N'Gas', 68871, 4)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (13, N'Internet', 120000, 1)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (16, N'Rác', 13213, 8)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (17, N'Gửi xe', 123, 8)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (18, N'Other', 12092, 9)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (19, N'Dien', 100000, 10)
INSERT [dbo].[DeltailInvoice] ([ID], [name], [amount], [detail_of]) VALUES (20, N'Nuoc', 14000, 10)
SET IDENTITY_INSERT [dbo].[DeltailInvoice] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [name], [email], [phone_number], [address], [join_date], [salary], [description]) VALUES (1, N'Tran Bao Loc', N'baoloc@gmail.com', N'09763843289', N'320 Nguyen Huu Tho', CAST(N'2021-04-25' AS Date), 10000000, N'Nhan vien moi 1')
INSERT [dbo].[Employee] ([ID], [name], [email], [phone_number], [address], [join_date], [salary], [description]) VALUES (3, N'Nhan vien 1', N'nhanvien@gmail.com', N'093736227291', N'320 Nguyen Thi Thap', CAST(N'2021-04-25' AS Date), 17228, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([ID], [name], [count], [equipment_of]) VALUES (2, N'May loc nuoc', 2, 4)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Floor] ON 

INSERT [dbo].[Floor] ([ID], [name], [description]) VALUES (1, N'Floor 1', NULL)
INSERT [dbo].[Floor] ([ID], [name], [description]) VALUES (2, N'Floor 2', NULL)
INSERT [dbo].[Floor] ([ID], [name], [description]) VALUES (3, N'Floor 3', NULL)
INSERT [dbo].[Floor] ([ID], [name], [description]) VALUES (4, N'Floor 4', NULL)
SET IDENTITY_INSERT [dbo].[Floor] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceApartment] ON 

INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (1, CAST(N'2021-02-22' AS Date), CAST(N'2021-02-26' AS Date), 1, 1)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (2, CAST(N'2021-03-22' AS Date), CAST(N'2021-03-27' AS Date), 1, 1)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (4, CAST(N'2021-04-22' AS Date), NULL, 0, 2)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (5, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 1, 2)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (6, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 1, 2)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (7, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 1, 2)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (8, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 1, 2)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (9, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 1, 1)
INSERT [dbo].[InvoiceApartment] ([ID], [date_release], [date_paid], [status], [invoice_of]) VALUES (10, CAST(N'2021-04-25' AS Date), CAST(N'2021-04-25' AS Date), 1, 4)
SET IDENTITY_INSERT [dbo].[InvoiceApartment] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceBuilding] ON 

INSERT [dbo].[InvoiceBuilding] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (1, N'Gas', CAST(N'2021-01-23' AS Date), 2340100, 1, NULL, 1)
INSERT [dbo].[InvoiceBuilding] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (2, N'Water', CAST(N'2021-01-24' AS Date), 2937100, 1, NULL, 1)
INSERT [dbo].[InvoiceBuilding] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (4, N'Electric', CAST(N'2021-04-23' AS Date), 200000, 1, N'Dien thang 5', 1)
INSERT [dbo].[InvoiceBuilding] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (5, N'Electric', CAST(N'2021-04-25' AS Date), 14289111, 1, N'Dien thang 5', 1)
SET IDENTITY_INSERT [dbo].[InvoiceBuilding] OFF
GO
SET IDENTITY_INSERT [dbo].[Maintenance] ON 

INSERT [dbo].[Maintenance] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (1, N'Tường tầng 1', CAST(N'2021-01-12' AS Date), 1200000, 1, N'Duong gas bi vo', 1)
INSERT [dbo].[Maintenance] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (5, N'Electric', CAST(N'2021-04-23' AS Date), 200000, 1, N'Dien thang 5', 1)
INSERT [dbo].[Maintenance] ([ID], [title], [date_create], [amount], [status], [description], [creator]) VALUES (6, N'Thanh toán hoá đơn tháng 5', CAST(N'2021-04-25' AS Date), 11212121, 0, N'13123123 sadadasdas', 1)
SET IDENTITY_INSERT [dbo].[Maintenance] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([ID], [title], [content], [date_release], [creator]) VALUES (1, N'hjks', N'jknsdndsk', CAST(N'2021-04-04' AS Date), 1)
INSERT [dbo].[Notification] ([ID], [title], [content], [date_release], [creator]) VALUES (2, N'Thanh toán hoá đơn tháng 5', N'Chúng tôi đã cập nhật thông tin hoá đơn cho các căn hộ trong tháng 5.
Chủ hộ có trách nhiệm kiểm tra và thanh toán hoá đơn trước 10/5', CAST(N'2021-04-22' AS Date), 1)
INSERT [dbo].[Notification] ([ID], [title], [content], [date_release], [creator]) VALUES (3, N'Thanh toán hoá đơn tháng 6', N'Thông báo thử nghiệm
Thông báo thử nghiệm
Thông báo thử nghiệmThông báo thử nghiệm
Thông báo thử nghiệm
Thông báo thử nghiệm
Thông báo thử nghiệm 
Thông báo thử nghiệm', CAST(N'2021-04-22' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[Tenant] ON 

INSERT [dbo].[Tenant] ([ID], [name], [email], [phone_number], [advance_payment], [rented_apartment]) VALUES (1, N'Trần Thanh Phong', N'tranthanhphong@gmail.com', N'09884572382', 1000000, 1)
INSERT [dbo].[Tenant] ([ID], [name], [email], [phone_number], [advance_payment], [rented_apartment]) VALUES (2, N'Nguyễn Thanh Phúc', N'nguyenthanhphuc@gmail.com', N'09283682912', 1000000, 2)
INSERT [dbo].[Tenant] ([ID], [name], [email], [phone_number], [advance_payment], [rented_apartment]) VALUES (4, N'Dan cu 1', N'dancu1@gmail.com', N'03783903739', 1400000, NULL)
SET IDENTITY_INSERT [dbo].[Tenant] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Apartmen__72E12F1BAFB9AF45]    Script Date: 25/4/2021 6:12:20 PM ******/
ALTER TABLE [dbo].[Apartment] ADD UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminAccount]  WITH CHECK ADD  CONSTRAINT [FK_ID_Admin_AdminAccount] FOREIGN KEY([account_of])
REFERENCES [dbo].[Admin] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminAccount] CHECK CONSTRAINT [FK_ID_Admin_AdminAccount]
GO
ALTER TABLE [dbo].[AdminComplaint]  WITH CHECK ADD  CONSTRAINT [FK_ID_Admin_AdminComplaint] FOREIGN KEY([complaint_of])
REFERENCES [dbo].[Admin] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminComplaint] CHECK CONSTRAINT [FK_ID_Admin_AdminComplaint]
GO
ALTER TABLE [dbo].[Apartment]  WITH CHECK ADD  CONSTRAINT [FK_ID_Floor_Apartment] FOREIGN KEY([floor])
REFERENCES [dbo].[Floor] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Apartment] CHECK CONSTRAINT [FK_ID_Floor_Apartment]
GO
ALTER TABLE [dbo].[DeltailInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ID_InvoiceApartment_DeltailInvoice] FOREIGN KEY([detail_of])
REFERENCES [dbo].[InvoiceApartment] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeltailInvoice] CHECK CONSTRAINT [FK_ID_InvoiceApartment_DeltailInvoice]
GO
ALTER TABLE [dbo].[EmployeeAccount]  WITH CHECK ADD  CONSTRAINT [FK_ID_Employee_EmployeeAccount] FOREIGN KEY([account_of])
REFERENCES [dbo].[Employee] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeAccount] CHECK CONSTRAINT [FK_ID_Employee_EmployeeAccount]
GO
ALTER TABLE [dbo].[EmployeeComplaint]  WITH CHECK ADD  CONSTRAINT [FK_ID_Employee_EmployeeComplaint] FOREIGN KEY([complaint_of])
REFERENCES [dbo].[Employee] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeComplaint] CHECK CONSTRAINT [FK_ID_Employee_EmployeeComplaint]
GO
ALTER TABLE [dbo].[EmployeeForm]  WITH CHECK ADD  CONSTRAINT [FK_ID_Employee_EmployeeForm] FOREIGN KEY([form_of])
REFERENCES [dbo].[Employee] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeForm] CHECK CONSTRAINT [FK_ID_Employee_EmployeeForm]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_ID_Apartment_Equipment] FOREIGN KEY([equipment_of])
REFERENCES [dbo].[Apartment] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_ID_Apartment_Equipment]
GO
ALTER TABLE [dbo].[Indicator]  WITH CHECK ADD  CONSTRAINT [FK_ID_Apartment_Indicator] FOREIGN KEY([owner])
REFERENCES [dbo].[Apartment] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Indicator] CHECK CONSTRAINT [FK_ID_Apartment_Indicator]
GO
ALTER TABLE [dbo].[InvoiceApartment]  WITH CHECK ADD  CONSTRAINT [FK_ID_Tenant_InvoiceApartment] FOREIGN KEY([invoice_of])
REFERENCES [dbo].[Tenant] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceApartment] CHECK CONSTRAINT [FK_ID_Tenant_InvoiceApartment]
GO
ALTER TABLE [dbo].[InvoiceBuilding]  WITH CHECK ADD  CONSTRAINT [FK_Admin_InvoiceBuilding] FOREIGN KEY([creator])
REFERENCES [dbo].[Admin] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceBuilding] CHECK CONSTRAINT [FK_Admin_InvoiceBuilding]
GO
ALTER TABLE [dbo].[Maintenance]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Mainteance] FOREIGN KEY([creator])
REFERENCES [dbo].[Admin] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Maintenance] CHECK CONSTRAINT [FK_Admin_Mainteance]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_ID_Admin_Notification] FOREIGN KEY([creator])
REFERENCES [dbo].[Admin] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_ID_Admin_Notification]
GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK_ID_Apartment_Tenant] FOREIGN KEY([rented_apartment])
REFERENCES [dbo].[Apartment] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK_ID_Apartment_Tenant]
GO
ALTER TABLE [dbo].[TenantAccount]  WITH CHECK ADD  CONSTRAINT [FK_ID_Tenant_TenantAccount] FOREIGN KEY([account_of])
REFERENCES [dbo].[Tenant] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TenantAccount] CHECK CONSTRAINT [FK_ID_Tenant_TenantAccount]
GO
ALTER TABLE [dbo].[TenantComplaint]  WITH CHECK ADD  CONSTRAINT [FK_ID_Tenant_TenantComplaint] FOREIGN KEY([complaint_of])
REFERENCES [dbo].[Tenant] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TenantComplaint] CHECK CONSTRAINT [FK_ID_Tenant_TenantComplaint]
GO
/****** Object:  StoredProcedure [dbo].[Apartment_DeleteByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Apartment_DeleteByID]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Apartment]
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Apartment_EditByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Apartment_EditByID]
	@id int,
	@name nvarchar(100),
	@floor int,
    @description nvarchar(MAX),
	@status bit
AS
BEGIN
	
	UPDATE [dbo].[Apartment]
	SET  
		[name] = @name
		,[floor] = @floor
		,[description] = @description
		,[status] = @status
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Apartment_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Apartment_GetAll]
AS
BEGIN
	SELECT [Apartment].[ID]
		  ,[Apartment].[name]
		  ,[floor]
		  ,[status]
		  ,[Apartment].[description]
		  ,[payment_per_month] as [paymentPerMonth]
		  ,[Floor].[name] as [floorName]
	  FROM [dbo].[Apartment] join [Floor]
	  ON [floor] = [FLOOR].[ID]
END
GO
/****** Object:  StoredProcedure [dbo].[Apartment_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Apartment_GetById]
	@id int
AS
BEGIN
	SELECT [Apartment].[ID]
		  ,[Apartment].[name]
		  ,[floor]
		  ,[status]
		  ,[Apartment].[description]
		  ,[payment_per_month] as [paymentPerMonth]
		  ,[Floor].[name] as [floorName]
	  FROM [dbo].[Apartment] join [Floor]
	  ON [floor] = [FLOOR].[ID]
	Where [Apartment].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Apartment_GetIdNameAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- chi lay ve ten va id
CREATE PROC [dbo].[Apartment_GetIdNameAll]
AS
BEGIN
	SELECT [Apartment].[ID]
		  ,[Apartment].[name]
	  FROM [dbo].[Apartment] 

END
GO
/****** Object:  StoredProcedure [dbo].[Apartment_Insert]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Apartment_Insert]
	@name nvarchar(100),
	@floor int,
	@description nvarchar(max),
	@status bit
AS
BEGIN
	INSERT INTO [dbo].[Apartment]
           (
           [name]
		   ,[floor]
           ,[description]
		   ,[status])
     VALUES
           (
           @name
		   ,@floor
           ,@description
		   ,@status);
END

GO
/****** Object:  StoredProcedure [dbo].[DetailInvoice_Create]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DetailInvoice_Create]
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
/****** Object:  StoredProcedure [dbo].[DetailInvoice_DeleteByIdDetailOf]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DetailInvoice_DeleteByIdDetailOf]
@id int,
@detail_of int
AS
BEGIN
	DELETE FROM DeltailInvoice
	WHERE [ID] = @id and [detail_of] = @detail_of
END
GO
/****** Object:  StoredProcedure [dbo].[DetailInvoice_EditById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DetailInvoice_EditById]
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
/****** Object:  StoredProcedure [dbo].[DetailInvoice_GetByDetailOf]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- Alter date: 21/04/2021
-- Description:	Proceduce cho modul quản lý thông báo
-- =============================================
CREATE PROC [dbo].[DetailInvoice_GetByDetailOf]
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
/****** Object:  StoredProcedure [dbo].[Employee_Create]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Employee_Create]
@name nvarchar(100),
@email varchar(150),
@phone_number varchar(15),
@address nvarchar(250),
@join_date date,
@salary int,
@description nvarchar(max)
AS
BEGIN
	INSERT INTO [dbo].[Employee]
           ([name]
           ,[email]
           ,[phone_number]
           ,[address]
           ,[join_date] 
           ,[salary]
           ,[description])
     VALUES
           (
		   @name,
           @email,
           @phone_number,
           @address,
           @join_date,
           @salary,
           @description)
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_DeleteById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Employee_DeleteById]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Employee]
    WHERE [ID] = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Employee_EditById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Employee_EditById]
@id int,
@name nvarchar(100),
@email varchar(150),
@phone_number varchar(15),
@address nvarchar(250),
@join_date date,
@salary int,
@description nvarchar(max)
AS
BEGIN
	UPDATE [dbo].[Employee]
	   SET [name] = @name
           ,[email] = @email
           ,[phone_number] = @phone_number
           ,[address] = @address
           ,[join_date] = @join_date
           ,[salary] = @salary
           ,[description] = @description
	 WHERE [Employee].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Employee_GetAll]
AS
BEGIN
	SELECT [Employee].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[address]
           ,[join_date] as [joinDate]
           ,[salary]
           ,[description]
	FROM [dbo].[Employee]
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Employee_GetById]
@id int
AS
BEGIN
	SELECT [Employee].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[address]
           ,[join_date] as [joinDate]
           ,[salary]
           ,[description]
	FROM [dbo].[Employee]
    WHERE [Employee].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Equipment_DeleteByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Equipment_DeleteByID]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Equipment]
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Equipment_EditByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Equipment_EditByID]
	@id int,
    @name nvarchar(100),
	@count int,
    @equipment_of int
AS
BEGIN
	
	UPDATE [dbo].[Equipment]
	SET  [name] = @name
		,[count] = @count
		,[equipment_of]=@equipment_of
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Equipment_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Equipment_GetAll]
AS
BEGIN
	SELECT [Equipment].[ID]
      ,[Equipment].[name]
      ,[count]
      ,[equipment_of] as [equipmentOf]
	  ,[Apartment].[name] as [apartmentName]
  FROM [dbo].[Equipment] join [Apartment]
  ON [equipment_of] = [Apartment].[ID]
END
GO
/****** Object:  StoredProcedure [dbo].[Equipment_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Equipment_GetById]
	@id int
AS
BEGIN
	SELECT [Equipment].[ID]
		  ,[Equipment].[name]
		  ,[count]
		  ,[equipment_of] as [equipmentOf]
		  ,[Apartment].[name] as [apartmentName]
	FROM [dbo].[Equipment] join [Apartment]
	ON [equipment_of] = [Apartment].[ID]
	Where [Equipment].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Equipment_Insert]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Equipment_Insert]
	@name nvarchar(100),
	@count int,
	@equipment_of int
AS
BEGIN
	INSERT INTO [dbo].[Equipment]
           ([name]
		   ,[count]
           ,[equipment_of])
     VALUES
           (@name
		   ,@count
           ,@equipment_of);
END
GO
/****** Object:  StoredProcedure [dbo].[Floor_DeleteByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Floor_DeleteByID]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Floor]
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Floor_EditByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Floor_EditByID]
	@id int,
    @name nvarchar(10),
    @description nvarchar(MAX)
AS
BEGIN
	
	UPDATE [dbo].[Floor]
	SET  [name] = @name
		,[description] = @description
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Floor_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nghiêm Minh Ti?n	
-- Alter date: 23/04/2021
-- Description:	Proceduce cho modul qu?n lý t?ng

CREATE PROC [dbo].[Floor_GetAll]
AS
BEGIN
	SELECT * From [dbo].[Floor]
END
GO
/****** Object:  StoredProcedure [dbo].[Floor_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Floor_GetById]
	@id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Floor]
	Where [Floor].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Floor_Insert]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Floor_Insert]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_Create]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- ALTER date: 21/04/2021
-- Description:	Proceduce cho modul quản lý thông báo
-- =============================================

CREATE PROC [dbo].[InvoiceApartment_Create]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_DeleteById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InvoiceApartment_DeleteById]
@id int
AS
BEGIN
	DELETE FROM InvoiceApartment
	WHERE [ID] = @id
END

GO
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_EditById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InvoiceApartment_EditById]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_EditStatusById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InvoiceApartment_EditStatusById]
@id int,
@status bit
AS
BEGIN
	UPDATE [dbo].[InvoiceApartment]
	SET [status] = @status
	WHERE [ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Lấy tất cả Invoice
CREATE PROC [dbo].[InvoiceApartment_GetAll]
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
	Order by [date_release] DESC, [InvoiceApartment].[ID]
END

GO
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy Invoice có id = @id
CREATE PROC [dbo].[InvoiceApartment_GetById]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_GetByRowNumber]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Phan trang, lấy từ start đến end - 1
CREATE PROC [dbo].[InvoiceApartment_GetByRowNumber]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_GetByTenantId]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy tất cả Invoice của Tenant có id = @id
CREATE PROC [dbo].[InvoiceApartment_GetByTenantId]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_GetByTenantIdRowNumber]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Dung để phân trang cho tai khoan tentant
CREATE PROC [dbo].[InvoiceApartment_GetByTenantIdRowNumber]
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
/****** Object:  StoredProcedure [dbo].[InvoiceApartment_GetRowCount]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InvoiceApartment_GetRowCount]
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
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_Add]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- ALTER date: 22/04/2021
-- Description:	Proceduce cho modul quản lý hoá đơn toà nhà
-- =============================================
CREATE PROC [dbo].[InvoiceBuilding_Add]
@title nvarchar(200),
@date_create date,
@amount int,
@status bit,
@description nvarchar(max),
@creator int
AS
BEGIN
	INSERT INTO [dbo].[InvoiceBuilding]
			   ([title]
			   ,[date_create]
			   ,[amount]
			   ,[status]
			   ,[description]
			   ,[creator])
		 VALUES
			   (@title,
			   @date_create,
			   @amount,
			   @status,
			   @description,
			   @creator)
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_DeleteById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InvoiceBuilding_DeleteById]
@id int
AS
BEGIN
	DELETE FROM [InvoiceBuilding]
	WHERE [ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_EditById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InvoiceBuilding_EditById]
@id int,
@title nvarchar(200),
@date_create date,
@amount int,
@status bit,
@description nvarchar(max)
AS
BEGIN

	UPDATE [dbo].[InvoiceBuilding]
	   SET [title] = @title
		  ,[date_create] = @date_create
		  ,[amount] = @amount
		  ,[status] = @status
		  ,[description] = @description
	 WHERE [ID] = @id
END

GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_EditStatusById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InvoiceBuilding_EditStatusById]
@id int,
@status bit
AS
BEGIN
	UPDATE	[dbo].[InvoiceBuilding]
	SET		[status] = @status
	WHERE	[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[InvoiceBuilding_GetAll]
AS
BEGIN
	SELECT [InvoiceBuilding].[ID]
			,[title]
			,[date_create] as [dateALTER]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
	FROM [dbo].[InvoiceBuilding] inner join [dbo].[Admin]
		ON [Admin].[ID] = [InvoiceBuilding].[creator]
	ORDER BY [date_create] DESC, [InvoiceBuilding].ID
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[InvoiceBuilding_GetById]
@id int
AS
BEGIN
	SELECT [InvoiceBuilding].[ID]
			,[title]
			,[date_create] as [dateALTER]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
	FROM [dbo].[InvoiceBuilding] inner join [dbo].[Admin]
		ON [Admin].[ID] = [InvoiceBuilding].[creator]
	WHERE [InvoiceBuilding].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_GetByRowNum]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[InvoiceBuilding_GetByRowNum]
@start int,
@end int
AS
BEGIN
	WITH work_tmp AS (
		SELECT 
			ROW_NUMBER() OVER (ORDER BY [date_create] DESC, [InvoiceBuilding].[ID]) as row#
			,[InvoiceBuilding].[ID]
			,[title]
			,[date_create]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
		FROM [dbo].[InvoiceBuilding] inner join [dbo].[Admin]
		ON [Admin].[ID] = [InvoiceBuilding].[creator]
	)
	SELECT 
		[ID]
		,[title]
		,[date_create] as [dateALTER]
		,[amount]
		,[status]
		,[description]
		,[creator]
	FROM work_tmp
	WHERE row# >= @start and row# < @end
END
GO
/****** Object:  StoredProcedure [dbo].[InvoiceBuilding_GetRowCount]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[InvoiceBuilding_GetRowCount]
AS
BEGIN
	SELECT COUNT(ID) as [count]
	FROM InvoiceBuilding
END
GO
/****** Object:  StoredProcedure [dbo].[Maintenance_Add]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- ALTER date: 22/04/2021
-- Description:	Proceduce cho modul quản lý chi phí bảo trì
-- =============================================

CREATE PROC [dbo].[Maintenance_Add]
@title nvarchar(200),
@date_create date,
@amount int,
@status int,
@description nvarchar(max),
@creator int
AS
BEGIN
	INSERT INTO [dbo].[Maintenance]
           ([title]
           ,[date_create]
           ,[amount]
           ,[status]
           ,[description]
           ,[creator])
     VALUES
           (
		   @title,
           @date_create ,
           @amount,
           @status,
           @description ,
           @creator)
END
GO
/****** Object:  StoredProcedure [dbo].[Maintenance_DeleteById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Maintenance_DeleteById]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Maintenance]
    WHERE [ID] = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Maintenance_EditById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Maintenance_EditById]
@id int,
@title nvarchar(200),
@date_create date,
@amount int,
@status int,
@description varchar(max)
AS
BEGIN
	UPDATE [dbo].[Maintenance]
	   SET [title] = @title
		  ,[date_create] = @date_create
		  ,[amount] = @amount
		  ,[status] = @status
		  ,[description] = @description
	 WHERE [Maintenance].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Maintenance_EditStatusById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Maintenance_EditStatusById]
@id int,
@status int
AS
BEGIN
	UPDATE [dbo].[Maintenance]
	   SET [status] = @status
	 WHERE [ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Maintenance_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Maintenance_GetAll]
AS
BEGIN
	SELECT [Maintenance].[ID]
		  ,[title]
		  ,[date_create] as [dateALTER]
		  ,[amount]
		  ,[status]
		  ,[description]
		  ,[Admin].[name] as [creator]
	FROM [dbo].[Maintenance] inner join [dbo].[Admin]
	ON [Admin].[ID] = [Maintenance].[creator]
	ORDER BY [date_create] DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Maintenance_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Maintenance_GetById]
@id int
AS
BEGIN
	SELECT [Maintenance].[ID]
		  ,[title]
		  ,[date_create] as [dateALTER]
		  ,[amount]
		  ,[status]
		  ,[description]
		  ,[Admin].[name] as [creator]
	FROM [dbo].[Maintenance] inner join [dbo].[Admin]
	ON [Admin].[ID] = [Maintenance].[creator]
    WHERE [Maintenance].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Maintenance_GetByRowNum]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Maintenance_GetByRowNum]
@start int,
@end int
AS 
BEGIN
	With work_tmp as (
		SELECT 
			ROW_NUMBER() OVER(ORDER BY [date_create] DESC) as row#
			,[Maintenance].[ID]
			,[title]
			,[date_create]
			,[amount]
			,[status]
			,[description]
			,[Admin].[name] as [creator]
		FROM [dbo].[Maintenance] inner join [dbo].[Admin]
		ON [Admin].[ID] = [Maintenance].[creator]
	)
	SELECT 
		[ID]
		,[title]
		,[date_create] as [dateALTER]
		,[amount]
		,[status]
		,[description]
		,[creator]
	FROM work_tmp
	Where row# >= @start and row# < @end
END

GO
/****** Object:  StoredProcedure [dbo].[Maintenance_GetRowCount]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Maintenance_GetRowCount]
AS
BEGIN
	SELECT COUNT([ID]) as [count]
	FROM [dbo].[Maintenance] 
END
GO
/****** Object:  StoredProcedure [dbo].[Notidication_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Notidication_GetAll]
AS
BEGIN
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Order by date_release DESC
END

GO
/****** Object:  StoredProcedure [dbo].[Notification_Add]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Trần Hưng Trọng	
-- ALTER date: 21/04/2021
-- Description:	Proceduce cho modul quản lý thông báo
-- =============================================
CREATE PROC [dbo].[Notification_Add]
    @title nvarchar(200),
    @content nvarchar(MAX),
    @date_release date,
    @creator int
AS
BEGIN
	INSERT INTO [dbo].[Notification]
           ([title]
           ,[content]
           ,[date_release]
           ,[creator])
     VALUES
           (@title
           ,@content
           ,@date_release
           ,@creator);
END
GO
/****** Object:  StoredProcedure [dbo].[Notification_DeleteByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Notification_DeleteByID]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Notification]
	WHERE ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Notification_EditByID]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Notification_EditByID]
	@ID int,
    @title nvarchar(200),
    @content nvarchar(MAX),
    @date_release date
AS
BEGIN
	
	UPDATE [dbo].[Notification]
	SET  [title] = @title
		,[content] = @content
	    ,[date_release] = @date_release
	WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Notification_GetByCreatorId]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Notification_GetByCreatorId]
@creatorId int
AS
Begin
	SELECT 
		[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Where [Admin].ID = @creatorId
	Order by date_release DESC
end

GO
/****** Object:  StoredProcedure [dbo].[Notification_GetByCreatorIdRowNumber]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Notification_GetByCreatorIdRowNumber]
@creatorId int,
@start int,
@end int
AS
Begin
	WITH work_tmp as (
		SELECT 
			ROW_NUMBER() Over (Order by [date_release])  as row#
			,[Notification].[ID] as ID
			,[title]
			,[date_release]
			,[Admin].[name] as creator
		FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
		Where [Admin].ID = @creatorId
	)
	Select [ID]
		,[title]
		,[date_release]
		,creator
	From work_tmp
	Where row# >= @start and row# < @end
	Order by date_release DESC
end

GO
/****** Object:  StoredProcedure [dbo].[Notification_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Notification_GetById]
	@id int
AS
BEGIN
	SELECT 
		[Notification].[ID] as ID
		,[content]
		,[title]
		,[date_release]
		,[Admin].[name] as creator
	FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	Where [Notification].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Notification_GetByRowNumber]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Notification_GetByRowNumber]
	@start int,
	@end int
AS
BEGIN
	
	With work_tmp as (
		SELECT 
		ROW_NUMBER() Over (Order by [date_release])  as row#
		,[Notification].[ID] as ID
		,[title]
		,[date_release]
		,[Admin].[name] as creator
		FROM [dbo].[Notification] join [Admin] on [Notification].creator = [Admin].ID
	)
	Select [ID]
		,[title]
		,[date_release]
		,creator
	From work_tmp
	Where row# >= @start and row# < @end
	Order by date_release DESC

END
GO
/****** Object:  StoredProcedure [dbo].[Notification_GetRowCount]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Proceduce đếm số dòng trong bảng table
-- Nếu creator > 0  thì sẽ đếm số thông báo do creator tạo
CREATE PROC [dbo].[Notification_GetRowCount]
@creatorId int
AS
BEGIN
	IF @creatorId > 0
		Select COUNT(id) as [count]
		From [Notification]
		Where creator = @creatorId
	else
		Select COUNT(id) as [count]
		From [Notification]
END

-- Edit Proceduce
-- 22/4/2021 
-- Loại bỏ dữ liệu thừa
GO
/****** Object:  StoredProcedure [dbo].[Tenant_Create]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Tenant_Create]
@name nvarchar(100), 
@email varchar(150), 
@phoneNumber varchar(15), 
@advancePayment int


AS
BEGIN
	INSERT INTO [dbo].[Tenant]
           ([name]
           ,[email]
           ,[phone_number]
           ,[advance_payment]
           )
     VALUES
           (
		   @name,
           @email,
           @phoneNumber,
           @advancePayment
           )
END
GO
/****** Object:  StoredProcedure [dbo].[Tenant_DeleteById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Tenant_DeleteById]
@id int
AS
BEGIN
	DELETE FROM [dbo].[Tenant]
    WHERE [ID] = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Tenant_EditById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Tenant_EditById]
@id int,
@name nvarchar(100), 
@email varchar(150), 
@phoneNumber varchar(15), 
@advancePayment int
AS
BEGIN
	UPDATE [dbo].[Tenant]
	   SET [name] = @name
           ,[email] = @email
           ,[phone_number] = @phoneNumber
           ,[advance_payment] = @advancePayment
           
	 WHERE [Tenant].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Tenant_GetAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Tenant_GetAll]
AS
BEGIN
	SELECT [Tenant].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[advance_payment] as [advancePayment]
           
	FROM [dbo].[Tenant]
END
GO
/****** Object:  StoredProcedure [dbo].[Tenant_GetById]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Tenant_GetById]
@id int
AS
BEGIN
	SELECT [Tenant].[ID]
		   ,[name]
           ,[email]
           ,[phone_number] as [phoneNumber]
           ,[advance_payment] as [advancePayment]
           
	FROM [dbo].[Tenant]
    WHERE [Tenant].[ID] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Tenant_GetIdNameAll]    Script Date: 25/4/2021 6:12:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Tenant_GetIdNameAll]
AS
BEGIN
	SELECT ID, name
	From [Tenant]
END
GO
