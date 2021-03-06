USE [SorceressLodge]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/26/2017 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Admin] [bit] NOT NULL,
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
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Admin]) VALUES (2, N'WelterZen', N'277', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[MagicUsers]    Script Date: 02/26/2017 15:25:12 ******/
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
	[Description] [text] NULL,
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
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Description], [Image]) VALUES (1, N'Bill', N'Cosby', N'African male, black hair, brown eyes. last seen wearing white button shirt, brown sweater, black suit pants and black shoes.', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Description], [Image]) VALUES (2, N'Daniel', N'Radcliffe', N'an awesome steep rock face, especially at the edge of the sea named Daniel. ccaucasian male, blue eyes, black hair. last seen wearing Hogwarts school uniform with Griffindor tie(red and yellow striped)', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Description], [Image]) VALUES (3, N'The Doctor (Alias)', N'UNKNOWN', N'caucasian male, light brown hair, brown eyes. last seen wearing light brown tweed suit and bow tie. Frequently changes appearance.', NULL)
INSERT [dbo].[MagicUsers] ([UserID], [FName], [SName], [Description], [Image]) VALUES (4, N'Sherlock', N'Holmes', N'caucasian male, brown hair, blue eyes. last seen wearing grey suit with navey blue trench coat, grey scarf and grey hunting cap.', NULL)
SET IDENTITY_INSERT [dbo].[MagicUsers] OFF
/****** Object:  Table [dbo].[MagicTypes]    Script Date: 02/26/2017 15:25:12 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
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
/****** Object:  Table [dbo].[UserSkills]    Script Date: 02/26/2017 15:25:12 ******/
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
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (5, 3, 1, 3)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (6, 3, 3, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (7, 3, 5, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (8, 3, 9, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (9, 4, 1, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (10, 4, 2, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (11, 4, 3, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (12, 4, 5, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (13, 4, 6, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (14, 4, 7, 1)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (15, 4, 8, 2)
INSERT [dbo].[UserSkills] ([SkillID], [UserID], [TypeID], [Proficiency]) VALUES (16, 4, 9, 1)
SET IDENTITY_INSERT [dbo].[UserSkills] OFF
/****** Object:  Table [dbo].[Location]    Script Date: 02/26/2017 15:25:12 ******/
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
/****** Object:  Table [dbo].[Bounty]    Script Date: 02/26/2017 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bounty](
	[BountyID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Bounty] [float] NOT NULL,
 CONSTRAINT [PK_Bounty] PRIMARY KEY CLUSTERED 
(
	[BountyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Users_Admin]    Script Date: 02/26/2017 15:25:12 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Admin]  DEFAULT ((0)) FOR [Admin]
GO
/****** Object:  ForeignKey [FK_Bounty_MagicUsers]    Script Date: 02/26/2017 15:25:12 ******/
ALTER TABLE [dbo].[Bounty]  WITH CHECK ADD  CONSTRAINT [FK_Bounty_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[Bounty] CHECK CONSTRAINT [FK_Bounty_MagicUsers]
GO
/****** Object:  ForeignKey [FK_Location_MagicUsers]    Script Date: 02/26/2017 15:25:12 ******/
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_MagicUsers]
GO
/****** Object:  ForeignKey [FK_UserSkills_MagicTypes]    Script Date: 02/26/2017 15:25:12 ******/
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_MagicTypes] FOREIGN KEY([TypeID])
REFERENCES [dbo].[MagicTypes] ([TypeID])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_MagicTypes]
GO
/****** Object:  ForeignKey [FK_UserSkills_MagicUsers]    Script Date: 02/26/2017 15:25:12 ******/
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_MagicUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MagicUsers] ([UserID])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_MagicUsers]
GO
