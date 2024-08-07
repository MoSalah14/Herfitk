USE [master]
GO
/****** Object:  Database [Herifa_Web]    Script Date: 3/9/2024 11:46:30 PM ******/
CREATE DATABASE [Herifa_Web]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Herifa_Web', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Herifa_Web.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Herifa_Web_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Herifa_Web_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Herifa_Web] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Herifa_Web].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Herifa_Web] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Herifa_Web] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Herifa_Web] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Herifa_Web] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Herifa_Web] SET ARITHABORT OFF 
GO
ALTER DATABASE [Herifa_Web] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Herifa_Web] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Herifa_Web] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Herifa_Web] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Herifa_Web] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Herifa_Web] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Herifa_Web] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Herifa_Web] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Herifa_Web] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Herifa_Web] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Herifa_Web] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Herifa_Web] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Herifa_Web] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Herifa_Web] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Herifa_Web] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Herifa_Web] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Herifa_Web] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Herifa_Web] SET RECOVERY FULL 
GO
ALTER DATABASE [Herifa_Web] SET  MULTI_USER 
GO
ALTER DATABASE [Herifa_Web] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Herifa_Web] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Herifa_Web] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Herifa_Web] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Herifa_Web] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Herifa_Web] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Herifa_Web', N'ON'
GO
ALTER DATABASE [Herifa_Web] SET QUERY_STORE = ON
GO
ALTER DATABASE [Herifa_Web] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Herifa_Web]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int]  IDENTITY(1,1) NOT NULL,
	[History] [nvarchar](max) NULL,
	[Review] [nvarchar](max) NULL,
	[User_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_Herify]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_Herify](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cost] [decimal](10, 2) NULL,
	[Date] [date] NULL,
	[State] [nvarchar](50) NULL,
	[Client_Review] [nvarchar](max) NULL,
	[Herify_Review] [nvarchar](max) NULL,
	[Client_ID] [int] NULL,
	[Herify_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herfiy]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herfiy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Zone] [nvarchar](100) NULL,
	[History] [nvarchar](max) NULL,
	[Speciality] [nvarchar](100) NULL,
	[User_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herify_Category]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herify_Category](
	[Herify_ID] [int] NULL,
	[Category_ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[State] [nvarchar](50) NULL,
	[Amount] [decimal](10, 2) NULL,
	[Payment_term] [nvarchar](50) NULL,
	[Herify_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[User_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [decimal](10, 2) NULL,
	[Hire_Date] [date] NULL,
	[Work_Hours] [int] NULL,
	[User_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/9/2024 11:46:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](200) NULL,
	[Address] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[National_ID] [nvarchar](15) NULL,
	[Personal_Image] [varbinary](max) NULL,
	[NationalID_Image] [varbinary](max) NULL,
	[Account_State] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Category] ( [Type]) VALUES ( N'Category A')
INSERT [dbo].[Category] ( [Type]) VALUES ( N'Category B')
GO
INSERT [dbo].[Client] ( [History], [Review], [User_ID]) VALUES ( N'Client history', N'Client review', 2)
INSERT [dbo].[Client] ( [History], [Review], [User_ID]) VALUES ( N'Another client history', N'Another client review', 1)
GO
SET IDENTITY_INSERT [dbo].[Client_Herify] ON 

INSERT [dbo].[Client_Herify] ([ID], [Cost], [Date], [State], [Client_Review], [Herify_Review], [Client_ID], [Herify_ID]) VALUES (1, CAST(500.00 AS Decimal(10, 2)), CAST(N'2024-01-20' AS Date), N'Completed', N'Client review for herfiy 1', N'Herfiy review for client 1', 1, 1)
INSERT [dbo].[Client_Herify] ([ID], [Cost], [Date], [State], [Client_Review], [Herify_Review], [Client_ID], [Herify_ID]) VALUES (2, CAST(700.00 AS Decimal(10, 2)), CAST(N'2024-02-25' AS Date), N'In Progress', N'Client review for herfiy 2', N'Herfiy review for client 2', 2, 2)
SET IDENTITY_INSERT [dbo].[Client_Herify] OFF
GO
INSERT [dbo].[Herfiy] ([Zone], [History], [Speciality], [User_ID]) VALUES ( N'Zone A', N'Herfiy history', N'Speciality A', 1)
INSERT [dbo].[Herfiy] ( [Zone], [History], [Speciality], [User_ID]) VALUES ( N'Zone B', N'Another herfiy history', N'Speciality B', 2)
GO
INSERT [dbo].[Herify_Category] ([Herify_ID], [Category_ID]) VALUES (1, 1)
INSERT [dbo].[Herify_Category] ([Herify_ID], [Category_ID]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 
--//as
INSERT [dbo].[Payment] ( [Date], [State], [Amount], [Payment_term], [Herify_ID]) VALUES ( CAST(N'2024-01-15' AS Date), N'Paid', CAST(1000.00 AS Decimal(10, 2)), N'Term A', 1)
INSERT [dbo].[Payment] ( [Date], [State], [Amount], [Payment_term], [Herify_ID]) VALUES ( CAST(N'2024-02-20' AS Date), N'Pending', CAST(1500.00 AS Decimal(10, 2)), N'Term B', 2)
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ( [Type], [User_ID]) VALUES ( N'Admin', 1)
INSERT [dbo].[Role] ( [Type], [User_ID]) VALUES ( N'User', 2)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ( [Salary], [Hire_Date], [Work_Hours], [User_ID]) VALUES ( CAST(50000.00 AS Decimal(10, 2)), CAST(N'2023-01-15' AS Date), 40, 1)
INSERT [dbo].[Staff] ( [Salary], [Hire_Date], [Work_Hours], [User_ID]) VALUES ( CAST(60000.00 AS Decimal(10, 2)), CAST(N'2023-03-20' AS Date), 35, 2)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ( [Name], [Phone], [Email], [Address], [Password], [National_ID], [Personal_Image], [NationalID_Image], [Account_State]) VALUES ( N'John Doe', N'123-456-7890', N'john@example.com', N'123 Main St, City, Country', N'password123', N'123456789', NULL, NULL, N'Active')
INSERT [dbo].[User] ( [Name], [Phone], [Email], [Address], [Password], [National_ID], [Personal_Image], [NationalID_Image], [Account_State]) VALUES ( N'Jane Smith', N'987-654-3210', N'jane@example.com', N'456 Elm St, City, Country', N'password456', N'987654321', NULL, NULL, N'Active')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Client_Herify]  WITH CHECK ADD FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Client] ([ID])
GO
ALTER TABLE [dbo].[Client_Herify]  WITH CHECK ADD FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Herfiy]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Herify_Category]  WITH CHECK ADD FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Herify_Category]  WITH CHECK ADD FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
USE [master]
GO
ALTER DATABASE [Herifa_Web] SET  READ_WRITE 
GO
