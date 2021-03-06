USE [MicroServices]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/27/2020 8:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/27/2020 8:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [uniqueidentifier] NOT NULL,
	[LocationName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/27/2020 8:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[StatusId] [uniqueidentifier] NULL,
	[LocationId] [uniqueidentifier] NULL,
	[OrderNumber] [nvarchar](50) NULL,
	[Amount] [money] NULL,
	[Tax] [money] NULL,
	[ShipTo] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 11/27/2020 8:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](25) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName]) VALUES (N'aa44d18a-cc6c-4e85-8cd8-8ef0878b1db9', N'Atul', N'Jain')
GO
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName]) VALUES (N'3824b3db-7801-4b18-82e2-f8ae0cec6e09', N'Rahul', N'Pushpkar')
GO
INSERT [dbo].[Location] ([Id], [LocationName], [IsActive]) VALUES (N'373d0811-9b0e-45df-9969-5d4114be8551', N'Indore', 1)
GO
INSERT [dbo].[Location] ([Id], [LocationName], [IsActive]) VALUES (N'd0a078e9-b2ec-4206-b99e-ac262351d8f6', N'Pune', 1)
GO
INSERT [dbo].[Location] ([Id], [LocationName], [IsActive]) VALUES (N'b2d30d93-5475-49c3-baa1-cb0a119acddb', N'Bhopal', 1)
GO
INSERT [dbo].[Order] ([Id], [CustomerId], [StatusId], [LocationId], [OrderNumber], [Amount], [Tax], [ShipTo], [Address], [Address2]) VALUES (N'58115174-7364-492a-9539-0a332d22f571', N'3824b3db-7801-4b18-82e2-f8ae0cec6e09', N'6b6d3b4e-1e01-4a9b-9acd-c7ba6b6741d9', N'373d0811-9b0e-45df-9969-5d4114be8551', N'11568', 600.0000, 18.0000, N'Devas', N'Devas 123', N'Devas MP Nagar')
GO
INSERT [dbo].[Order] ([Id], [CustomerId], [StatusId], [LocationId], [OrderNumber], [Amount], [Tax], [ShipTo], [Address], [Address2]) VALUES (N'7a3ec6e4-8d36-42cc-b2a7-147972c6b3de', N'3824b3db-7801-4b18-82e2-f8ae0cec6e09', N'6b6d3b4e-1e01-4a9b-9acd-c7ba6b6741d9', N'373d0811-9b0e-45df-9969-5d4114be8551', N'11567', 500.0000, 14.0000, N'Indore', N'Indore india', N'Nipania Indore')
GO
INSERT [dbo].[Order] ([Id], [CustomerId], [StatusId], [LocationId], [OrderNumber], [Amount], [Tax], [ShipTo], [Address], [Address2]) VALUES (N'ebe97538-21bd-4512-8ae6-9c78a718b178', N'3824b3db-7801-4b18-82e2-f8ae0cec6e09', N'6b6d3b4e-1e01-4a9b-9acd-c7ba6b6741d9', N'373d0811-9b0e-45df-9969-5d4114be8551', N'11568', 580.0000, 15.0000, N'Bhopal', N'Bhopal 123', N'Bhopal MP Nagar')
GO
INSERT [dbo].[Status] ([Id], [Status], [IsActive]) VALUES (N'a9958450-9130-4403-81eb-8ee5108db44d', N'Shipped', 1)
GO
INSERT [dbo].[Status] ([Id], [Status], [IsActive]) VALUES (N'4af3f9d4-ba40-4cfb-8e0a-bf7363d69ce0', N'Completed', 1)
GO
INSERT [dbo].[Status] ([Id], [Status], [IsActive]) VALUES (N'6b6d3b4e-1e01-4a9b-9acd-c7ba6b6741d9', N'Ordered', 1)
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Location]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
