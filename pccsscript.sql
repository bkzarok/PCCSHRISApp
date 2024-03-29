USE [master]
GO
/****** Object:  Database [sspdf]    Script Date: 2/13/2024 9:56:44 AM ******/
CREATE DATABASE [sspdf]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sspdf', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\sspdf.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sspdf_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\sspdf_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [sspdf] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sspdf].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sspdf] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sspdf] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sspdf] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sspdf] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sspdf] SET ARITHABORT OFF 
GO
ALTER DATABASE [sspdf] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sspdf] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sspdf] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sspdf] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sspdf] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sspdf] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sspdf] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sspdf] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sspdf] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sspdf] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sspdf] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sspdf] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sspdf] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sspdf] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sspdf] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sspdf] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sspdf] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sspdf] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sspdf] SET  MULTI_USER 
GO
ALTER DATABASE [sspdf] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sspdf] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sspdf] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sspdf] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sspdf] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sspdf] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [sspdf] SET QUERY_STORE = OFF
GO
USE [sspdf]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/13/2024 9:56:45 AM ******/
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
/****** Object:  Table [dbo].[Address]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Counuty] [nvarchar](50) NOT NULL,
	[Payam] [nvarchar](50) NOT NULL,
	[Boma] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
	[Discriminator] [nvarchar](21) NOT NULL,
	[Firstname] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[PeriodFrom] [date] NOT NULL,
	[PeriodTo] [date] NOT NULL,
	[PositionHeld] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Battle]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Battle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateOfBattle] [date] NOT NULL,
	[PlaceOfBattle] [nvarchar](50) NOT NULL,
	[InjurySustained] [bit] NOT NULL,
	[TypeOfInjury] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Battle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Child]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Child](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Occupation] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Child] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateOfEnrollment] [date] NOT NULL,
	[PlaceOfEnrollment] [nvarchar](50) NOT NULL,
	[ServiceOutsideSSPDF] [bit] NOT NULL,
	[PeriodFrom] [date] NOT NULL,
	[PeriodTo] [date] NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthCondition]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthCondition](
	[ID] [int] NOT NULL,
	[HaveAHealthCondition] [bit] NOT NULL,
	[IfYesExplain] [nvarchar](50) NOT NULL,
	[DegreeOfHealthProblem] [nvarchar](50) NOT NULL,
	[WhenStarted] [date] NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HealthCondition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imprisonment]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imprisonment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Imprisoned] [bit] NOT NULL,
	[Place] [nvarchar](50) NOT NULL,
	[ForHowLong] [nvarchar](50) NOT NULL,
	[Conviction] [bit] NOT NULL,
	[ExplainTheReason] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Imprisonment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FluencyLevel] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NextOfKin]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NextOfKin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Occupation] [nvarchar](50) NOT NULL,
	[TelephoneNo] [nvarchar](13) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NextOfKin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Occupation] [nvarchar](50) NOT NULL,
	[Dependency] [bit] NOT NULL,
	[HelpProvided] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDetail]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDetail](
	[MilitaryNo] [nvarchar](50) NOT NULL,
	[ProfilePicture] [image] NOT NULL,
	[SoldierRank] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[BloodGroup] [nvarchar](50) NOT NULL,
	[Ethnicity] [nvarchar](50) NOT NULL,
	[ShieldNo] [int] NOT NULL,
	[Gender] [bit] NOT NULL,
	[MaritalStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PersonalDetail_1] PRIMARY KEY CLUSTERED 
(
	[MilitaryNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SoldierRank] [nvarchar](50) NOT NULL,
	[DateOfPromotion] [date] NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryDetail]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NOT NULL,
	[BasicPay] [money] NOT NULL,
	[Cola] [money] NOT NULL,
	[ResponsibiltyAllowance] [money] NOT NULL,
	[RepresentationAllowance] [money] NOT NULL,
	[HouseAllowance] [money] NOT NULL,
	[GrossTotal] [money] NOT NULL,
	[PIT] [money] NOT NULL,
	[Pension] [money] NOT NULL,
	[TotalDeduction] [money] NOT NULL,
	[NetPay] [money] NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SalaryDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolLevel] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Place] [nvarchar](50) NOT NULL,
	[PeriodFrom] [date] NOT NULL,
	[PeriodTo] [date] NOT NULL,
	[FieldOfTraining] [nvarchar](50) NOT NULL,
	[CertificateAcquired] [nvarchar](50) NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spouse]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spouse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[County] [nvarchar](50) NOT NULL,
	[Occupation] [nvarchar](50) NOT NULL,
	[TelephoneNo] [int] NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Spouse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Training]    Script Date: 2/13/2024 9:56:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Training](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingType] [nvarchar](50) NOT NULL,
	[TrainingCenter] [nvarchar](50) NOT NULL,
	[Place] [nvarchar](50) NOT NULL,
	[PeriodFrom] [date] NOT NULL,
	[PeriodTo] [date] NOT NULL,
	[MilitaryNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Training] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/13/2024 9:56:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_PersonalDetail]
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
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_PersonalDetail]
GO
ALTER TABLE [dbo].[Battle]  WITH CHECK ADD  CONSTRAINT [FK_Battle_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Battle] CHECK CONSTRAINT [FK_Battle_PersonalDetail]
GO
ALTER TABLE [dbo].[Child]  WITH CHECK ADD  CONSTRAINT [FK_Child_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Child] CHECK CONSTRAINT [FK_Child_PersonalDetail]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_PersonalDetail]
GO
ALTER TABLE [dbo].[HealthCondition]  WITH CHECK ADD  CONSTRAINT [FK_HealthCondition_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[HealthCondition] CHECK CONSTRAINT [FK_HealthCondition_PersonalDetail]
GO
ALTER TABLE [dbo].[Imprisonment]  WITH CHECK ADD  CONSTRAINT [FK_Imprisonment_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Imprisonment] CHECK CONSTRAINT [FK_Imprisonment_PersonalDetail]
GO
ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_PersonalDetail]
GO
ALTER TABLE [dbo].[NextOfKin]  WITH CHECK ADD  CONSTRAINT [FK_NextOfKin_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[NextOfKin] CHECK CONSTRAINT [FK_NextOfKin_PersonalDetail]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_Parent_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_Parent_PersonalDetail]
GO
ALTER TABLE [dbo].[Promotion]  WITH CHECK ADD  CONSTRAINT [FK_Promotion_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Promotion] CHECK CONSTRAINT [FK_Promotion_PersonalDetail]
GO
ALTER TABLE [dbo].[SalaryDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalaryDetails_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[SalaryDetail] CHECK CONSTRAINT [FK_SalaryDetails_PersonalDetail]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_PersonalDetail]
GO
ALTER TABLE [dbo].[Spouse]  WITH CHECK ADD  CONSTRAINT [FK_Spouse_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Spouse] CHECK CONSTRAINT [FK_Spouse_PersonalDetail]
GO
ALTER TABLE [dbo].[Training]  WITH CHECK ADD  CONSTRAINT [FK_Training_PersonalDetail] FOREIGN KEY([MilitaryNo])
REFERENCES [dbo].[PersonalDetail] ([MilitaryNo])
GO
ALTER TABLE [dbo].[Training] CHECK CONSTRAINT [FK_Training_PersonalDetail]
GO
USE [master]
GO
ALTER DATABASE [sspdf] SET  READ_WRITE 
GO
