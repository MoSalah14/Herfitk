USE [master]
GO
/****** Object:  Database [Herifa_Web]    Script Date: 11/3/2024 11:45:41 pm ******/
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
ALTER DATABASE [Herifa_Web] SET READ_COMMITTED_SNAPSHOT ON 
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/3/2024 11:45:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/3/2024 11:45:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NULL,
 CONSTRAINT [PK__Category__3214EC279B2D105D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/3/2024 11:45:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[History] [nvarchar](max) NULL,
	[Review] [nvarchar](max) NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK__Client__3214EC272790489E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_Herify]    Script Date: 11/3/2024 11:45:42 pm ******/
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
 CONSTRAINT [PK__Client_H__3214EC27824A65FA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herfiy]    Script Date: 11/3/2024 11:45:42 pm ******/
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
 CONSTRAINT [PK__Herfiy__3214EC27C698B292] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herify_Category]    Script Date: 11/3/2024 11:45:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herify_Category](
	[Herify_ID] [int] NULL,
	[Category_ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11/3/2024 11:45:42 pm ******/
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
 CONSTRAINT [PK__Payment__3214EC2751EE6894] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/3/2024 11:45:42 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK__Role__3214EC27D1EB7E98] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 11/3/2024 11:45:42 pm ******/
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
 CONSTRAINT [PK__Staff__3214EC27832438F9] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/3/2024 11:45:42 pm ******/
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
	[Personal_Image] [nvarchar](max) NULL,
	[NationalID_Image] [nvarchar](max) NULL,
	[Account_State] [nvarchar](50) NULL,
 CONSTRAINT [PK__User__3214EC272A074D8C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240311213627_ReCreat', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Type]) VALUES (1, N'Category A')
INSERT [dbo].[Category] ([ID], [Type]) VALUES (2, N'Category B')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Herfiy] ON 

INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [User_ID]) VALUES (1, N'Zone A', N'Herfiy history', N'Speciality A', 1)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [User_ID]) VALUES (2, N'Zone B', N'Another herfiy history', N'Speciality B', 2)
SET IDENTITY_INSERT [dbo].[Herfiy] OFF
GO
INSERT [dbo].[Herify_Category] ([Herify_ID], [Category_ID]) VALUES (1, 1)
INSERT [dbo].[Herify_Category] ([Herify_ID], [Category_ID]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([ID], [Date], [State], [Amount], [Payment_term], [Herify_ID]) VALUES (3, CAST(N'2024-01-15' AS Date), N'Paid', CAST(1000.00 AS Decimal(10, 2)), N'Term A', 1)
INSERT [dbo].[Payment] ([ID], [Date], [State], [Amount], [Payment_term], [Herify_ID]) VALUES (4, CAST(N'2024-02-20' AS Date), N'Pending', CAST(1500.00 AS Decimal(10, 2)), N'Term B', 2)
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Type], [User_ID]) VALUES (1, N'Admin', 1)
INSERT [dbo].[Role] ([ID], [Type], [User_ID]) VALUES (2, N'User', 2)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([ID], [Salary], [Hire_Date], [Work_Hours], [User_ID]) VALUES (1, CAST(50000.00 AS Decimal(10, 2)), CAST(N'2023-01-15' AS Date), 40, 1)
INSERT [dbo].[Staff] ([ID], [Salary], [Hire_Date], [Work_Hours], [User_ID]) VALUES (2, CAST(60000.00 AS Decimal(10, 2)), CAST(N'2023-03-20' AS Date), 35, 2)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Phone], [Email], [Address], [Password], [National_ID], [Personal_Image], [NationalID_Image], [Account_State]) VALUES (1, N'John Doe', N'123-456-7890', N'john@example.com', N'123 Main St, City, Country', N'password123', N'123456789', NULL, NULL, N'Active')
INSERT [dbo].[User] ([ID], [Name], [Phone], [Email], [Address], [Password], [National_ID], [Personal_Image], [NationalID_Image], [Account_State]) VALUES (2, N'Jane Smith', N'987-654-3210', N'jane@example.com', N'456 Elm St, City, Country', N'password456', N'987654321', NULL, NULL, N'Active')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [IX_Client_User_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Client_User_ID] ON [dbo].[Client]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_Herify_Client_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Client_Herify_Client_ID] ON [dbo].[Client_Herify]
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_Herify_Herify_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Client_Herify_Herify_ID] ON [dbo].[Client_Herify]
(
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herfiy_User_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Herfiy_User_ID] ON [dbo].[Herfiy]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herify_Category_Category_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Herify_Category_Category_ID] ON [dbo].[Herify_Category]
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herify_Category_Herify_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Herify_Category_Herify_ID] ON [dbo].[Herify_Category]
(
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payment_Herify_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Payment_Herify_ID] ON [dbo].[Payment]
(
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Role_User_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Role_User_ID] ON [dbo].[Role]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_User_ID]    Script Date: 11/3/2024 11:45:42 pm ******/
CREATE NONCLUSTERED INDEX [IX_Staff_User_ID] ON [dbo].[Staff]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK__Client__User_ID__3F466844] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK__Client__User_ID__3F466844]
GO
ALTER TABLE [dbo].[Client_Herify]  WITH CHECK ADD  CONSTRAINT [FK__Client_He__Clien__4CA06362] FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Client] ([ID])
GO
ALTER TABLE [dbo].[Client_Herify] CHECK CONSTRAINT [FK__Client_He__Clien__4CA06362]
GO
ALTER TABLE [dbo].[Client_Herify]  WITH CHECK ADD  CONSTRAINT [FK__Client_He__Herif__4D94879B] FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Client_Herify] CHECK CONSTRAINT [FK__Client_He__Herif__4D94879B]
GO
ALTER TABLE [dbo].[Herfiy]  WITH CHECK ADD  CONSTRAINT [FK__Herfiy__User_ID__4222D4EF] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Herfiy] CHECK CONSTRAINT [FK__Herfiy__User_ID__4222D4EF]
GO
ALTER TABLE [dbo].[Herify_Category]  WITH CHECK ADD  CONSTRAINT [FK__Herify_Ca__Categ__49C3F6B7] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Herify_Category] CHECK CONSTRAINT [FK__Herify_Ca__Categ__49C3F6B7]
GO
ALTER TABLE [dbo].[Herify_Category]  WITH CHECK ADD  CONSTRAINT [FK__Herify_Ca__Herif__48CFD27E] FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Herify_Category] CHECK CONSTRAINT [FK__Herify_Ca__Herif__48CFD27E]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK__Payment__Herify___46E78A0C] FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK__Payment__Herify___46E78A0C]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK__Role__User_ID__398D8EEE] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK__Role__User_ID__398D8EEE]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK__Staff__User_ID__3C69FB99] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK__Staff__User_ID__3C69FB99]
GO
USE [master]
GO
ALTER DATABASE [Herifa_Web] SET  READ_WRITE 
GO
