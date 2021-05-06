USE [BetterCalmDB]
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrators](
	[AdministratorDtoId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[UserDtoId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED 
(
	[AdministratorDtoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AudioCategoryDto]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudioCategoryDto](
	[AudioID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_AudioCategoryDto] PRIMARY KEY CLUSTERED 
(
	[AudioID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Audios]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audios](
	[AudioDtoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Duration] [float] NOT NULL,
	[AuthorName] [nvarchar](max) NULL,
	[UrlImage] [nvarchar](max) NULL,
	[UrlAudio] [nvarchar](max) NULL,
 CONSTRAINT [PK_Audios] PRIMARY KEY CLUSTERED 
(
	[AudioDtoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryDtoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryDtoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[PsychologistId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Meeting] PRIMARY KEY CLUSTERED 
(
	[PsychologistId] ASC,
	[PatientId] ASC,
	[DateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientDtoId] [int] IDENTITY(1,1) NOT NULL,
	[Cellphone] [nvarchar](max) NULL,
	[BirthDay] [datetime2](7) NOT NULL,
	[UserDtoId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientDtoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistAudioDto]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistAudioDto](
	[AudioID] [int] NOT NULL,
	[PlaylistID] [int] NOT NULL,
 CONSTRAINT [PK_PlaylistAudioDto] PRIMARY KEY CLUSTERED 
(
	[PlaylistID] ASC,
	[AudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistCategoryDto]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistCategoryDto](
	[CategoryID] [int] NOT NULL,
	[PlaylistID] [int] NOT NULL,
 CONSTRAINT [PK_PlaylistCategoryDto] PRIMARY KEY CLUSTERED 
(
	[PlaylistID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists](
	[PlaylistDtoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UrlImage] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[PlaylistDtoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Problematics]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problematics](
	[ProblematicDtoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Problematics] PRIMARY KEY CLUSTERED 
(
	[ProblematicDtoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PsychologistProblematic]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PsychologistProblematic](
	[PsychologistId] [int] NOT NULL,
	[ProblematicId] [int] NOT NULL,
 CONSTRAINT [PK_PsychologistProblematic] PRIMARY KEY CLUSTERED 
(
	[PsychologistId] ASC,
	[ProblematicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Psychologists]    Script Date: 6/5/2021 12:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Psychologists](
	[PsychologistDtoId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[WorksOnline] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UserDtoId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Psychologists] PRIMARY KEY CLUSTERED 
(
	[PsychologistDtoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrators] ON 

INSERT [dbo].[Administrators] ([AdministratorDtoId], [Email], [Password], [Token], [UserDtoId], [Name], [LastName]) VALUES (1, N'admin@admin.com', N'pass', N'token', 1, N'Joselen', N'Cecilia')
INSERT [dbo].[Administrators] ([AdministratorDtoId], [Email], [Password], [Token], [UserDtoId], [Name], [LastName]) VALUES (2, N'email@me2.com', N'pass', NULL, 0, N'Juan Pablo', N'Poittevin')
SET IDENTITY_INSERT [dbo].[Administrators] OFF
GO
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (4, 1)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (9, 1)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (1, 2)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (8, 2)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (11, 2)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (2, 3)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (3, 4)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (7, 4)
INSERT [dbo].[AudioCategoryDto] ([AudioID], [CategoryID]) VALUES (10, 4)
GO
SET IDENTITY_INSERT [dbo].[Audios] ON 

INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (1, N'Let it be', 250, N'The Beatles', N'', N'https://www.youtube.com/watch?v=QDYfEBY9NM4')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (2, N'Holy', 300, N'Justin Bieber', N'', N'https://www.youtube.com/watch?v=pvPsJFRGleA')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (3, N'Heartbreak Anniversary', 194, N'Giveon', N'https://image.com', N'https://www.youtube.com/watch?v=nja_0BaQcNg')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (4, N' Leave the Door Open', 194, N'Bruno Mars', N'', N'')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (5, N'Mienteme', 180, N'TINI Maria Becerra', N'http//imageMusic.com', N'')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (6, N'Pareja del Año', 240, N'Sebastian Yatra', N'http//imageMusic.com', N'')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (7, N'Vacio', 240, N'Lusi Fonsi', N'', N'https://www.youtube.com/watch?v=bgE3oMfl19Q')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (8, N'Baila Conmigo', 304, N'Selena Gomez', N'', N'')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (9, N'LA NOCHE DE ANOCHE', 304, N'Rosalia', N'', N'')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (10, N'When I Was Your Man', 344, N'Bruno Mars', N'', N'https://www.youtube.com/watch?v=ekzHIouo8Q4')
INSERT [dbo].[Audios] ([AudioDtoID], [Name], [Duration], [AuthorName], [UrlImage], [UrlAudio]) VALUES (11, N'Talking To The Moon', 334, N'Bruno Mars', N'', N'https://www.youtube.com/watch?v=fXw0jcYbqdo')
SET IDENTITY_INSERT [dbo].[Audios] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryDtoID], [Name]) VALUES (1, N'Dormir')
INSERT [dbo].[Categories] ([CategoryDtoID], [Name]) VALUES (2, N'Meditar')
INSERT [dbo].[Categories] ([CategoryDtoID], [Name]) VALUES (3, N'Musica')
INSERT [dbo].[Categories] ([CategoryDtoID], [Name]) VALUES (4, N'Cuerpo')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (1, 6, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My house 1234')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (1, 8, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My house 1234')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (1, 9, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My house 1234')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (2, 2, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'https://bettercalm.com.uy/2_0/ac7a2220-144f-4fbf-9190-abf8f1411c59')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (2, 3, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'https://bettercalm.com.uy/2_0/159502fc-6bed-4325-94f2-f35278575262')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (3, 7, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'https://bettercalm.com.uy/3_0/94cb1b1c-ecb2-45a5-b52a-9891064dc3f1')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (5, 10, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My home 2312')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (8, 4, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My home 9')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (8, 12, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My home 9')
INSERT [dbo].[Meeting] ([PsychologistId], [PatientId], [DateTime], [Address]) VALUES (8, 15, CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), N'My home 9')
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (1, N'123499823', CAST(N'1993-07-18T00:00:00.0000000' AS DateTime2), 0, N'Patient1', N'Rodriguez')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (2, N'87654321', CAST(N'1998-08-19T00:00:00.0000000' AS DateTime2), 0, N'Juan', N'Poittevin')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (3, N'435345224', CAST(N'2000-08-04T00:00:00.0000000' AS DateTime2), 0, N'Joselen', N'Cecilia')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (4, N'435345224', CAST(N'2000-07-04T00:00:00.0000000' AS DateTime2), 0, N'Belen', N'Martinez')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (5, N'435345224', CAST(N'2001-07-04T00:00:00.0000000' AS DateTime2), 0, N'Jazmin', N'Velazquez')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (6, N'435345224', CAST(N'2001-10-04T00:00:00.0000000' AS DateTime2), 0, N'Yanina', N'Perez')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (7, N'435345224', CAST(N'2000-10-21T00:00:00.0000000' AS DateTime2), 0, N'Evelyn', N'Jodus')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (8, N'435345224', CAST(N'1999-10-21T00:00:00.0000000' AS DateTime2), 0, N'Camila', N'Burgueño')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (9, N'435345224', CAST(N'1999-10-21T00:00:00.0000000' AS DateTime2), 0, N'Pedro', N'Garcia')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (10, N'435345224', CAST(N'1998-11-21T00:00:00.0000000' AS DateTime2), 0, N'Alvaro', N'Tomas')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (12, N'12345678', CAST(N'1998-08-21T00:00:00.0000000' AS DateTime2), 0, N'Gabriel', N'Piffaretti')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (13, N'12345678', CAST(N'1999-08-12T00:00:00.0000000' AS DateTime2), 0, N'Nicolás', N'Fierro')
INSERT [dbo].[Patients] ([PatientDtoId], [Cellphone], [BirthDay], [UserDtoId], [Name], [LastName]) VALUES (15, N'12345678', CAST(N'1999-07-12T00:00:00.0000000' AS DateTime2), 0, N'Nicolas', N'Hernandez')
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (1, 2)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (1, 8)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (1, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (2, 5)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (2, 6)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (2, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (3, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (4, 1)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (4, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (5, 3)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (5, 6)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (5, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (6, 3)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (6, 6)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (6, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (7, 7)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (7, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (8, 4)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (8, 10)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (9, 3)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (10, 1)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (10, 8)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (10, 9)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (11, 1)
INSERT [dbo].[PlaylistAudioDto] ([AudioID], [PlaylistID]) VALUES (11, 6)
GO
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (1, 2)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (1, 7)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (1, 8)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (2, 4)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (2, 8)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (2, 9)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (2, 10)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (3, 3)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (3, 6)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (3, 7)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (4, 1)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (4, 5)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (4, 6)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (4, 9)
INSERT [dbo].[PlaylistCategoryDto] ([CategoryID], [PlaylistID]) VALUES (4, 10)
GO
SET IDENTITY_INSERT [dbo].[Playlists] ON 

INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (1, N'Top Bruno Mars', N'', N'Best songs Bruno Mars')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (2, N'Top The Beatles', N'http//image.com', N'Best songs The beatles')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (3, N'Fiesta', N'http//dance.com', N'Para bailar')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (4, N'Selena Gomez', N'', N'2021 Selena Gomez en español')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (5, N'Justin Bieber', N'', N'Top Bieber 2021')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (6, N'Top 2021', N'', N'Top 2021')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (7, N'Luis Fonsi top 2021', N'', N'Exitos Luis fonsi 2021')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (8, N'Old songs', N'', N'old hit')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (9, N'Old songs', N'', N'old hit')
INSERT [dbo].[Playlists] ([PlaylistDtoID], [Name], [UrlImage], [Description]) VALUES (10, N'Mix', N'', N'mix styles')
SET IDENTITY_INSERT [dbo].[Playlists] OFF
GO
SET IDENTITY_INSERT [dbo].[Problematics] ON 

INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (1, N'Depresión')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (2, N'Estrés')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (3, N'Ansiedad')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (4, N'Autoestima')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (5, N'Enojo')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (6, N'Relaciones')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (7, N'Duelo')
INSERT [dbo].[Problematics] ([ProblematicDtoID], [Name]) VALUES (8, N'Otros')
SET IDENTITY_INSERT [dbo].[Problematics] OFF
GO
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (5, 1)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (6, 1)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (7, 1)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (8, 2)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (9, 2)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (3, 4)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (4, 4)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (1, 5)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (1, 6)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (1, 7)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (2, 8)
INSERT [dbo].[PsychologistProblematic] ([PsychologistId], [ProblematicId]) VALUES (10, 8)
GO
SET IDENTITY_INSERT [dbo].[Psychologists] ON 

INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (1, N'My house 1234', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Jose', N'Collazo')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (2, N'My office 2323', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Agustina', N'Sayas')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (3, N'My office 12', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Lucia', N'Fontes')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (4, N'My home 2345', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Federico', N'Cabrera')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (5, N'My home 2312', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Pedro', N'Cabrera')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (6, N'My home 555', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Lucia', N'Martina')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (7, N'My home 1212', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Cecilia', N'Cuitiño')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (8, N'My home 9', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Melany', N'Rodriguez')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (9, N'My home 9', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Matias', N'Rodriguez')
INSERT [dbo].[Psychologists] ([PsychologistDtoId], [Address], [WorksOnline], [CreationDate], [UserDtoId], [Name], [LastName]) VALUES (10, N'My home 9', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Julio', N'Cecilia')
SET IDENTITY_INSERT [dbo].[Psychologists] OFF
GO
ALTER TABLE [dbo].[AudioCategoryDto]  WITH CHECK ADD  CONSTRAINT [FK_AudioCategoryDto_Audios_AudioID] FOREIGN KEY([AudioID])
REFERENCES [dbo].[Audios] ([AudioDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AudioCategoryDto] CHECK CONSTRAINT [FK_AudioCategoryDto_Audios_AudioID]
GO
ALTER TABLE [dbo].[AudioCategoryDto]  WITH CHECK ADD  CONSTRAINT [FK_AudioCategoryDto_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AudioCategoryDto] CHECK CONSTRAINT [FK_AudioCategoryDto_Categories_CategoryID]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientDtoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_Patients_PatientId]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Psychologists_PsychologistId] FOREIGN KEY([PsychologistId])
REFERENCES [dbo].[Psychologists] ([PsychologistDtoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_Psychologists_PsychologistId]
GO
ALTER TABLE [dbo].[PlaylistAudioDto]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistAudioDto_Audios_AudioID] FOREIGN KEY([AudioID])
REFERENCES [dbo].[Audios] ([AudioDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistAudioDto] CHECK CONSTRAINT [FK_PlaylistAudioDto_Audios_AudioID]
GO
ALTER TABLE [dbo].[PlaylistAudioDto]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistAudioDto_Playlists_PlaylistID] FOREIGN KEY([PlaylistID])
REFERENCES [dbo].[Playlists] ([PlaylistDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistAudioDto] CHECK CONSTRAINT [FK_PlaylistAudioDto_Playlists_PlaylistID]
GO
ALTER TABLE [dbo].[PlaylistCategoryDto]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistCategoryDto_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistCategoryDto] CHECK CONSTRAINT [FK_PlaylistCategoryDto_Categories_CategoryID]
GO
ALTER TABLE [dbo].[PlaylistCategoryDto]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistCategoryDto_Playlists_PlaylistID] FOREIGN KEY([PlaylistID])
REFERENCES [dbo].[Playlists] ([PlaylistDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistCategoryDto] CHECK CONSTRAINT [FK_PlaylistCategoryDto_Playlists_PlaylistID]
GO
ALTER TABLE [dbo].[PsychologistProblematic]  WITH CHECK ADD  CONSTRAINT [FK_PsychologistProblematic_Problematics_ProblematicId] FOREIGN KEY([ProblematicId])
REFERENCES [dbo].[Problematics] ([ProblematicDtoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PsychologistProblematic] CHECK CONSTRAINT [FK_PsychologistProblematic_Problematics_ProblematicId]
GO
ALTER TABLE [dbo].[PsychologistProblematic]  WITH CHECK ADD  CONSTRAINT [FK_PsychologistProblematic_Psychologists_PsychologistId] FOREIGN KEY([PsychologistId])
REFERENCES [dbo].[Psychologists] ([PsychologistDtoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PsychologistProblematic] CHECK CONSTRAINT [FK_PsychologistProblematic_Psychologists_PsychologistId]
GO
