USE [master]
GO
/****** Object:  Database [SorceressLodge]    Script Date: 02/15/2017 13:30:01 ******/
CREATE DATABASE [SorceressLodge] ON  PRIMARY 
( NAME = N'SorceressLodge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SorceressLodge.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SorceressLodge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SorceressLodge_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [SorceressLodge] SET AUTO_CREATE_STATISTICS ON
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
ALTER DATABASE [SorceressLodge] SET  READ_WRITE
GO
ALTER DATABASE [SorceressLodge] SET RECOVERY FULL
GO
ALTER DATABASE [SorceressLodge] SET  MULTI_USER
GO
ALTER DATABASE [SorceressLodge] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SorceressLodge] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SorceressLodge', N'ON'
GO
USE [SorceressLodge]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/15/2017 13:30:01 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Admin]) VALUES (1, N'Riccorbypro', N'Windows8.1', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Admin]) VALUES (2, N'WelterZen', N'27727746', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[MagicUsers]    Script Date: 02/15/2017 13:30:01 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MagicUsers] ON
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (1, N'Bill', N'Cosby', N'African male, black hair, brown eyes. last seen wearing white button shirt, brown sweater, black suit pants and black shoes.', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (2, N'Daniel', N'Radcliffe', N'an awesome steep rock face, especially at the edge of the sea named Daniel. ccaucasian male, blue eyes, black hair. last seen wearing Hogwarts school uniform with Griffindor tie(red and yellow striped)', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (3, N'The Doctor (Alias)', N'UNKNOWN', N'caucasian male, light brown hair, brown eyes. last seen wearing light brown tweed suit and bow tie. Frequently changes appearance.', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Desription], [Image]) VALUES (4, N'Sherlock', N'Holmes', N'caucasian male, brown hair, blue eyes. last seen wearing grey suit with navey blue trench coat, grey scarf and grey hunting cap.', NULL)
SET IDENTITY_INSERT [dbo].[MagicUsers] OFF
/****** Object:  Table [dbo].[MagicTypes]    Script Date: 02/15/2017 13:30:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MagicTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeDesc] [text] NOT NULL,
	[Allowed] [tinyint] NOT NULL,
 CONSTRAINT [PK_MagicTypes] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MagicTypes] ON
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (1, N'Elemental', 1)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (2, N'Herbalist', 1)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (3, N'Summoning', 1)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (4, N'Nature', 1)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (5, N'Arcane', 1)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (6, N'Alchemy', 1)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (7, N'Blood Magic', 0)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (8, N'Necromancy', 0)
INSERT [dbo].[MagicTypes] ([TypeID], [TypeDesc], [Allowed]) VALUES (9, N'Transmogrify', 0)
SET IDENTITY_INSERT [dbo].[MagicTypes] OFF
/****** Object:  Table [dbo].[UserSkills]    Script Date: 02/15/2017 13:30:01 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserSkills] ON
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (1, 1, 2, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (2, 1, 6, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (3, 2, 5, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (4, 2, 9, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (6, 3, 1, 3)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (7, 3, 3, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (8, 3, 5, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (9, 3, 7, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (10, 3, 9, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (11, 4, 1, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (12, 4, 2, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (13, 4, 3, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (14, 4, 5, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (15, 4, 6, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (16, 4, 7, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (17, 4, 8, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (18, 4, 9, 1)
SET IDENTITY_INSERT [dbo].[UserSkills] OFF
/****** Object:  Table [dbo].[Location]    Script Date: 02/15/2017 13:30:01 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Location] ON
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (1, 1, N'Student Bar, Downtown Abbey', CAST(0x0000A68400000000 AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (2, 2, N'Hogwarts, school of witchcraft and wizardry', CAST(0x0000A6EF00000000 AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (3, 3, N'South London', CAST(0xFFFFCA6000000000 AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (4, 3, N'Northern Germany', CAST(0x00013ADC00000000 AS DateTime))
INSERT [dbo].[Location] ([LocationID], [UserID], [Location], [DateTime]) VALUES (5, 4, N'221B Baker Street, London', CAST(0x0000A6F100000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Location] OFF
/****** Object:  Table [dbo].[Bounty]    Script Date: 02/15/2017 13:30:01 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bounty] ON
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (1, 1, 0)
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (2, 2, 0)
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (3, 3, 0)
INSERT [dbo].[Bounty] ([BountyID], [UserID], [Bounty]) VALUES (4, 4, 0)
SET IDENTITY_INSERT [dbo].[Bounty] OFF
/****** Object:  ForeignKey [FK_UserSkills_MagicTypes]    Script Date: 02/15/2017 13:30:01 ******/
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_MagicTypes] FOREIGN KEY([TypeID])
REFERENCES [dbo].[MagicTypes] ([TypeID])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_MagicTypes]
GO
/****** Object:  ForeignKey [FK_UserSkills_MagicUsers]    Script Date: 02/15/2017 13:30:01 ******/
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_MagicUsers]
GO
/****** Object:  ForeignKey [FK_Location_MagicUsers]    Script Date: 02/15/2017 13:30:01 ******/
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_MagicUsers]
GO
/****** Object:  ForeignKey [FK_Bounty_MagicUsers]    Script Date: 02/15/2017 13:30:01 ******/
ALTER TABLE [dbo].[Bounty]  WITH CHECK ADD  CONSTRAINT [FK_Bounty_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[Bounty] CHECK CONSTRAINT [FK_Bounty_MagicUsers]
GO
