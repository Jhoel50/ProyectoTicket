USE [master]
GO
/****** Object:  Database [DB_121710_ticketperu]    Script Date: 6/14/2018 11:54:16 PM ******/
CREATE DATABASE [DB_121710_ticketperu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_121710_ticketperu_data', FILENAME = N'e:\sqldata\DB_121710_ticketperu_data.mdf' , SIZE = 6144KB , MAXSIZE = 30720KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_121710_ticketperu_log', FILENAME = N'f:\sqllog\DB_121710_ticketperu_log.ldf' , SIZE = 2048KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_121710_ticketperu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_121710_ticketperu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_121710_ticketperu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_121710_ticketperu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_121710_ticketperu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_121710_ticketperu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_121710_ticketperu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_121710_ticketperu] SET  MULTI_USER 
GO
ALTER DATABASE [DB_121710_ticketperu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_121710_ticketperu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_121710_ticketperu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_121710_ticketperu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_121710_ticketperu] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DB_121710_ticketperu]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/14/2018 11:54:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUser](
	[Id] [nvarchar](128) NOT NULL,
	[BTId] [nvarchar](max) NULL,
	[Nombres] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[TipoDocumentoID] [int] NOT NULL,
	[Documento] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evento]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BTEventoID] [int] NOT NULL,
	[NombreEvento] [nvarchar](max) NULL,
	[DescripcionEvento] [nvarchar](max) NULL,
	[DescripcionLargaEvento] [nvarchar](max) NULL,
	[TipoEventoID] [int] NOT NULL,
	[EstadoEvento] [int] NOT NULL,
	[DescripcionEstadoEvento] [nvarchar](max) NULL,
	[CodigoExtra] [nvarchar](max) NULL,
	[Imagen] [nvarchar](max) NULL,
	[ImagenMini] [nvarchar](max) NULL,
	[ImagenMedia] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Evento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityRole]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRole](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.IdentityRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserClaim]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserLogin]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserLogin](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserRole]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRole](
	[RoleId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pase]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BTPaseID] [int] NOT NULL,
	[NombrePase] [nvarchar](max) NULL,
	[DescripcionPase] [nvarchar](max) NULL,
	[DescripcionLargaPase] [nvarchar](max) NULL,
	[RecintoID] [int] NOT NULL,
	[NombreRecinto] [nvarchar](max) NULL,
	[EstadoPase] [int] NOT NULL,
	[DescripcionEstadoPase] [nvarchar](max) NULL,
	[FechaPase] [nvarchar](max) NULL,
	[FechaPorConfirmar] [nvarchar](max) NULL,
	[Imagen] [nvarchar](max) NULL,
	[ImagenMini] [nvarchar](max) NULL,
	[ImagenMedia] [nvarchar](max) NULL,
	[Destacado] [int] NOT NULL,
	[EventoID] [int] NOT NULL,
	[PrecioMinimo] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Pase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 6/14/2018 11:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BTTipoEventoID] [int] NOT NULL,
	[IdiomaID] [int] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoEvento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_TipoEventoID]    Script Date: 6/14/2018 11:54:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_TipoEventoID] ON [dbo].[Evento]
(
	[TipoEventoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 6/14/2018 11:54:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[IdentityUserClaim]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 6/14/2018 11:54:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[IdentityUserLogin]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 6/14/2018 11:54:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[IdentityUserRole]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityRole_Id]    Script Date: 6/14/2018 11:54:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id] ON [dbo].[IdentityUserRole]
(
	[IdentityRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EventoID]    Script Date: 6/14/2018 11:54:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_EventoID] ON [dbo].[Pase]
(
	[EventoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Evento_dbo.TipoEvento_TipoEventoID] FOREIGN KEY([TipoEventoID])
REFERENCES [dbo].[TipoEvento] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_dbo.Evento_dbo.TipoEvento_TipoEventoID]
GO
ALTER TABLE [dbo].[IdentityUserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserClaim_dbo.ApplicationUser_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserClaim] CHECK CONSTRAINT [FK_dbo.IdentityUserClaim_dbo.ApplicationUser_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[IdentityUserLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserLogin_dbo.ApplicationUser_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserLogin] CHECK CONSTRAINT [FK_dbo.IdentityUserLogin_dbo.ApplicationUser_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[IdentityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRole_dbo.ApplicationUser_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserRole] CHECK CONSTRAINT [FK_dbo.IdentityUserRole_dbo.ApplicationUser_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[IdentityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRole_dbo.IdentityRole_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[IdentityRole] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserRole] CHECK CONSTRAINT [FK_dbo.IdentityUserRole_dbo.IdentityRole_IdentityRole_Id]
GO
ALTER TABLE [dbo].[Pase]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pase_dbo.Evento_EventoID] FOREIGN KEY([EventoID])
REFERENCES [dbo].[Evento] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pase] CHECK CONSTRAINT [FK_dbo.Pase_dbo.Evento_EventoID]
GO
USE [master]
GO
ALTER DATABASE [DB_121710_ticketperu] SET  READ_WRITE 
GO
