USE [TinTuc]
GO
/****** Object:  Table [dbo].[TheLoaiTin]    Script Date: 17/06/2021 6:40:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoaiTin](
	[IDLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](100) NULL,
 CONSTRAINT [PK_TheLoaiTin] PRIMARY KEY CLUSTERED 
(
	[IDLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 17/06/2021 6:40:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[IdTin] [int] IDENTITY(1,1) NOT NULL,
	[IDLoai] [int] NOT NULL,
	[TieuDeTin] [nvarchar](100) NULL,
	[NoiDungTin] [ntext] NULL,
 CONSTRAINT [PK_TinTuc] PRIMARY KEY CLUSTERED 
(
	[IdTin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TheLoaiTin] ON 

INSERT [dbo].[TheLoaiTin] ([IDLoai], [TenTheLoai]) VALUES (2, N'Kinh Tế')
INSERT [dbo].[TheLoaiTin] ([IDLoai], [TenTheLoai]) VALUES (3, N'Thế Giới')
INSERT [dbo].[TheLoaiTin] ([IDLoai], [TenTheLoai]) VALUES (12, N'Văn hóa nghệ thuật')
INSERT [dbo].[TheLoaiTin] ([IDLoai], [TenTheLoai]) VALUES (18, N'Bóng Bàn')
INSERT [dbo].[TheLoaiTin] ([IDLoai], [TenTheLoai]) VALUES (19, N'Bóng rỗ')
SET IDENTITY_INSERT [dbo].[TheLoaiTin] OFF
GO
SET IDENTITY_INSERT [dbo].[TinTuc] ON 

INSERT [dbo].[TinTuc] ([IdTin], [IDLoai], [TieuDeTin], [NoiDungTin]) VALUES (2, 12, N'Kinh Tế', N'Khủng Hoảng Kinh Tế')
INSERT [dbo].[TinTuc] ([IdTin], [IDLoai], [TieuDeTin], [NoiDungTin]) VALUES (3, 2, N'Thế giới', N'Bi la đen song')
SET IDENTITY_INSERT [dbo].[TinTuc] OFF
GO
ALTER TABLE [dbo].[TinTuc]  WITH CHECK ADD  CONSTRAINT [FK_TinTuc_TheLoaiTin] FOREIGN KEY([IDLoai])
REFERENCES [dbo].[TheLoaiTin] ([IDLoai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TinTuc] CHECK CONSTRAINT [FK_TinTuc_TheLoaiTin]
GO
