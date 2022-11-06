USE [master]
GO
/****** Object:  Database [M3I]    Script Date: 16/02/2022 00:05:03 ******/
CREATE DATABASE [M3I]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'M3I', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\M3I.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'M3I_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\M3I_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [M3I] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [M3I].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [M3I] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [M3I] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [M3I] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [M3I] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [M3I] SET ARITHABORT OFF 
GO
ALTER DATABASE [M3I] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [M3I] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [M3I] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [M3I] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [M3I] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [M3I] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [M3I] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [M3I] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [M3I] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [M3I] SET  DISABLE_BROKER 
GO
ALTER DATABASE [M3I] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [M3I] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [M3I] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [M3I] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [M3I] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [M3I] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [M3I] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [M3I] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [M3I] SET  MULTI_USER 
GO
ALTER DATABASE [M3I] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [M3I] SET DB_CHAINING OFF 
GO
ALTER DATABASE [M3I] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [M3I] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [M3I] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [M3I] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [M3I] SET QUERY_STORE = OFF
GO
USE [M3I]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[EmailID] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[CategorieID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NULL,
 CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[CategorieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENT]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENT](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[IsEmailVerified] [bit] NULL,
	[ActivationCode] [uniqueidentifier] NULL,
	[Photo] [nvarchar](50) NULL,
	[Adresse] [nvarchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COULEUR]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COULEUR](
	[CouleurID] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](50) NULL,
 CONSTRAINT [PK_COULEUR] PRIMARY KEY CLUSTERED 
(
	[CouleurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FOURNISSEUR]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FOURNISSEUR](
	[FournisseurID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NULL,
	[Adresse] [nvarchar](50) NULL,
 CONSTRAINT [PK_FOURNISSEUR] PRIMARY KEY CLUSTERED 
(
	[FournisseurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUIT]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUIT](
	[ProduitID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL,
	[Prix] [int] NULL,
	[FournisseurID] [int] NULL,
	[CategorieID] [int] NULL,
 CONSTRAINT [PK_PRODUIT] PRIMARY KEY CLUSTERED 
(
	[ProduitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUIT_COULEUR]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUIT_COULEUR](
	[ProduitID] [int] NOT NULL,
	[CouleurID] [int] NOT NULL,
 CONSTRAINT [PK_PRODUIT_COULEUR] PRIMARY KEY CLUSTERED 
(
	[ProduitID] ASC,
	[CouleurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/02/2022 00:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRODUIT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUIT_CATEGORY] FOREIGN KEY([CategorieID])
REFERENCES [dbo].[CATEGORY] ([CategorieID])
GO
ALTER TABLE [dbo].[PRODUIT] CHECK CONSTRAINT [FK_PRODUIT_CATEGORY]
GO
ALTER TABLE [dbo].[PRODUIT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUIT_FOURNISSEUR] FOREIGN KEY([FournisseurID])
REFERENCES [dbo].[FOURNISSEUR] ([FournisseurID])
GO
ALTER TABLE [dbo].[PRODUIT] CHECK CONSTRAINT [FK_PRODUIT_FOURNISSEUR]
GO
ALTER TABLE [dbo].[PRODUIT_COULEUR]  WITH CHECK ADD  CONSTRAINT [FK_PRODUIT_COULEUR_COULEUR] FOREIGN KEY([CouleurID])
REFERENCES [dbo].[COULEUR] ([CouleurID])
GO
ALTER TABLE [dbo].[PRODUIT_COULEUR] CHECK CONSTRAINT [FK_PRODUIT_COULEUR_COULEUR]
GO
ALTER TABLE [dbo].[PRODUIT_COULEUR]  WITH CHECK ADD  CONSTRAINT [FK_PRODUIT_COULEUR_PRODUIT] FOREIGN KEY([ProduitID])
REFERENCES [dbo].[PRODUIT] ([ProduitID])
GO
ALTER TABLE [dbo].[PRODUIT_COULEUR] CHECK CONSTRAINT [FK_PRODUIT_COULEUR_PRODUIT]
GO
USE [master]
GO
ALTER DATABASE [M3I] SET  READ_WRITE 
GO
