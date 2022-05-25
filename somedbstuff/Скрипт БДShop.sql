
/****** Object:  Table [dbo].[Заказ]    Script Date: 18.01.2022 9:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказ](
	[Код заказа] [int] NOT NULL,
	[Дата заказа] [date] NULL,
	[Дата исполнения] [date] NULL,
	[Название заказа] [nchar](50) NULL,
	[Оплата] [int] NULL,
	[Код клиента] [int] NULL,
 CONSTRAINT [PK_Заказ] PRIMARY KEY CLUSTERED 
(
	[Код заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Каталог заказов]    Script Date: 18.01.2022 9:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Каталог заказов](
	[Код заказа] [nchar](10) NULL,
	[Дата заказа] [nchar](10) NULL,
	[Дата исполнения] [nchar](10) NULL,
	[Поставщик] [nchar](10) NULL,
	[Фамилия] [nchar](10) NULL,
	[Наименование] [nchar](10) NULL,
	[Банк] [nchar](10) NULL,
	[Номер счета] [nchar](10) NULL,
	[Цена] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Клиенты]    Script Date: 18.01.2022 9:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Клиенты](
	[Код клиента] [int] NOT NULL,
	[Фамилия] [nchar](50) NOT NULL,
	[Имя] [nchar](50) NOT NULL,
	[Отчество] [nchar](50) NULL,
	[Адрес] [nchar](50) NULL,
	[Телефон] [nchar](50) NULL,
 CONSTRAINT [PK_Клиенты] PRIMARY KEY CLUSTERED 
(
	[Код клиента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Поставщик]    Script Date: 18.01.2022 9:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Поставщик](
	[Код поставщика] [int] NOT NULL,
	[Наименование] [nchar](50) NOT NULL,
	[ИНН] [int] NULL,
	[Адрес] [nchar](50) NULL,
	[Телефон] [nchar](50) NULL,
	[Руководитель] [nchar](50) NULL,
 CONSTRAINT [PK_Поставщик] PRIMARY KEY CLUSTERED 
(
	[Код поставщика] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Тип оплаты]    Script Date: 18.01.2022 9:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Тип оплаты](
	[Код оплаты] [int] NOT NULL,
	[Название банка] [nchar](50) NOT NULL,
	[Номер счета] [int] NOT NULL,
	[Код клиента] [int] NULL,
	[Сумма] [int] NULL,
 CONSTRAINT [PK_Тип оплаты] PRIMARY KEY CLUSTERED 
(
	[Код оплаты] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товар]    Script Date: 18.01.2022 9:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товар](
	[Код товара] [int] NOT NULL,
	[Название] [nchar](50) NOT NULL,
	[Цена] [int] NOT NULL,
	[Количество] [int] NOT NULL,
	[Код поставщика] [int] NOT NULL,
	[Код заказа] [int] NULL,
 CONSTRAINT [PK_Товар] PRIMARY KEY CLUSTERED 
(
	[Код товара] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (1254, N'Shabby                                            ', 987123456, N'город Красногорск, пер. Чехова, 92                ', N'89518177338                                       ', N'Иванов В.В.                                       ')
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (2364, N'Fringe                                            ', 1234509876, N'город Шаховская, ул. Гоголя, 62                   ', N'89127835285                                       ', N'Павлечко У.К.                                     ')
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (3672, N'Mango                                             ', 1234567890, N'город Орехово-Зуево, пер. Бухарестская, 50        ', N'89123018458                                       ', N'Гапонова В.А                                      ')
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (8265, N'Jewel                                             ', 1234567890, N'город Чехов, ул. Гоголя, 24                       ', N'89518199116                                       ', N'Нурманова С.А.                                    ')
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (8357, N'Lime                                              ', 987654321, N'город Видное, спуск Бухарестская, 75              ', N'89516375981                                       ', N'Захарова А.А.                                     ')
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (8467, N'Aesthetic                                         ', 192837465, N'город Кашира, проезд Космонавтов, 99              ', N'89515388227                                       ', N'Марченко И.В.                                     ')
INSERT [dbo].[Поставщик] ([Код поставщика], [Наименование], [ИНН], [Адрес], [Телефон], [Руководитель]) VALUES (9264, N'Laid-Back                                         ', 1209348756, N' город Щёлково, ул. Домодедовская, 22             ', N'89517299441                                       ', N'Диденко В.К.                                      ')
GO
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (1, N'Футболка Makroni черная                           ', 499, 10, 3672, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (2, N'Джинсы Belly голубые                              ', 1699, 20, 8265, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (3, N'Носки Nike белые                                  ', 100, 30, 8357, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (4, N'Шорты Mida фиолетовые                             ', 500, 6, 8467, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (5, N'Футболка Makroni Синяя                            ', 500, 2, 3672, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (6, N'Футболка Makroni белая                            ', 500, 1, 3672, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (7, N'Носки Nike зеленые                                ', 100, 4, 8357, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (8, N'Джинсы belly черные                               ', 1499, 6, 8265, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (9, N'Джинсы Belly синие                                ', 1499, 2, 8265, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (10, N'Джинсы Belly серые                                ', 1499, 0, 8265, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (11, N'Лонгслив Furly черный                             ', 2349, 3, 1254, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (12, N'Лонгслив Furly белый                              ', 2349, 2, 2364, NULL)
INSERT [dbo].[Товар] ([Код товара], [Название], [Цена], [Количество], [Код поставщика], [Код заказа]) VALUES (13, N'Лонгслив Furly голубой                            ', 2349, 1, 1254, NULL)
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Клиенты] FOREIGN KEY([Код клиента])
REFERENCES [dbo].[Клиенты] ([Код клиента])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Клиенты]
GO
ALTER TABLE [dbo].[Тип оплаты]  WITH CHECK ADD  CONSTRAINT [FK_Тип оплаты_Клиенты] FOREIGN KEY([Код клиента])
REFERENCES [dbo].[Клиенты] ([Код клиента])
GO
ALTER TABLE [dbo].[Тип оплаты] CHECK CONSTRAINT [FK_Тип оплаты_Клиенты]
GO
ALTER TABLE [dbo].[Товар]  WITH CHECK ADD  CONSTRAINT [FK_Товар_Заказ] FOREIGN KEY([Код заказа])
REFERENCES [dbo].[Заказ] ([Код заказа])
GO
ALTER TABLE [dbo].[Товар] CHECK CONSTRAINT [FK_Товар_Заказ]
GO
ALTER TABLE [dbo].[Товар]  WITH CHECK ADD  CONSTRAINT [FK_Товар_Поставщик] FOREIGN KEY([Код поставщика])
REFERENCES [dbo].[Поставщик] ([Код поставщика])
GO
ALTER TABLE [dbo].[Товар] CHECK CONSTRAINT [FK_Товар_Поставщик]
GO
USE [master]
GO
ALTER DATABASE [Курсовая] SET  READ_WRITE 
GO
