USE [ECommerceDB] --Önceden oluşturduğunuz database'e tabloları eklemek için bunu kullanın. 
--Direk database ile oluşturmak istiyorsanız aşağıdaki yorum satırını kaldırın ve buradaki Database ismini 'master' olarak değiştirin
GO

--İsterseniz yorum satırını kaldırıp istediğiniz klösere direk oluşturabilirsiniz
--CREATE DATABASE [ECommerceDB]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'ECommerceDB', FILENAME = N'/var/opt/mssql/data/ECommerceDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'ECommerceDB_log', FILENAME = N'/var/opt/mssql/data/ECommerceDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO
ALTER DATABASE [ECommerceDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECommerceDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECommerceDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECommerceDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECommerceDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECommerceDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECommerceDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECommerceDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECommerceDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECommerceDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECommerceDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECommerceDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECommerceDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECommerceDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECommerceDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECommerceDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECommerceDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECommerceDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECommerceDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ECommerceDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECommerceDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ECommerceDB] SET  MULTI_USER 
GO
ALTER DATABASE [ECommerceDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECommerceDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ECommerceDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ECommerceDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ECommerceDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ECommerceDB', N'ON'
GO
ALTER DATABASE [ECommerceDB] SET QUERY_STORE = OFF
GO
USE [ECommerceDB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 04/16/2019 8:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Stock] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ImageUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwOrderDetail]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[VwOrderDetail]
AS
SELECT 
		od.*,
		p.Name AS ProductName,
		(od.Quantity * od.UnitPrice) AS TotalPrice
		FROM OrderDetail od
		INNER JOIN Product p ON p.Id = od.ProductId

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwProductCategories]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VwProductCategories]
AS
SELECT 
		*
		,(SELECT CAST(CategoryId AS NVARCHAR(36)) + ',' FROM ProductCategory pc WHERE pc.ProductId = p.Id  FOR XML PATH('')) AS ProductCategories
		FROM Product p	
GO
/****** Object:  Table [dbo].[Category]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ImageUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwCategoryProducts]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VwCategoryProducts]
AS
SELECT 
		*
		,(SELECT c.* FROM ProductCategory pc INNER JOIN Product p ON pc.ProductId = p.Id WHERE pc.CategoryId = c.Id  FOR JSON AUTO) AS CategoryProducts
		FROM Category c
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 04/16/2019 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Status] [bit] NOT NULL,
	[BillingAddress] [nvarchar](500) NULL,
	[ShippingAddress] [nvarchar](500) NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductBasket]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductBasket](
	[ProductId] [uniqueidentifier] NOT NULL,
	[BasketId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductBasket] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[BasketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwProductBasket]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[VwProductBasket]
AS
SELECT 
		 pb.*
		,b.CustomerId
		,b.Status
		,p.Name
		,p.Price
		,(p.Price * pb.Quantity) AS TotalPrice 
		FROM ProductBasket pb
		INNER JOIN Basket b ON b.Id = pb.BasketId
		INNER JOIN Product p ON p.Id = pb.ProductId
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[OrderCode] [nvarchar](50) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[BillingAddress] [nvarchar](500) NULL,
	[ShippingAddress] [nvarchar](500) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwOrder]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VwOrder]
AS
SELECT 
		o.* 
		,c.Name AS CustomerName
		,c.Surname AS CustomerSurname
		FROM [Order] o
		INNER JOIN Customer c ON o.CustomerId = c.Id
GO
/****** Object:  Table [dbo].[Address]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[City] [nvarchar](50) NOT NULL,
	[Town] [nvarchar](50) NOT NULL,
	[District] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[PhoneNumbers] [nvarchar](50) NOT NULL,
	[IsCustomBillingAddress] [bit] NOT NULL,
	[IsCustomShippingAddress] [bit] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 04/16/2019 8:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Address] ([Id], [CustomerId], [Description], [City], [Town], [District], [Street], [PhoneNumbers], [IsCustomBillingAddress], [IsCustomShippingAddress]) VALUES (N'301622d7-54db-4258-ea3b-08d6c2519606', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', N'Kütükhane kafe üstü', N'Adana', N'Çukurova', N'Beyazevler mahallesi', N'80007 sokak', N'434534453343', 0, 0)
INSERT [dbo].[Address] ([Id], [CustomerId], [Description], [City], [Town], [District], [Street], [PhoneNumbers], [IsCustomBillingAddress], [IsCustomShippingAddress]) VALUES (N'aa47f366-aec7-44c2-483f-08d6c255d91a', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', N'Cegiz apartman kat 2 daire 5', N'İzmir', N'Karşıyaka', N'Bahçelievler', N'10700 sokak ', N'213241212313', 1, 1)
INSERT [dbo].[Admin] ([ID], [UserName], [Password]) VALUES (N'da804917-04b9-4b8d-a724-c953f01d6c2e', N'aiken', N'1')
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'ecb777fb-18ea-499e-5c0c-08d6c24927c2', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', CAST(N'2019-04-16T12:05:53.753' AS DateTime), CAST(190.00 AS Decimal(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'56b2ee9c-5d92-4790-e9f5-08d6c25edfad', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', CAST(N'2019-04-16T14:30:05.490' AS DateTime), CAST(299.00 AS Decimal(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'21577315-7ca8-443f-9e23-08d6c26e02f0', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', CAST(N'2019-04-16T16:18:27.100' AS DateTime), CAST(932.00 AS Decimal(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'7f139e45-c746-454d-fba9-08d6c2752179', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', CAST(N'2019-04-16T17:12:02.623' AS DateTime), CAST(275.00 AS Decimal(18, 2)), 0, NULL, NULL)
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'69bb00c3-9156-4d95-8551-08d6c2774e6a', N'9a0909f9-822b-41ec-d876-08d6c275ad71', CAST(N'2019-04-16T17:26:21.680' AS DateTime), CAST(213.00 AS Decimal(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'f9829d96-1107-4a02-8552-08d6c2774e6a', N'9a0909f9-822b-41ec-d876-08d6c275ad71', CAST(N'2019-04-16T17:26:39.707' AS DateTime), CAST(77.00 AS Decimal(18, 2)), 1, NULL, NULL)
INSERT [dbo].[Basket] ([Id], [CustomerId], [Date], [Total], [Status], [BillingAddress], [ShippingAddress]) VALUES (N'9c5b1169-6cc6-44b5-1d06-08d6c28aae73', N'9a0909f9-822b-41ec-d876-08d6c275ad71', CAST(N'2019-04-16T16:43:40.683' AS DateTime), CAST(35.00 AS Decimal(18, 2)), 0, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [ImageUrl]) VALUES (N'2ef37654-3b6f-48dd-3270-08d6bab279f0', N'test', N'category', N'')
INSERT [dbo].[Category] ([Id], [Name], [Description], [ImageUrl]) VALUES (N'943b1bb0-b3da-415e-3271-08d6bab279f0', N'Teknoloji 21', N'Teknolojik Ürünler', N'')
INSERT [dbo].[Category] ([Id], [Name], [Description], [ImageUrl]) VALUES (N'867ac273-075a-4f3c-c059-08d6bb54ca65', N'Category 3', N'Description 3', N'')
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [Email], [Phone], [Password]) VALUES (N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', N'asd', N'asd', N'aiken@asd', N'123123123122', N'1')
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [Email], [Phone], [Password]) VALUES (N'9a0909f9-822b-41ec-d876-08d6c275ad71', N'Alp Eren', N'Güngör', N'proysis@prs.com', N'453422323562', N'1')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderCode], [TotalPrice], [Date], [BillingAddress], [ShippingAddress]) VALUES (N'2bccc85f-205a-465a-b437-08d6c25ec15d', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', N'ZYETTSHBWI', CAST(190.00 AS Decimal(18, 2)), CAST(N'2019-04-16T14:29:14.600' AS DateTime), N'10700 sokak  Bahçelievler Karşıyaka/İzmir

Note: Cegiz apartman kat 2 daire 5', N'10700 sokak  Bahçelievler Karşıyaka/İzmir

Note: Cegiz apartman kat 2 daire 5')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderCode], [TotalPrice], [Date], [BillingAddress], [ShippingAddress]) VALUES (N'06d32031-f18d-41d5-e9c5-08d6c26c2954', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', N'XAHGSTGOKM', CAST(299.00 AS Decimal(18, 2)), CAST(N'2019-04-16T16:05:12.487' AS DateTime), N'10700 sokak  Bahçelievler Karşıyaka/İzmir

Note: Cegiz apartman kat 2 daire 5', N'10700 sokak  Bahçelievler Karşıyaka/İzmir

Note: Cegiz apartman kat 2 daire 5')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderCode], [TotalPrice], [Date], [BillingAddress], [ShippingAddress]) VALUES (N'f9296017-e0b0-4d3f-8c34-08d6c2736be5', N'9756dfe2-e40f-4140-fefe-08d6bd2aa62e', N'SEWMVSXZXV', CAST(932.00 AS Decimal(18, 2)), CAST(N'2019-04-16T16:57:10.660' AS DateTime), N'10700 sokak  Bahçelievler Karşıyaka/İzmir

Note: Cegiz apartman kat 2 daire 5', N'10700 sokak  Bahçelievler Karşıyaka/İzmir

Note: Cegiz apartman kat 2 daire 5')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderCode], [TotalPrice], [Date], [BillingAddress], [ShippingAddress]) VALUES (N'b691f620-ba8a-4f12-f035-08d6c27785ef', N'9a0909f9-822b-41ec-d876-08d6c275ad71', N'XWSAQVTBEA', CAST(213.00 AS Decimal(18, 2)), CAST(N'2019-04-16T17:26:32.343' AS DateTime), N'You have no billing address', N'You have no shipping address')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderCode], [TotalPrice], [Date], [BillingAddress], [ShippingAddress]) VALUES (N'4611509e-3a11-43ee-5103-08d6c27d0afc', N'9a0909f9-822b-41ec-d876-08d6c275ad71', N'HULRDBMHEK', CAST(77.00 AS Decimal(18, 2)), CAST(N'2019-04-16T15:06:03.040' AS DateTime), N'You have no billing address', N'You have no shipping address')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'e4a18334-96b7-47d7-28f0-08d6c25ec19d', N'2bccc85f-205a-465a-b437-08d6c25ec15d', N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', 2, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'a5d47a02-0d87-41d7-28f1-08d6c25ec19d', N'2bccc85f-205a-465a-b437-08d6c25ec15d', N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', 1, CAST(78.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'769cef60-b370-4772-da42-08d6c26c2979', N'06d32031-f18d-41d5-e9c5-08d6c26c2954', N'10300813-c4f3-4785-ca15-08d6bae5ff5c', 1, CAST(42.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'4b6b3cba-cbf8-41cc-da43-08d6c26c2979', N'06d32031-f18d-41d5-e9c5-08d6c26c2954', N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', 1, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'44b3a47a-85d0-48c2-da44-08d6c26c2979', N'06d32031-f18d-41d5-e9c5-08d6c26c2954', N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', 3, CAST(78.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'6903dc56-f97e-43ef-282a-08d6c2736c1b', N'f9296017-e0b0-4d3f-8c34-08d6c2736be5', N'10300813-c4f3-4785-ca15-08d6bae5ff5c', 1, CAST(42.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'9edab42a-9c3c-4717-282b-08d6c2736c1b', N'f9296017-e0b0-4d3f-8c34-08d6c2736be5', N'71319640-c92e-4273-1f03-08d6bb54a90e', 2, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'fa1aa53c-a90e-4f8a-282c-08d6c2736c1b', N'f9296017-e0b0-4d3f-8c34-08d6c2736be5', N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', 2, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'b733ed2c-be4c-4282-282d-08d6c2736c1b', N'f9296017-e0b0-4d3f-8c34-08d6c2736be5', N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', 2, CAST(78.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'8d0de62d-f4c7-4edc-282e-08d6c2736c1b', N'f9296017-e0b0-4d3f-8c34-08d6c2736be5', N'abd54151-177f-441e-1f06-08d6bb54a90e', 2, CAST(332.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'90e98392-01fc-4c40-27ed-08d6c277861f', N'b691f620-ba8a-4f12-f035-08d6c27785ef', N'10300813-c4f3-4785-ca15-08d6bae5ff5c', 1, CAST(42.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'0ee0c718-a427-4812-27ee-08d6c277861f', N'b691f620-ba8a-4f12-f035-08d6c27785ef', N'71319640-c92e-4273-1f03-08d6bb54a90e', 2, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'bab9b5ba-d1c0-46be-27ef-08d6c277861f', N'b691f620-ba8a-4f12-f035-08d6c27785ef', N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', 3, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'83035281-9eed-46e5-27f0-08d6c277861f', N'b691f620-ba8a-4f12-f035-08d6c27785ef', N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', 1, CAST(78.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'dccb2b32-2160-4574-912b-08d6c27d0b03', N'4611509e-3a11-43ee-5103-08d6c27d0afc', N'10300813-c4f3-4785-ca15-08d6bae5ff5c', 1, CAST(42.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'56d3a8f3-f0bd-4368-912c-08d6c27d0b03', N'4611509e-3a11-43ee-5103-08d6c27d0afc', N'71319640-c92e-4273-1f03-08d6bb54a90e', 1, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (N'7e502e25-3402-44e4-912d-08d6c27d0b03', N'4611509e-3a11-43ee-5103-08d6c27d0afc', N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', 1, CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Stock], [Price], [ImageUrl]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'Product 1', N'Product Description 1', 21, CAST(42.00 AS Decimal(18, 2)), N'')
INSERT [dbo].[Product] ([Id], [Name], [Description], [Stock], [Price], [ImageUrl]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'Product 2', N'Descirption 2', 32, CAST(12.00 AS Decimal(18, 2)), N'')
INSERT [dbo].[Product] ([Id], [Name], [Description], [Stock], [Price], [ImageUrl]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'Product 3', N'Descirption 3', 213, CAST(23.00 AS Decimal(18, 2)), N'')
INSERT [dbo].[Product] ([Id], [Name], [Description], [Stock], [Price], [ImageUrl]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'Product 4', N'Descirption 4', 45, CAST(78.00 AS Decimal(18, 2)), N'')
INSERT [dbo].[Product] ([Id], [Name], [Description], [Stock], [Price], [ImageUrl]) VALUES (N'abd54151-177f-441e-1f06-08d6bb54a90e', N'Product 5', N'Descirption 5', 346, CAST(332.00 AS Decimal(18, 2)), N'')
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'56b2ee9c-5d92-4790-e9f5-08d6c25edfad', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'21577315-7ca8-443f-9e23-08d6c26e02f0', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'7f139e45-c746-454d-fba9-08d6c2752179', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'69bb00c3-9156-4d95-8551-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'f9829d96-1107-4a02-8552-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'21577315-7ca8-443f-9e23-08d6c26e02f0', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'7f139e45-c746-454d-fba9-08d6c2752179', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'65e52c55-68fc-4abe-854f-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'69bb00c3-9156-4d95-8551-08d6c2774e6a', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'f9829d96-1107-4a02-8552-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'9c5b1169-6cc6-44b5-1d06-08d6c28aae73', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'ecb777fb-18ea-499e-5c0c-08d6c24927c2', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'56b2ee9c-5d92-4790-e9f5-08d6c25edfad', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'21577315-7ca8-443f-9e23-08d6c26e02f0', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'7f139e45-c746-454d-fba9-08d6c2752179', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'e0604336-8964-4337-8550-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'69bb00c3-9156-4d95-8551-08d6c2774e6a', 3)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'f9829d96-1107-4a02-8552-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'9c5b1169-6cc6-44b5-1d06-08d6c28aae73', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'ecb777fb-18ea-499e-5c0c-08d6c24927c2', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'56b2ee9c-5d92-4790-e9f5-08d6c25edfad', 3)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'21577315-7ca8-443f-9e23-08d6c26e02f0', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'7f139e45-c746-454d-fba9-08d6c2752179', 2)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'69bb00c3-9156-4d95-8551-08d6c2774e6a', 1)
INSERT [dbo].[ProductBasket] ([ProductId], [BasketId], [Quantity]) VALUES (N'abd54151-177f-441e-1f06-08d6bb54a90e', N'21577315-7ca8-443f-9e23-08d6c26e02f0', 2)
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'2ef37654-3b6f-48dd-3270-08d6bab279f0')
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'10300813-c4f3-4785-ca15-08d6bae5ff5c', N'943b1bb0-b3da-415e-3271-08d6bab279f0')
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'2ef37654-3b6f-48dd-3270-08d6bab279f0')
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'71319640-c92e-4273-1f03-08d6bb54a90e', N'943b1bb0-b3da-415e-3271-08d6bab279f0')
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'36cc77bc-48d3-4837-1f04-08d6bb54a90e', N'943b1bb0-b3da-415e-3271-08d6bab279f0')
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'95818f1d-8e2d-4338-1f05-08d6bb54a90e', N'2ef37654-3b6f-48dd-3270-08d6bab279f0')
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (N'abd54151-177f-441e-1f06-08d6bb54a90e', N'867ac273-075a-4f3c-c059-08d6bb54ca65')
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Address] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Address]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
USE [master]
GO
ALTER DATABASE [ECommerceDB] SET  READ_WRITE 
GO
