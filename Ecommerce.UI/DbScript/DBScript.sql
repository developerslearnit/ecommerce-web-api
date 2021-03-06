
CREATE DATABASE [E-CommerceDB]
 
GO
USE [E-CommerceDB]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CartID] [nvarchar](300) NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](700) NOT NULL,
	[CategotyName] [nvarchar](300) NOT NULL,
	[Datecreated] [datetime] NOT NULL CONSTRAINT [DF_Category_Datecreated]  DEFAULT (getdate()),
	[slug] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consumer]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consumer](
	[ConsumerId] [int] IDENTITY(1,1) NOT NULL,
	[ConsumerName] [nvarchar](550) NOT NULL,
	[ConsumerKey] [nvarchar](500) NOT NULL,
	[IsLocked] [bit] NOT NULL CONSTRAINT [DF_Consumer_IsLocked]  DEFAULT ((0)),
 CONSTRAINT [PK_Consumer] PRIMARY KEY CLUSTERED 
(
	[ConsumerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](70) NOT NULL,
	[Password] [nvarchar](3000) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](450) NULL,
	[Mobile] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAddress](
	[AddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[AddressLine1] [nvarchar](500) NULL,
	[Landmark] [nvarchar](150) NULL,
	[AddressLine2] [nvarchar](150) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](100) NULL,
 CONSTRAINT [PK_CustomerAddress] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Datecreated] [datetime] NULL CONSTRAINT [DF_Product_Datecreated]  DEFAULT (getdate()),
	[ShortDescription] [nvarchar](1000) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[OldPrice] [decimal](18, 2) NOT NULL,
	[QuantityInStock] [bigint] NOT NULL,
	[ShowOnPromoPage] [bit] NOT NULL CONSTRAINT [DF_Product_ShowOnPromoPage]  DEFAULT ((0)),
	[ProductSlug] [nvarchar](1500) NOT NULL,
	[ProductRating] [float] NOT NULL CONSTRAINT [DF_Product_ProductRating]  DEFAULT ((0)),
	[ReviewCount] [int] NOT NULL CONSTRAINT [DF_Product_ReviewCount]  DEFAULT ((0)),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductAttribute]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttribute](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Color] [nvarchar](30) NULL,
	[Image] [image] NULL,
	[Sized] [nvarchar](30) NULL,
 CONSTRAINT [PK_ProductAttribute] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](700) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductReview]    Script Date: 2/22/2018 4:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReview](
	[ReviewId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[Rating] [float] NOT NULL,
	[Comment] [nvarchar](1000) NOT NULL,
	[DateCreated] [datetime] NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_ProductReview] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (1, N'Electronics', N'Electronics', CAST(N'2018-02-05 11:10:39.480' AS DateTime), N'electronics')
GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (2, N'Computers', N'Computers', CAST(N'2018-02-13 11:24:48.583' AS DateTime), N'computers')
GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (3, N'Jewelry', N'Jewelry', CAST(N'2018-02-13 11:25:29.693' AS DateTime), N'jewelry')
GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (4, N'Apparel', N'Apparel', CAST(N'2018-02-13 11:26:28.887' AS DateTime), N'apparel')
GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (5, N'Phones and Tablets', N'Phones and Tablets', CAST(N'2018-02-13 11:27:35.890' AS DateTime), N'phones-and-tablets')
GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (6, N'Watches & Sunglasses', N'Watches & Sunglasses', CAST(N'2018-02-13 11:28:51.347' AS DateTime), N'watches-and-sunglasses')
GO
INSERT [dbo].[Category] ([CatID], [Description], [CategotyName], [Datecreated], [slug]) VALUES (7, N'Games and Consoles', N'Games and Consoles', CAST(N'2018-02-13 11:51:07.110' AS DateTime), N'games-and-consoles')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Consumer] ON 

GO
INSERT [dbo].[Consumer] ([ConsumerId], [ConsumerName], [ConsumerKey], [IsLocked]) VALUES (1, N'Akintunde Toba', N'e-key_9c8d2bb6-2673-4a98-a7df-b661083816c263654122', 0)
GO
SET IDENTITY_INSERT [dbo].[Consumer] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([CustomerId], [Email], [Password], [FirstName], [LastName], [Mobile], [DateCreated]) VALUES (1, N'toba.akin@gmail.com', N'123456', N'Toba', N'Akin', N'08060257733', NULL)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

GO
INSERT [dbo].[Product] ([ProductID], [CategoryId], [Name], [Description], [Datecreated], [ShortDescription], [Price], [OldPrice], [QuantityInStock], [ShowOnPromoPage], [ProductSlug], [ProductRating], [ReviewCount]) VALUES (1, 1, N'Djack 3.1 X-Bass Bluetooth Home Theatre System DJ-403', N'Fill your space with as much volume as you require to get you stepping to the music or to have your family fully tuned in to the entertainment on TV or for for a high-level gaming session.This Djack Home Theatre is made for optimum performance with less concessions than is usually found giving your home or office limitless possibilities', NULL, N'Fill your space with as much volume as you require to get you stepping to the music or to have your family fully tuned in to the entertainment on TV or for for a high-level gaming session', CAST(15500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 5, 1, N'djack-31-x-bass-bluetooth-home-theatre-system-dj-403', 3.5, 1)
GO
INSERT [dbo].[Product] ([ProductID], [CategoryId], [Name], [Description], [Datecreated], [ShortDescription], [Price], [OldPrice], [QuantityInStock], [ShowOnPromoPage], [ProductSlug], [ProductRating], [ReviewCount]) VALUES (2, 1, N'HTC One M8 Android L 5.0 Lollipop', N'HTC One (M8) Cell Phone for Sprint: With its brushed-metal design and wrap-around unibody frame, the HTC One (M8) is designed to fit beautifully', NULL, N'HTC One (M8) Cell Phone for Sprint: With its brushed-metal design and wrap-around unibody frame', CAST(64500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 5, 1, N'htc-one-m8-android-l-50-lollipop', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImage] ON 

GO
INSERT [dbo].[ProductImage] ([ImageId], [ImagePath], [ProductId]) VALUES (3, N'http://localhost:41797/Content/Uploads/2018/February/14/ac0b2f3f-7ba2-4e48-8e24-382702f13d87.jpg', 1)
GO
INSERT [dbo].[ProductImage] ([ImageId], [ImagePath], [ProductId]) VALUES (4, N'http://localhost:41797/Content/Uploads/2018/February/14/8198d1f8-a89d-4cd6-b879-1f8da01c5f2f.PNG', 1)
GO
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductReview] ON 

GO
INSERT [dbo].[ProductReview] ([ReviewId], [CustomerId], [Rating], [Comment], [DateCreated], [ProductId]) VALUES (1, 1, 3.5, N'Reviewed by Toba', CAST(N'2018-02-20 10:49:36.110' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[ProductReview] OFF
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddress_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Customer]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CatID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttribute_ProductAttribute] FOREIGN KEY([ID])
REFERENCES [dbo].[ProductAttribute] ([ID])
GO
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK_ProductAttribute_ProductAttribute]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_Customer]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_Product]
GO
USE [master]
GO
ALTER DATABASE [E-CommerceDB] SET  READ_WRITE 
GO
