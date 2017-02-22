USE [master]
GO
/****** Object:  Database [SorceressLodge]    Script Date: 22/02/2017 19:27:39 ******/
CREATE DATABASE [SorceressLodge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SorceressLodge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SorceressLodge.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SorceressLodge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SorceressLodge_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SorceressLodge] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SorceressLodge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SorceressLodge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SorceressLodge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SorceressLodge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SorceressLodge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SorceressLodge] SET ARITHABORT OFF 
GO
ALTER DATABASE [SorceressLodge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SorceressLodge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SorceressLodge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SorceressLodge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SorceressLodge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SorceressLodge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SorceressLodge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SorceressLodge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SorceressLodge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SorceressLodge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SorceressLodge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SorceressLodge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SorceressLodge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SorceressLodge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SorceressLodge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SorceressLodge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SorceressLodge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SorceressLodge] SET RECOVERY FULL 
GO
ALTER DATABASE [SorceressLodge] SET  MULTI_USER 
GO
ALTER DATABASE [SorceressLodge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SorceressLodge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SorceressLodge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SorceressLodge] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SorceressLodge] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SorceressLodge]
GO
/****** Object:  Table [dbo].[Bounty]    Script Date: 22/02/2017 19:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bounty](
	[BountyID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Bounty] [real] NOT NULL,
 CONSTRAINT [PK_Bounty] PRIMARY KEY CLUSTERED 
(
	[BountyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 22/02/2017 19:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Location] [text] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MagicTypes]    Script Date: 22/02/2017 19:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MagicTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeDesc] [varchar](127) NOT NULL,
	[Allowed] [bit] NOT NULL,
 CONSTRAINT [PK_MagicTypes] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MagicUsers]    Script Date: 22/02/2017 19:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MagicUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](20) NOT NULL,
	[SName] [varchar](20) NOT NULL,
	[Desription] [text] NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_MagicUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/02/2017 19:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Admin] [tinyint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserSkills]    Script Date: 22/02/2017 19:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkills](
	[SkillID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[Proficiency] [int] NOT NULL,
 CONSTRAINT [PK_UserSkills] PRIMARY KEY CLUSTERED 
(
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bounty] ON 

INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (1, 1, 0)
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (2, 2, 0)
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (3, 3, 0)
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (4, 4, 0)
SET IDENTITY_INSERT [dbo].[Bounty] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (1, 1, N'Student Bar, Downtown Abbey', CAST(N'2016-09-17 00:00:00.000' AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (2, 2, N'Hogwarts, school of witchcraft and wizardry', CAST(N'2017-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (3, 3, N'South London', CAST(N'1862-06-01 00:00:00.000' AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (4, 3, N'Northern Germany', CAST(N'2120-09-08 00:00:00.000' AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (5, 4, N'221B Baker Street, London', CAST(N'2017-01-04 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[MagicUsers] ON 

INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (1, N'Bill', N'Cosby', N'African male, black hair, brown eyes. last seen wearing white button shirt, brown sweater, black suit pants and black shoes.', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (2, N'Daniel', N'Radcliffe', N'an awesome steep rock face, especially at the edge of the sea named Daniel. ccaucasian male, blue eyes, black hair. last seen wearing Hogwarts school uniform with Griffindor tie(red and yellow striped)', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (3, N'The Doctor (Alias)', N'UNKNOWN', N'caucasian male, light brown hair, brown eyes. last seen wearing light brown tweed suit and bow tie. Frequently changes appearance.', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (4, N'Sherlock', N'Holmes', N'caucasian male, brown hair, blue eyes. last seen wearing grey suit with navey blue trench coat, grey scarf and grey hunting cap.', NULL)
SET IDENTITY_INSERT [dbo].[MagicUsers] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [Admin]) VALUES (1, N'Riccorbypro', N'Windows8.1', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Admin]) VALUES (2, N'WelterZen', N'27727746', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Bounty]  WITH CHECK ADD  CONSTRAINT [FK_Bounty_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[Bounty] CHECK CONSTRAINT [FK_Bounty_MagicUsers]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_MagicUsers]
GO
USE [master]
GO
ALTER DATABASE [SorceressLodge] SET  READ_WRITE 
GO
