USE [master]
GO
/****** Object:  Database [ShopDB]    Script Date: 14.06.2022 0:20:56 ******/
CREATE DATABASE [ShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopDB] SET QUERY_STORE = OFF
GO
USE [ShopDB]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Клиенты] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Importance]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Importance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[PhotoPath] [nvarchar](50) NULL,
 CONSTRAINT [PK_Importance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](50) NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
	[ImportanceId] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[RecieveDate] [date] NULL,
	[ClientId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Заказ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentType](
	[BankAccountNumber] [int] NOT NULL,
	[BankName] [nchar](50) NOT NULL,
	[ClientId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_Тип оплаты] PRIMARY KEY CLUSTERED 
(
	[BankAccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[CountInStock] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_Товар] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[INN] [int] NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[DirectorName] [nvarchar](50) NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Поставщик] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.06.2022 0:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Surname], [Name], [Patronymic], [Address], [Phone]) VALUES (1, N'Иванов', N'Иван', N'Иванович', N'Ул. Пушкина', N'88005553535')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Importance] ON 

INSERT [dbo].[Importance] ([Id], [Title], [PhotoPath]) VALUES (1, N'Срочно', N'\Resources\red.png')
INSERT [dbo].[Importance] ([Id], [Title], [PhotoPath]) VALUES (2, N'Важно', N'\Resources\yellow.png')
INSERT [dbo].[Importance] ([Id], [Title], [PhotoPath]) VALUES (3, N'Значимо', N'\Resources\blue.png')
INSERT [dbo].[Importance] ([Id], [Title], [PhotoPath]) VALUES (4, N'Неважно', N'\Resources\green.png')
SET IDENTITY_INSERT [dbo].[Importance] OFF
GO
SET IDENTITY_INSERT [dbo].[Note] ON 

INSERT [dbo].[Note] ([Id], [Header], [Text], [ImportanceId]) VALUES (1, N'заметочка', N'Дом милый дом. Как жаль что ты сейчас горишь и я ничего не могу с этим поделать и лишь жалуюсь об этом сюда как дурачок)', 2)
INSERT [dbo].[Note] ([Id], [Header], [Text], [ImportanceId]) VALUES (2, N'Срочная', N'Сделать это задание', 1)
INSERT [dbo].[Note] ([Id], [Header], [Text], [ImportanceId]) VALUES (3, N'Не очень срочная', N'Помыть посуду', 3)
INSERT [dbo].[Note] ([Id], [Header], [Text], [ImportanceId]) VALUES (4, N'Вообще не нужная', N'Учеба', 4)
SET IDENTITY_INSERT [dbo].[Note] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [OrderDate], [RecieveDate], [ClientId], [ProductId], [Quantity]) VALUES (1, CAST(N'2022-06-04' AS Date), CAST(N'2022-06-04' AS Date), 1, 1, 1)
INSERT [dbo].[Order] ([Id], [OrderDate], [RecieveDate], [ClientId], [ProductId], [Quantity]) VALUES (2, CAST(N'2022-06-04' AS Date), CAST(N'2022-06-04' AS Date), 1, 2, 1)
INSERT [dbo].[Order] ([Id], [OrderDate], [RecieveDate], [ClientId], [ProductId], [Quantity]) VALUES (4, CAST(N'2022-06-05' AS Date), CAST(N'2022-06-12' AS Date), 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (0, N'Boy', 777, 2, 8467)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (1, N'Футболка Makroni черная', 499, 10, 3672)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (2, N'Джинсы Belly голубые', 1699, 20, 8265)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (3, N'Носки Nike белые', 100, 30, 8357)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (4, N'Шорты Mida фиолетовые', 500, 6, 8467)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (5, N'Футболка Makroni Синяя', 500, 2, 3672)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (6, N'Футболка Makroni белая', 500, 1, 3672)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (7, N'Носки Nike зеленые', 100, 4, 8357)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (8, N'Джинсы belly черные', 1499, 6, 8265)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (9, N'Джинсы Belly синие', 1499, 2, 8265)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (10, N'Джинсы Belly серые', 1499, 0, 8265)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (11, N'Лонгслив Furly черный', 2349, 3, 1254)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (12, N'Лонгслив Furly белый', 2349, 2, 2364)
INSERT [dbo].[Product] ([Id], [Title], [Price], [CountInStock], [SupplierId]) VALUES (13, N'Лонгслив Furly голубой', 2349, 1, 1254)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'User')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (1254, N'Shabby                                            ', 987123456, N'город Красногорск, пер. Чехова, 92                ', N'89518177338                                       ', N'Иванов В.В.                                       ', NULL)
INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (2364, N'Fringe                                            ', 1234509876, N'город Шаховская, ул. Гоголя, 62                   ', N'89127835285                                       ', N'Павлечко У.К.                                     ', NULL)
INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (3672, N'Mango                                             ', 1234567890, N'город Орехово-Зуево, пер. Бухарестская, 50        ', N'89123018458                                       ', N'Гапонова В.А                                      ', NULL)
INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (8265, N'Jewel                                             ', 1234567890, N'город Чехов, ул. Гоголя, 24                       ', N'89518199116                                       ', N'Нурманова С.А.                                    ', NULL)
INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (8357, N'Lime                                              ', 987654321, N'город Видное, спуск Бухарестская, 75              ', N'89516375981                                       ', N'Захарова А.А.                                     ', NULL)
INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (8467, N'Aesthetic                                         ', 192837465, N'город Кашира, проезд Космонавтов, 99              ', N'89515388227                                       ', N'Марченко И.В.                                     ', NULL)
INSERT [dbo].[Supplier] ([Id], [Name], [INN], [Address], [Phone], [DirectorName], [Photo]) VALUES (9264, N'Laid-Back                                         ', 1209348756, N' город Щёлково, ул. Домодедовская, 22             ', N'89517299441                                       ', N'Диденко В.К.                                      ', NULL)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
INSERT [dbo].[User] ([Login], [Password], [RoleId]) VALUES (N'11111', N'11111', 2)
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Importance] FOREIGN KEY([ImportanceId])
REFERENCES [dbo].[Importance] ([Id])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Importance]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Клиенты] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Заказ_Клиенты]
GO
ALTER TABLE [dbo].[PaymentType]  WITH CHECK ADD  CONSTRAINT [FK_PaymentType_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[PaymentType] CHECK CONSTRAINT [FK_PaymentType_Order]
GO
ALTER TABLE [dbo].[PaymentType]  WITH CHECK ADD  CONSTRAINT [FK_Тип оплаты_Клиенты] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[PaymentType] CHECK CONSTRAINT [FK_Тип оплаты_Клиенты]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Товар_Поставщик] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Товар_Поставщик]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [ShopDB] SET  READ_WRITE 
GO
