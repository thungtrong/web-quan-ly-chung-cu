USE [CNPM]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Priority] [int] NULL,
	[Processing] [int] NULL,
	[Status] [int] NULL,
	[CreateTime] [datetime] NULL,
	[DueTime] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[RegisterDate] [varchar](max) NULL,
	[LastDate] [varchar](max) NULL,
	[LastOperator] [varchar](max) NULL,
	[PG] [varchar](max) NULL,
	[DataVersion] [varchar](max) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NULL,
	[ParentId] [bigint] NULL,
	[Status] [int] NULL,
	[ProjectId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreateUserId] [int] NULL,
	[CreateTime] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[RegisterDate] [varchar](max) NULL,
	[LastDate] [varchar](max) NULL,
	[LastOperator] [varchar](max) NULL,
	[PG] [varchar](max) NULL,
	[DataVersion] [varchar](max) NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskUser]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskUser](
	[TaskId] [bigint] NULL,
	[UserId] [int] NULL,
	[AssignerID] [int] NULL,
	[DateAssign] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Birthday] [date] NULL,
	[FullName] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Status] [int] NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[LoginTime] [datetime] NULL,
	[LastLogin] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[RegisterDate] [varchar](max) NULL,
	[LastDate] [varchar](max) NULL,
	[LastOperator] [varchar](max) NULL,
	[PG] [varchar](max) NULL,
	[DataVersion] [varchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (1, N'Project 2', N'New Project', 1, 1, 1, CAST(N'2021-02-24T00:00:00.000' AS DateTime), CAST(N'2021-02-26T00:00:00.000' AS DateTime), 0, N'20210224060910', N'20210224060910', N'LM', N'Insert_Project', N'20210224060910')
INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (3, N'New Project', N'ffffff2', 2, 4, 4, CAST(N'2021-02-21T00:00:00.000' AS DateTime), CAST(N'2021-02-28T00:00:00.000' AS DateTime), 0, N'2213', NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (16, N'New Row', N'sadasd 122', 3, 3, 3, CAST(N'2020-02-21T00:00:00.000' AS DateTime), CAST(N'2021-02-21T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (19, N'đaasdasd', N'adsadasd', 2, 2, 2, CAST(N'2222-12-21T00:00:00.000' AS DateTime), CAST(N'2223-12-21T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (20, N'da', N'ad', 2, 2, 2, CAST(N'2333-12-21T00:00:00.000' AS DateTime), CAST(N'2222-12-21T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (21, N'ssa', N'asa', 2, 2, -2, CAST(N'2000-02-21T00:00:00.000' AS DateTime), CAST(N'3131-02-21T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([id], [Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (22, N'ấ', NULL, -1, 0, 0, CAST(N'2000-12-12T00:00:00.000' AS DateTime), CAST(N'2001-12-12T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([id], [Priority], [ParentId], [Status], [ProjectId], [Name], [Description], [CreateUserId], [CreateTime], [DueDate], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (3, 1, 1, 1, 1, N'New Task', N'asdsad', 1, CAST(N'2020-10-20T00:00:00.000' AS DateTime), CAST(N'2020-10-20T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Task] ([id], [Priority], [ParentId], [Status], [ProjectId], [Name], [Description], [CreateUserId], [CreateTime], [DueDate], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (7, 2, 2, 2, 2, N'New Row 2', NULL, 0, CAST(N'2020-12-21T00:00:00.000' AS DateTime), CAST(N'2021-12-21T00:00:00.000' AS DateTime), 0, N'12321312', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
INSERT [dbo].[TaskUser] ([TaskId], [UserId], [AssignerID], [DateAssign]) VALUES (1, 1, 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [Birthday], [FullName], [Description], [Image], [Phone], [Email], [Status], [UserName], [Password], [Position], [LoginTime], [LastLogin], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (1, CAST(N'2000-10-10' AS Date), N'Tran Hung Trong', N'asa', N'asdjlalsdnals', N'0939943056', N'kensakuai1475@gmail.com', 1, N'kensakuai', N'1234567', N'Van Phong', CAST(N'2020-12-12T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([id], [Birthday], [FullName], [Description], [Image], [Phone], [Email], [Status], [UserName], [Password], [Position], [LoginTime], [LastLogin], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion]) VALUES (2, CAST(N'1988-12-21' AS Date), N'Trần Hưng Trọng', N'aasdasdasdsa 2', N'adasdas2', N'0939943056', N'kensakuai1475@gmail.com', 0, N'kensakuai', N'kensakuai123', N'Quan ly', CAST(N'2020-02-21T00:00:00.000' AS DateTime), CAST(N'2020-02-21T00:00:00.000' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  StoredProcedure [dbo].[projects_Create]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[projects_Create]
@name nvarchar(Max),
@des nvarchar(Max),
@pri int,
@processing int,
@status int,
@createTime date,
@dueTime date,
@isDelete bit,
@registerDate varchar(Max),
@lastDate varchar(Max),
@lastOperator varchar(Max),
@pg varchar(Max),
@dataVersion varchar(Max)
AS
BEGIN
	Insert into Project ([Name], [Description], [Priority], [Processing], [Status], [CreateTime], [DueTime], [IsDelete], [RegisterDate], [LastDate], [LastOperator], [PG], [DataVersion])
	values (@name, @des, @pri, @processing,
	@status, @createTime, @dueTime, @isDelete, @registerDate,
	@lastDate, @lastOperator, @pg, @dataVersion);
END
GO
/****** Object:  StoredProcedure [dbo].[projects_Delete]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[projects_Delete]
@id int
AS
BEGIN
	Delete from Project
	where [id] = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[projects_Edit]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[projects_Edit]
@id int,
@name nvarchar(Max),
@des nvarchar(Max),
@pri int,
@processing int,
@status int,
@createTime date,
@dueTime date,
@isDelete bit,
@registerDate varchar(Max),
@lastDate varchar(Max),
@lastOperator varchar(Max),
@pg varchar(Max),
@dataVersion varchar(Max)
AS
BEGIN
	Update Project
	SET [Name] = @name, [Description] = @des, [Priority] = @pri, [Processing] = @processing, [Status] = @status, [CreateTime] = @createTime, [DueTime] = @dueTime, [IsDelete] = @isDelete, [RegisterDate] = @registerDate, [LastDate] = @lastDate, [LastOperator] = @lastOperator, [PG] = @pg, [DataVersion] = @dataVersion
	Where [id] = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[projects_GetAll]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[projects_GetAll]

as
begin
	select * from Project
end
GO
/****** Object:  StoredProcedure [dbo].[projects_GetByID]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[projects_GetByID]
	@id int
as
begin
	select * from Project where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[task_Create]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[task_Create]
	@pri int,
	@parent int,
	@status int,
	@projectid int,
	@name nvarchar(Max),
	@des varchar(max),
	@createUserId int,
	@createTime datetime,
	@dueTime datetime,
	@isDelete bit,
	@registerDate varchar(Max),
	@lastDate varchar(Max),
	@lastOperator varchar(Max),
	@pg varchar(Max),
	@dataVersion varchar(Max)
AS
BEGIN
	INSERT INTO [dbo].[Task]
           ([Priority]
           ,[ParentId]
           ,[Status]
           ,[ProjectId]
           ,[Name]
           ,[Description]
           ,[CreateUserId]
           ,[CreateTime]
           ,[DueDate]
           ,[IsDelete]
           ,[RegisterDate]
           ,[LastDate]
           ,[LastOperator]
           ,[PG]
           ,[DataVersion])
     VALUES
           (@pri,
			@parent,
			@status,
			@projectid,
			@name,
			@des,
			@createUserId,
			@createTime,
			@dueTime,
			@isDelete,
			@registerDate,
			@lastDate,
			@lastOperator,
			@pg,
			@dataVersion)
END
GO
/****** Object:  StoredProcedure [dbo].[task_Delete]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[task_Delete]
@id int
AS
BEGIN
	Delete from Task where [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[task_Edit]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[task_Edit]
	@id bigint,
	@Priority int,
    @ParentId bigint,
    @Status int,
    @ProjectId int,
    @Name nvarchar(max),
    @Description nvarchar(max),
    @CreateUserId int,
    @CreateTime datetime,
    @DueTime datetime,
    @IsDelete bit,
    @RegisterDate varchar(max),
    @LastDate varchar(max),
    @LastOperator varchar(max),
    @PG varchar(max),
    @DataVersion varchar(max)
AS
BEGIN
	Update [dbo].[Task]
	Set
           [Priority] = @Priority
           ,[ParentId] = @ParentId
           ,[Status] = @Status
           ,[ProjectId] = @ProjectId
           ,[Name] = @Name
           ,[Description] = @Description
           ,[CreateUserId] = @CreateUserId
           ,[CreateTime] = @CreateTime
           ,[DueDate] = @DueTime
           ,[IsDelete] = @IsDelete
           ,[RegisterDate] = @RegisterDate
           ,[LastDate] = @LastDate
           ,[LastOperator] = @LastOperator
           ,[PG] = @PG
           ,[DataVersion] = @DataVersion
	Where [id] = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[task_GetAll]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[task_GetAll]
AS
BEGIN
	Select * from task
END
GO
/****** Object:  StoredProcedure [dbo].[task_GetByID]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[task_GetByID]
@id int
AS
BEGIN
	Select * from task where [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[taskUser_Create]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[taskUser_Create]
@TaskId int,
           @UserId int,
           @AssignerID int,
           @DateAssign date
AS
BEGIN
	INSERT INTO [dbo].[TaskUser]
           ([TaskId]
           ,[UserId]
           ,[AssignerID]
           ,[DateAssign])
     VALUES
           (@TaskId,
           @UserId,
           @AssignerID,
           @DateAssign)
END
GO
/****** Object:  StoredProcedure [dbo].[taskUser_Delete]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[taskUser_Delete]
@taskId int,
@userId int,
@assignerId int
AS
BEGIN
	Delete from TaskUser 
	where TaskId = @taskId and UserId = @userId and AssignerID = @assignerId
END
GO
/****** Object:  StoredProcedure [dbo].[taskUser_Edit]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[taskUser_Edit]
@taskId int,
@userId int,
@assignerId int,
@dateA datetime
AS
BEGIN
	Update TaskUser 
	Set DateAssign = @dateA
	where TaskId = @taskId and UserId = @userId and AssignerID = @assignerId
END
GO
/****** Object:  StoredProcedure [dbo].[taskUser_GetAll]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[taskUser_GetAll]
AS
BEGIN
	Select * from TaskUser
END
GO
/****** Object:  StoredProcedure [dbo].[taskUser_GetById]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[taskUser_GetById]
@taskId int,
@userId int,
@assignerId int
AS
BEGIN
	Select * from TaskUser 
	where TaskId = @taskId and UserId = @userId and AssignerID = @assignerId
END
GO
/****** Object:  StoredProcedure [dbo].[user_Create]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_Create]
	@Birthday date
    ,@FullName nvarchar(100)
    ,@Description nvarchar(max)
    ,@Image nvarchar(max)
    ,@Phone varchar(50)
    ,@Email varchar(200)
    ,@Status int
    ,@UserName varchar(100)
    ,@Password varchar(max)
    ,@Position nvarchar(max)
    ,@LoginTime datetime
    ,@LastLogin datetime
    ,@IsDelete bit
    ,@RegisterDate varchar(max)
    ,@LastDate varchar(max)
    ,@LastOperator varchar(max)
    ,@PG varchar(max)
    ,@DataVersion varchar(max)
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Birthday]
           ,[FullName]
           ,[Description]
           ,[Image]
           ,[Phone]
           ,[Email]
           ,[Status]
           ,[UserName]
           ,[Password]
           ,[Position]
           ,[LoginTime]
           ,[LastLogin]
           ,[IsDelete]
           ,[RegisterDate]
           ,[LastDate]
           ,[LastOperator]
           ,[PG]
           ,[DataVersion])
     VALUES
           (@Birthday,
           @FullName,
           @Description,
           @Image,
           @Phone,
           @Email,
           @Status,
           @UserName,
           @Password,
           @Position,
           @LoginTime,
           @LastLogin,
           @IsDelete,
           @RegisterDate,
           @LastDate,
           @LastOperator,
           @PG,
           @DataVersion)
END
GO
/****** Object:  StoredProcedure [dbo].[user_Delete]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[user_Delete]
@id int
AS
BEGIN
	Delete from [dbo].[User]
	where [id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[user_Edit]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_Edit]
	@id int,
	@Birthday date
    ,@FullName nvarchar(100)
    ,@Description nvarchar(max)
    ,@Image nvarchar(max)
    ,@Phone varchar(50)
    ,@Email varchar(200)
    ,@Status int
    ,@UserName varchar(100)
    ,@Password varchar(max)
    ,@Position nvarchar(max)
    ,@LoginTime datetime
    ,@LastLogin datetime
    ,@IsDelete bit
    ,@RegisterDate varchar(max)
    ,@LastDate varchar(max)
    ,@LastOperator varchar(max)
    ,@PG varchar(max)
    ,@DataVersion varchar(max)
AS
BEGIN
	Update [dbo].[User]
     Set [Birthday] = @Birthday
           ,[FullName] = @FullName
           ,[Description] = @Description
           ,[Image] = @Image
           ,[Phone] = @Phone
           ,[Email] = @Email
           ,[Status] = @Status
           ,[UserName] = @UserName
           ,[Password] = @Password
           ,[Position] = @Position
           ,[LoginTime] = @LoginTime
           ,[LastLogin] = @LastLogin
           ,[IsDelete] = @IsDelete
           ,[RegisterDate] = RegisterDate
           ,[LastDate] = @LastDate
           ,[LastOperator] = @LastOperator
           ,[PG] = @PG
           ,[DataVersion] = @DataVersion
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[user_GetAll]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_GetAll]
AS
BEGIN
	Select * from [dbo].[User]
END
GO
/****** Object:  StoredProcedure [dbo].[user_GetByID]    Script Date: 26/4/2021 10:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_GetByID]
@id int
AS
BEGIN
	Select * from [dbo].[User] where id = @id
END
GO
