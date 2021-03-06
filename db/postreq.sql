USE [postreq]
GO
ALTER TABLE [dbo].[requests] DROP CONSTRAINT [FK_states_request]
GO
ALTER TABLE [dbo].[request_rows] DROP CONSTRAINT [FK_request_rows_requests]
GO
ALTER TABLE [dbo].[requests] DROP CONSTRAINT [DF_requests_state_id]
GO
/****** Object:  Table [dbo].[states]    Script Date: 25.12.2016 12:42:55 ******/
DROP TABLE [dbo].[states]
GO
/****** Object:  Table [dbo].[requests]    Script Date: 25.12.2016 12:42:55 ******/
DROP TABLE [dbo].[requests]
GO
/****** Object:  Table [dbo].[request_rows]    Script Date: 25.12.2016 12:42:55 ******/
DROP TABLE [dbo].[request_rows]
GO
USE [master]
GO
/****** Object:  Database [postreq]    Script Date: 25.12.2016 12:42:55 ******/
DROP DATABASE [postreq]
GO
/****** Object:  Database [postreq]    Script Date: 25.12.2016 12:42:55 ******/
CREATE DATABASE [postreq]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'postreq', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLNAS\MSSQL\DATA\postreq.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'postreq_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLNAS\MSSQL\DATA\postreq_log.ldf' , SIZE = 84992KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [postreq] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [postreq].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [postreq] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [postreq] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [postreq] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [postreq] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [postreq] SET ARITHABORT OFF 
GO
ALTER DATABASE [postreq] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [postreq] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [postreq] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [postreq] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [postreq] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [postreq] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [postreq] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [postreq] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [postreq] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [postreq] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [postreq] SET  DISABLE_BROKER 
GO
ALTER DATABASE [postreq] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [postreq] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [postreq] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [postreq] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [postreq] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [postreq] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [postreq] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [postreq] SET RECOVERY FULL 
GO
ALTER DATABASE [postreq] SET  MULTI_USER 
GO
ALTER DATABASE [postreq] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [postreq] SET DB_CHAINING OFF 
GO
ALTER DATABASE [postreq] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [postreq] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'postreq', N'ON'
GO
USE [postreq]
GO
/****** Object:  Table [dbo].[request_rows]    Script Date: 25.12.2016 12:42:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[request_rows](
	[id] [int] IDENTITY(30,1) NOT NULL,
	[name] [varchar](256) NOT NULL,
	[amount] [decimal](10, 3) NOT NULL,
	[request_id] [int] NOT NULL,
	[goods_id] [varchar](32) NOT NULL,
	[ed_izm] [varchar](32) NOT NULL,
 CONSTRAINT [PK_request_rows] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[requests]    Script Date: 25.12.2016 12:42:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[requests](
	[id] [int] IDENTITY(20,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[state_id] [int] NOT NULL,
 CONSTRAINT [PK_requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[states]    Script Date: 25.12.2016 12:42:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[states](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](32) NOT NULL,
 CONSTRAINT [PK_states] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[request_rows] ON 

INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (15, N'29495 ЗУБНОЙ ТЕХНИК (16+)', CAST(5.000 AS Decimal(10, 3)), 13, N'82412C59E545398611E5CA2EC6606617', N'компл')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (16, N'25072 САНАТОРНО-КУРОРТНЫЕ ОРГАН', CAST(5.000 AS Decimal(10, 3)), 13, N'82412C59E545398611E5CA2EB365C5E', N'компл')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (17, N'Кент HD Futura №8 сигареты (50*10) МРЦ 74,00', CAST(0.000 AS Decimal(10, 3)), 14, N'80C62C59E54561E311E3F79F1A9E92FD', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (18, N'"ARMADA" с/ф красная пачка (МРЦ 16,00)', CAST(0.000 AS Decimal(10, 3)), 14, N'80C82C59E54561E111E3F81C3C85A87B', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (19, N'"Kiss" clubnichka superslims с/ф (МРЦ 29,00)', CAST(0.000 AS Decimal(10, 3)), 14, N'80C82C59E54561E111E3F81C3C85A87D', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (20, N'"Kiss" clubnichka superslims с/ф (МРЦ 34,00)', CAST(0.000 AS Decimal(10, 3)), 14, N'80C82C59E54561E111E3F81C3C85A87F', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (21, N'"Kiss" energy superslims с/ф (МРЦ 29,00)', CAST(0.000 AS Decimal(10, 3)), 14, N'80C82C59E54561E111E3F81C3C85A881', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (22, N'Акварель "Юный художник" 8цв.пласт..уп.', CAST(0.000 AS Decimal(10, 3)), 15, N'80C62C59E54561E311E3F75967C686BD', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (23, N'Акварель 12цв. "Пушистые друзья" пл.уп / 33', CAST(0.000 AS Decimal(10, 3)), 15, N'80C62C59E54561E311E3F75967C686BF', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (24, N'Акварель 12цв. картон. уп. б/кисти "маленькие друзья"/40', CAST(0.000 AS Decimal(10, 3)), 15, N'80C62C59E54561E311E3F75967C686C1', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (25, N'Акварель Erich Krause медовая 18 цв./ 42', CAST(0.000 AS Decimal(10, 3)), 15, N'80C62C59E54561E311E3F75967C686C5', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (31, N'"Знахарь" Зубная паста ""TOTAL PROTECTION" (Комплексный ухо', CAST(5.000 AS Decimal(10, 3)), 21, N'80C62C59E54561E311E3F6BAB7EF45E5', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (32, N'з/п Акварель двухц. 75мл Whitening/Акв/50x10', CAST(10.000 AS Decimal(10, 3)), 21, N'80C62C59E54561E311E3F6BAE7D4E15', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (33, N'"Знахарь" Зубная паста ""TOTAL PROTECTION" (Комплексный ухо', CAST(5.000 AS Decimal(10, 3)), 22, N'80C62C59E54561E311E3F6BAB7EF45E5', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (34, N'"Знахарь" Зубная паста ""TOTAL PROTECTION" (Комплексный ухо', CAST(55.000 AS Decimal(10, 3)), 23, N'80C62C59E54561E311E3F6BAB7EF45E5', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (35, N'1 сентября. ENGLISH 79002', CAST(66.000 AS Decimal(10, 3)), 24, N'80C82C59E54561E111E403C2B788A57', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (36, N'ARIEL 450г Белая роза', CAST(0.000 AS Decimal(10, 3)), 25, N'80C62C59E54561E311E3F6BABDEC763F', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (37, N'BiMax 100 Пятен 400 г 1/24 560-1', CAST(0.000 AS Decimal(10, 3)), 25, N'80C62C59E54561E311E3F6BABDEC7687', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (38, N'BiMax Color Automat 400гр 1/24 520-1', CAST(0.000 AS Decimal(10, 3)), 25, N'80C62C59E54561E311E3F6BABDEC7689', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (39, N'DOSIA Концентрат-ополаскиватель Пробуждение весны 1л', CAST(0.000 AS Decimal(10, 3)), 25, N'80C62C59E54561E311E3F6BABDEC76FB', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (40, N'E СМС автомат 2в1 д/белого Софт 400гр', CAST(0.000 AS Decimal(10, 3)), 25, N'80C62C59E54561E311E3F6BAC3E9A9DE', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (41, N'70 моделей и композиций из картон. Мартин. Квилинг', CAST(0.000 AS Decimal(10, 3)), 28, N'80C82C59E54561E111E403C2B788A65', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (42, N'доска разделочная "В клеточку" 175*270 средняя/МатПл/52', CAST(0.000 AS Decimal(10, 3)), 29, N'80C62C59E54561E311E3F6BAE7D4D8E', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (43, N'доска разделочная "В клеточку" 200*310 большая цвет./МатПл/7', CAST(0.000 AS Decimal(10, 3)), 29, N'80C62C59E54561E311E3F6BAE7D4D90', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (44, N'доска разделочная "В клеточку" 200*310 большая/МатПл/75', CAST(0.000 AS Decimal(10, 3)), 29, N'80C62C59E54561E311E3F6BAE7D4D92', N'шт')
INSERT [dbo].[request_rows] ([id], [name], [amount], [request_id], [goods_id], [ed_izm]) VALUES (45, N'Конверт 229х324 крафт (Портапринт)', CAST(0.000 AS Decimal(10, 3)), 36, N'80C62C59E54561E311E3F787FC2538EF', N'шт')
SET IDENTITY_INSERT [dbo].[request_rows] OFF
SET IDENTITY_INSERT [dbo].[requests] ON 

INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (13, CAST(0x0000A6E400C4DE73 AS DateTime), N'MAIN\Evgenij.Lucenko', 2)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (14, CAST(0x0000A6E400C58899 AS DateTime), N'MAIN\Evgenij.Lucenko', 2)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (15, CAST(0x0000A6E400C62770 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (16, CAST(0x0000A6E400C6C89F AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (21, CAST(0x0000A6E500C6D888 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (22, CAST(0x0000A6E500D1D792 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (23, CAST(0x0000A6E500D21255 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (24, CAST(0x0000A6E500D9A809 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (25, CAST(0x0000A6E500DD1CA5 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (26, CAST(0x0000A6E500DD8086 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (27, CAST(0x0000A6E500DDE32F AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (28, CAST(0x0000A6E500DE01D5 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (29, CAST(0x0000A6E500F6CD79 AS DateTime), N'MAIN\Evgenij.Lucenko', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (30, CAST(0x0000A6E60115DA5E AS DateTime), N'ATHLONX2\Eugeny', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (31, CAST(0x0000A6E601170264 AS DateTime), N'ATHLONX2\Eugeny', 2)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (34, CAST(0x0000A6E60119F032 AS DateTime), N'ATHLONX2\Eugeny', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (35, CAST(0x0000A6E6011A60B9 AS DateTime), N'ATHLONX2\Eugeny', 1)
INSERT [dbo].[requests] ([id], [date], [username], [state_id]) VALUES (36, CAST(0x0000A6E60125690E AS DateTime), N'ATHLONX2\Eugeny', 1)
SET IDENTITY_INSERT [dbo].[requests] OFF
SET IDENTITY_INSERT [dbo].[states] ON 

INSERT [dbo].[states] ([id], [name]) VALUES (1, N'Сохранена')
INSERT [dbo].[states] ([id], [name]) VALUES (2, N'Отправлена')
INSERT [dbo].[states] ([id], [name]) VALUES (3, N'Загружена накладная')
INSERT [dbo].[states] ([id], [name]) VALUES (4, N'saved')
SET IDENTITY_INSERT [dbo].[states] OFF
ALTER TABLE [dbo].[requests] ADD  CONSTRAINT [DF_requests_state_id]  DEFAULT ((0)) FOR [state_id]
GO
ALTER TABLE [dbo].[request_rows]  WITH CHECK ADD  CONSTRAINT [FK_request_rows_requests] FOREIGN KEY([request_id])
REFERENCES [dbo].[requests] ([id])
GO
ALTER TABLE [dbo].[request_rows] CHECK CONSTRAINT [FK_request_rows_requests]
GO
ALTER TABLE [dbo].[requests]  WITH NOCHECK ADD  CONSTRAINT [FK_states_request] FOREIGN KEY([state_id])
REFERENCES [dbo].[states] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[requests] NOCHECK CONSTRAINT [FK_states_request]
GO
USE [master]
GO
ALTER DATABASE [postreq] SET  READ_WRITE 
GO
