USE [Hrms]
GO
/****** Object:  Table [dbo].[tblAdmincheck]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblApplicant]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCandidates]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCandidates](
	[CandidateId] [int] NOT NULL,
	[ApplicationId] [int] NULL,
	[Cname] [nvarchar](max) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tblCandidates] PRIMARY KEY CLUSTERED 
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDepartments]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDocDetails]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDocDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNo] [int] NULL,
	[ItemId] [int] NULL,
	[ItemName] [nvarchar](max) NULL,
	[VendorId] [int] NULL,
	[VendorName] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[DeliveredQuantity] [int] NULL,
	[PartialDeliveredQuantity] [int] NULL,
	[RemainingQuantity] [int] NULL,
	[TotalPrice] [money] NULL,
	[POReference] [int] NULL,
 CONSTRAINT [PK_tblDocDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDoctype]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDoctype](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType] [varchar](50) NULL,
	[DocumentName] [varchar](100) NULL,
	[NumberRangefrom] [int] NULL,
	[NumberRangeTo] [int] NULL,
 CONSTRAINT [PK_tblDoctype] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDocument]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDocument](
	[DocumentNo] [int] IDENTITY(1,1) NOT NULL,
	[Docno] [varchar](max) NULL,
	[DTypeId] [int] NULL,
	[CreationDate] [date] NULL,
	[CreatedBy] [varchar](50) NULL,
	[DocStatus] [varchar](100) NULL,
	[Status] [varchar](75) NULL,
	[VendorId] [int] NULL,
	[ItemRequestedDate] [date] NULL,
	[DeliveryDate] [date] NULL,
	[IssuedDate] [date] NULL,
	[ItemName] [nvarchar](max) NULL,
	[PrReferenceNo] [int] NULL,
	[POReferenceno] [int] NULL,
	[ReturnReferenceno] [int] NULL,
	[GRReferencenoforReturn] [int] NULL,
	[Reasonofreturn] [varchar](max) NULL,
	[GRApproved] [varchar](50) NULL,
 CONSTRAINT [PK_tblDocument] PRIMARY KEY CLUSTERED 
(
	[DocumentNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployeeDetail]    Script Date: 11/22/2020 4:13:19 PM ******/
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
	[EmployeeSalary] [money] NULL,
	[IsSalaryset] [bit] NULL,
	[IsSeenPromotion] [bit] NULL,
 CONSTRAINT [PK_tblEmployeeDetail] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployeeLeaves]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployeeLeaves](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[CasualLeave] [int] NULL,
	[SickLeave] [int] NULL,
 CONSTRAINT [PK_tblEmployeeLeaves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblExpenses]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExpenses](
	[ExpenseId] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Month] [varchar](max) NULL,
	[ExpenseDate] [date] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_tblExpenses] PRIMARY KEY CLUSTERED 
(
	[ExpenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGiLine]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGiLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GINo] [int] NULL,
	[ItemId] [int] NULL,
	[IssuedQuantity] [int] NULL,
 CONSTRAINT [PK_tblGiLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGrItemsPrice]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGrItemsPrice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNo] [int] NULL,
	[ItemId] [int] NULL,
	[DeliveredQuantity] [int] NULL,
	[PartialDeliveredQuantity] [int] NULL,
	[ReturnQuantity] [int] NULL,
	[MissingQuantity] [int] NULL,
	[ApprovedQuantity] [int] NULL,
	[ItemPrice] [decimal](18, 0) NULL,
	[Approved] [varchar](50) NULL,
 CONSTRAINT [PK_tblGrItemsPrice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInvoiceReceipt]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvoiceReceipt](
	[InvoiceReceiptId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceReceiptNo] [varchar](max) NULL,
	[GRReferenceNo] [int] NULL,
	[TotalAmount] [money] NULL,
	[PaidAmount] [money] NULL,
	[Balance] [money] NULL,
	[Createdby] [varchar](100) NULL,
	[Createdon] [date] NULL,
	[Status] [varchar](75) NULL,
 CONSTRAINT [PK_tblInvoiceReceipt] PRIMARY KEY CLUSTERED 
(
	[InvoiceReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblItem]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblItem](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](max) NULL,
	[TypeId] [int] NULL,
	[StorageLocation] [varchar](75) NULL,
	[ReorderPoint] [int] NULL,
	[ItemPrice] [money] NULL,
	[IsConsumable] [int] NULL,
	[Availablestock] [int] NULL,
	[Qualityinspectionstock] [int] NULL,
 CONSTRAINT [PK_tblItem] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblItemType]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblItemType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemType] [varchar](75) NULL,
 CONSTRAINT [PK_tblItemType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrganizationStructure]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrganizationStructure](
	[CompanyCode] [int] NOT NULL,
	[CityCode] [int] NULL,
	[StorageLocation] [nvarchar](max) NULL,
	[PurchaseOrganization] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayroll]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPosition]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPosition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[JobLevel] [int] NULL,
	[Position] [varchar](max) NULL,
	[BasicPay] [money] NULL,
	[IncomeTax] [money] NULL,
	[Experience] [nvarchar](75) NULL,
 CONSTRAINT [PK_tblPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPositionLeavetypes]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPositionLeavetypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionId] [int] NULL,
	[CasualLeave] [int] NULL,
	[SickLeave] [int] NULL,
 CONSTRAINT [PK_tblPositionLeavetypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblprlineitem]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblprlineitem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemType] [varchar](max) NULL,
	[ItemName] [varchar](max) NULL,
	[Quantity] [int] NULL,
	[ItemPrice] [money] NULL,
	[VendorName] [varchar](max) NULL,
	[Status] [varchar](50) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_tblprlineitem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPurchase]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPurchaseitem]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRequestdetail]    Script Date: 11/22/2020 4:13:19 PM ******/
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRequests]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRequests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[PositionId] [int] NULL,
	[RequestType] [nvarchar](max) NULL,
	[LeaveType] [nvarchar](max) NULL,
	[CitytoTranser] [varchar](75) NULL,
	[DateofRequest] [datetime] NULL,
	[Status] [nvarchar](max) NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[Respondedby] [nvarchar](max) NULL,
	[ResponseDate] [datetime] NULL,
	[ReasonofRequest] [varchar](max) NULL,
	[AuthorizedRole] [varchar](75) NULL,
	[ResponseReason] [varchar](max) NULL,
	[IsSeen] [bit] NULL,
 CONSTRAINT [PK_tblRequests_1] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblResults]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblreturnlineitem]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblreturnlineitem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReturnNo] [int] NULL,
	[Grreferenceno] [int] NULL,
	[VendorId] [int] NULL,
	[ItemId] [int] NULL,
	[DeliveredQuantity] [int] NULL,
	[RejectedQuantity] [int] NULL,
	[ApprovedQtybyQuality] [int] NULL,
	[MissingQuantity] [int] NULL,
	[AvailableQuantity] [int] NULL,
	[ReturnQuantity] [int] NULL,
	[PartialReturnQuantity] [int] NULL,
	[RemainingQuantity] [int] NULL,
	[Approved] [varchar](50) NULL,
 CONSTRAINT [PK_tblreturnlineitem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoles]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSL]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSL](
	[SLId] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](75) NULL,
	[StorageLocation] [varchar](75) NULL,
 CONSTRAINT [PK_tblSL] PRIMARY KEY CLUSTERED 
(
	[SLId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStock]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[SLId] [int] NULL,
	[AvailableStock] [int] NULL,
 CONSTRAINT [PK_tblStock] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStructuredetail]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTest]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTestCriteria]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTestCriteria](
	[DepartmentId] [int] NULL,
	[PassingPercent] [nvarchar](max) NULL,
	[Marks] [int] NULL,
	[Grade] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 11/22/2020 4:13:19 PM ******/
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
	[ResetPasswordCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVacancies]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVacancydetails]    Script Date: 11/22/2020 4:13:19 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVendors]    Script Date: 11/22/2020 4:13:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVendors](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[TypeId] [int] NULL,
	[Address] [varchar](100) NULL,
	[VendorType] [varchar](100) NULL,
 CONSTRAINT [PK_tblVendors] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblApplicant]  WITH CHECK ADD  CONSTRAINT [FK_tblApplicant_tblVacancies] FOREIGN KEY([VacancyId])
REFERENCES [dbo].[tblVacancies] ([VacancyId])
GO
ALTER TABLE [dbo].[tblApplicant] CHECK CONSTRAINT [FK_tblApplicant_tblVacancies]
GO
ALTER TABLE [dbo].[tblCandidates]  WITH CHECK ADD  CONSTRAINT [FK_tblCandidates_tblApplicant] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[tblApplicant] ([ApplicationId])
GO
ALTER TABLE [dbo].[tblCandidates] CHECK CONSTRAINT [FK_tblCandidates_tblApplicant]
GO
ALTER TABLE [dbo].[tblDocDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblDocDetails_tblDocument] FOREIGN KEY([DocumentNo])
REFERENCES [dbo].[tblDocument] ([DocumentNo])
GO
ALTER TABLE [dbo].[tblDocDetails] CHECK CONSTRAINT [FK_tblDocDetails_tblDocument]
GO
ALTER TABLE [dbo].[tblDocDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblDocDetails_tblVendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[tblVendors] ([VendorId])
GO
ALTER TABLE [dbo].[tblDocDetails] CHECK CONSTRAINT [FK_tblDocDetails_tblVendor]
GO
ALTER TABLE [dbo].[tblDocument]  WITH CHECK ADD  CONSTRAINT [FK_tblDocument_tblDoctype] FOREIGN KEY([DTypeId])
REFERENCES [dbo].[tblDoctype] ([TypeId])
GO
ALTER TABLE [dbo].[tblDocument] CHECK CONSTRAINT [FK_tblDocument_tblDoctype]
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblDepartment]
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblPosition] FOREIGN KEY([PositionId])
REFERENCES [dbo].[tblPosition] ([Id])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblPosition]
GO
ALTER TABLE [dbo].[tblEmployeeDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeeDetail_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblEmployeeDetail] CHECK CONSTRAINT [FK_tblEmployeeDetail_tblEmployee]
GO
ALTER TABLE [dbo].[tblEmployeeLeaves]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeeLeaves_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblEmployeeLeaves] CHECK CONSTRAINT [FK_tblEmployeeLeaves_tblEmployee]
GO
ALTER TABLE [dbo].[tblItem]  WITH CHECK ADD  CONSTRAINT [FK_tblItem_tblItemType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[tblItemType] ([Id])
GO
ALTER TABLE [dbo].[tblItem] CHECK CONSTRAINT [FK_tblItem_tblItemType]
GO
ALTER TABLE [dbo].[tblPayroll]  WITH CHECK ADD  CONSTRAINT [FK_tblPayroll_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblPayroll] CHECK CONSTRAINT [FK_tblPayroll_tblEmployee]
GO
ALTER TABLE [dbo].[tblPosition]  WITH CHECK ADD  CONSTRAINT [FK_tblPosition_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblPosition] CHECK CONSTRAINT [FK_tblPosition_tblDepartment]
GO
ALTER TABLE [dbo].[tblPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchase_tblDocument] FOREIGN KEY([DocumentNo])
REFERENCES [dbo].[tblDocument] ([DocumentNo])
GO
ALTER TABLE [dbo].[tblPurchase] CHECK CONSTRAINT [FK_tblPurchase_tblDocument]
GO
ALTER TABLE [dbo].[tblPurchaseitem]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseitem_tblItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tblItem] ([ItemId])
GO
ALTER TABLE [dbo].[tblPurchaseitem] CHECK CONSTRAINT [FK_tblPurchaseitem_tblItem]
GO
ALTER TABLE [dbo].[tblPurchaseitem]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseitem_tblPurchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[tblPurchase] ([PurchaseId])
GO
ALTER TABLE [dbo].[tblPurchaseitem] CHECK CONSTRAINT [FK_tblPurchaseitem_tblPurchase]
GO
ALTER TABLE [dbo].[tblRequestdetail]  WITH CHECK ADD  CONSTRAINT [FK_tblRequestdetail_tblEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[tblEmployee] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblRequestdetail] CHECK CONSTRAINT [FK_tblRequestdetail_tblEmployee]
GO
ALTER TABLE [dbo].[tblResults]  WITH CHECK ADD  CONSTRAINT [FK_tblResults_tblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[tblTest] ([TestId])
GO
ALTER TABLE [dbo].[tblResults] CHECK CONSTRAINT [FK_tblResults_tblTest]
GO
ALTER TABLE [dbo].[tblTest]  WITH CHECK ADD  CONSTRAINT [FK_tblTest_tblCandidate] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[tblCandidates] ([CandidateId])
GO
ALTER TABLE [dbo].[tblTest] CHECK CONSTRAINT [FK_tblTest_tblCandidate]
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tblRoles] ([Id])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_Users_tbladmincheck] FOREIGN KEY([AdminId])
REFERENCES [dbo].[tblAdmincheck] ([AdminId])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_Users_tbladmincheck]
GO
ALTER TABLE [dbo].[tblVacancies]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancies_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblVacancies] CHECK CONSTRAINT [FK_tblVacancies_tblDepartment]
GO
ALTER TABLE [dbo].[tblVacancydetails]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancydetails_tblDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartments] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblVacancydetails] CHECK CONSTRAINT [FK_tblVacancydetails_tblDepartment]
GO
ALTER TABLE [dbo].[tblVacancydetails]  WITH CHECK ADD  CONSTRAINT [FK_tblVacancydetails_tblStructure] FOREIGN KEY([StructureId])
REFERENCES [dbo].[tblStructuredetail] ([Id])
GO
ALTER TABLE [dbo].[tblVacancydetails] CHECK CONSTRAINT [FK_tblVacancydetails_tblStructure]
GO
ALTER TABLE [dbo].[tblVendors]  WITH CHECK ADD  CONSTRAINT [FK_tblVendors_tblItemType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[tblItemType] ([Id])
GO
ALTER TABLE [dbo].[tblVendors] CHECK CONSTRAINT [FK_tblVendors_tblItemType]
GO
