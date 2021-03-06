USE [master]
GO
/****** Object:  Database [NKingimeDb]    Script Date: 09/07/2017 16:20:26 ******/
CREATE DATABASE [NKingimeDb] ON  PRIMARY 
( NAME = N'Kingime.Net', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER08\MSSQL\DATA\Kingime.Net.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Kingime.Net_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER08\MSSQL\DATA\Kingime.Net_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NKingimeDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NKingimeDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NKingimeDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NKingimeDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NKingimeDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NKingimeDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [NKingimeDb] SET ARITHABORT OFF
GO
ALTER DATABASE [NKingimeDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [NKingimeDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [NKingimeDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [NKingimeDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [NKingimeDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [NKingimeDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NKingimeDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [NKingimeDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NKingimeDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NKingimeDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [NKingimeDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [NKingimeDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [NKingimeDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [NKingimeDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NKingimeDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [NKingimeDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NKingimeDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [NKingimeDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NKingimeDb] SET  READ_WRITE
GO
ALTER DATABASE [NKingimeDb] SET RECOVERY FULL
GO
ALTER DATABASE [NKingimeDb] SET  MULTI_USER
GO
ALTER DATABASE [NKingimeDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [NKingimeDb] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'NKingimeDb', N'ON'
GO
USE [NKingimeDb]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/07/2017 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Nickname] [nvarchar](max) NULL,
	[Gender] [tinyint] NULL,
	[Mobile] [nvarchar](max) NULL,
	[RegisterTime] [datetime] NULL,
	[Enabled] [int] NOT NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (1, N'admin', N'admin', N'admin', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (2, N'dev', N'dev123', N'dev', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (3, N'dev1', N'dev123', N'dev1', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (4, N'dev2', N'dev123', N'dev3', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (5, N'dev3', N'dev123', N'dev3', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (6, N'dev4', N'dev123', N'dev4', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (7, N'dev5', N'dev123', N'dev5', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (8, N'dev6', N'dev123', N'dev6', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (9, N'dev7', N'dev123', N'dev7', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (10, N'dev8', N'dev123', N'dev8', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (11, N'dev9', N'dev123', N'dev9', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (12, N'dev10', N'dev123', N'dev10', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (13, N'dev11', N'dev123', N'dev11', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (14, N'dev12', N'dev123', N'dev12', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (15, N'dev13', N'dev123', N'dev13', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (16, N'dev14', N'dev123', N'dev14', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (17, N'dev15', N'dev123', N'dev15', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Nickname], [Gender], [Mobile], [RegisterTime], [Enabled], [CreatedTime]) VALUES (18, N'dev16', N'dev123', N'dev16', 1, N'13535555555', CAST(0x0000A7D1015A4180 AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 09/07/2017 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[Sort] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([Id], [Name], [Remark], [Sort], [CreatedBy], [CreatedTime]) VALUES (1, N'超级管理员', N'超级管理员', 1, 1, CAST(0x0000A7E700B33192 AS DateTime))
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Module]    Script Date: 09/07/2017 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NULL,
	[Name] [nvarchar](50) NULL,
	[ParentId] [int] NULL,
	[Url] [varchar](200) NULL,
	[Sort] [int] NULL,
	[Remark] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Module] ON
INSERT [dbo].[Module] ([Id], [Code], [Name], [ParentId], [Url], [Sort], [Remark], [CreatedBy], [CreatedTime]) VALUES (1, N'SM0001', N'系统管理', NULL, NULL, 1, N'系统管理', 1, CAST(0x0000A7D700D93A08 AS DateTime))
INSERT [dbo].[Module] ([Id], [Code], [Name], [ParentId], [Url], [Sort], [Remark], [CreatedBy], [CreatedTime]) VALUES (2, N'SM0002', N'用户查询', 1, N'/User/List', 1, N'系统管理 - 用户查询', 1, CAST(0x0000A7D700DA1CFE AS DateTime))
INSERT [dbo].[Module] ([Id], [Code], [Name], [ParentId], [Url], [Sort], [Remark], [CreatedBy], [CreatedTime]) VALUES (3, N'SM0003', N'角色查询', 1, N'/Role/List', 2, N'系统管理 - 角色查询', 1, CAST(0x0000A7E700B81BDD AS DateTime))
INSERT [dbo].[Module] ([Id], [Code], [Name], [ParentId], [Url], [Sort], [Remark], [CreatedBy], [CreatedTime]) VALUES (4, N'SM0004', N'数据字典分类查询', 1, N'/DataDictSort/List', 3, N'系统管理 - 数据字典分类查询', 1, CAST(0x0000A7E700FD6CE8 AS DateTime))
INSERT [dbo].[Module] ([Id], [Code], [Name], [ParentId], [Url], [Sort], [Remark], [CreatedBy], [CreatedTime]) VALUES (5, N'SM0005', N'数据字典查询', 1, N'/DataDict/List', 4, N'系统管理 - 数据字典查询', 1, CAST(0x0000A7E700FD8B11 AS DateTime))
SET IDENTITY_INSERT [dbo].[Module] OFF
/****** Object:  Table [dbo].[DataDictSort]    Script Date: 09/07/2017 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataDictSort](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[Sort] [int] NULL,
	[Enabled] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DataDictSort] ON
INSERT [dbo].[DataDictSort] ([Id], [Code], [Name], [Remark], [Sort], [Enabled], [CreatedBy], [CreatedTime]) VALUES (1, N'User_Gender', N'性别', N'性别', 1, 1, 1, CAST(0x0000A7E700EF555E AS DateTime))
SET IDENTITY_INSERT [dbo].[DataDictSort] OFF
/****** Object:  Table [dbo].[DataDict]    Script Date: 09/07/2017 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataDict](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](50) NULL,
	[Value] [nvarchar](100) NULL,
	[Remark] [nvarchar](200) NULL,
	[Sort] [int] NULL,
	[Enabled] [int] NOT NULL,
	[SortId] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DataDict] ON
INSERT [dbo].[DataDict] ([Id], [Key], [Value], [Remark], [Sort], [Enabled], [SortId], [CreatedBy], [CreatedTime]) VALUES (1, N'1', N'男', N'性别-男', 1, 1, 1, 1, CAST(0x0000A7E700EFE87E AS DateTime))
INSERT [dbo].[DataDict] ([Id], [Key], [Value], [Remark], [Sort], [Enabled], [SortId], [CreatedBy], [CreatedTime]) VALUES (3, N'2', N'女', N'性别-女', 2, 1, 1, 1, CAST(0x0000A7E700F0075A AS DateTime))
SET IDENTITY_INSERT [dbo].[DataDict] OFF
