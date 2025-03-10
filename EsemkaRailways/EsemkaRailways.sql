USE [master]
GO
/****** Object:  Database [EsemkaRailways]    Script Date: 08/03/2024 11:23:00 ******/
CREATE DATABASE [EsemkaRailways]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EsemkaRailways', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER2008\MSSQL\DATA\EsemkaRailways.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EsemkaRailways_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER2008\MSSQL\DATA\EsemkaRailways_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EsemkaRailways] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EsemkaRailways].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EsemkaRailways] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EsemkaRailways] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EsemkaRailways] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EsemkaRailways] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EsemkaRailways] SET ARITHABORT OFF 
GO
ALTER DATABASE [EsemkaRailways] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EsemkaRailways] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EsemkaRailways] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EsemkaRailways] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EsemkaRailways] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EsemkaRailways] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EsemkaRailways] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EsemkaRailways] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EsemkaRailways] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EsemkaRailways] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EsemkaRailways] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EsemkaRailways] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EsemkaRailways] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EsemkaRailways] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EsemkaRailways] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EsemkaRailways] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EsemkaRailways] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EsemkaRailways] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EsemkaRailways] SET  MULTI_USER 
GO
ALTER DATABASE [EsemkaRailways] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EsemkaRailways] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EsemkaRailways] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EsemkaRailways] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EsemkaRailways] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EsemkaRailways] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EsemkaRailways] SET QUERY_STORE = OFF
GO
USE [EsemkaRailways]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 08/03/2024 11:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[PassengerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[PhoneNumber] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[PassengerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 08/03/2024 11:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[TrainID] [int] NULL,
	[DepartureStationID] [int] NULL,
	[ArrivalStationID] [int] NULL,
	[DepartureTime] [datetime] NULL,
	[ArrivalTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Station]    Script Date: 08/03/2024 11:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Station](
	[StationID] [int] IDENTITY(1,1) NOT NULL,
	[StationName] [varchar](255) NULL,
	[Location] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[StationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 08/03/2024 11:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[PassengerID] [int] NULL,
	[ScheduleID] [int] NULL,
	[SeatNumber] [varchar](10) NULL,
	[BookingTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 08/03/2024 11:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[TrainID] [int] IDENTITY(1,1) NOT NULL,
	[TrainName] [varchar](255) NULL,
	[Capacity] [int] NULL,
	[Type] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Passenger] ON 

INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (1, N'John', N'Doe', N'john.doe@email.com', N'123-456-7890')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (2, N'Jane', N'Smith', N'jane.smith@email.com', N'987-654-3210')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (3, N'Michael', N'Johnson', N'michael.johnson@email.com', N'456-789-0123')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (4, N'Emily', N'Davis', N'emily.davis@email.com', N'789-012-3456')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (5, N'Daniel', N'Martinez', N'daniel.martinez@email.com', N'234-567-8901')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (6, N'Olivia', N'Taylor', N'olivia.taylor@email.com', N'567-890-1234')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (7, N'James', N'Brown', N'james.brown@email.com', N'012-345-6789')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (8, N'Sophia', N'Wilson', N'sophia.wilson@email.com', N'345-678-9012')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (9, N'David', N'Moore', N'david.moore@email.com', N'678-901-2345')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (10, N'Emma', N'Anderson', N'emma.anderson@email.com', N'901-234-5678')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (11, N'William', N'Jackson', N'william.jackson@email.com', N'432-109-8765')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (12, N'Ava', N'White', N'ava.white@email.com', N'321-098-7654')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (13, N'Alexander', N'Harris', N'alexander.harris@email.com', N'210-987-6543')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (14, N'Ella', N'Martin', N'ella.martin@email.com', N'109-876-5432')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (15, N'Benjamin', N'Thompson', N'benjamin.thompson@email.com', N'876-543-2109')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (16, N'Mia', N'Clark', N'mia.clark@email.com', N'765-432-1098')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (17, N'Henry', N'Lee', N'henry.lee@email.com', N'654-321-0987')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (18, N'Aria', N'Walker', N'aria.walker@email.com', N'543-210-9876')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (19, N'Jackson', N'Baker', N'jackson.baker@email.com', N'432-109-8765')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (20, N'Scarlett', N'Turner', N'scarlett.turner@email.com', N'321-098-7654')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (21, N'Liam', N'Ward', N'liam.ward@email.com', N'210-987-6543')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (22, N'Grace', N'Evans', N'grace.evans@email.com', N'109-876-5432')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (23, N'Lucas', N'Cooper', N'lucas.cooper@email.com', N'876-543-2109')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (24, N'Lily', N'Parker', N'lily.parker@email.com', N'765-432-1098')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (25, N'Ethan', N'Miller', N'ethan.miller@email.com', N'654-321-0987')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (26, N'Chloe', N'Hill', N'chloe.hill@email.com', N'543-210-9876')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (27, N'Mason', N'Stewart', N'mason.stewart@email.com', N'432-109-8765')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (28, N'Isabella', N'Carter', N'isabella.carter@email.com', N'321-098-7654')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (29, N'Noah', N'Hayes', N'noah.hayes@email.com', N'210-987-6543')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (30, N'Sofia', N'Dixon', N'sofia.dixon@email.com', N'109-876-5432')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (31, N'Logan', N'Warren', N'logan.warren@email.com', N'876-543-2109')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (32, N'Amelia', N'Barnes', N'amelia.barnes@email.com', N'765-432-1098')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (33, N'Lucas', N'Bell', N'lucas.bell@email.com', N'654-321-0987')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (34, N'Emma', N'Ross', N'emma.ross@email.com', N'543-210-9876')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (35, N'Aiden', N'Long', N'aiden.long@email.com', N'432-109-8765')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (36, N'Ella', N'Fisher', N'ella.fisher@email.com', N'321-098-7654')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (37, N'Carter', N'Cole', N'carter.cole@email.com', N'210-987-6543')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (38, N'Grace', N'Reed', N'grace.reed@email.com', N'109-876-5432')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (39, N'Oliver', N'Morgan', N'oliver.morgan@email.com', N'876-543-2109')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (40, N'Aria', N'Mitchell', N'aria.mitchell@email.com', N'765-432-1098')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (41, N'James', N'West', N'james.west@email.com', N'654-321-0987')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (42, N'Abigail', N'Gordon', N'abigail.gordon@email.com', N'543-210-9876')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (43, N'Daniel', N'Rossi', N'daniel.rossi@email.com', N'432-109-8765')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (44, N'Mila', N'Ferguson', N'mila.ferguson@email.com', N'321-098-7654')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (45, N'Jack', N'Fletcher', N'jack.fletcher@email.com', N'210-987-6543')
INSERT [dbo].[Passenger] ([PassengerID], [FirstName], [LastName], [Email], [PhoneNumber]) VALUES (46, N'Avery', N'Stewart', N'avery.stewart@email.com', N'109-876-5432')
SET IDENTITY_INSERT [dbo].[Passenger] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (14, 11, 1, 5, CAST(N'2024-03-06T08:00:00.000' AS DateTime), CAST(N'2024-03-06T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (15, 12, 2, 7, CAST(N'2024-03-06T10:30:00.000' AS DateTime), CAST(N'2024-03-06T13:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (16, 13, 3, 9, CAST(N'2024-03-06T12:45:00.000' AS DateTime), CAST(N'2024-03-06T15:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (17, 14, 4, 11, CAST(N'2024-03-06T15:00:00.000' AS DateTime), CAST(N'2024-03-06T18:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (18, 15, 5, 13, CAST(N'2024-03-06T17:30:00.000' AS DateTime), CAST(N'2024-03-06T20:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (19, 16, 6, 15, CAST(N'2024-03-06T20:00:00.000' AS DateTime), CAST(N'2024-03-07T01:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (20, 17, 7, 17, CAST(N'2024-03-06T23:15:00.000' AS DateTime), CAST(N'2024-03-07T04:15:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (21, 18, 8, 19, CAST(N'2024-03-07T01:45:00.000' AS DateTime), CAST(N'2024-03-07T06:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (22, 19, 9, 1, CAST(N'2024-03-07T04:00:00.000' AS DateTime), CAST(N'2024-03-07T09:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (23, 20, 10, 3, CAST(N'2024-03-07T06:30:00.000' AS DateTime), CAST(N'2024-03-07T11:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (24, 11, 1, 5, CAST(N'2024-03-07T08:00:00.000' AS DateTime), CAST(N'2024-03-07T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (25, 12, 2, 7, CAST(N'2024-03-07T10:30:00.000' AS DateTime), CAST(N'2024-03-07T13:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (26, 13, 3, 9, CAST(N'2024-03-07T12:45:00.000' AS DateTime), CAST(N'2024-03-07T15:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (27, 14, 4, 11, CAST(N'2024-03-07T15:00:00.000' AS DateTime), CAST(N'2024-03-07T18:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (28, 15, 5, 13, CAST(N'2024-03-07T17:30:00.000' AS DateTime), CAST(N'2024-03-07T20:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (29, 16, 6, 15, CAST(N'2024-03-07T20:00:00.000' AS DateTime), CAST(N'2024-03-08T01:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (30, 17, 7, 17, CAST(N'2024-03-07T23:15:00.000' AS DateTime), CAST(N'2024-03-08T04:15:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (31, 18, 8, 19, CAST(N'2024-03-08T01:45:00.000' AS DateTime), CAST(N'2024-03-08T06:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (32, 19, 9, 1, CAST(N'2024-03-08T04:00:00.000' AS DateTime), CAST(N'2024-03-08T09:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (33, 20, 10, 3, CAST(N'2024-03-08T06:30:00.000' AS DateTime), CAST(N'2024-03-08T11:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (34, 11, 1, 5, CAST(N'2024-03-08T08:00:00.000' AS DateTime), CAST(N'2024-03-08T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (35, 12, 2, 7, CAST(N'2024-03-08T10:30:00.000' AS DateTime), CAST(N'2024-03-08T13:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (36, 13, 3, 9, CAST(N'2024-03-08T12:45:00.000' AS DateTime), CAST(N'2024-03-08T15:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (37, 14, 4, 11, CAST(N'2024-03-08T15:00:00.000' AS DateTime), CAST(N'2024-03-08T18:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (38, 15, 5, 13, CAST(N'2024-03-08T17:30:00.000' AS DateTime), CAST(N'2024-03-08T20:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (39, 16, 6, 15, CAST(N'2024-03-08T20:00:00.000' AS DateTime), CAST(N'2024-03-09T01:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (40, 17, 7, 17, CAST(N'2024-03-08T23:15:00.000' AS DateTime), CAST(N'2024-03-09T04:15:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (41, 18, 8, 19, CAST(N'2024-03-09T01:45:00.000' AS DateTime), CAST(N'2024-03-09T06:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (42, 19, 9, 1, CAST(N'2024-03-09T04:00:00.000' AS DateTime), CAST(N'2024-03-09T09:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (43, 20, 10, 3, CAST(N'2024-03-09T06:30:00.000' AS DateTime), CAST(N'2024-03-09T11:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (44, 11, 1, 5, CAST(N'2024-03-09T08:00:00.000' AS DateTime), CAST(N'2024-03-09T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (45, 12, 2, 7, CAST(N'2024-03-09T10:30:00.000' AS DateTime), CAST(N'2024-03-09T13:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (46, 13, 3, 9, CAST(N'2024-03-09T12:45:00.000' AS DateTime), CAST(N'2024-03-09T15:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (47, 14, 4, 11, CAST(N'2024-03-09T15:00:00.000' AS DateTime), CAST(N'2024-03-09T18:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (48, 15, 5, 13, CAST(N'2024-03-09T17:30:00.000' AS DateTime), CAST(N'2024-03-09T20:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (49, 16, 6, 15, CAST(N'2024-03-09T20:00:00.000' AS DateTime), CAST(N'2024-03-10T01:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (50, 17, 7, 17, CAST(N'2024-03-09T23:15:00.000' AS DateTime), CAST(N'2024-03-10T04:15:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (51, 18, 8, 19, CAST(N'2024-03-10T01:45:00.000' AS DateTime), CAST(N'2024-03-10T06:45:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (52, 19, 9, 1, CAST(N'2024-03-10T04:00:00.000' AS DateTime), CAST(N'2024-03-10T09:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleID], [TrainID], [DepartureStationID], [ArrivalStationID], [DepartureTime], [ArrivalTime]) VALUES (53, 20, 10, 3, CAST(N'2024-03-10T06:30:00.000' AS DateTime), CAST(N'2024-03-10T11:30:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Station] ON 

INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (1, N'Grand Central Terminal', N'New York, USA')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (2, N'Kings Cross Station', N'London, UK')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (3, N'Shinjuku Station', N'Tokyo, Japan')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (4, N'Gare du Nord', N'Paris, France')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (5, N'Hauptbahnhof Berlin', N'Berlin, Germany')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (6, N'Central do Brasil', N'Rio de Janeiro, Brazil')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (7, N'Union Station', N'Toronto, Canada')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (8, N'Moscow Kazansky Railway Station', N'Moscow, Russia')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (9, N'Seoul Station', N'Seoul, South Korea')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (10, N'Central Station Sydney', N'Sydney, Australia')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (11, N'Beijing West Railway Station', N'Beijing, China')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (12, N'Chhatrapati Shivaji Maharaj Terminus', N'Mumbai, India')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (13, N'Centraal Station Amsterdam', N'Amsterdam, Netherlands')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (14, N'Antwerp Central Station', N'Antwerp, Belgium')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (15, N'Zurich Hauptbahnhof', N'Zurich, Switzerland')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (16, N'Estación de Atocha', N'Madrid, Spain')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (17, N'Union Station Los Angeles', N'Los Angeles, USA')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (18, N'Central Station Milan', N'Milan, Italy')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (19, N'Keleti Railway Station', N'Budapest, Hungary')
INSERT [dbo].[Station] ([StationID], [StationName], [Location]) VALUES (20, N'Cape Town Station', N'Cape Town, South Africa')
SET IDENTITY_INSERT [dbo].[Station] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (1, 1, 14, N'A1', CAST(N'2024-03-06T08:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (2, 2, 15, N'B2', CAST(N'2024-03-06T10:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (3, 3, 16, N'C3', CAST(N'2024-03-06T13:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (4, 4, 17, N'D4', CAST(N'2024-03-06T15:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (5, 5, 18, N'E5', CAST(N'2024-03-06T17:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (6, 6, 19, N'F6', CAST(N'2024-03-06T19:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (7, 7, 20, N'G7', CAST(N'2024-03-06T22:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (8, 8, 21, N'H8', CAST(N'2024-03-07T01:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (9, 9, 22, N'I9', CAST(N'2024-03-07T04:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (10, 10, 23, N'J10', CAST(N'2024-03-07T07:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (11, 11, 14, N'A1', CAST(N'2024-03-07T10:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (12, 12, 15, N'B2', CAST(N'2024-03-07T13:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (13, 13, 16, N'C3', CAST(N'2024-03-07T16:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (14, 14, 17, N'D4', CAST(N'2024-03-07T18:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (15, 15, 18, N'E5', CAST(N'2024-03-07T20:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (16, 16, 19, N'F6', CAST(N'2024-03-07T22:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (17, 17, 20, N'G7', CAST(N'2024-03-08T01:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (18, 18, 21, N'H8', CAST(N'2024-03-08T04:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (19, 19, 22, N'I9', CAST(N'2024-03-08T07:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (20, 20, 23, N'J10', CAST(N'2024-03-08T10:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (21, 1, 14, N'A1', CAST(N'2024-03-08T08:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (22, 2, 15, N'B2', CAST(N'2024-03-08T10:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (23, 3, 16, N'C3', CAST(N'2024-03-08T13:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (24, 4, 17, N'D4', CAST(N'2024-03-08T15:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (25, 5, 18, N'E5', CAST(N'2024-03-08T17:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (26, 6, 19, N'F6', CAST(N'2024-03-08T19:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (27, 7, 20, N'G7', CAST(N'2024-03-08T22:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (28, 8, 21, N'H8', CAST(N'2024-03-09T01:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (29, 9, 22, N'I9', CAST(N'2024-03-09T04:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (30, 10, 23, N'J10', CAST(N'2024-03-09T07:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (31, 11, 14, N'A1', CAST(N'2024-03-09T10:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (32, 12, 15, N'B2', CAST(N'2024-03-09T13:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (33, 13, 16, N'C3', CAST(N'2024-03-09T16:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (34, 14, 17, N'D4', CAST(N'2024-03-09T18:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (35, 15, 18, N'E5', CAST(N'2024-03-09T20:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (36, 16, 19, N'F6', CAST(N'2024-03-09T22:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (37, 17, 20, N'G7', CAST(N'2024-03-10T01:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (38, 18, 21, N'H8', CAST(N'2024-03-10T04:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (39, 19, 22, N'I9', CAST(N'2024-03-10T07:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (40, 20, 23, N'J10', CAST(N'2024-03-10T10:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (41, 1, 24, N'A1', CAST(N'2024-03-10T08:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (42, 2, 25, N'B2', CAST(N'2024-03-10T10:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (43, 3, 26, N'C3', CAST(N'2024-03-10T13:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (44, 4, 27, N'D4', CAST(N'2024-03-10T15:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (45, 5, 28, N'E5', CAST(N'2024-03-10T17:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (46, 6, 29, N'F6', CAST(N'2024-03-10T19:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (47, 7, 30, N'G7', CAST(N'2024-03-10T22:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (48, 8, 31, N'H8', CAST(N'2024-03-11T01:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (49, 9, 32, N'I9', CAST(N'2024-03-11T04:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (50, 10, 33, N'J10', CAST(N'2024-03-11T07:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (51, 11, 34, N'A1', CAST(N'2024-03-11T10:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (52, 12, 35, N'B2', CAST(N'2024-03-11T13:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (53, 13, 36, N'C3', CAST(N'2024-03-11T16:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (54, 14, 37, N'D4', CAST(N'2024-03-11T18:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (55, 15, 38, N'E5', CAST(N'2024-03-11T20:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (56, 16, 39, N'F6', CAST(N'2024-03-11T22:45:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (57, 17, 40, N'G7', CAST(N'2024-03-12T01:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (58, 18, 41, N'H8', CAST(N'2024-03-12T04:15:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (59, 19, 42, N'I9', CAST(N'2024-03-12T07:30:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketID], [PassengerID], [ScheduleID], [SeatNumber], [BookingTime]) VALUES (60, 20, 43, N'J10', CAST(N'2024-03-12T10:45:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[Train] ON 

INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (11, N'Express One', 200, N'Express')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (12, N'Local Shuttle', 150, N'Local')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (13, N'Rapid Transit', 180, N'Express')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (14, N'City Connect', 160, N'Express')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (15, N'Metro Cruiser', 120, N'Local')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (16, N'Highland Explorer', 180, N'Express')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (17, N'Suburban Sprinter', 140, N'Local')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (18, N'Coastal Express', 200, N'Express')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (19, N'Regional Runner', 160, N'Local')
INSERT [dbo].[Train] ([TrainID], [TrainName], [Capacity], [Type]) VALUES (20, N'Mountain Mover', 180, N'Express')
SET IDENTITY_INSERT [dbo].[Train] OFF
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([ArrivalStationID])
REFERENCES [dbo].[Station] ([StationID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([DepartureStationID])
REFERENCES [dbo].[Station] ([StationID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([PassengerID])
REFERENCES [dbo].[Passenger] ([PassengerID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
USE [master]
GO
ALTER DATABASE [EsemkaRailways] SET  READ_WRITE 
GO
