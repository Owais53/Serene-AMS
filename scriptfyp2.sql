USE [Hrms]
GO
/****** Object:  Table [dbo].[tblOrganizationStructure]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrganizationStructure](
	[CompanyCode] [int] NOT NULL,
	[CityCode] [int] NULL,
	[StorageLocation] [nvarchar](max) NULL,
	[PurchaseOrganization] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblItem]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblItem](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](max) NULL,
	[ItemType] [varchar](50) NULL,
	[StorageLocation] [varchar](50) NULL,
	[ReorderPoint] [int] NULL,
	[ItemPrice] [money] NULL,
 CONSTRAINT [PK_tblItem] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDoctype]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDoctype](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType] [varchar](50) NULL,
	[DocumentName] [varchar](100) NULL,
 CONSTRAINT [PK_tblDoctype] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDepartments]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblDepartments] ON
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (1, N'HR')
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (3, N'Finance')
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (4, N'Supply Chain')
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (5, N'BI')
SET IDENTITY_INSERT [dbo].[tblDepartments] OFF
/****** Object:  Table [dbo].[tblAdmincheck]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmincheck](
	[AdminId] [int] NOT NULL,
	[IsAdmin] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblAdmincheck] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblAdmincheck] ([AdminId], [IsAdmin], [desc]) VALUES (0, N'0', N'NotAdmin')
INSERT [dbo].[tblAdmincheck] ([AdminId], [IsAdmin], [desc]) VALUES (1, N'1', N'Admin')
/****** Object:  Table [dbo].[tblRoles]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblRoles] ON
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (1, N'Recruitment Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (2, N'Recruitment Officer')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (3, N'Store Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (4, N'Hr Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (5, N'DGM')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (6, N'Admin')
SET IDENTITY_INSERT [dbo].[tblRoles] OFF
/****** Object:  Table [dbo].[tblRequests]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRequests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[PositionId] [int] NULL,
	[RequestType] [nvarchar](max) NULL,
	[CitytoTranser] [varchar](75) NULL,
	[DateofRequest] [datetime] NULL,
	[Status] [nvarchar](max) NULL,
	[Respondedby] [nvarchar](max) NULL,
	[ResponseDate] [datetime] NULL,
	[ReasonofRequest] [varchar](max) NULL,
	[AuthorizedRole] [varchar](75) NULL,
 CONSTRAINT [PK_tblRequests_1] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblRequests] ON
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [CitytoTranser], [DateofRequest], [Status], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole]) VALUES (14, 49, 4, N'Transfer', N'Lahore', CAST(0x0000AB6600000000 AS DateTime), N'Rejected', N'Afzaal', CAST(0x0000AB6700000000 AS DateTime), N'Leaving Karachi', N'DGM')
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [CitytoTranser], [DateofRequest], [Status], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole]) VALUES (18, 48, 18, N'Transfer', N'Lahore', CAST(0x0000AB6700000000 AS DateTime), N'Rejected', N'Afzaal', CAST(0x0000AB6700000000 AS DateTime), N'Leaving Karachi', N'DGM')
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [CitytoTranser], [DateofRequest], [Status], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole]) VALUES (19, 48, 18, N'Transfer', N'Islamabad', CAST(0x0000AB6700000000 AS DateTime), N'Pending', NULL, NULL, N'Leaving', N'DGM')
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [CitytoTranser], [DateofRequest], [Status], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole]) VALUES (20, 49, 2, N'Transfer', N'Lahore', CAST(0x0000AB6700000000 AS DateTime), N'Accepted', N'Afzaal', CAST(0x0000AB6700000000 AS DateTime), N'Leaving Please Accept', N'DGM')
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [CitytoTranser], [DateofRequest], [Status], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole]) VALUES (21, 48, 4, N'Transfer', N'Islamabad', CAST(0x0000AB6800000000 AS DateTime), N'Pending', NULL, NULL, N'Leaving Karachi', N'DGM')
SET IDENTITY_INSERT [dbo].[tblRequests] OFF
/****** Object:  Table [dbo].[tblTestCriteria]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTestCriteria](
	[DepartmentId] [int] NULL,
	[PassingPercent] [nvarchar](max) NULL,
	[Marks] [int] NULL,
	[Grade] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblStructuredetail]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStructuredetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CityCode] [int] NULL,
	[CityName] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblStructuredetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblStructuredetail] ON
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (1, 1000, N'Serene Air Pvt Lmd', 100, N'Karachi')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (2, 1000, N'Serene Air pvt Lmd', 101, N'Lahore')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (3, 2000, N'Serene Engg Services', 100, N'Karachi')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (4, 2000, N'Serene Engg Services', 101, N'Lahore')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (5, 3000, N'Serene Air pvt Limited', 101, N'Lahore')
SET IDENTITY_INSERT [dbo].[tblStructuredetail] OFF
/****** Object:  Table [dbo].[tblVendors]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblVendors](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[ItemType] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
 CONSTRAINT [PK_tblVendors] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVacancydetails]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacancydetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [int] NULL,
	[CityCode] [int] NULL,
	[DepartmentId] [int] NULL,
	[PositionId] [int] NULL,
	[Availableseats] [int] NULL,
	[SeatAvailablityDate] [date] NULL,
	[StructureId] [int] NULL,
 CONSTRAINT [PK_tblVacancydetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblVacancydetails] ON
INSERT [dbo].[tblVacancydetails] ([Id], [CompanyCode], [CityCode], [DepartmentId], [PositionId], [Availableseats], [SeatAvailablityDate], [StructureId]) VALUES (80, 1000, 100, 1, 2, 1, CAST(0xBC400B00 AS Date), 1)
INSERT [dbo].[tblVacancydetails] ([Id], [CompanyCode], [CityCode], [DepartmentId], [PositionId], [Availableseats], [SeatAvailablityDate], [StructureId]) VALUES (81, 2000, 101, 4, 3, 1, CAST(0xBE400B00 AS Date), 4)
SET IDENTITY_INSERT [dbo].[tblVacancydetails] OFF
/****** Object:  Table [dbo].[tblVacancies]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblVacancies](
	[VacancyId] [int] IDENTITY(1,1) NOT NULL,
	[VacancyName] [varchar](max) NULL,
	[CityName] [varchar](max) NULL,
	[PositionId] [int] NULL,
	[DepartmentId] [int] NULL,
	[NoofVacany] [int] NULL,
	[RequiredQualification] [nvarchar](max) NULL,
	[JobLevel] [int] NULL,
	[CreationDate] [date] NULL,
	[MarksCriteria] [int] NULL,
	[Testpaper] [varchar](200) NULL,
 CONSTRAINT [PK_tblVacancies] PRIMARY KEY CLUSTERED 
(
	[VacancyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblVacancies] ON
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (1, N'Recruitment Officer', N'Karachi', 1, 1, 3, N'Must have BS degree in HR or relevant field.', 4, CAST(0xB3400B00 AS Date), 65, N'18087a87-81a9-44cd-935b-684d32df827c.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (2, N'Hiring Manager', N'Karachi', 2, 1, 1, N'Must have relevant degree in Hr', 3, CAST(0xB3400B00 AS Date), 60, N'27641158-c858-432d-bd87-6f5284db1eff.pdf')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (3, N'Store Manager', N'Lahore', 3, 4, 1, N'Must have degree in supply chain or relevant field', 4, CAST(0xB4400B00 AS Date), 55, N'd98a41e0-7875-4661-9b1b-cbe035103b16.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (7, N'Hr Officer', N'Islamabad', 18, 1, NULL, N'Must have degree in HR', 4, CAST(0xBE400B00 AS Date), 65, N'afbba3c0-e6ec-48a2-ba83-d8e657f1cef5.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (8, N'Hiring Manager', N'Lahore', 2, 1, NULL, N'Must Have degree in HR', 3, CAST(0xBE400B00 AS Date), 64, N'e2903b15-9da4-4dbd-b105-565b67f76bfa.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (12, N'DGM', N'Islamabad', 19, 1, NULL, N'Must have degree in MBA', 5, CAST(0xC1400B00 AS Date), 70, N'd41af054-700c-4884-ad64-0a7aee0aa0f0.docx')
SET IDENTITY_INSERT [dbo].[tblVacancies] OFF
/****** Object:  Table [dbo].[tblUsers]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[RoleId] [int] NULL,
	[AdminId] [int] NULL,
	[DepartmentId] [int] NULL,
	[EmployeeId] [int] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblUsers] ON
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive]) VALUES (15, N'Owais', N'9248133abc', 1, 0, 1, 49, 1)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive]) VALUES (16, N'Tahir', N'9248133abc', 2, 0, 1, 46, 1)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive]) VALUES (17, N'Tahir23', N'1234567', 5, 0, 1, 50, 1)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive]) VALUES (18, N'Afzaal', N'9248133', 5, 0, 1, 48, 1)
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
/****** Object:  Table [dbo].[tblStock]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[TotalStockCapacity] [int] NULL,
	[AvailableStock] [int] NULL,
 CONSTRAINT [PK_tblStock] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllUsers]    Script Date: 02/22/2020 19:33:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllUsers]
as
Begin
select u.UserId,u.UserName,d.DepartmentName,r.RoleName,a.IsAdmin from Users u inner join Roles r on u.RoleId = r.Id 
inner join Departments d on u.DepartmentId = d.DepartmentId 
inner join tblAdmincheck a on u.AdminId = a.AdminId
End
GO
/****** Object:  Table [dbo].[tblPosition]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPosition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[JobLevel] [varchar](75) NULL,
	[Position] [varchar](max) NULL,
	[BasicPay] [money] NULL,
	[IncomeTax] [money] NULL,
 CONSTRAINT [PK_tblPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblPosition] ON
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax]) VALUES (1, 1, N'High', N'Recruitment Officer', NULL, NULL)
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax]) VALUES (2, 1, N'Medium', N'Hiring Manager', NULL, NULL)
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax]) VALUES (3, 4, N'Medium', N'Store Manager', NULL, NULL)
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax]) VALUES (4, 1, N'Medium', N'Recruitment Manager', NULL, NULL)
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax]) VALUES (18, 1, N'Low', N'Hr Officer', 15000.0000, 15000.0000)
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax]) VALUES (19, 1, N'Medium', N'DGM', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblPosition] OFF
/****** Object:  Table [dbo].[tblDocument]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDocument](
	[DocumentNo] [int] NOT NULL,
	[DTypeId] [int] NULL,
	[CreationDate] [date] NULL,
	[CreatedBy] [varchar](50) NULL,
	[VendorId] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [money] NULL,
 CONSTRAINT [PK_tblDocument] PRIMARY KEY CLUSTERED 
(
	[DocumentNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[CityName] [nvarchar](max) NULL,
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](max) NULL,
	[Gender] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[DateofBirth] [date] NULL,
	[Contact] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PositionId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblEmployee] ON
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 46, N'Tahir', N'Male', 1, CAST(0xED1D0B00 AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 1, 16)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 47, N'Aamir Mumtaz', N'Male', 1, CAST(0x65190B00 AS Date), N'03028285732', N'aamirmumtaz22@gmail.com', N'H#669, DOHS-1, Malir Cantt', 2, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 48, N'Afzaal', N'Male', 4, CAST(0xBD400B00 AS Date), N'0342453355', N'afzaal@gmail.com', N'Malir Cantt', 19, 18)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 49, N'Owais', N'Male', 1, CAST(0xA71F0B00 AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 2, 15)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 50, N'Tahir', N'Male', 1, CAST(0xED1D0B00 AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 1, 17)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Islamabad', 51, N'Aamir Mumtaz', N'Male', 1, CAST(0x65190B00 AS Date), N'03028285732', N'aamirmumtaz22@gmail.com', N'H#669, DOHS-1, Malir Cantt', 2, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 52, N'Afzaal', N'Male', 4, CAST(0xBD400B00 AS Date), N'0342453355', N'afzaal@gmail.com', N'Malir Cantt', 3, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Islamabad', 53, N'Tahir', N'Male', 1, CAST(0xED1D0B00 AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 1, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 54, N'Ahmed Zafar', N'Male', 1, CAST(0x25210B00 AS Date), N'03423058814', N'ahmedzafar422@gmail.com', N'Malir Cantt', 2, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Islamabad', 56, N'Ali Ahmed', N'Male', 1, CAST(0x1EF80A00 AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 19, NULL)
SET IDENTITY_INSERT [dbo].[tblEmployee] OFF
/****** Object:  Table [dbo].[tblApplicant]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblApplicant](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[VacancyId] [int] NULL,
	[ApplicantName] [nvarchar](max) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Dob] [date] NULL,
	[Gender] [varchar](50) NULL,
	[Appliedfor] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Submittedon] [date] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[CV] [varchar](200) NULL,
	[Marks] [int] NULL,
	[TestStatus] [varchar](50) NULL,
	[InterviewDate] [date] NULL,
	[JoiningDate] [date] NULL,
	[Salary] [money] NULL,
 CONSTRAINT [PK_tblApplicant] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblApplicant] ON
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (6, 1, N'Owais', N'03003497300', N'owaismumtaz96@gmail.com', CAST(0xA71F0B00 AS Date), N'Male', N'Recruitment Manager', N'Hired', CAST(0xAF400B00 AS Date), N'H#669, DOHS-1, Malir Cantt', N'd022e7f8-84f4-4667-aa2a-e5185b95306e.pdf', 77, N'Pass', CAST(0xBD400B00 AS Date), CAST(0xCD400B00 AS Date), 70000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (7, 2, N'Aamir Mumtaz', N'03028285732', N'aamirmumtaz22@gmail.com', CAST(0x65190B00 AS Date), N'Male', N'Hiring Manager', N'Hired', CAST(0xAF400B00 AS Date), N'H#669, DOHS-1, Malir Cantt', N'f80de075-1f72-4a2e-92a7-57fa18978d7b.docx', 88, N'Pass', CAST(0xBE400B00 AS Date), CAST(0xC6400B00 AS Date), 50000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (8, 3, N'Afzaal', N'0342453355', N'afzaal@gmail.com', CAST(0xBD400B00 AS Date), N'Male', N'Recruitment Officer', N'Hired', CAST(0xB0400B00 AS Date), N'Malir Cantt', N'31f3ebce-f855-4bdd-80c8-f5b6fae27d15.pdf', 70, N'Pass', CAST(0xBE400B00 AS Date), CAST(0xBF400B00 AS Date), 35000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (9, 1, N'Tahir', N'03003497300', N'owaismumtaz96@gmail.com', CAST(0xED1D0B00 AS Date), N'Male', N'Recruitment Officer', N'Hired', CAST(0xBA400B00 AS Date), N'H#669, DOHS-1, Malir Cantt', N'e6dd05ab-d19b-44a6-adf1-06bf93e65e79.pdf', 70, N'Pass', CAST(0xBE400B00 AS Date), CAST(0xC6400B00 AS Date), 50000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (10, 7, N'Hassan', N'03304573735', N'hassanzulfiqar@gmail.com', CAST(0xED1C0B00 AS Date), N'Male', N'Hr Officer', N'Approved', CAST(0xBE400B00 AS Date), N'Malir Halt', N'd42d2d5c-0c83-4262-b6cf-ee19ef3ccfd5.pdf', 64, N'Fail', NULL, NULL, NULL)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (11, 8, N'Ahmed Zafar', N'03423058814', N'ahmedzafar422@gmail.com', CAST(0x25210B00 AS Date), N'Male', N'Hiring Manager', N'Hired', CAST(0xBE400B00 AS Date), N'Malir Cantt', N'bbced265-956d-4d2c-b40c-ebe9496dd347.pdf', 67, N'Pass', CAST(0xBF400B00 AS Date), CAST(0xC0400B00 AS Date), 40000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (12, 12, N'Ali Ahmed', N'03003497300', N'owaismumtaz96@gmail.com', CAST(0x1EF80A00 AS Date), N'Male', N'DGM', N'Hired', CAST(0xC1400B00 AS Date), N'H#669, DOHS-1, Malir Cantt', N'6011b1a0-0c62-4a7a-9fe1-55a0013e8101.pdf', 75, N'Pass', CAST(0xC2400B00 AS Date), CAST(0xC8400B00 AS Date), 80000.0000)
SET IDENTITY_INSERT [dbo].[tblApplicant] OFF
/****** Object:  Table [dbo].[tblPurchase]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPurchase](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNo] [int] NULL,
	[PurchaseOrg] [varchar](50) NULL,
	[DeliveryDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[OrderedDate] [date] NULL,
 CONSTRAINT [PK_tblPurchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRequestdetail]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRequestdetail](
	[RequestId] [int] NOT NULL,
	[CompanyCode] [int] NULL,
	[CityCode] [int] NULL,
	[DepartmentId] [int] NULL,
	[PositionId] [int] NULL,
	[Position] [nvarchar](max) NULL,
	[EmployeeId] [int] NULL,
	[EmployeeName] [nvarchar](max) NULL,
	[ReasonofRequest] [nvarchar](max) NULL,
	[LastWorkingDate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPurchaseitem]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPurchaseitem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [int] NULL,
	[ItemId] [int] NULL,
	[NoofMissingStock] [int] NULL,
	[NoofDamagedStock] [int] NULL,
 CONSTRAINT [PK_tblPurchaseitem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCandidates]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCandidates](
	[CandidateId] [int] NOT NULL,
	[ApplicationId] [int] NULL,
	[Cname] [nvarchar](max) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tblCandidates] PRIMARY KEY CLUSTERED 
(
	[CandidateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[getcountnoti]    Script Date: 02/22/2020 19:33:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getcountnoti]
    @role varchar,@requestId Int
AS
BEGIN 
	Declare @countpend INT,@countnotpend INT


select Totalcount = (select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and AuthorizedRole=@role)+(select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestId=@requestId)
	
    
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserLogin]    Script Date: 02/22/2020 19:33:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserLogin] @UserName nvarchar(max) = NULL, @Password nvarchar(max) = NULL
AS
Select u.UserName,u.UserId,d.DepartmentName,a.[desc],r.RoleName,s.CompanyCode,s.CityCode,s.CompanyName,s.CityName,e.EmployeeId,e.EmployeeName,e.DepartmentId,e.Position
 from tblUsers u join tblDepartments d on u.DepartmentId=d.DepartmentId join tblAdmincheck a on u.AdminId=a.AdminId join tblRoles r on u.RoleId=r.Id join tblEmployee e on u.EmployeeId=e.EmployeeId join tblStructuredetail s on e.CityCode=s.CityCode and e.CompanyCode=s.CompanyCode 
where u.UserName=@UserName and Password=@Password
GO
/****** Object:  Table [dbo].[tblEmployeeDetail]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployeeDetail](
	[EmployeeId] [int] NOT NULL,
	[EmployeeStatus] [nvarchar](max) NULL,
	[Dateofjoining] [datetime] NULL,
	[Dateofresignation] [datetime] NULL,
	[DateofTransfer] [datetime] NULL,
	[DateofPromotion] [datetime] NULL,
	[LastLeaveDate] [datetime] NULL,
 CONSTRAINT [PK_tblEmployeeDetail] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (46, N'Active', CAST(0x0000AB6B00000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (47, N'Active', CAST(0x0000AB6B00000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (48, N'Active', CAST(0x0000AB6400000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (49, N'Active', CAST(0x0000AB7200000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (50, N'Active', CAST(0x0000AB6600000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (51, N'Active', CAST(0x0000AB6B00000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (52, N'Active', CAST(0x0000AB6400000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (53, N'Active', CAST(0x0000AB6B00000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (54, N'Active', CAST(0x0000AB6500000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate]) VALUES (56, N'Active', CAST(0x0000AB6D00000000 AS DateTime), NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[tblPayroll]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPayroll](
	[PayrollId] [int] IDENTITY(1,1) NOT NULL,
	[FortheMonth] [varchar](50) NULL,
	[Year] [int] NULL,
	[CompanyCode] [int] NULL,
	[CityCode] [int] NULL,
	[EmployeeId] [int] NULL,
	[BasicSalary] [money] NULL,
	[GrossSalary] [money] NULL,
	[Bonuses] [money] NULL,
	[IncomeTax] [money] NULL,
	[MedicalAllowance] [money] NULL,
	[TotalDeduction] [money] NULL,
	[NetSalary] [nchar](10) NULL,
 CONSTRAINT [PK_tblPayroll] PRIMARY KEY CLUSTERED 
(
	[PayrollId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblExpenses]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblExpenses](
	[ExpenseId] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[CompanyCode] [varchar](50) NULL,
	[CityCode] [varchar](50) NULL,
	[ExpenseType] [varchar](50) NULL,
	[PurchaseId] [int] NULL,
	[PayrollId] [int] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_tblExpenses] PRIMARY KEY CLUSTERED 
(
	[ExpenseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_BackEndAvailablity]    Script Date: 02/22/2020 19:33:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BackEndAvailablity]
AS
BEGIN
Update tblVacancydetails set Availableseats=Availableseats+1
from tblVacancydetails v INNER JOIN tblRequestdetail d on v.CompanyCode=d.CompanyCode and v.CityCode=d.CityCode and v.DepartmentId=d.DepartmentId and v.PositionId=d.PositionId
INNER JOIN tblRequests r on d.RequestId=r.RequestId
where d.LastWorkingDate=Convert(varchar,getdate(),23) and r.Status='Approved'
END
GO
/****** Object:  Table [dbo].[tblTest]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTest](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [datetime] NULL,
	[DepartmentId] [int] NULL,
	[CandidateId] [int] NULL,
 CONSTRAINT [PK_tblTest] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblResults]    Script Date: 02/22/2020 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblResults](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NULL,
	[CandidateId] [int] NULL,
	[TotalMarks] [int] NULL,
	[MarksObtained] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tblResults] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_tblApplicant_tblVacancies]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblApplicant]  WITH CHECK ADD  CONSTRAINT [FK_tblApplicant_tblVacancies] FOREIGN KEY([VacancyId])
REFERENCES [dbo].[tblVacancies] ([VacancyId])
GO
ALTER TABLE [dbo].[tblApplicant] CHECK CONSTRAINT [FK_tblApplicant_tblVacancies]
GO
/****** Object:  ForeignKey [FK_tblCandidates_tblApplicant]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblCandidates]  WITH CHECK ADD  CONSTRAINT [FK_tblCandidates_tblApplicant] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[tblApplicant] ([ApplicationId])
GO
ALTER TABLE [dbo].[tblCandidates] CHECK CONSTRAINT [FK_tblCandidates_tblApplicant]
GO
/****** Object:  ForeignKey [FK_tblDocument_tblDoctype]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblDocument]  WITH CHECK ADD  CONSTRAINT [FK_tblDocument_tblDoctype] FOREIGN KEY([DTypeId])
REFERENCES [dbo].[tblDoctype] ([TypeId])
GO
ALTER TABLE [dbo].[tblDocument] CHECK CONSTRAINT [FK_tblDocument_tblDoctype]
GO
/****** Object:  ForeignKey [FK_tblDocument_tblItem]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblDocument]  WITH CHECK ADD  CONSTRAINT [FK_tblDocument_tblItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tblItem] ([ItemId])
GO
ALTER TABLE [dbo].[tblDocument] CHECK CONSTRAINT [FK_tblDocument_tblItem]
GO
/****** Object:  ForeignKey [FK_tblDocument_tblVendors]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblDocument]  WITH CHECK ADD  CONSTRAINT [FK_tblDocument_tblVendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[tblVendors] ([VendorId])
GO
ALTER TABLE [dbo].[tblDocument] CHECK CONSTRAINT [FK_tblDocument_tblVendors]
GO
/****** Object:  ForeignKey [FK_tblEmployee_tblDepartment]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblDepartment]
GO
/****** Object:  ForeignKey [FK_tblEmployee_tblPosition]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblPosition] FOREIGN KEY([PositionId])
REFERENCES [dbo].[tblPosition] ([Id])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblPosition]
GO
/****** Object:  ForeignKey [FK_tblEmployeeDetail_tblEmployee]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblEmployeeDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeeDetail_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblEmployeeDetail] CHECK CONSTRAINT [FK_tblEmployeeDetail_tblEmployee]
GO
/****** Object:  ForeignKey [FK_tblExpenses_tblPayroll]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblExpenses]  WITH CHECK ADD  CONSTRAINT [FK_tblExpenses_tblPayroll] FOREIGN KEY([PayrollId])
REFERENCES [dbo].[tblPayroll] ([PayrollId])
GO
ALTER TABLE [dbo].[tblExpenses] CHECK CONSTRAINT [FK_tblExpenses_tblPayroll]
GO
/****** Object:  ForeignKey [FK_tblExpenses_tblPurchase]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblExpenses]  WITH CHECK ADD  CONSTRAINT [FK_tblExpenses_tblPurchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[tblPurchase] ([PurchaseId])
GO
ALTER TABLE [dbo].[tblExpenses] CHECK CONSTRAINT [FK_tblExpenses_tblPurchase]
GO
/****** Object:  ForeignKey [FK_tblPayroll_tblEmployee]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblPayroll]  WITH CHECK ADD  CONSTRAINT [FK_tblPayroll_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblPayroll] CHECK CONSTRAINT [FK_tblPayroll_tblEmployee]
GO
/****** Object:  ForeignKey [FK_tblPosition_tblDepartment]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblPosition]  WITH CHECK ADD  CONSTRAINT [FK_tblPosition_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblPosition] CHECK CONSTRAINT [FK_tblPosition_tblDepartment]
GO
/****** Object:  ForeignKey [FK_tblPurchase_tblDocument]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchase_tblDocument] FOREIGN KEY([DocumentNo])
REFERENCES [dbo].[tblDocument] ([DocumentNo])
GO
ALTER TABLE [dbo].[tblPurchase] CHECK CONSTRAINT [FK_tblPurchase_tblDocument]
GO
/****** Object:  ForeignKey [FK_tblPurchaseitem_tblItem]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblPurchaseitem]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseitem_tblItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tblItem] ([ItemId])
GO
ALTER TABLE [dbo].[tblPurchaseitem] CHECK CONSTRAINT [FK_tblPurchaseitem_tblItem]
GO
/****** Object:  ForeignKey [FK_tblPurchaseitem_tblPurchase]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblPurchaseitem]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseitem_tblPurchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[tblPurchase] ([PurchaseId])
GO
ALTER TABLE [dbo].[tblPurchaseitem] CHECK CONSTRAINT [FK_tblPurchaseitem_tblPurchase]
GO
/****** Object:  ForeignKey [FK_tblRequestdetail_tblEmployee]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblRequestdetail]  WITH CHECK ADD  CONSTRAINT [FK_tblRequestdetail_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblRequestdetail] CHECK CONSTRAINT [FK_tblRequestdetail_tblEmployee]
GO
/****** Object:  ForeignKey [FK_tblStock_tblItem]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tblItem] ([ItemId])
GO
ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblItem]
GO
/****** Object:  ForeignKey [FK_tblTest_tblCandidate]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblTest]  WITH CHECK ADD  CONSTRAINT [FK_tblTest_tblCandidate] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[tblCandidates] ([CandidateId])
GO
ALTER TABLE [dbo].[tblTest] CHECK CONSTRAINT [FK_tblTest_tblCandidate]
GO
/****** Object:  ForeignKey [FK_tblResults_tblTest]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblResults]  WITH CHECK ADD  CONSTRAINT [FK_tblResults_tblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[tblTest] ([TestId])
GO
ALTER TABLE [dbo].[tblResults] CHECK CONSTRAINT [FK_tblResults_tblTest]
GO
/****** Object:  ForeignKey [FK_Users_Roles]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tblRoles] ([Id])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  ForeignKey [FK_Users_tbladmincheck]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_Users_tbladmincheck] FOREIGN KEY([AdminId])
REFERENCES [dbo].[tblAdmincheck] ([AdminId])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_Users_tbladmincheck]
GO
/****** Object:  ForeignKey [FK_tblVacancies_tblDepartment]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblVacancies]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancies_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblVacancies] CHECK CONSTRAINT [FK_tblVacancies_tblDepartment]
GO
/****** Object:  ForeignKey [FK_tblVacancydetails_tblDepartment]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblVacancydetails]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancydetails_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblVacancydetails] CHECK CONSTRAINT [FK_tblVacancydetails_tblDepartment]
GO
/****** Object:  ForeignKey [FK_tblVacancydetails_tblStructure]    Script Date: 02/22/2020 19:33:56 ******/
ALTER TABLE [dbo].[tblVacancydetails]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancydetails_tblStructure] FOREIGN KEY([StructureId])
REFERENCES [dbo].[tblStructuredetail] ([Id])
GO
ALTER TABLE [dbo].[tblVacancydetails] CHECK CONSTRAINT [FK_tblVacancydetails_tblStructure]
GO
