USE [master]
GO
/****** Object:  Database [Ministop]    Script Date: 10/13/2020 5:27:44 PM ******/
CREATE DATABASE [Ministop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ministop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Ministop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ministop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Ministop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ministop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ministop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ministop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ministop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ministop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ministop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ministop] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ministop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ministop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ministop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ministop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ministop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ministop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ministop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ministop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ministop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ministop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ministop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ministop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ministop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ministop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ministop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ministop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ministop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ministop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ministop] SET  MULTI_USER 
GO
ALTER DATABASE [Ministop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ministop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ministop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ministop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ministop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ministop] SET QUERY_STORE = OFF
GO
USE [Ministop]
GO
/****** Object:  Table [dbo].[ChiTietDatHang]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDatHang](
	[SanPhamID] [int] NOT NULL,
	[DonDatHangID] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[GiaTien] [money] NULL,
 CONSTRAINT [PK_ChiTietDatHang] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC,
	[DonDatHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[SanPhamID] [int] NOT NULL,
	[HoaDonID] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [money] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC,
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[PhieuNhapID] [int] NOT NULL,
	[SanPhamID] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[GiaTien] [money] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[PhieuNhapID] ASC,
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[NhanVienID] [int] NOT NULL,
	[PhanQuyenID] [int] NOT NULL,
	[TaiKhoan] [varchar](20) NULL,
	[MatKhau] [varchar](32) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[NhanVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonDatHang]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatHang](
	[ID] [int] NOT NULL,
	[KhachHangID] [int] NULL,
	[NhanVienID] [int] NULL,
	[NgayDat] [date] NULL,
	[TongTien] [money] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_DonDatHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienID] [int] NULL,
	[KhachHangID] [int] NULL,
	[ThueVAT] [int] NULL,
	[NgayMua] [date] NULL,
	[TongTien] [money] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [date] NULL,
	[SoCMND] [varchar](20) NULL,
	[SoDT] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Facebook] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TinhTrang] [bit] NULL,
	[NgayThamGia] [date] NULL,
	[NgayCapNhat] [date] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[SanPhamID] [int] IDENTITY(1,1) NOT NULL,
	[GiamGia] [float] NULL,
	[GiaMoi] [money] NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SoDT] [varchar](20) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[CongTy] [nvarchar](50) NULL,
	[MaSoThue] [nvarchar](50) NULL,
	[NgayThamGia] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [date] NULL,
	[SoCMND] [varchar](20) NULL,
	[SoDT] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](20) NULL,
	[MucLuong] [money] NULL,
	[NgayThamGia] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuyenHan] [varchar](10) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienID] [int] NULL,
	[NhaCungCapID] [int] NULL,
	[NgayDat] [date] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiSanPhamID] [int] NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[ThuongHieu] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[GiaNhap] [money] NULL,
	[GiaBan] [money] NULL,
	[SoLuong] [int] NULL,
	[NgayThem] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thue]    Script Date: 10/13/2020 5:27:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thue](
	[VAT] [int] NOT NULL,
 CONSTRAINT [PK_Thue] PRIMARY KEY CLUSTERED 
(
	[VAT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietPhieuNhap] ([PhieuNhapID], [SanPhamID], [SoLuong], [GiaTien]) VALUES (1, 2, 3, 44444.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([PhieuNhapID], [SanPhamID], [SoLuong], [GiaTien]) VALUES (1, 3, 2, 444444.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([PhieuNhapID], [SanPhamID], [SoLuong], [GiaTien]) VALUES (2, 2, 0, 0.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([PhieuNhapID], [SanPhamID], [SoLuong], [GiaTien]) VALUES (2, 3, 0, 0.0000)
GO
INSERT [dbo].[DangNhap] ([NhanVienID], [PhanQuyenID], [TaiKhoan], [MatKhau], [TinhTrang]) VALUES (1, 1, N'admin', N'c4ca4238a0b923820dcc509a6f75849b', 1)
INSERT [dbo].[DangNhap] ([NhanVienID], [PhanQuyenID], [TaiKhoan], [MatKhau], [TinhTrang]) VALUES (2, 2, N'user', N'c81e728d9d4c2f636f067f89cc14862c', 1)
INSERT [dbo].[DangNhap] ([NhanVienID], [PhanQuyenID], [TaiKhoan], [MatKhau], [TinhTrang]) VALUES (19, 2, N'1', N'c4ca4238a0b923820dcc509a6f75849b', 1)
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [TenKH], [GioiTinh], [NgaySinh], [SoCMND], [SoDT], [Email], [DiaChi], [Facebook], [GhiChu], [TinhTrang], [NgayThamGia], [NgayCapNhat]) VALUES (1, N'Vũ Quốc Huy', N'Nam', CAST(N'1999-03-17' AS Date), N'036099008132        ', N'0828365961', N'vuquochuyz99@gmail.com', N'Dĩ An', N'Huy VQ', N'1', 1, NULL, CAST(N'2020-10-13' AS Date))
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai]) VALUES (1, N'Thực phẩm ăn liền')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([ID], [TenNCC], [SoDT], [DiaChi], [Email], [CongTy], [MaSoThue], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (1, N'Test-1', N'0828365961', N'Di An', N'vuquochuyz99@gmail.com', N'Huy', N'082123A', NULL, NULL, NULL, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNCC], [SoDT], [DiaChi], [Email], [CongTy], [MaSoThue], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (2, N'TEst01', N'08282365903         ', N'dĩ a1', N'vh12a@gmail.com', N'21399', N'2131299', CAST(N'2020-09-29' AS Date), CAST(N'2020-09-29' AS Date), N'asdfasdf99', 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNCC], [SoDT], [DiaChi], [Email], [CongTy], [MaSoThue], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (8, N'TEst01', N'08282365961         ', NULL, NULL, NULL, NULL, CAST(N'2020-09-29' AS Date), CAST(N'2020-10-11' AS Date), NULL, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNCC], [SoDT], [DiaChi], [Email], [CongTy], [MaSoThue], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (9, N'test1', N'0828365912', N'000', N'vuquochuyz299@gmail.com', N'000', N'082123', CAST(N'2020-10-11' AS Date), CAST(N'2020-10-11' AS Date), N'000', 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNCC], [SoDT], [DiaChi], [Email], [CongTy], [MaSoThue], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (13, N'asd', N'0828365911', NULL, N'123', N'123', N'123', CAST(N'2020-10-12' AS Date), NULL, NULL, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNCC], [SoDT], [DiaChi], [Email], [CongTy], [MaSoThue], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (20, N'1', N'1', N'1', N'1@gmail.com', N'1', N'1', CAST(N'2020-10-13' AS Date), CAST(N'2020-10-13' AS Date), N'1', 1)
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [GioiTinh], [NgaySinh], [SoCMND], [SoDT], [Email], [HinhAnh], [DiaChi], [ChucVu], [MucLuong], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (1, N'VuQuocHuy', N'Nam', CAST(N'1999-03-17' AS Date), N'036099008132', N'036099008132', N'huyvq22@fpt.com.vn', N'VuQuocHuy.jpg', N'Nam Định', N'Quan ly', NULL, CAST(N'2020-09-29' AS Date), CAST(N'2020-10-13' AS Date), NULL, 1)
INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [GioiTinh], [NgaySinh], [SoCMND], [SoDT], [Email], [HinhAnh], [DiaChi], [ChucVu], [MucLuong], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (2, N'Vũ Quốc Huy', N'Nam', CAST(N'1999-03-17' AS Date), N'444', N'444', N'vha@gmail.com', N'Vũ Quốc Huy2.jpg', N'dĩ an', N'12312', 3123123.0000, CAST(N'2020-09-29' AS Date), CAST(N'2020-10-13' AS Date), N'3123123', 1)
INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [GioiTinh], [NgaySinh], [SoCMND], [SoDT], [Email], [HinhAnh], [DiaChi], [ChucVu], [MucLuong], [NgayThamGia], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (19, N'2', N'Nu', CAST(N'1999-03-17' AS Date), N'2', N'2', N'2@gmail.com', N'test123.jpg', N'2', N'1', 1.0000, CAST(N'2020-10-13' AS Date), CAST(N'2020-10-13' AS Date), N'1', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([ID], [QuyenHan]) VALUES (1, N'admin     ')
INSERT [dbo].[PhanQuyen] ([ID], [QuyenHan]) VALUES (2, N'user      ')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([ID], [NhanVienID], [NhaCungCapID], [NgayDat], [TongTien]) VALUES (1, 1, 1, CAST(N'2020-10-07' AS Date), 100000.0000)
INSERT [dbo].[PhieuNhap] ([ID], [NhanVienID], [NhaCungCapID], [NgayDat], [TongTien]) VALUES (2, 1, 2, CAST(N'2020-10-12' AS Date), 500000.0000)
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([ID], [LoaiSanPhamID], [TenSanPham], [ThuongHieu], [HinhAnh], [GiaNhap], [GiaBan], [SoLuong], [NgayThem], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (2, 1, N'Mì hảo hảo', N'2', N'haha.png', 2.0000, 20000.0000, 2, NULL, CAST(N'2020-10-05' AS Date), N'2', 1)
INSERT [dbo].[SanPham] ([ID], [LoaiSanPhamID], [TenSanPham], [ThuongHieu], [HinhAnh], [GiaNhap], [GiaBan], [SoLuong], [NgayThem], [NgayCapNhat], [GhiChu], [TinhTrang]) VALUES (3, 1, N'2', N'2', N'11.jpg', 2.0000, 2.0000, 2, NULL, CAST(N'2020-10-13' AS Date), N'2', 1)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_KhachHang_Email]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UQ_KhachHang_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_KhachHang_SoCMND]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UQ_KhachHang_SoCMND] UNIQUE NONCLUSTERED 
(
	[SoCMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_KhachHang_SoDT]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UQ_KhachHang_SoDT] UNIQUE NONCLUSTERED 
(
	[SoDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhaCungCap_Email]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [UQ_NhaCungCap_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhaCungCap_MaThue]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [UQ_NhaCungCap_MaThue] UNIQUE NONCLUSTERED 
(
	[MaSoThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhaCungCap_SoDT]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [UQ_NhaCungCap_SoDT] UNIQUE NONCLUSTERED 
(
	[SoDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhanVien_Email]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [UQ_NhanVien_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhanVien_SoCMND]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [UQ_NhanVien_SoCMND] UNIQUE NONCLUSTERED 
(
	[SoCMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NhanVien_SoDT]    Script Date: 10/13/2020 5:27:45 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [UQ_NhanVien_SoDT] UNIQUE NONCLUSTERED 
(
	[SoDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDatHang_DonDatHang] FOREIGN KEY([DonDatHangID])
REFERENCES [dbo].[DonDatHang] ([ID])
GO
ALTER TABLE [dbo].[ChiTietDatHang] CHECK CONSTRAINT [FK_ChiTietDatHang_DonDatHang]
GO
ALTER TABLE [dbo].[ChiTietDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDatHang_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[ChiTietDatHang] CHECK CONSTRAINT [FK_ChiTietDatHang_SanPham]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([PhieuNhapID])
REFERENCES [dbo].[PhieuNhap] ([ID])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD  CONSTRAINT [FK_DangNhap_NhanVien] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DangNhap] CHECK CONSTRAINT [FK_DangNhap_NhanVien]
GO
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD  CONSTRAINT [FK_DangNhap_PhanQuyen] FOREIGN KEY([PhanQuyenID])
REFERENCES [dbo].[PhanQuyen] ([ID])
GO
ALTER TABLE [dbo].[DangNhap] CHECK CONSTRAINT [FK_DangNhap_PhanQuyen]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_KhachHang] FOREIGN KEY([KhachHangID])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_KhachHang]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_NhanVien] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_NhanVien]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([KhachHangID])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[KhuyenMai]  WITH CHECK ADD  CONSTRAINT [FK_KhuyenMai_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[KhuyenMai] CHECK CONSTRAINT [FK_KhuyenMai_SanPham]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([NhaCungCapID])
REFERENCES [dbo].[NhaCungCap] ([ID])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([LoaiSanPhamID])
REFERENCES [dbo].[LoaiSanPham] ([ID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhat_KhachHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapNhat_KhachHang]
	-- Add the parameters for the stored procedure here
	@id int, @tenKH nvarchar(50), @gioiTinh nvarchar(5), @ngaySinh date, @soCMND varchar(20), @soDT varchar(20),
	@email nvarchar(50), @diaChi nvarchar(100), @facebook nvarchar(50), @ghiChu nvarchar(max), @ngayCapNhat date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	
UPDATE [dbo].[KhachHang]
   SET [TenKH] = @tenKH
      ,[GioiTinh] = @gioiTinh
      ,[NgaySinh] = @ngaySinh
      ,[SoCMND] = @soCMND
      ,[SoDT] = @soDT
      ,[Email] = @email
      ,[DiaChi] = @diaChi
      ,[Facebook] = @facebook
      ,[GhiChu] = @ghiChu
      ,[NgayCapNhat] = @ngayCapNhat
 WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhat_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapNhat_NhaCungCap]
	-- Add the parameters for the stored procedure here
	@id int, @tenNCC nvarchar(50), @soDT varchar(20), @diaChi nvarchar(100), @email nvarchar(50), @congTy nvarchar(50),
	@maSoThue nvarchar(50), @ngayCapNhat date, @ghiChu nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE [dbo].[NhaCungCap]
   SET [TenNCC] = @tenNCC
      ,[SoDT] = @soDT
      ,[DiaChi] = @diaChi
      ,[Email] = @email
      ,[CongTy] = @congTy
      ,[MaSoThue] = @maSoThue
      ,[NgayCapNhat] = @ngayCapNhat
      ,[GhiChu] = @ghiChu
 WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhat_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapNhat_NhanVien] 
	-- Add the parameters for the stored procedure here
	@id int, @tenNV nvarchar(50), @gioiTinh nvarchar(5), @ngaySinh date,
	@soCMND varchar(20), @soDT varchar(20), @ngayCapNhat date,
	@email nvarchar(50), @hinhAnh nvarchar(50), @diaChi nvarchar(100),
	@chucVu nvarchar(20), @mucLuong money, @ghiChu nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE [dbo].[NhanVien]
   SET [TenNhanVien] = @tenNV
      ,[GioiTinh] = @gioiTinh  
      ,[NgaySinh] = @ngaySinh
      ,[SoCMND] = @soCMND
      ,[SoDT] = @soDT
      ,[Email] = @email
	  ,[HinhAnh] = @hinhAnh
      ,[DiaChi] = @diaChi
      ,[ChucVu] = @chucVu
      ,[MucLuong] = @mucLuong
      ,[NgayCapNhat] = @ngayCapNhat
      ,[GhiChu] = @ghiChu
	  WHERE ID =  @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhat_SanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapNhat_SanPham] 
	-- Add the parameters for the stored procedure here
	@loaiSanPhamID int, @tenSanPham nvarchar(50), @thuongHieu nvarchar(50), @hinhAnh nvarchar(50), @giaBan money, @giaNhap money,
	@soLuong int, @ngayCapNhat date, @ghiChu nvarchar(MAX), @id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE [dbo].[SanPham]
   SET [LoaiSanPhamID] = @loaiSanPhamID
      ,[TenSanPham] = @tenSanPham
      ,[ThuongHieu] = @thuongHieu
	  ,[HinhAnh] = @hinhAnh
      ,[GiaNhap] = @giaNhap
      ,[GiaBan] = @giaBan
      ,[SoLuong] = @soLuong
      ,[NgayCapNhat] = @ngayCapNhat
      ,[GhiChu] = @ghiChu
 WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhat_ThongTin]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapNhat_ThongTin]
	-- Add the parameters for the stored procedure here
	@id int, @tenNV nvarchar(50), @gioiTinh nvarchar(5), @ngaySinh date,
	@soCMND varchar(20), @soDT varchar(20), @ngayCapNhat date,
	@email nvarchar(50), @diaChi nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE [dbo].[NhanVien]
   SET [TenNhanVien] = @tenNV
      ,[GioiTinh] = @gioiTinh  
      ,[NgaySinh] = @ngaySinh
      ,[SoCMND] = @soCMND
      ,[SoDT] = @soDT
      ,[Email] = @email
      ,[DiaChi] = @diaChi     
      ,[NgayCapNhat] = @ngayCapNhat
	  WHERE ID =  @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhSo_Thang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DoanhSo_Thang]
	-- Add the parameters for the stored procedure here
	@ngay int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	select  sum(TongTien)
from PhieuNhap
where  DAY(NgayDat) = @ngay
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DoiMatKhau_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DoiMatKhau_NhanVien]
	-- Add the parameters for the stored procedure here
	@Id int, @matKhau varchar(32), @matKhauMoi varchar(32)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE [dbo].[DangNhap]
   SET [MatKhau] = @matKhauMoi
 WHERE NhanVienID = @Id AND MatKhau = @matKhau
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_DonDatHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_DonDatHang]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From DonDatHang
	ORDER BY ID DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_HoaDon]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_HoaDon]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From HoaDon
	ORDER BY ID DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_KhachHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_KhachHang]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From KhachHang
	ORDER BY ID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_LoaiSanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_LoaiSanPham]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From LoaiSanPham
	ORDER BY TenLoai DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_NhaCungCap]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From NhaCungCap
	ORDER BY ID DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_NhanVien]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Select * 
	From NhanVien
	ORDER BY ID DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_PhieuNhap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_PhieuNhap]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT  p.ID, p.NgayDat, n.TenNCC, p.TongTien, v.TenNhanVien, s.TenSanPham, c.SoLuong, c.GiaTien
	From PhieuNhap p, ChiTietPhieuNhap c, NhaCungCap n, SanPham s, NhanVien v
	Where p.NhaCungCapID = n.ID AND p.ID = c.PhieuNhapID AND s.ID = c.SanPhamID AND v.ID = p.NhanVienID
	ORDER BY p.ID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAll_SanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAll_SanPham]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From SanPham
	ORDER BY ID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetById_KhachHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetById_KhachHang]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM KhachHang
	Where ID = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetById_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetById_NhaCungCap]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From NhaCungCap
	Where ID = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetByID_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetByID_NhanVien]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From NhanVien a, DangNhap b
	Where ID = @Id AND a.ID = b.NhanVienID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetById_SanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetById_SanPham]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From SanPham
	Where ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KichHoat_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_KichHoat_NhaCungCap] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE [dbo].[NhaCungCap]
   SET [TinhTrang] = 1
	  WHERE ID =  @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KichHoat_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_KichHoat_NhanVien]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[NhanVien]
   SET [TinhTrang] = 1
	  WHERE ID =  @id
	  UPDATE [dbo].[DangNhap]
   SET [TinhTrang] = 1
	  WHERE NhanVienID =  @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Login]
	-- Add the parameters for the stored procedure here
	@taikhoan varchar(20),
	@matkhau varchar(32)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT b.ID, b.TenNhanVien, b.ChucVu, b.HinhAnh, a.PhanQuyenID
	From DangNhap a, NhanVien b
	Where a.NhanVienID = b.ID AND TaiKhoan = @taikhoan AND MatKhau = @matkhau AND a.TinhTrang = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Search_KhachHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Search_KhachHang]
	-- Add the parameters for the stored procedure here
	@soDT varchar(20) = null,
	@tenKH nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From KhachHang
	Where SoDT = @soDt OR TenKH = @tenKH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Search_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Search_NhaCungCap]
	-- Add the parameters for the stored procedure here
	@tenNCC nvarchar(50) = null,
	@email nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From NhaCungCap
	Where TenNCC = @tenNCC OR Email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Search_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Search_NhanVien]
	-- Add the parameters for the stored procedure here
	@tenNV nvarchar(50),
	@soDT varchar(20),
	@chucVu nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From NhanVien
	Where TenNhanVien = @tenNV OR SoDT = @soDT OR ChucVu = @chucVu
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Search_SanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Search_SanPham]
	-- Add the parameters for the stored procedure here
	@tenSanPham nvarchar(50) = null,
	@thuongHieu nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	From SanPham 
	Where  TenSanPham = @tenSanPham OR ThuongHieu = @thuongHieu
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemMoi_KhachHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThemMoi_KhachHang]
	-- Add the parameters for the stored procedure here
	@tenKH nvarchar(50), @gioiTinh nvarchar(5), @ngaySinh date, @soCMND varchar(20), @soDT varchar(20),
	@email nvarchar(50), @diaChi nvarchar(100), @facebook nvarchar(50), @ghiChu nvarchar(max), @ngayThamGia date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[KhachHang]
           ([TenKH]
           ,[GioiTinh]
           ,[NgaySinh]
           ,[SoCMND]
           ,[SoDT]
           ,[Email]
           ,[DiaChi]
           ,[Facebook]
           ,[GhiChu]
           ,[TinhTrang]
           ,[NgayThamGia])
     VALUES
           (
			  @tenKH, @gioiTinh, @ngaySinh, @soCMND, @soDT, @email, @diaChi, @facebook, @ghiChu, 1, @ngayThamGia
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemMoi_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThemMoi_NhaCungCap] 
	-- Add the parameters for the stored procedure here
	@tenNCC nvarchar(50), @soDT varchar(20), @diaChi nvarchar(100), @email nvarchar(50), @congTy nvarchar(50),
	@maSoThue nvarchar(50), @ngayThamGia date, @ghiChu nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
INSERT INTO [dbo].[NhaCungCap]
           ([TenNCC]
           ,[SoDT]
           ,[DiaChi]
           ,[Email]
           ,[CongTy]
           ,[MaSoThue]
           ,[NgayThamGia]
           ,[GhiChu]
           ,[TinhTrang])
     VALUES
          (@tenNCC, @soDT, @diaChi, @email, @congTy, @maSoThue, @ngayThamGia, @ghiChu, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemMoi_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThemMoi_NhanVien]
	-- Add the parameters for the stored procedure here
	@tenNV nvarchar(50), @gioiTinh nvarchar(5), @ngaySinh date,
	@soCMND varchar(20), @soDT varchar(20), @ngayThamGia date,
	@email nvarchar(50), @hinhAnh nvarchar(50), @diaChi nvarchar(100),
	@chucVu nvarchar(20), @mucLuong money, @ghiChu nvarchar(max), @matKhau varchar(32)
AS
BEGIN
	declare @nhanvienID int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[NhanVien]
           ([TenNhanVien]
           ,[GioiTinh]
           ,[NgaySinh]
           ,[SoCMND]
           ,[SoDT]
           ,[Email]
           ,[HinhAnh]
           ,[DiaChi]
           ,[ChucVu]
           ,[MucLuong]
           ,[NgayThamGia]
           ,[GhiChu]
           ,[TinhTrang])
     VALUES
			(@tenNV, @gioiTinh, @ngaySinh, @soCMND, @soDT, @email, @hinhAnh, @diaChi, @chucVu, @mucLuong, @ngayThamGia, @ghiChu, 1)
	select @nhanvienID = scope_identity();

	INSERT INTO [dbo].[DangNhap]
           ([NhanVienID]
           ,[PhanQuyenID]
           ,[TaiKhoan]
           ,[MatKhau]
           ,[TinhTrang])
     VALUES
           (@nhanvienID
           ,2
           ,@soDT
           ,@matKhau
           ,1)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemMoi_SanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThemMoi_SanPham]
	-- Add the parameters for the stored procedure here
	@loaiSanPhamID int, @tenSanPham nvarchar(50), @thuongHieu nvarchar(50), @hinhAnh nvarchar(50), @giaBan money, @giaNhap money,
	@soLuong int, @ngayThem date, @ghiChu nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[SanPham]
           ([LoaiSanPhamID]
           ,[TenSanPham]
           ,[ThuongHieu]
           ,[HinhAnh]
           ,[GiaNhap]
           ,[GiaBan]
           ,[SoLuong]
           ,[NgayThem]
           ,[GhiChu]
           ,[TinhTrang])
     VALUES
           (@loaiSanPhamID, @tenSanPham, @thuongHieu, @hinhAnh, @giaNhap, @giaBan, @soLuong, @ngayThem, @ghiChu, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Xoa_KhachHang]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Xoa_KhachHang]
	-- Add the parameters for the stored procedure here
	@Id int, @ngayCapNhat date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[KhachHang]
   SET [TinhTrang] = 0	  
	  ,[NgayCapNhat] = @ngayCapNhat
 WHERE ID = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Xoa_NhaCungCap]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Xoa_NhaCungCap]
	-- Add the parameters for the stored procedure here
	@Id int, @ngayCapNhat date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[NhaCungCap]
   SET [NgayCapNhat] = @ngayCapNhat
      ,[TinhTrang] = 0
 WHERE ID = @Id 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Xoa_NhanVien]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Xoa_NhanVien]
	-- Add the parameters for the stored procedure here
	@Id int, @ngayCapNhat date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[NhanVien]
   SET [NgayCapNhat] = @ngayCapNhat
      ,[TinhTrang] = 0

	  WHERE ID =  @Id
UPDATE [dbo].[DangNhap]
   SET [TinhTrang] =0
 WHERE NhanVienID = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Xoa_SanPham]    Script Date: 10/13/2020 5:27:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Xoa_SanPham]
	-- Add the parameters for the stored procedure here
	@Id int, @ngayCapNhat date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[SanPham]
   SET [TinhTrang] = 0
	,[NgayCapNhat] = @ngayCapNhat
 WHERE ID = @Id
END
GO
USE [master]
GO
ALTER DATABASE [Ministop] SET  READ_WRITE 
GO
