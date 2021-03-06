USE [ReCapProjectDb]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (1, N'BMW')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (2, N'Audi')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (3, N'Alfa Romeo')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (4, N'Aston Martin')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (5, N'Bentley')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (6, N'Bugatti')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (7, N'Buick')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (8, N'Cadillac')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (9, N'Ford')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (10, N'Volvo')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (11, N'Mercedes')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

GO
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (1, 1, 1, N'520i Executive M Sport', 2012, 600.0000, NULL)
GO
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (2, 10, 5, N'Volvo s80', 2019, 800.0000, NULL)
GO
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (3, 2, 2, N'A5', 2020, 1000.0000, NULL)
GO
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (4, 3, 5, N'Giulietta 1.6 JTD Distinctive', 2020, 600.0000, N'Hatchback 5 kapı')
GO
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (1, N'Siyah')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (2, N'Kırmızı')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (3, N'Mavi')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (4, N'Turuncu')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (5, N'Turkuaz')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (6, N'Sarı')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (7, N'Mor')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (8, N'Yeşil')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (9, N'Pembe')
GO
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
