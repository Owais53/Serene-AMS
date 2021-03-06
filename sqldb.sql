USE [Hrms]
GO
/****** Object:  Table [dbo].[tblAdmincheck]    Script Date: 12/6/2020 7:00:59 PM ******/
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
/****** Object:  Table [dbo].[tblApplicant]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblCandidates]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblDepartments]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblDocDetails]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblDoctype]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblDocument]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblEmployeeDetail]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblEmployeeLeaves]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblExpenses]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblGiLine]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblGrItemsPrice]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblInvoiceReceipt]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblItem]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblItemType]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblOrganizationStructure]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblPayroll]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblPosition]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblPositionLeavetypes]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblprlineitem]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblPurchase]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblPurchaseitem]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblRequestdetail]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblRequests]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblResults]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblreturnlineitem]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblRoles]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblSL]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblStock]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblStructuredetail]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblTest]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblTestCriteria]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblUsers]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblVacancies]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblVacancydetails]    Script Date: 12/6/2020 7:01:00 PM ******/
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
/****** Object:  Table [dbo].[tblVendors]    Script Date: 12/6/2020 7:01:00 PM ******/
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
INSERT [dbo].[tblAdmincheck] ([AdminId], [IsAdmin], [desc]) VALUES (0, N'0', N'NotAdmin')
INSERT [dbo].[tblAdmincheck] ([AdminId], [IsAdmin], [desc]) VALUES (1, N'1', N'Admin')
SET IDENTITY_INSERT [dbo].[tblApplicant] ON 

INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (6, 1, N'Owais', N'03003497300', N'owaismumtaz96@gmail.com', CAST(N'1996-12-07' AS Date), N'Male', N'Recruitment Manager', N'Hired', CAST(N'2020-02-01' AS Date), N'H#669, DOHS-1, Malir Cantt', N'd022e7f8-84f4-4667-aa2a-e5185b95306e.pdf', 77, N'Pass', CAST(N'2020-02-15' AS Date), CAST(N'2020-03-02' AS Date), 70000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (7, 2, N'Aamir Mumtaz', N'03028285732', N'aamirmumtaz22@gmail.com', CAST(N'1992-07-19' AS Date), N'Male', N'Hiring Manager', N'Hired', CAST(N'2020-02-01' AS Date), N'H#669, DOHS-1, Malir Cantt', N'f80de075-1f72-4a2e-92a7-57fa18978d7b.docx', 88, N'Pass', CAST(N'2020-02-16' AS Date), CAST(N'2020-02-24' AS Date), 50000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (8, 3, N'Afzaal', N'0342453355', N'afzaal@gmail.com', CAST(N'2020-02-15' AS Date), N'Male', N'Recruitment Officer', N'Hired', CAST(N'2020-02-02' AS Date), N'Malir Cantt', N'31f3ebce-f855-4bdd-80c8-f5b6fae27d15.pdf', 70, N'Pass', CAST(N'2020-02-16' AS Date), CAST(N'2020-02-17' AS Date), 35000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (9, 1, N'Tahir', N'03003497300', N'owaismumtaz96@gmail.com', CAST(N'1995-09-22' AS Date), N'Male', N'Recruitment Officer', N'Hired', CAST(N'2020-02-12' AS Date), N'H#669, DOHS-1, Malir Cantt', N'e6dd05ab-d19b-44a6-adf1-06bf93e65e79.pdf', 70, N'Pass', CAST(N'2020-02-16' AS Date), CAST(N'2020-02-24' AS Date), 50000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (10, 7, N'Hassan', N'03304573735', N'hassanzulfiqar@gmail.com', CAST(N'1995-01-09' AS Date), N'Male', N'Hr Officer', N'Hired', CAST(N'2020-02-16' AS Date), N'Malir Halt', N'd42d2d5c-0c83-4262-b6cf-ee19ef3ccfd5.pdf', 65, N'Pass', CAST(N'2020-03-13' AS Date), CAST(N'2020-03-13' AS Date), 15000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (11, 8, N'Ahmed Zafar', N'03423058814', N'ahmedzafar422@gmail.com', CAST(N'1997-12-24' AS Date), N'Male', N'Hiring Manager', N'Hired', CAST(N'2020-02-16' AS Date), N'Malir Cantt', N'bbced265-956d-4d2c-b40c-ebe9496dd347.pdf', 67, N'Pass', CAST(N'2020-02-17' AS Date), CAST(N'2020-02-18' AS Date), 40000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (12, 12, N'Ali Ahmed', N'03003497300', N'owaismumtaz96@gmail.com', CAST(N'1969-03-23' AS Date), N'Male', N'DGM', N'Hired', CAST(N'2020-02-19' AS Date), N'H#669, DOHS-1, Malir Cantt', N'6011b1a0-0c62-4a7a-9fe1-55a0013e8101.pdf', 75, N'Pass', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-16' AS Date), 90000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (13, 13, N'Waqas nasir', N'03303497300', N'waqasnasir@gmail.com', CAST(N'1997-03-03' AS Date), N'Male', N'Hr Officer', N'Hired', CAST(N'2020-03-01' AS Date), N'H # 669, DOHS-1, Malir Cantt', N'a7ecff22-4b05-4db5-95e0-4558afe6e3d6.docx', 61, N'Pass', CAST(N'2020-03-01' AS Date), CAST(N'2020-03-24' AS Date), 684735.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (14, 13, N'Waqas nasir', N'03303497300', N'owaismumtaz96@gmail.com', CAST(N'1997-03-03' AS Date), N'Male', N'Hr Officer', N'Called for Interview', CAST(N'2020-03-01' AS Date), N'H # 669, DOHS-1, Malir Cantt', N'435a45cb-eb3b-48d4-84d3-7650d7cd1fc4.docx', 87, N'Pass', CAST(N'2020-08-19' AS Date), NULL, NULL)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (1013, 3, N'Ali', N'03003497300', N'owaismumtaz96@gmail.com', CAST(N'1996-01-10' AS Date), N'Male', N'Store Manager', N'Hired', CAST(N'2020-05-03' AS Date), N'H # 669, DOHS-1, Malir Cantt', N'121d720d-e5e4-4e26-8d10-2bfbe5362abf.docx', 89, N'Pass', CAST(N'2020-05-03' AS Date), CAST(N'2020-05-13' AS Date), 71000.0000)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (1014, 1014, N'Owais Mumtaz', N'03003497300', N'owaismumtaz96@gmail.com', CAST(N'2001-01-24' AS Date), N'Male', N'Hiring Manager', N'Rejected', CAST(N'2020-08-15' AS Date), N'H # 669, DOHS-1, Malir Cantt', N'73abdb7b-e5fa-4b46-a2aa-ad95f2d19332.pdf', NULL, N'Pending', NULL, NULL, NULL)
INSERT [dbo].[tblApplicant] ([ApplicationId], [VacancyId], [ApplicantName], [Phone], [Email], [Dob], [Gender], [Appliedfor], [Status], [Submittedon], [Address], [CV], [Marks], [TestStatus], [InterviewDate], [JoiningDate], [Salary]) VALUES (1015, 1014, N'Owais Mumtaz', N'03003497300', N'owaismumtaz96@gmail.com', CAST(N'2001-01-24' AS Date), N'Male', N'Hiring Manager', N'Called for Interview', CAST(N'2020-08-15' AS Date), N'H # 669, DOHS-1, Malir Cantt', N'15246c7e-a2f7-4a4b-9b05-4a4089cdfa34.pdf', 76, N'Pass', CAST(N'2020-08-15' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblApplicant] OFF
SET IDENTITY_INSERT [dbo].[tblDepartments] ON 

INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (1, N'HR')
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (3, N'Finance')
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (4, N'Supply Chain')
INSERT [dbo].[tblDepartments] ([DepartmentId], [DepartmentName]) VALUES (5, N'BI')
SET IDENTITY_INSERT [dbo].[tblDepartments] OFF
SET IDENTITY_INSERT [dbo].[tblDocDetails] ON 

INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4332, 2201, 1, NULL, 3, NULL, 3, 3, 0, 0, 600000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4333, 2202, 1, NULL, 3, NULL, 3, 3, 1, 0, 600000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4334, 2202, 2, NULL, 3, NULL, 1, 1, 0, 0, 10000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4335, 2203, 2, NULL, 3, NULL, 1, 1, 0, 0, 10000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4336, 2203, 1, NULL, 3, NULL, 4, 4, 1, 0, 800000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4337, 2204, 6, NULL, 1, NULL, 3, 3, 0, 0, 400000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4338, 2205, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4339, 2205, 2, NULL, 4, NULL, 2, 2, 0, 0, 20000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4340, 2205, 4, NULL, 4, NULL, 1, 1, 0, 0, 1000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4341, 2206, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4342, 2206, 2, NULL, 4, NULL, 2, 2, 0, 0, 20000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4343, 2206, 4, NULL, 4, NULL, 1, 1, 0, 0, 1000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4344, 2207, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4345, 2207, 2, NULL, 4, NULL, 2, 2, 0, 0, 20000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4346, 2207, 4, NULL, 4, NULL, 1, 1, 0, 0, 1000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4347, 2208, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4348, 2208, 2, NULL, 4, NULL, 2, 2, 0, 0, 20000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4349, 2208, 4, NULL, 4, NULL, 1, 1, 0, 0, 1000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4350, 2209, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4351, 2209, 2, NULL, 4, NULL, 2, 2, 0, 0, 20000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4352, 2209, 4, NULL, 4, NULL, 1, 1, 0, 0, 1000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4353, 2210, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4354, 2210, 2, NULL, 4, NULL, 2, 2, 1, 0, 20000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4355, 2211, 1, NULL, 4, NULL, 1, 1, 0, 0, 200000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4356, 2212, 2, NULL, 4, NULL, 1, NULL, 0, -1, 10000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4357, 2213, 2, NULL, 4, NULL, 1, NULL, 0, -1, 10000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (4358, 2214, 2, NULL, 4, NULL, 1, NULL, 0, -1, 10000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (5352, 3242, 2, NULL, 4, NULL, 3, 3, 0, 0, 30000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (5353, 3242, 1, NULL, 4, NULL, 2, 1, 0, 1, 400000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (5354, 3245, 1, NULL, 3, NULL, 2, 2, 0, 0, 400000.0000, NULL)
INSERT [dbo].[tblDocDetails] ([Id], [DocumentNo], [ItemId], [ItemName], [VendorId], [VendorName], [Quantity], [DeliveredQuantity], [PartialDeliveredQuantity], [RemainingQuantity], [TotalPrice], [POReference]) VALUES (5355, 3245, 2, NULL, 3, NULL, 3, 1, 0, 2, 30000.0000, NULL)
SET IDENTITY_INSERT [dbo].[tblDocDetails] OFF
SET IDENTITY_INSERT [dbo].[tblDoctype] ON 

INSERT [dbo].[tblDoctype] ([TypeId], [DocumentType], [DocumentName], [NumberRangefrom], [NumberRangeTo]) VALUES (1, N'PR', N'Purchase Request', 1000, 1999)
INSERT [dbo].[tblDoctype] ([TypeId], [DocumentType], [DocumentName], [NumberRangefrom], [NumberRangeTo]) VALUES (3, N'PO', N'Purchase Order', NULL, NULL)
INSERT [dbo].[tblDoctype] ([TypeId], [DocumentType], [DocumentName], [NumberRangefrom], [NumberRangeTo]) VALUES (4, N'GR', N'Goods Receipt', NULL, NULL)
INSERT [dbo].[tblDoctype] ([TypeId], [DocumentType], [DocumentName], [NumberRangefrom], [NumberRangeTo]) VALUES (5, N'Return', N'Return Delivery', NULL, NULL)
INSERT [dbo].[tblDoctype] ([TypeId], [DocumentType], [DocumentName], [NumberRangefrom], [NumberRangeTo]) VALUES (6, N'GI', N'Goods Issue', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblDoctype] OFF
SET IDENTITY_INSERT [dbo].[tblDocument] ON 

INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2201, N'PR - 2201', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 3, CAST(N'2020-08-13' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2202, N'PR - 2202', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 3, CAST(N'2020-08-13' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2203, N'PR - 2203', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 3, CAST(N'2020-08-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2204, N'PR - 2204', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 1, CAST(N'2020-08-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2205, N'PR - 2205', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2206, N'PR - 2206', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-18' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2207, N'PR - 2207', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-24' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2208, N'PR - 2208', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-19' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2209, N'PR - 2209', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-19' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2210, N'PR - 2210', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-19' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2211, N'PR - 2211', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-19' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2212, N'PR - 2212', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-19' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2213, N'PR - 2213', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-24' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (2214, N'PR - 2214', 1, CAST(N'2020-08-13' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3210, N'PO - 3210', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 3, CAST(N'2020-08-13' AS Date), CAST(N'2020-08-13' AS Date), NULL, NULL, 2201, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3211, N'PO - 3211', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 3, CAST(N'2020-08-13' AS Date), CAST(N'2020-08-13' AS Date), NULL, NULL, 2202, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3212, N'PO - 3212', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 3, CAST(N'2020-08-14' AS Date), CAST(N'2020-08-14' AS Date), NULL, NULL, 2203, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3213, N'PO - 3213', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 1, CAST(N'2020-08-14' AS Date), CAST(N'2020-08-14' AS Date), NULL, NULL, 2204, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3214, N'PO - 3214', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-14' AS Date), CAST(N'2020-08-14' AS Date), NULL, NULL, 2205, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3215, N'PO - 3215', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-18' AS Date), CAST(N'2020-08-18' AS Date), NULL, NULL, 2206, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3216, N'PO - 3216', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-24' AS Date), CAST(N'2020-08-24' AS Date), NULL, NULL, 2207, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3217, N'PO - 3217', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), NULL, NULL, 2208, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3218, N'PO - 3218', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), NULL, NULL, 2209, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3219, N'PO - 3219', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), NULL, NULL, 2210, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3220, N'PO - 3220', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete Delivery', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), NULL, NULL, 2211, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3221, N'PO - 3221', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', NULL, 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), NULL, NULL, 2212, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3222, N'PO - 3222', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', NULL, 4, CAST(N'2020-08-24' AS Date), CAST(N'2020-08-24' AS Date), NULL, NULL, 2213, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3223, N'PO - 3223', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', NULL, 4, CAST(N'2020-08-26' AS Date), CAST(N'2020-08-26' AS Date), NULL, NULL, 2214, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3224, N'GR - 3224', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Open', N'Paid', 3, NULL, NULL, NULL, NULL, NULL, 3210, NULL, NULL, NULL, N'Yes')
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3226, N'GR - 3226', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Open', N'Rejected', 3, NULL, NULL, NULL, NULL, NULL, 3211, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3228, N'GR - 3228', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Paid', 3, NULL, NULL, NULL, NULL, NULL, 3212, NULL, NULL, NULL, N'Yes')
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3229, N'GR - 3229', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Paid', 1, NULL, NULL, NULL, NULL, NULL, 3213, NULL, NULL, NULL, N'Yes')
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3230, N'GR - 3230', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Paid', 4, NULL, NULL, NULL, NULL, NULL, 3214, NULL, NULL, NULL, N'Yes')
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3231, N'GR - 3231', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Open', N'Rejected', 4, NULL, NULL, NULL, NULL, NULL, 3215, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3232, N'GR - 3232', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Paid', 4, NULL, NULL, NULL, NULL, NULL, 3216, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3233, N'GR - 3233', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Open', N'Rejected', 4, NULL, NULL, NULL, NULL, NULL, 3217, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3234, N'GR - 3234', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Open', N'Complete', 4, NULL, NULL, NULL, NULL, NULL, 3218, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3235, N'Return - 3235', 5, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'InProgress', 3, NULL, CAST(N'2020-08-14' AS Date), NULL, NULL, 2201, NULL, NULL, 3224, N'Bad Quality', NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3236, N'Return - 3236', 5, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'InProgress', 3, NULL, CAST(N'2020-08-14' AS Date), NULL, NULL, 2202, NULL, NULL, 3226, N'Bad Quality', NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3237, N'Return - 3237', 5, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'InProgress', 4, NULL, CAST(N'2020-08-14' AS Date), NULL, NULL, 2206, NULL, NULL, 3231, N'Bad Quality', NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3238, N'Return - 3238', 5, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'InProgress', 4, NULL, CAST(N'2020-08-14' AS Date), NULL, NULL, 2209, NULL, NULL, 3234, N'Damaged Goods', NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3239, N'Return - 3239', 5, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'InProgress', 4, NULL, CAST(N'2020-08-14' AS Date), NULL, NULL, 2208, NULL, NULL, 3233, N'Damaged Goods', NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3240, N'GR - 3240', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Partial', 4, NULL, NULL, NULL, NULL, NULL, 3219, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3241, N'GR - 3241', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Paid', 4, NULL, NULL, NULL, NULL, NULL, 3219, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3242, N'PR - 3242', 1, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'PO Created', 4, CAST(N'2020-08-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3243, N'PO - 3243', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Partial Delivery', 4, CAST(N'2020-08-14' AS Date), CAST(N'2020-08-14' AS Date), NULL, NULL, 3242, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3244, N'GR - 3244', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Partial', 4, NULL, NULL, NULL, NULL, NULL, 3243, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3245, N'PR - 3245', 1, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'PO Created', 3, CAST(N'2020-08-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3246, N'PO - 3246', 3, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Partial Delivery', 3, CAST(N'2020-08-14' AS Date), CAST(N'2020-08-14' AS Date), NULL, NULL, 3245, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3247, N'GR - 3247', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Partial', 3, NULL, NULL, NULL, NULL, NULL, 3246, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblDocument] ([DocumentNo], [Docno], [DTypeId], [CreationDate], [CreatedBy], [DocStatus], [Status], [VendorId], [ItemRequestedDate], [DeliveryDate], [IssuedDate], [ItemName], [PrReferenceNo], [POReferenceno], [ReturnReferenceno], [GRReferencenoforReturn], [Reasonofreturn], [GRApproved]) VALUES (3248, N'GR - 3248', 4, CAST(N'2020-08-14' AS Date), N'Owais', N'Complete', N'Complete', 4, NULL, NULL, NULL, NULL, NULL, 3220, NULL, NULL, NULL, N'Yes')
SET IDENTITY_INSERT [dbo].[tblDocument] OFF
SET IDENTITY_INSERT [dbo].[tblEmployee] ON 

INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 46, N'Tahir', N'Male', 1, CAST(N'1995-09-22' AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 1, 16)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 47, N'Aamir Mumtaz', N'Male', 1, CAST(N'1992-07-19' AS Date), N'03028285732', N'aamirmumtaz22@gmail.com', N'H#669, DOHS-1, Malir Cantt', 19, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 48, N'Afzaal', N'Male', 1, CAST(N'2020-02-15' AS Date), N'0342453355', N'owaismumtaz96@gmail.com', N'Malir Cantt', 1, 18)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 49, N'Owais', N'Male', 1, CAST(N'1996-12-07' AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 20, 15)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 50, N'Tahir', N'Male', 1, CAST(N'1995-09-22' AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 1, 19)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 51, N'Aamir Mumtaz', N'Male', 1, CAST(N'1992-07-19' AS Date), N'03028285732', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 19, 1019)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 52, N'Afzaal', N'Male', 4, CAST(N'2020-02-15' AS Date), N'0342453355', N'afzaal@gmail.com', N'Malir Cantt', 2021, 2021)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Islamabad', 53, N'Tahir', N'Male', 1, CAST(N'1995-09-22' AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 1, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 54, N'Ahmed Zafar', N'Male', 1, CAST(N'1997-12-24' AS Date), N'03423058814', N'ahmedzafar422@gmail.com', N'Malir Cantt', 19, 2019)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Karachi', 57, N'Waqas nasir', N'Male', 1, CAST(N'1997-03-03' AS Date), N'03303497300', N'waqasnasir@gmail.com', N'H # 669, DOHS-1, Malir Cantt', 18, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Islamabad', 1061, N'Ali Ahmed', N'Male', 1, CAST(N'1969-03-23' AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H#669, DOHS-1, Malir Cantt', 19, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Islamabad', 1062, N'Hassan', N'Male', 1, CAST(N'1995-01-09' AS Date), N'03304573735', N'hassanzulfiqar@gmail.com', N'Malir Halt', 18, NULL)
INSERT [dbo].[tblEmployee] ([CityName], [EmployeeId], [EmployeeName], [Gender], [DepartmentId], [DateofBirth], [Contact], [Email], [Address], [PositionId], [UserId]) VALUES (N'Lahore', 2062, N'Ali', N'Male', 4, CAST(N'1996-01-10' AS Date), N'03003497300', N'owaismumtaz96@gmail.com', N'H # 669, DOHS-1, Malir Cantt', 3, 2020)
SET IDENTITY_INSERT [dbo].[tblEmployee] OFF
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (46, N'Active', CAST(N'2020-02-24T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (47, N'Active', CAST(N'2020-02-24T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2020-03-09T00:00:00.000' AS DateTime), NULL, 95000.0000, 1, 0)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (48, N'Active', CAST(N'2020-02-17T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2020-05-02T00:00:00.000' AS DateTime), NULL, 90000.0000, 1, 1)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (49, N'Active', CAST(N'2020-03-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (50, N'Active', CAST(N'2020-02-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (51, N'Active', CAST(N'2020-02-24T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2020-03-12T00:00:00.000' AS DateTime), NULL, 95000.0000, 1, 1)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (52, N'Active', CAST(N'2020-02-17T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (53, N'Active', CAST(N'2020-02-24T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (54, N'Active', CAST(N'2020-02-18T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2020-03-21T00:00:00.000' AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (57, N'Active', CAST(N'2020-03-24T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (1061, N'Active', CAST(N'2020-03-16T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 90000.0000, 1, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (1062, N'Active', CAST(N'2020-03-13T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 15000.0000, 1, NULL)
INSERT [dbo].[tblEmployeeDetail] ([EmployeeId], [EmployeeStatus], [Dateofjoining], [Dateofresignation], [DateofTransfer], [DateofPromotion], [LastLeaveDate], [EmployeeSalary], [IsSalaryset], [IsSeenPromotion]) VALUES (2062, N'Active', CAST(N'2020-05-13T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 71000.0000, 1, NULL)
SET IDENTITY_INSERT [dbo].[tblEmployeeLeaves] ON 

INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (1, 1062, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (2, 46, 2, 1)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (3, 47, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (4, 48, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (5, 49, 2, 6)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (6, 50, 0, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (7, 51, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (8, 52, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (9, 53, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (10, 54, 6, 5)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (11, 57, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (12, 1061, NULL, NULL)
INSERT [dbo].[tblEmployeeLeaves] ([Id], [EmployeeId], [CasualLeave], [SickLeave]) VALUES (1002, 2062, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblEmployeeLeaves] OFF
SET IDENTITY_INSERT [dbo].[tblExpenses] ON 

INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (1, 2020, N'5', CAST(N'2020-05-03' AS Date), 2000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (2, 2020, N'5', CAST(N'2020-05-04' AS Date), 1000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (3, 2020, N'4', CAST(N'2020-04-03' AS Date), 6000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (4, 2020, N'4', CAST(N'2020-04-23' AS Date), 4000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (6, 2020, N'5', CAST(N'2020-05-03' AS Date), 2000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (7, 2020, N'1', CAST(N'2020-01-03' AS Date), 20000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (8, 2020, N'1', CAST(N'2020-01-24' AS Date), 100.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (9, 2020, N'2', CAST(N'2020-02-05' AS Date), 25000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (10, 2020, N'3', CAST(N'2020-03-26' AS Date), 1000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (11, 2020, N'3', CAST(N'2020-03-12' AS Date), 10000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (12, 2019, N'1', CAST(N'2019-01-15' AS Date), 1000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (14, 2020, N'8', CAST(N'2020-08-14' AS Date), 600000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (15, 2020, N'8', CAST(N'2020-08-14' AS Date), 200000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (16, 2020, N'8', CAST(N'2020-08-14' AS Date), 200000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (17, 2020, N'8', CAST(N'2020-08-14' AS Date), 300000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (18, 2020, N'8', CAST(N'2020-08-14' AS Date), 200000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (19, 2020, N'8', CAST(N'2020-08-14' AS Date), 200000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (20, 2020, N'8', CAST(N'2020-08-14' AS Date), 200000.0000)
INSERT [dbo].[tblExpenses] ([ExpenseId], [Year], [Month], [ExpenseDate], [Amount]) VALUES (21, 2020, N'8', CAST(N'2020-08-14' AS Date), 10000.0000)
SET IDENTITY_INSERT [dbo].[tblExpenses] OFF
SET IDENTITY_INSERT [dbo].[tblGrItemsPrice] ON 

INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1054, 3224, 1, 3, NULL, 1, 0, 2, CAST(600000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1055, 3226, 1, 1, NULL, 1, 0, 0, CAST(200000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1056, 3228, 1, 1, NULL, 0, 0, 0, CAST(200000 AS Decimal(18, 0)), N'Yes')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1057, 3229, 6, 3, NULL, 0, 0, 0, CAST(300000 AS Decimal(18, 0)), N'Yes')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1058, 3230, 1, 1, NULL, 0, 0, 0, CAST(200000 AS Decimal(18, 0)), N'Yes')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1059, 3231, 1, 1, NULL, 1, 0, 0, CAST(200000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1060, 3232, 1, 1, NULL, 0, 0, 0, CAST(200000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1061, 3233, 1, 1, NULL, 1, 0, 0, CAST(200000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1062, 3234, 1, 1, NULL, 1, 0, 0, CAST(200000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1063, 3241, 2, 1, NULL, 0, 0, 0, CAST(10000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1064, 3247, 1, 2, NULL, 0, 0, 0, CAST(400000 AS Decimal(18, 0)), N'No')
INSERT [dbo].[tblGrItemsPrice] ([id], [DocumentNo], [ItemId], [DeliveredQuantity], [PartialDeliveredQuantity], [ReturnQuantity], [MissingQuantity], [ApprovedQuantity], [ItemPrice], [Approved]) VALUES (1065, 3248, 1, 1, NULL, 0, 0, 0, CAST(200000 AS Decimal(18, 0)), N'Yes')
SET IDENTITY_INSERT [dbo].[tblGrItemsPrice] OFF
SET IDENTITY_INSERT [dbo].[tblInvoiceReceipt] ON 

INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1015, N'IR - 1015', 3224, 600000.0000, 600000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1016, N'IR - 1016', 3226, 200000.0000, 200000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1017, N'IR - 1017', 3228, 200000.0000, 200000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1018, N'IR - 1018', 3229, 300000.0000, 300000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1019, N'IR - 1019', 3230, 200000.0000, 200000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1020, N'IR - 1020', 3231, 200000.0000, 200000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1021, N'IR - 1021', 3232, 200000.0000, 200000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
INSERT [dbo].[tblInvoiceReceipt] ([InvoiceReceiptId], [InvoiceReceiptNo], [GRReferenceNo], [TotalAmount], [PaidAmount], [Balance], [Createdby], [Createdon], [Status]) VALUES (1022, N'IR - 1022', 3241, 10000.0000, 10000.0000, 0.0000, N'Owais', CAST(N'2020-08-14' AS Date), N'Complete')
SET IDENTITY_INSERT [dbo].[tblInvoiceReceipt] OFF
SET IDENTITY_INSERT [dbo].[tblItem] ON 

INSERT [dbo].[tblItem] ([ItemId], [ItemName], [TypeId], [StorageLocation], [ReorderPoint], [ItemPrice], [IsConsumable], [Availablestock], [Qualityinspectionstock]) VALUES (1, N'Sealent', 1, N'Foreign Receipt Section', 3, 200000.0000, 1, 8, 0)
INSERT [dbo].[tblItem] ([ItemId], [ItemName], [TypeId], [StorageLocation], [ReorderPoint], [ItemPrice], [IsConsumable], [Availablestock], [Qualityinspectionstock]) VALUES (2, N'Tyres', 1, N'Local Receipt Section', 4, 10000.0000, 0, 5, 1)
INSERT [dbo].[tblItem] ([ItemId], [ItemName], [TypeId], [StorageLocation], [ReorderPoint], [ItemPrice], [IsConsumable], [Availablestock], [Qualityinspectionstock]) VALUES (4, N'Screw', 1, N'Local Receipt Section', 24, 1000.0000, 1, 31, 0)
INSERT [dbo].[tblItem] ([ItemId], [ItemName], [TypeId], [StorageLocation], [ReorderPoint], [ItemPrice], [IsConsumable], [Availablestock], [Qualityinspectionstock]) VALUES (6, N'Engine', 2, N'Foreign Receipt Section', 3, 100000.0000, 1, 3, 0)
SET IDENTITY_INSERT [dbo].[tblItem] OFF
SET IDENTITY_INSERT [dbo].[tblItemType] ON 

INSERT [dbo].[tblItemType] ([Id], [ItemType]) VALUES (1, N'Consumable(One Time Use)')
INSERT [dbo].[tblItemType] ([Id], [ItemType]) VALUES (2, N'Rotable(Reusable)')
SET IDENTITY_INSERT [dbo].[tblItemType] OFF
SET IDENTITY_INSERT [dbo].[tblPosition] ON 

INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (1, 1, 4, N'Recruitment Officer', 85000.0000, NULL, N'7 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (2, 1, 3, N'Hiring Manager', 90000.0000, NULL, N'5 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (3, 4, 3, N'Store Manager', 70000.0000, NULL, N'4 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (4, 1, 3, N'Recruitment Manager', 100000.0000, NULL, N'5 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (18, 1, 3, N'Hr Officer', 15000.0000, 15000.0000, N'8 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (19, 1, 4, N'DGM', 90000.0000, 3000.0000, N'11 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (20, 1, 5, N'CEO', 200000.0000, NULL, N'20 years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (1022, 3, 3, N'Accounts Officer', 70000.0000, 5000.0000, N'6 Years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (2020, 1, 3, N'GM', 90000.0000, 5000.0000, N'9 Years')
INSERT [dbo].[tblPosition] ([Id], [DepartmentId], [JobLevel], [Position], [BasicPay], [IncomeTax], [Experience]) VALUES (2021, 4, 3, N'Quality Manager', 60000.0000, 5000.0000, N'4 Years')
SET IDENTITY_INSERT [dbo].[tblPosition] OFF
SET IDENTITY_INSERT [dbo].[tblPositionLeavetypes] ON 

INSERT [dbo].[tblPositionLeavetypes] ([Id], [PositionId], [CasualLeave], [SickLeave]) VALUES (1, 1, 4, 8)
INSERT [dbo].[tblPositionLeavetypes] ([Id], [PositionId], [CasualLeave], [SickLeave]) VALUES (2, 2, 5, 10)
INSERT [dbo].[tblPositionLeavetypes] ([Id], [PositionId], [CasualLeave], [SickLeave]) VALUES (3, 20, 6, 8)
INSERT [dbo].[tblPositionLeavetypes] ([Id], [PositionId], [CasualLeave], [SickLeave]) VALUES (4, 19, 6, 5)
SET IDENTITY_INSERT [dbo].[tblPositionLeavetypes] OFF
SET IDENTITY_INSERT [dbo].[tblprlineitem] ON 

INSERT [dbo].[tblprlineitem] ([Id], [ItemType], [ItemName], [Quantity], [ItemPrice], [VendorName], [Status], [Date]) VALUES (2146, N'Consumable(One Time Use)', N'Sealent', 2, 400000.0000, N'Allan', N'Pending', CAST(N'2020-08-14' AS Date))
INSERT [dbo].[tblprlineitem] ([Id], [ItemType], [ItemName], [Quantity], [ItemPrice], [VendorName], [Status], [Date]) VALUES (2147, N'Consumable(One Time Use)', N'Tyres', 3, 30000.0000, N'Allan', N'Pending', CAST(N'2020-08-14' AS Date))
SET IDENTITY_INSERT [dbo].[tblprlineitem] OFF
SET IDENTITY_INSERT [dbo].[tblRequests] ON 

INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [LeaveType], [CitytoTranser], [DateofRequest], [Status], [FromDate], [ToDate], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole], [ResponseReason], [IsSeen]) VALUES (2032, 48, 4, N'Transfer', NULL, N'Karachi', CAST(N'2020-03-02T00:00:00.000' AS DateTime), N'Accepted', NULL, NULL, N'Aamir Mumtaz', CAST(N'2020-03-02T17:11:50.490' AS DateTime), N'Leaving', N'CEO', N'There is vacant seat right now so i approve your request', 1)
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [LeaveType], [CitytoTranser], [DateofRequest], [Status], [FromDate], [ToDate], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole], [ResponseReason], [IsSeen]) VALUES (2035, 51, 19, N'Transfer', NULL, N'Karachi', CAST(N'2020-03-10T17:52:56.477' AS DateTime), N'Accepted', NULL, NULL, N'Owais', CAST(N'2020-03-10T17:54:29.127' AS DateTime), N'Leaving', N'CEO', N'There is vacant Seat Available ', 1)
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [LeaveType], [CitytoTranser], [DateofRequest], [Status], [FromDate], [ToDate], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole], [ResponseReason], [IsSeen]) VALUES (3053, 49, 20, N'Leave', N'Casual Leave', NULL, CAST(N'2020-03-24T16:21:11.833' AS DateTime), N'Rejected', CAST(N'2020-03-25' AS Date), CAST(N'2020-03-27' AS Date), N'Tahir', CAST(N'2020-03-24T16:26:45.180' AS DateTime), N'Leave', N'Hr Manager', N'Leave rejected', 1)
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [LeaveType], [CitytoTranser], [DateofRequest], [Status], [FromDate], [ToDate], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole], [ResponseReason], [IsSeen]) VALUES (3054, 50, 1, N'Leave', N'Casual Leave', NULL, CAST(N'2020-03-24T16:22:04.077' AS DateTime), N'Accepted', CAST(N'2020-03-24' AS Date), CAST(N'2020-03-27' AS Date), N'Owais', CAST(N'2020-03-24T16:25:54.033' AS DateTime), N'Leave', N'CEO', N'Leave granted', 1)
INSERT [dbo].[tblRequests] ([RequestId], [EmployeeId], [PositionId], [RequestType], [LeaveType], [CitytoTranser], [DateofRequest], [Status], [FromDate], [ToDate], [Respondedby], [ResponseDate], [ReasonofRequest], [AuthorizedRole], [ResponseReason], [IsSeen]) VALUES (3055, 49, 20, N'Leave', N'Casual Leave', NULL, CAST(N'2020-05-02T16:00:51.723' AS DateTime), N'Accepted', CAST(N'2020-05-19' AS Date), CAST(N'2020-05-25' AS Date), N'Tahir', CAST(N'2020-05-02T16:06:31.853' AS DateTime), N'Give me Leave ', N'Hr Manager', N'Approved', 1)
SET IDENTITY_INSERT [dbo].[tblRequests] OFF
SET IDENTITY_INSERT [dbo].[tblreturnlineitem] ON 

INSERT [dbo].[tblreturnlineitem] ([Id], [ReturnNo], [Grreferenceno], [VendorId], [ItemId], [DeliveredQuantity], [RejectedQuantity], [ApprovedQtybyQuality], [MissingQuantity], [AvailableQuantity], [ReturnQuantity], [PartialReturnQuantity], [RemainingQuantity], [Approved]) VALUES (1020, 3235, 3224, 3, 1, 3, 1, 2, 0, 0, 0, 0, -1, N'Yes')
INSERT [dbo].[tblreturnlineitem] ([Id], [ReturnNo], [Grreferenceno], [VendorId], [ItemId], [DeliveredQuantity], [RejectedQuantity], [ApprovedQtybyQuality], [MissingQuantity], [AvailableQuantity], [ReturnQuantity], [PartialReturnQuantity], [RemainingQuantity], [Approved]) VALUES (1021, 3236, 3226, 3, 1, 1, 1, 0, 0, 0, 0, 0, -1, N'No')
INSERT [dbo].[tblreturnlineitem] ([Id], [ReturnNo], [Grreferenceno], [VendorId], [ItemId], [DeliveredQuantity], [RejectedQuantity], [ApprovedQtybyQuality], [MissingQuantity], [AvailableQuantity], [ReturnQuantity], [PartialReturnQuantity], [RemainingQuantity], [Approved]) VALUES (1022, 3237, 3231, 4, 1, 1, 1, 0, 0, 0, 0, 0, -1, N'No')
INSERT [dbo].[tblreturnlineitem] ([Id], [ReturnNo], [Grreferenceno], [VendorId], [ItemId], [DeliveredQuantity], [RejectedQuantity], [ApprovedQtybyQuality], [MissingQuantity], [AvailableQuantity], [ReturnQuantity], [PartialReturnQuantity], [RemainingQuantity], [Approved]) VALUES (1023, 3239, 3233, 4, 1, 1, 1, 0, 0, 0, 0, 0, -1, N'No')
SET IDENTITY_INSERT [dbo].[tblreturnlineitem] OFF
SET IDENTITY_INSERT [dbo].[tblRoles] ON 

INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (1, N'Recruitment Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (2, N'Recruitment Officer')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (3, N'Store Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (4, N'Hr Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (5, N'DGM')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (6, N'Admin')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (7, N'CEO')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (1008, N'Finance Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (1009, N'Inventory Manager')
INSERT [dbo].[tblRoles] ([Id], [RoleName]) VALUES (1010, N'Quality Manager')
SET IDENTITY_INSERT [dbo].[tblRoles] OFF
SET IDENTITY_INSERT [dbo].[tblSL] ON 

INSERT [dbo].[tblSL] ([SLId], [City], [StorageLocation]) VALUES (2, N'Karachi', N'Local Receipt Section')
INSERT [dbo].[tblSL] ([SLId], [City], [StorageLocation]) VALUES (3, N'Karachi', N'Foreign Receipt Section')
INSERT [dbo].[tblSL] ([SLId], [City], [StorageLocation]) VALUES (4, N'Karachi', N'Quality Inspection')
SET IDENTITY_INSERT [dbo].[tblSL] OFF
SET IDENTITY_INSERT [dbo].[tblStock] ON 

INSERT [dbo].[tblStock] ([StockId], [SLId], [AvailableStock]) VALUES (1, 4, 0)
INSERT [dbo].[tblStock] ([StockId], [SLId], [AvailableStock]) VALUES (2, 2, 1)
INSERT [dbo].[tblStock] ([StockId], [SLId], [AvailableStock]) VALUES (6, 3, 12)
SET IDENTITY_INSERT [dbo].[tblStock] OFF
SET IDENTITY_INSERT [dbo].[tblStructuredetail] ON 

INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (1, 1000, N'Serene Air Pvt Lmd', 100, N'Karachi')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (2, 1000, N'Serene Air pvt Lmd', 101, N'Lahore')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (3, 2000, N'Serene Engg Services', 100, N'Karachi')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (4, 2000, N'Serene Engg Services', 101, N'Lahore')
INSERT [dbo].[tblStructuredetail] ([Id], [CompanyCode], [CompanyName], [CityCode], [CityName]) VALUES (5, 3000, N'Serene Air pvt Limited', 101, N'Lahore')
SET IDENTITY_INSERT [dbo].[tblStructuredetail] OFF
SET IDENTITY_INSERT [dbo].[tblUsers] ON 

INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (15, N'Owais', N'9248133abc', 1, 1, 1, 49, 1, N'')
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (16, N'Tahir', N'9248133abc', 2, 0, 1, 46, 1, NULL)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (18, N'Afzaal', N'9248133', 5, 0, 1, 48, 1, NULL)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (19, N'Tahir24', N'1234567', 4, 0, 1, 50, 1, NULL)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (1019, N'Aamir Mumtaz', N'9248133abc', 1008, 0, 1, 51, 1, N'')
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (2019, N'Ahmed Zafar', N'1234567', 1009, 0, 4, 54, 1, NULL)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (2020, N'Ali', N'9248133abc', 3, 0, 4, 2062, 1, NULL)
INSERT [dbo].[tblUsers] ([UserId], [UserName], [Password], [RoleId], [AdminId], [DepartmentId], [EmployeeId], [IsActive], [ResetPasswordCode]) VALUES (2021, N'Afzaal23', N'9248133', 1010, 0, 4, 52, 1, NULL)
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
SET IDENTITY_INSERT [dbo].[tblVacancies] ON 

INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (1, N'Recruitment Officer', N'Karachi', 1, 1, 3, N'Must have BS degree in HR or relevant field.', 4, CAST(N'2020-02-05' AS Date), 65, N'18087a87-81a9-44cd-935b-684d32df827c.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (2, N'Hiring Manager', N'Karachi', 2, 1, 1, N'Must have relevant degree in Hr', 3, CAST(N'2020-02-05' AS Date), 60, N'27641158-c858-432d-bd87-6f5284db1eff.pdf')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (3, N'Store Manager', N'Lahore', 3, 4, 1, N'Must have degree in supply chain or relevant field', 4, CAST(N'2020-02-06' AS Date), 55, N'd98a41e0-7875-4661-9b1b-cbe035103b16.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (7, N'Hr Officer', N'Islamabad', 18, 1, NULL, N'Must have degree in HR', 4, CAST(N'2020-02-16' AS Date), 65, N'afbba3c0-e6ec-48a2-ba83-d8e657f1cef5.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (8, N'Hiring Manager', N'Lahore', 2, 1, NULL, N'Must Have degree in HR', 3, CAST(N'2020-02-16' AS Date), 64, N'e2903b15-9da4-4dbd-b105-565b67f76bfa.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (12, N'DGM', N'Islamabad', 19, 1, NULL, N'Must have degree in MBA', 5, CAST(N'2020-02-19' AS Date), 70, N'd41af054-700c-4884-ad64-0a7aee0aa0f0.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (13, N'Hr Officer', N'Karachi', 18, 4, NULL, N'Must have degree in Supply chain', 5, CAST(N'2020-03-01' AS Date), 60, N'c6661210-9f5d-44f0-ad95-96a678d2cfc7.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (1013, N'Hiring Manager', N'Lahore', 2, 1, NULL, N'Must be Ms', 3, CAST(N'2020-08-15' AS Date), 60, N'0e66b89e-3e91-4875-94a1-26c2d8b6aec7.docx')
INSERT [dbo].[tblVacancies] ([VacancyId], [VacancyName], [CityName], [PositionId], [DepartmentId], [NoofVacany], [RequiredQualification], [JobLevel], [CreationDate], [MarksCriteria], [Testpaper]) VALUES (1014, N'Hiring Manager', N'Lahore', 2, 1, NULL, N'Must be Ms', 3, CAST(N'2020-08-15' AS Date), 60, N'3aa7acd3-58b9-4e04-8df8-d468d555fc05.pdf')
SET IDENTITY_INSERT [dbo].[tblVacancies] OFF
SET IDENTITY_INSERT [dbo].[tblVacancydetails] ON 

INSERT [dbo].[tblVacancydetails] ([Id], [CompanyCode], [CityCode], [DepartmentId], [PositionId], [Availableseats], [SeatAvailablityDate], [StructureId]) VALUES (80, 1000, 100, 1, 2, 1, CAST(N'2020-02-14' AS Date), 1)
INSERT [dbo].[tblVacancydetails] ([Id], [CompanyCode], [CityCode], [DepartmentId], [PositionId], [Availableseats], [SeatAvailablityDate], [StructureId]) VALUES (81, 2000, 101, 4, 3, 1, CAST(N'2020-02-16' AS Date), 4)
SET IDENTITY_INSERT [dbo].[tblVacancydetails] OFF
SET IDENTITY_INSERT [dbo].[tblVendors] ON 

INSERT [dbo].[tblVendors] ([VendorId], [VendorName], [Contact], [TypeId], [Address], [VendorType]) VALUES (1, N'Kamran', N'03003497300', 2, N'H # 669, DOHS-1, Malir Cantt', N'Local')
INSERT [dbo].[tblVendors] ([VendorId], [VendorName], [Contact], [TypeId], [Address], [VendorType]) VALUES (2, N'Imran', N'03303497300', 2, N'Korangi', N'Local')
INSERT [dbo].[tblVendors] ([VendorId], [VendorName], [Contact], [TypeId], [Address], [VendorType]) VALUES (3, N'Allan', N'03003497300', 1, N'New york', N'Foreign')
INSERT [dbo].[tblVendors] ([VendorId], [VendorName], [Contact], [TypeId], [Address], [VendorType]) VALUES (4, N'David', N'03303497300', 1, N'Uk', N'Local')
SET IDENTITY_INSERT [dbo].[tblVendors] OFF
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
