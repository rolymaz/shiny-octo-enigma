USE [SalesTrackerDb]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Team]
GO
/****** Object:  Table [dbo].[Reason]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Reason]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[PostvetResults]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[PostvetResults]
GO
/****** Object:  Table [dbo].[OrderQueue]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[OrderQueue]
GO
/****** Object:  Table [dbo].[OrderLog]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[OrderLog]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[OrderItem]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Order]
GO
/****** Object:  Table [dbo].[Lead]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Lead]
GO
/****** Object:  Table [dbo].[FileLog]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[FileLog]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[ActivationResults]    Script Date: 14/04/2017 20:42:59 ******/
DROP TABLE [dbo].[ActivationResults]
GO
/****** Object:  Table [dbo].[ActivationResults]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivationResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileId] [int] NOT NULL,
	[MSISDN] [nvarchar](50) NULL,
	[Outcome] [nvarchar](50) NULL,
	[ProcessDate] [datetime] NULL,
	[StatusId] [int] NULL,
 CONSTRAINT [PK_ActivationResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RegistrationNo] [nchar](10) NOT NULL,
	[CKDocsRecieved] [nchar](10) NULL,
	[Director1Name] [nchar](10) NULL,
	[Director1RSAID] [nchar](10) NULL,
	[Director1ContactNo] [nchar](10) NULL,
	[Director2Name] [nchar](10) NULL,
	[Director2RSAID] [nchar](10) NULL,
	[Director2ContactNo] [nchar](10) NULL,
	[PhysicalAddress1] [nchar](10) NULL,
	[PhysicalSuburb] [nchar](10) NULL,
	[PhysicalTown] [nchar](10) NULL,
	[PhysicalProvince] [nchar](10) NULL,
	[PhysicalPostCode] [nchar](10) NULL,
	[PostalAddress1] [nchar](10) NULL,
	[PostalSuburb] [nchar](10) NULL,
	[PostalTown] [nchar](10) NULL,
	[PostalProvince] [nchar](10) NULL,
	[PostalPostCode] [nchar](10) NULL,
	[PrimaryContactName] [nchar](10) NULL,
	[PrimaryContactTel] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] NOT NULL,
	[CustomerType] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RSAID] [nchar](10) NULL,
	[Title] [nchar](10) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[TelMobileNo] [nvarchar](50) NULL,
	[TelMobile2No] [nchar](10) NULL,
	[TelHomeNo] [nchar](10) NULL,
	[TelWorkNo] [nchar](10) NULL,
	[Email] [nchar](10) NULL,
	[DeliveryAddress1] [nchar](10) NULL,
	[DeliveryStreet] [nchar](10) NULL,
	[DeliverySuburb] [nchar](10) NULL,
	[DeliveryProvince] [nchar](10) NULL,
	[DeliveryTown] [nchar](10) NULL,
	[DeliveryPostCode] [nchar](10) NULL,
	[DeliveryNotes] [nchar](10) NULL,
	[DeliveryContactNo] [nchar](10) NULL,
	[DeliveryGPS] [nchar](10) NULL,
	[DeliveryLandmark] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Gender] [nchar](10) NULL,
	[RSAID] [nchar](10) NULL,
	[MobileNo] [nchar](10) NULL,
	[EmailWNS] [nchar](10) NULL,
	[EmailClient] [nchar](10) NULL,
	[EmailPersonal] [nchar](10) NULL,
	[IsAgent] [nchar](10) NULL,
	[IsTeamleader] [nchar](10) NULL,
	[IsAdmin] [nchar](10) NULL,
	[IsQA] [nchar](10) NULL,
	[SalaryRef] [nchar](10) NULL,
	[UID] [nchar](10) NULL,
	[StartDate] [date] NULL,
	[EmploymentStatus] [nchar](10) NULL,
	[CreateDate] [nchar](10) NULL,
	[TeamId] [nchar](10) NULL,
	[DivisionId] [nchar](10) NULL,
	[LOBID] [nchar](10) NULL,
	[SiteId] [nchar](10) NULL,
	[ClientId] [nchar](10) NULL,
	[Username] [nchar](10) NULL,
	[TerminateDate] [nchar](10) NULL,
	[TerminateReason] [nchar](10) NULL,
	[Password] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FileLog]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [nvarchar](50) NULL,
	[Filepath] [nvarchar](50) NULL,
	[Filetype] [int] NULL,
	[TotalRecords] [int] NULL,
	[StatusId] [int] NULL,
 CONSTRAINT [PK_FileLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lead]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lead](
	[Id] [int] NOT NULL,
	[DatasetId] [int] NOT NULL,
	[RSAID] [nvarchar](50) NULL,
	[Title] [nchar](10) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nchar](10) NULL,
	[TelMobile1] [nchar](10) NULL,
	[TelMobile2] [nchar](10) NULL,
	[TelMobile3] [nchar](10) NULL,
	[TelMobile4] [nchar](10) NULL,
	[TelHome] [nchar](10) NULL,
	[TelWork] [nchar](10) NULL,
	[CreditScore] [nchar](10) NULL,
	[CompanyName] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CampaignId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderQueueId] [int] NOT NULL,
	[OrderQueueChangeDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [nvarchar](50) NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
	[SeqNo] [int] NOT NULL,
	[WorkflowId] [int] NOT NULL,
	[ChangeBy] [nvarchar](50) NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[ReasonId] [int] NOT NULL,
	[OrderRef] [nvarchar](50) NULL,
	[AccountNo] [nvarchar](50) NULL,
	[AssignedTo] [nvarchar](50) NULL,
	[OrderPriority] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[IMEI] [nvarchar](50) NULL,
	[MSISDN] [nvarchar](50) NULL,
	[ActivationDate] [datetime] NULL,
	[ContractExpiryDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[ItemStatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderLog]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Source] [int] NOT NULL,
	[Destination] [int] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[ChangeBy] [nvarchar](50) NOT NULL,
	[EnterDate] [datetime] NULL,
	[ExitDate] [datetime] NULL,
	[MinutesInQueue] [decimal](18, 0) NULL,
	[ReasonId] [int] NULL,
	[SeqNo] [int] NULL,
 CONSTRAINT [PK_OrderLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderQueue]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderQueue](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderQueue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostvetResults]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostvetResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileId] [int] NULL,
	[IDN] [nvarchar](50) NULL,
	[Outcome] [nvarchar](50) NULL,
	[ProcessDate] [datetime] NULL,
	[StatusId] [int] NULL,
 CONSTRAINT [PK_PostvetResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[ShortName] [nvarchar](50) NULL,
	[Description] [nchar](10) NULL,
	[tOffer] [nchar](10) NULL,
	[tFeatureCode] [nchar](10) NULL,
	[tFeatureDescr] [nchar](10) NULL,
	[tPricePlan] [nchar](10) NULL,
	[tRental] [decimal](18, 0) NULL,
	[tCommExVat] [decimal](18, 0) NULL,
	[tCommIncVat] [decimal](18, 0) NULL,
	[ProductStatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ProductTemplateId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reason]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkQueueId] [int] NOT NULL,
	[ReasonType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReasonCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Team]    Script Date: 14/04/2017 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[TeamleaderId] [int] NULL,
	[ClientId] [int] NULL,
	[SiteId] [int] NULL,
	[LOBId] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [DepartmentId], [CampaignId], [TeamId], [LeadId], [CustomerId], [OrderQueueId], [OrderQueueChangeDate], [CreateDate], [CreateBy], [Owner], [SeqNo], [WorkflowId], [ChangeBy], [ChangeDate], [ReasonId], [OrderRef], [AccountNo], [AssignedTo], [OrderPriority], [Notes], [IMEI], [MSISDN], [ActivationDate], [ContractExpiryDate]) VALUES (13, 1, 1, 1, 1, 1, 6, CAST(0x0000A755015372B8 AS DateTime), CAST(0x0000A7550152DD7F AS DateTime), N'RM', N'RM', 3, 2, N'rm', CAST(0x0000A7550152DD7F AS DateTime), 5, NULL, NULL, NULL, NULL, N'
14/04/2017 20:33:46 RM >> 14/04/2017 20:33:46 RM >> Order opened | 
 | 
14/04/2017 20:34:37 rm >> test | 
14/04/2017 20:35:53 rm >> test | ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Order] ([Id], [DepartmentId], [CampaignId], [TeamId], [LeadId], [CustomerId], [OrderQueueId], [OrderQueueChangeDate], [CreateDate], [CreateBy], [Owner], [SeqNo], [WorkflowId], [ChangeBy], [ChangeDate], [ReasonId], [OrderRef], [AccountNo], [AssignedTo], [OrderPriority], [Notes], [IMEI], [MSISDN], [ActivationDate], [ContractExpiryDate]) VALUES (14, 1, 1, 1, 1, 1, 4, CAST(0x0000A7550153BC01 AS DateTime), CAST(0x0000A75501535DDD AS DateTime), N'RM', N'RM', 2, 2, N'rm', CAST(0x0000A75501535DDD AS DateTime), 2, NULL, NULL, NULL, NULL, N'
14/04/2017 20:35:35 RM >> 14/04/2017 20:35:35 RM >> Order opened | 
 | 
14/04/2017 20:36:56 rm >> test | ', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderLog] ON 

INSERT [dbo].[OrderLog] ([Id], [OrderId], [Source], [Destination], [ChangeDate], [ChangeBy], [EnterDate], [ExitDate], [MinutesInQueue], [ReasonId], [SeqNo]) VALUES (1047, 13, 1, 2, CAST(0x0000A7550152DD91 AS DateTime), N'RM', CAST(0x0000A7550152DD91 AS DateTime), CAST(0x0000A75501531A25 AS DateTime), CAST(1 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[OrderLog] ([Id], [OrderId], [Source], [Destination], [ChangeDate], [ChangeBy], [EnterDate], [ExitDate], [MinutesInQueue], [ReasonId], [SeqNo]) VALUES (1048, 13, 2, 4, CAST(0x0000A75501531A25 AS DateTime), N'rm', CAST(0x0000A75501531A25 AS DateTime), CAST(0x0000A755015372B8 AS DateTime), CAST(1 AS Decimal(18, 0)), 2, 2)
INSERT [dbo].[OrderLog] ([Id], [OrderId], [Source], [Destination], [ChangeDate], [ChangeBy], [EnterDate], [ExitDate], [MinutesInQueue], [ReasonId], [SeqNo]) VALUES (1049, 14, 1, 2, CAST(0x0000A75501535DE2 AS DateTime), N'RM', CAST(0x0000A75501535DE2 AS DateTime), CAST(0x0000A7550153BC01 AS DateTime), CAST(1 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[OrderLog] ([Id], [OrderId], [Source], [Destination], [ChangeDate], [ChangeBy], [EnterDate], [ExitDate], [MinutesInQueue], [ReasonId], [SeqNo]) VALUES (1050, 13, 4, 6, CAST(0x0000A755015372B8 AS DateTime), N'rm', CAST(0x0000A755015372B8 AS DateTime), NULL, NULL, 5, 3)
INSERT [dbo].[OrderLog] ([Id], [OrderId], [Source], [Destination], [ChangeDate], [ChangeBy], [EnterDate], [ExitDate], [MinutesInQueue], [ReasonId], [SeqNo]) VALUES (1051, 14, 2, 4, CAST(0x0000A7550153BC01 AS DateTime), N'rm', CAST(0x0000A7550153BC01 AS DateTime), NULL, NULL, 2, 2)
SET IDENTITY_INSERT [dbo].[OrderLog] OFF
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (0, N'None')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (1, N'Opened')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (2, N'NewOrder')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (3, N'PendingFix')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (4, N'PendingCompliance')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (5, N'PendingComplianceFix')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (6, N'PendingPostVet')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (7, N'PendingPostVetFix')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (8, N'PendingCapture')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (9, N'PendingCaptureFix')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (10, N'PendingDelivery')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (11, N'PendingDeliveryFix')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (12, N'PendingActivation')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (13, N'PendingCancel')
INSERT [dbo].[OrderQueue] ([Id], [Name]) VALUES (14, N'Closed')
SET IDENTITY_INSERT [dbo].[Reason] ON 

INSERT [dbo].[Reason] ([Id], [WorkQueueId], [ReasonType], [Description]) VALUES (1, 1, N'Pass', N'Order opened successfully')
INSERT [dbo].[Reason] ([Id], [WorkQueueId], [ReasonType], [Description]) VALUES (2, 2, N'Pass', N'New order successfully created')
INSERT [dbo].[Reason] ([Id], [WorkQueueId], [ReasonType], [Description]) VALUES (3, 2, N'Cancel', N'Cancelled - Customer not interested')
INSERT [dbo].[Reason] ([Id], [WorkQueueId], [ReasonType], [Description]) VALUES (4, 2, N'Cancel', N'Cancelled - Order was created incorrectly')
INSERT [dbo].[Reason] ([Id], [WorkQueueId], [ReasonType], [Description]) VALUES (5, 2, N'Cancel', N'Cancelled by System')
SET IDENTITY_INSERT [dbo].[Reason] OFF
