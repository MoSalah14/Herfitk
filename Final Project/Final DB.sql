USE [master]
GO
/****** Object:  Database [Herifa_Web]    Script Date: 26/3/2024 11:33:50 pm ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/3/2024 11:33:50 pm ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[NationalId] [nvarchar](max) NOT NULL,
	[PersonalImage] [nvarchar](max) NULL,
	[NationalIdImage] [nvarchar](max) NULL,
	[AccountState] [nvarchar](max) NULL,
	[UserRoleID] [int] NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[Descraption] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK__Category__3214EC279B2D105D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[History] [nvarchar](max) NULL,
	[Review] [nvarchar](max) NULL,
	[User_ID] [int] NOT NULL,
 CONSTRAINT [PK__Client__3214EC272790489E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_Herify]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_Herify](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Client_Review] [nvarchar](max) NULL,
	[Client_ID] [int] NULL,
	[Herify_ID] [int] NULL,
	[Rate] [int] NULL,
 CONSTRAINT [PK__Client_H__3214EC27824A65FA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herfiy]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herfiy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Zone] [nvarchar](100) NULL,
	[History] [nvarchar](max) NULL,
	[Speciality] [nvarchar](100) NULL,
	[Image] [nvarchar](max) NULL,
	[User_ID] [int] NOT NULL,
 CONSTRAINT [PK__Herfiy__3214EC27C698B292] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HerifyCategories]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HerifyCategories](
	[Herify_ID] [int] NOT NULL,
	[Category_ID] [int] NOT NULL,
 CONSTRAINT [PK_HerifyCategories] PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC,
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 26/3/2024 11:33:50 pm ******/
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
/****** Object:  Table [dbo].[Staff]    Script Date: 26/3/2024 11:33:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [decimal](10, 2) NULL,
	[Hire_Date] [date] NULL,
	[Work_Hours] [int] NULL,
	[User_ID] [int] NOT NULL,
 CONSTRAINT [PK__Staff__3214EC27832438F9] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240320230638_EditRoles', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323160744_init', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323221925_EditTableHerifyReview', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323232856_addRateColumn', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323234212_adddateTime', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323234650_EditdateTime', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Staff', N'STAFF', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Client', N'CLIENT', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, N'Herify', N'HERIFY', NULL)
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (11, 1)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (2, N'Abdo Gomaa', N'Cairo', N'29711230100733', NULL, NULL, NULL, 2, N'abdo@gmail.com', NULL, N'abdo@gmail.com', NULL, 0, NULL, NULL, N'1a4d6cd5-6067-4a34-84b0-f9821b31722b', N'01203665233', 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (3, N'yassmin', N'Menofya', N'Minya', NULL, NULL, NULL, 2, N'yassmin@gmail.com', NULL, N'yassmin@gmail.com', NULL, 0, NULL, NULL, N'4637cf3e-50e3-4245-be83-913aaed67888', N'01512476353', 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (4, N'مازن حسن', N'Giza', N'22038576354632', N'/PersonalImage/39c44d8e-bc06-426b-aa2e-52f41c19d9ec_WhatsApp Image 2024-03-26 at 17.44.30_28a8ad68.jpg', NULL, NULL, 4, N'mazen@gmail.com', N'MAZEN@GMAIL.COM', N'mazen@gmail.com', N'MAZEN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEMSsm9SGF38iL9/TbiyTYZrIwTrvfDiiMLMYoXLHdzrN7yaLWp+mnX3a7IRQ1hRK6g==', N'IGJUXO7NWFXAFMXBS3QLKNLVLP65R77J', N'bdff0e36-7bd4-4a4b-b24a-efa01dc1783b', N'01153254532', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (5, N'خالد', N'بنها', N'29549857264321', N'/PersonalImage/43a67464-bf87-4dd6-a5b6-a4ba547c1e13_WhatsApp Image 2024-03-26 at 17.43.55_fdf1b5e0.jpg', NULL, NULL, 4, N'khaled@gmail.com', N'KHALED@GMAIL.COM', N'khaled@gmail.com', N'KHALED@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEDiQBx3ypqyoWO4kx/ywQbxpgltmSdQCNHl9pf6j7cpBPgcJ7xuPxbFoyPWrY+s00g==', N'CVUT3MGC2YRUIT7G5M5MA73D7JFNRZDZ', N'9de6e3cc-1f4f-4eba-af14-47d13465ec41', N'01203665233', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (6, N'عادل سيد', N'المنصورة', N'29483748390248', N'/PersonalImage/5cdc1f7f-e6a7-4c08-b154-d2800fea3ae7_WhatsApp Image 2024-03-26 at 17.42.51_8a9b360e.jpg', NULL, NULL, 4, N'adel@gmail.com', N'ADEL@GMAIL.COM', N'adel@gmail.com', N'ADEL@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGk0dQlrm14YndPIMXu7W9A7YdQS+b6LyzINvmGpxDuz6pTB5xz/zUOoJ884yRt8WA==', N'HU7DOY56RPG6H3UCJFIZLIGMQMCVZO54', N'84dfca7f-0bfe-4fd2-8a2a-b691e88f26b6', N'01543874632', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (7, N'سعد', N'المنيا', N'29893857684372', N'/PersonalImage/b0967903-c9e7-4fa5-b218-996ae5773f5b_WhatsApp Image 2024-03-26 at 17.45.29_df1549d5.jpg', NULL, NULL, 4, N'saad@gmail.com', N'SAAD@GMAIL.COM', N'saad@gmail.com', N'SAAD@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEMUlFRarjgADX0sFecpiqYip5w8GiaL4uFGdniBVQEa7lqBQlCCtqQ1fJ0e0W5aM1w==', N'MQPXVJPV54PDO5P4UM6KY2QXZYNURQ4L', N'a5c722bf-d3ce-4a49-95ab-79d62c1f7c64', N'01118588765', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (8, N'محمود حسن', N'المنوفية', N'29394728574284', N'/PersonalImage/5bf71015-9a8f-4d76-bc36-e284989eb79c_WhatsApp Image 2024-03-26 at 17.42.51_1bd6521c.jpg', NULL, NULL, 4, N'mahmoudhassan@gmail.com', N'MAHMOUDHASSAN@GMAIL.COM', N'mahmoudhassan@gmail.com', N'MAHMOUDHASSAN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECqP82mhOJu1DgiTJZkC6GtnqB+bmAStF1Gchs9jq+aow7aPz6vak8v90jm4ypL1IA==', N'CL7UUGXC63ZKONHP56B2BWRPBWQDFR6O', N'6a400b65-55cf-4bb3-ab2c-ed4130f08d4c', N'01237659841', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (9, N'احمد خميس', N'دمياط', N'28958475948734', N'/PersonalImage/26d4696a-8c56-47ee-bb7e-9c9642fea281_WhatsApp Image 2024-03-26 at 17.43.31_73224a1a.jpg', NULL, NULL, 4, N'ahmedkhames@gmail.com', N'AHMEDKHAMES@GMAIL.COM', N'ahmedkhames@gmail.com', N'AHMEDKHAMES@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELIkLqqRqvnyIppAB7xmU59sbU12SijwaKJhIb/w5mtm4V5KTZYHxoMULa9BnRU5hQ==', N'G4PLKKTDXN5JVFKTTAHK3SCOC5JYE5FC', N'4976b8e3-0b18-4f73-bcd8-3e2883f65f19', N'01088833378', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (11, N'Mohamed', N'Cairo', N'29711230100732', N'/PersonalImage/a9096d2f-6374-494f-8ba4-22023a6ffc1e_00 (11).jpg', NULL, NULL, 1, N'mohammed.eldeberky@gmail.com', N'MOHAMMED.ELDEBERKY@GMAIL.COM', N'mohammed.eldeberky@gmail.com', N'MOHAMMED.ELDEBERKY@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFu/YwHXJL24J9RUFEIbvvQf0vm3yGzcO86K5DMvu9Zm527zgH2OIWfTSehADqsuPw==', N'U2GYUE3HZSAUDQABKTLNGIOAQQCIEZJP', N'138e8d1e-2e51-4fe6-9635-72c57972a4e7', N'01022202732', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (12, N'حسن مسعود', N'القاهرة', N'29714732747284', N'/PersonalImage/d6f6e5df-f052-44d8-8790-a4b15800260d_WhatsApp Image 2024-03-26 at 17.44.12_ee7fe16a.jpg', NULL, NULL, 4, N'hassan@gmail.com', N'HASSAN@GMAIL.COM', N'hassan@gmail.com', N'HASSAN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEOy4ubWEnPbdhZwRv/ebZHws7OKI098f81o3EIkIz1GQ1W+K4CM2RsCiiiyy3qbWAA==', N'PXVV2FX4IDZQCDDRKOJNNYKJS2PC3Z5C', N'ffb98bae-af0d-430f-8d8c-f77e2c11a9a4', N'01203756651', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DisplayName], [Address], [NationalId], [PersonalImage], [NationalIdImage], [AccountState], [UserRoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (13, N'mohaned', N'الجيزة', N'22002985769584', N'/PersonalImage/e538a50f-c353-4d9b-b0eb-69847e95e12a_WhatsApp Image 2024-03-26 at 17.41.23_24fd8117.jpg', NULL, NULL, 3, N'mohaned@gmail.com', N'MOHANED@GMAIL.COM', N'mohaned@gmail.com', N'MOHANED@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGUpwCyRSIiKmedCeiSQBpK1sA4zDkLi8jzhEY2ispXC+sBI5jNRhjYrTNTrtniSmg==', N'MRTGYYD65OI57K5X2JAXQLVYUMAYVVTW', N'db02d97e-17cb-40fc-b3b2-d53de9929330', N'01123655488', 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (1, N'حداد', N'جميع الاعمال المتعلقة بالحدادة تجدها هنا', N'/UploadsPhotos/c0aaefa1-bc3f-43af-b881-ad5fd4ec893b_5.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (2, N'سباك', N'جميع الاعمال المتعلقة بالسباكة تجدها هنا	', N'/UploadsPhotos/b7a827e7-ff88-4ae3-a77c-9e8c8ed40c57_1.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (3, N'نجار', N'جميع الاعمال المتعلقة بالنجارة تجدها هنا', N'/UploadsPhotos/3fe04836-7d31-47b7-96a0-63c442c95e4e_4.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (4, N'كهربائى', N'جميع الاعمال المتعلقة بالكهرباء تجدها هنا	', N'/UploadsPhotos/730ebfe8-6053-45b6-aefd-52f0e6a3c669_2.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (5, N'غاز', N'جميع الاعمال المتعلقة بالغاز تجدها هنا	', N'/UploadsPhotos/7482ef1e-8c4a-4d03-bc98-f44a6e8c4cb4_2.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (6, N'نقاشة', N'جميع الاعمال المتعلة بالنقاشة تجدها هنا', N'/UploadsPhotos/8b199b0e-a0d0-4c43-9f40-0fc471a40537_building-painter-Hero-Trustimm.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (7, N'سيراميك', N'جميع الاعمال المتعلقة بالسيراميك تجدها هنا', N'/UploadsPhotos/849924ed-d8c8-4eaf-bc1d-ed2be846b5d2_WhatsApp Image 2024-03-26 at 17.50.38_ab271686.jpg')
INSERT [dbo].[Category] ([ID], [CategoryName], [Descraption], [Image]) VALUES (8, N'عامل بناء', N'جميع الاعمال المتعلقة بالبناء تجدها هنا', N'/UploadsPhotos/f1a8ee22-e126-4a71-95d2-5b7b9165a838_147-120343-housebuilders-call-30-000-brickies_700x400.jpg')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (1, NULL, NULL, 4)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (2, NULL, NULL, 5)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (3, NULL, NULL, 6)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (4, NULL, NULL, 7)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (5, NULL, NULL, 8)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (6, NULL, NULL, 9)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (8, NULL, NULL, 12)
INSERT [dbo].[Client] ([ID], [History], [Review], [User_ID]) VALUES (9, NULL, NULL, 13)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Client_Herify] ON 

INSERT [dbo].[Client_Herify] ([ID], [Date], [Client_Review], [Client_ID], [Herify_ID], [Rate]) VALUES (1, CAST(N'2024-03-26' AS Date), N'رائع جدا وسريع ومحترم فى التعامل تحياتي لابو محمد', 9, 1, 5)
INSERT [dbo].[Client_Herify] ([ID], [Date], [Client_Review], [Client_ID], [Herify_ID], [Rate]) VALUES (4, CAST(N'2024-03-26' AS Date), N'عظيم', 9, 1, 3)
INSERT [dbo].[Client_Herify] ([ID], [Date], [Client_Review], [Client_ID], [Herify_ID], [Rate]) VALUES (5, CAST(N'2024-03-26' AS Date), N'سريع ومحترف فى التعامل', 9, 2, 5)
INSERT [dbo].[Client_Herify] ([ID], [Date], [Client_Review], [Client_ID], [Herify_ID], [Rate]) VALUES (7, CAST(N'2024-03-26' AS Date), N'Very Good man', 9, 2, 3)
INSERT [dbo].[Client_Herify] ([ID], [Date], [Client_Review], [Client_ID], [Herify_ID], [Rate]) VALUES (10, CAST(N'2024-03-26' AS Date), N'الراجل دا جدع', 9, 3, 3)
SET IDENTITY_INSERT [dbo].[Client_Herify] OFF
GO
SET IDENTITY_INSERT [dbo].[Herfiy] ON 

INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (1, N'المنيب', N'لقد عملت في الكثير من الاماكن', N'نجار سلح', N'/HerifyImage/1133c8d3-53c3-40ca-afd7-ade3e8f7a9e5_93501-نجار-المسلح.jpg', 4)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (2, N'بنها', N'لدي خبرة 7 سنوات فى مجال الكهرباء', N'نجار ابواب', N'/HerifyImage/b15fe42b-1050-470a-888f-544f03710d2a_FLWXmiLXoAIgTsn.jpeg', 5)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (3, N'المنصورة', N'خبرة كبيرة فى شغل الحدادة  وامتلك ورشةة', N'حداد مسلح', N'/HerifyImage/5e87fe1d-89b4-4d8d-a698-d9a0233138ac_download.jpg', 6)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (4, N'بني مزار', N'اجيد جميع اعمال السباكة من الالف للياء', N'سباك تأسيس', N'/HerifyImage/431523cb-7371-4a66-82b6-ffa30f258037_WhatsApp Image 2024-03-26 at 20.58.26_8dfea1da.jpg', 7)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (5, N'شبين الكوم', N'تأسيس اعمال الكهرباء', N'تأسيس كهرباء', N'/HerifyImage/53fb10ef-df57-41ab-a053-1429f3cf5408_رقم-فني-كهربائي-منازل-1.jpg', 8)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (6, N'دمياط', N'تأسيس الكهرباء بأعلي جودة ممكنة', N'كهربائى تأسيس', N'/HerifyImage/bad9b426-6116-4ad5-8624-86cda20ed441_WhatsApp Image 2024-03-26 at 21.20.24_0f7f27b8.jpg', 9)
INSERT [dbo].[Herfiy] ([ID], [Zone], [History], [Speciality], [Image], [User_ID]) VALUES (7, N'باب الشعرية', N'لدي القدرة علي موازنة واعداد السيراميك بطريقة احترافية', N'سيراميك ارضي', N'/HerifyImage/b1ec1638-9c92-4ee3-b96f-9c0e29abd7d2_WhatsApp Image 2024-03-26 at 17.50.38_a0e39f21.jpg', 12)
SET IDENTITY_INSERT [dbo].[Herfiy] OFF
GO
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (1, 3)
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (2, 3)
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (3, 1)
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (4, 2)
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (5, 4)
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (6, 4)
INSERT [dbo].[HerifyCategories] ([Herify_ID], [Category_ID]) VALUES (7, 7)
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([ID], [Salary], [Hire_Date], [Work_Hours], [User_ID]) VALUES (1, CAST(12000.00 AS Decimal(10, 2)), CAST(N'2020-05-12' AS Date), 8, 2)
INSERT [dbo].[Staff] ([ID], [Salary], [Hire_Date], [Work_Hours], [User_ID]) VALUES (2, CAST(17000.00 AS Decimal(10, 2)), CAST(N'2024-09-12' AS Date), 10, 3)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_UserRoleID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_UserRoleID] ON [dbo].[AspNetUsers]
(
	[UserRoleID] ASC
)
WHERE ([UserRoleID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_User_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Client_User_ID] ON [dbo].[Client]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_User_ID1]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Client_User_ID1] ON [dbo].[Client]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_Herify_Client_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Client_Herify_Client_ID] ON [dbo].[Client_Herify]
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client_Herify_Herify_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Client_Herify_Herify_ID] ON [dbo].[Client_Herify]
(
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herfiy_User_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Herfiy_User_ID] ON [dbo].[Herfiy]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herfiy_User_ID1]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Herfiy_User_ID1] ON [dbo].[Herfiy]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herify_Category_Category_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Herify_Category_Category_ID] ON [dbo].[HerifyCategories]
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Herify_Category_Herify_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Herify_Category_Herify_ID] ON [dbo].[HerifyCategories]
(
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payment_Herify_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Payment_Herify_ID] ON [dbo].[Payment]
(
	[Herify_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_User_ID]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staff_User_ID] ON [dbo].[Staff]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_User_ID1]    Script Date: 26/3/2024 11:33:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Staff_User_ID1] ON [dbo].[Staff]
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Herify] ADD  DEFAULT ('0001-01-01') FOR [Date]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_AspNetRoles_UserRoleID] FOREIGN KEY([UserRoleID])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_AspNetRoles_UserRoleID]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK__Client__User_ID__3F466844] FOREIGN KEY([User_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
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
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Herfiy] CHECK CONSTRAINT [FK__Herfiy__User_ID__4222D4EF]
GO
ALTER TABLE [dbo].[HerifyCategories]  WITH CHECK ADD  CONSTRAINT [FK__Herify_Ca__Categ__49C3F6B7] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HerifyCategories] CHECK CONSTRAINT [FK__Herify_Ca__Categ__49C3F6B7]
GO
ALTER TABLE [dbo].[HerifyCategories]  WITH CHECK ADD  CONSTRAINT [FK__Herify_Ca__Herif__48CFD27E] FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HerifyCategories] CHECK CONSTRAINT [FK__Herify_Ca__Herif__48CFD27E]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK__Payment__Herify___46E78A0C] FOREIGN KEY([Herify_ID])
REFERENCES [dbo].[Herfiy] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK__Payment__Herify___46E78A0C]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK__Staff__User_ID__3C69FB99] FOREIGN KEY([User_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK__Staff__User_ID__3C69FB99]
GO
USE [master]
GO
ALTER DATABASE [Herifa_Web] SET  READ_WRITE 
GO
