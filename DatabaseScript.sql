USE [master]
GO
/****** Object:  Database [QuanLyPhongMach]    Script Date: 6/24/2021 3:40:42 PM ******/
CREATE DATABASE [QuanLyPhongMach]
ALTER DATABASE [QuanLyPhongMach] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyPhongMach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyPhongMach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyPhongMach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyPhongMach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyPhongMach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyPhongMach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyPhongMach] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyPhongMach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyPhongMach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyPhongMach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyPhongMach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyPhongMach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyPhongMach] SET QUERY_STORE = OFF
GO
USE [QuanLyPhongMach]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaSoBN] [int] NOT NULL,
	[HoTen] [nvarchar](max) NOT NULL,
	[GioiTinh] [nvarchar](max) NOT NULL,
	[NamSinh] [int] NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[NgayKham] [datetime] NOT NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[MaSoBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CachDung]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CachDung](
	[MaCachDung] [int] NOT NULL,
	[CachSuDung] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CachDung] PRIMARY KEY CLUSTERED 
(
	[MaCachDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonThuoc]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonThuoc](
	[MaDT] [int] NOT NULL,
	[MaThuoc] [int] NOT NULL,
	[MaDonVi] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[MaCachDung] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonThuoc]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonThuoc](
	[MaDT] [int] NOT NULL,
	[MaPK] [int] NOT NULL,
 CONSTRAINT [PK_DonThuoc] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[MaDonVi] [int] NOT NULL,
	[TenDonVi] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DonVi] PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiBenh]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBenh](
	[MaBenh] [int] NOT NULL,
	[TenBenh] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiBenh] PRIMARY KEY CLUSTERED 
(
	[MaBenh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiThuoc]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThuoc](
	[MaThuoc] [int] NOT NULL,
	[TenThuoc] [nvarchar](max) NOT NULL,
	[MaDonVi] [int] NOT NULL,
	[Gia] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[SoLanSuDung] [int] NOT NULL,
 CONSTRAINT [PK_LoaiThuoc] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaSoNV] [int] NOT NULL,
	[HoTen] [nvarchar](max) NOT NULL,
	[SDT] [nvarchar](20) NULL,
	[NamSinh] [datetime] NOT NULL,
	[Account] [nchar](10) NOT NULL,
	[Password] [nchar](10) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaSoNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKham]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKham](
	[MaPK] [int] NOT NULL,
	[MaBN] [int] NOT NULL,
	[TrieuChung] [nvarchar](max) NOT NULL,
	[MaLoaiBenh] [int] NOT NULL,
	[TienKham] [int] NOT NULL,
	[TienThuoc] [int] NOT NULL,
	[Xoa] [bit] NULL,
 CONSTRAINT [PK_PhieuKham] PRIMARY KEY CLUSTERED 
(
	[MaPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuyDinh]    Script Date: 6/24/2021 3:40:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyDinh](
	[SoBenhNhanMotNgay] [int] NOT NULL,
	[SoTienKham] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (1, N'Bành Thị Nở', N'Nữ', 1975, N'Làng Vũ Đại', CAST(N'2021-05-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (2, N'Chí Phèo', N'Nam', 1973, N'Làng Vũ Đại', CAST(N'2021-05-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (3, N'Vladimir Vladimirovich Putin', N'Nam', 1952, N'Nga', CAST(N'2021-05-10T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (4, N'Đỗ Nam Trâm', N'Nam', 1946, N'Ờ Me Ri Cờ', CAST(N'2021-05-11T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (5, N'Đỗ Phan Minh Ngọc', N'Nam', 2004, N'Đờ Rét Rô Xa', CAST(N'2021-05-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (6, N'Vương Thúy Kiều', N'Nữ', 2018, N'Trung Quốc', CAST(N'2021-05-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (7, N'Vương Thúy Vân', N'Nữ', 2019, N'Trung Quốc', CAST(N'2021-05-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (8, N'Tôn Nga', N'Nữ', 1974, N'698, Ấp Cam Tú, Phường Bửu, Huyện 8 Bến Tre', CAST(N'2021-05-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (9, N'Sử Hiếu Sỹ', N'Nam', 1974, N'7817 Phố Hứa, Xã Phúc Từ, Quận 36 Đà Nẵng', CAST(N'2021-05-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (10, N'Trà Duyên', N'Nữ', 1998, N'74, Thôn Phong Châu, Thôn Mang Cẩn, Quận Nhân Định Phú Thọ', CAST(N'2021-05-27T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (11, N'Kim Băng Dung', N'Nữ', 1965, N'17 Phố Giáp Bổng Thảo, Phường Thuận, Quận Khải Trí Đắk Nông', CAST(N'2021-06-02T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (12, N'Chiêm Hiệp Kỳ', N'Nam', 1973, N'209 Phố Kim Linh Nghị, Xã Mỹ, Huyện Toản Hồ Chí Minh', CAST(N'2021-06-02T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (13, N'Giao Hân', N'Nam', 1997, N'7 Phố Nghĩa, Phường 05, Huyện Đan Ma Lào Cai', CAST(N'2021-06-02T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (14, N'Bồ Huy Độ', N'Nam', 1981, N'380 Phố Yên, Phường 9, Huyện 66 Cần Thơ', CAST(N'2021-06-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[BenhNhan] ([MaSoBN], [HoTen], [GioiTinh], [NamSinh], [DiaChi], [NgayKham], [Xoa]) VALUES (15, N'Thập Kỳ Toản', N'Nam', 1983, N'965 Phố Chử Đào Ly, Phường Yến Đinh, Quận Bạch Phương Bến Tre', CAST(N'2021-06-05T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[CachDung] ([MaCachDung], [CachSuDung]) VALUES (1, N'Uống trực tiếp')
INSERT [dbo].[CachDung] ([MaCachDung], [CachSuDung]) VALUES (2, N'Nhét hậu môn')
INSERT [dbo].[CachDung] ([MaCachDung], [CachSuDung]) VALUES (3, N'Truyền dịch')
INSERT [dbo].[CachDung] ([MaCachDung], [CachSuDung]) VALUES (4, N'Hít')
GO
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (1, 10, 2, 1, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (2, 13, 1, 10, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (3, 15, 1, 1, 2)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (4, 21, 2, 1, 4)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (5, 14, 1, 10, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (6, 11, 2, 1, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (7, 23, 2, 1, 4)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (8, 5, 1, 10, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (9, 23, 1, 1, 4)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (10, 30, 1, 2, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (11, 28, 1, 10, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (12, 20, 2, 1, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (13, 26, 2, 1, 1)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (14, 24, 1, 5, 4)
INSERT [dbo].[ChiTietDonThuoc] ([MaDT], [MaThuoc], [MaDonVi], [SoLuong], [MaCachDung]) VALUES (15, 8, 1, 6, 1)
GO
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (1, 1)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (2, 2)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (3, 3)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (4, 4)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (5, 5)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (6, 6)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (7, 7)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (8, 8)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (9, 9)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (10, 10)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (11, 11)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (12, 12)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (13, 13)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (14, 14)
INSERT [dbo].[DonThuoc] ([MaDT], [MaPK]) VALUES (15, 15)
GO
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (1, N'viên')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (2, N'chai')
GO
INSERT [dbo].[LoaiBenh] ([MaBenh], [TenBenh]) VALUES (1, N'Sốt')
INSERT [dbo].[LoaiBenh] ([MaBenh], [TenBenh]) VALUES (2, N'Cảm cúm')
INSERT [dbo].[LoaiBenh] ([MaBenh], [TenBenh]) VALUES (3, N'Tiêu chảy')
INSERT [dbo].[LoaiBenh] ([MaBenh], [TenBenh]) VALUES (4, N'Táo bón')
INSERT [dbo].[LoaiBenh] ([MaBenh], [TenBenh]) VALUES (5, N'Hen suyễn')
GO
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (1, N'Paracetamol', 1, 5000, 50, 5)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (2, N'Aspirin', 1, 4000, 60, 7)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (3, N'Ibuprofen', 1, 6000, 100, 10)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (4, N'Bổ phế nam hà chỉ thái lộ', 2, 30000, 30, 15)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (5, N'Tiffy', 1, 3000, 100, 30)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (6, N'Biragan 500', 1, 3000, 134, 14)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (7, N'E - cox 90', 1, 4000, 67, 3)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (8, N'Codein', 1, 3500, 51, 34)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (9, N'Ambroxol', 2, 45000, 42, 5)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (10, N'Berberin', 2, 43000, 32, 13)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (11, N'Diphenoxylate', 2, 56000, 23, 52)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (12, N'Codein', 2, 32100, 45, 21)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (13, N'Bisacodyl', 1, 4700, 54, 34)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (14, N'Normacol', 1, 5500, 21, 32)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (15, N'Efferalgan', 1, 15000, 142, 12)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (16, N'Doliprane', 1, 16000, 95, 12)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (17, N'Paracetamol - Kabi', 2, 89000, 32, 10)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (18, N'Paracetamol - BIVID', 2, 79000, 54, 4)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (19, N'Amvifeta', 2, 67000, 43, 12)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (20, N'MOMETA HEXAL', 2, 150000, 10, 43)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (21, N'Berodual', 2, 54000, 12, 3)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (22, N'Ventolin', 2, 65000, 32, 6)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (23, N'Symbicort', 2, 34000, 12, 4)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (24, N'Broncho-vaxom', 1, 5600, 98, 12)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (25, N'PQA Sinh huyền môn', 1, 10000, 43, 12)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (26, N'Nhuận tràng BT', 2, 750000, 40, 0)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (27, N'Naphazolin', 2, 32100, 187, 43)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (28, N'Pseudoephedrine', 1, 2100, 123, 233)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (29, N'Ephedrine', 2, 143000, 231, 31)
INSERT [dbo].[LoaiThuoc] ([MaThuoc], [TenThuoc], [MaDonVi], [Gia], [SoLuong], [SoLanSuDung]) VALUES (30, N'Decolgen', 1, 15000, 43, 3)
GO
INSERT [dbo].[NhanVien] ([MaSoNV], [HoTen], [SDT], [NamSinh], [Account], [Password]) VALUES (1, N'Nguyễn Đình Khôi', N'123123123', CAST(N'2000-06-27T00:00:00.000' AS DateTime), N'khoi      ', N'1234      ')
INSERT [dbo].[NhanVien] ([MaSoNV], [HoTen], [SDT], [NamSinh], [Account], [Password]) VALUES (2, N'Nguyễn Thanh Duy', N'234234234', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'duy       ', N'6789      ')
INSERT [dbo].[NhanVien] ([MaSoNV], [HoTen], [SDT], [NamSinh], [Account], [Password]) VALUES (3, N'Phạm Tấn', N'123345763', CAST(N'2000-12-31T00:00:00.000' AS DateTime), N'tan       ', N'0000      ')
GO
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (1, 1, N'Đau bụng', 3, 30000, 43000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (2, 2, N'Đau bụng, ko đi ngoài được', 4, 30000, 47000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (3, 3, N'Sốt ho, sổ mũi', 1, 30000, 15000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (4, 4, N'Khó thở', 5, 30000, 54000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (5, 5, N'Khó đi ngoài', 4, 30000, 55000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (6, 6, N'Tào táo dí cả sáng', 3, 30000, 56000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (7, 7, N'Ho nhiều vào buổi sáng', 5, 30000, 34000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (8, 8, N'Sốt trên 39 độ', 1, 30000, 30000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (9, 9, N'Thở khò khè, nặng ngực', 5, 30000, 34000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (10, 10, N'Ho và hắt xì, chảy nước mũi', 2, 30000, 30000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (11, 11, N'Chảy nước mũi, hát xì thường xuyên', 2, 30000, 21000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (12, 12, N'Sốt trên 38 độ, toàn thân đau nhức', 1, 30000, 150000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (13, 13, N'7 ngày không đi ngoài', 4, 30000, 750000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (14, 14, N'Nặng ngực, thở khò kè', 5, 30000, 28000, 0)
INSERT [dbo].[PhieuKham] ([MaPK], [MaBN], [TrieuChung], [MaLoaiBenh], [TienKham], [TienThuoc], [Xoa]) VALUES (15, 15, N'Chảy nước mũi, hắt xì thường xuyên', 2, 30000, 21000, 0)
GO
INSERT [dbo].[QuyDinh] ([SoBenhNhanMotNgay], [SoTienKham]) VALUES (40, 30000)
GO
ALTER TABLE [dbo].[ChiTietDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonThuoc_CachDung] FOREIGN KEY([MaCachDung])
REFERENCES [dbo].[CachDung] ([MaCachDung])
GO
ALTER TABLE [dbo].[ChiTietDonThuoc] CHECK CONSTRAINT [FK_ChiTietDonThuoc_CachDung]
GO
ALTER TABLE [dbo].[ChiTietDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonThuoc_DonThuoc] FOREIGN KEY([MaDT])
REFERENCES [dbo].[DonThuoc] ([MaDT])
GO
ALTER TABLE [dbo].[ChiTietDonThuoc] CHECK CONSTRAINT [FK_ChiTietDonThuoc_DonThuoc]
GO
ALTER TABLE [dbo].[ChiTietDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonThuoc_DonVi] FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[ChiTietDonThuoc] CHECK CONSTRAINT [FK_ChiTietDonThuoc_DonVi]
GO
ALTER TABLE [dbo].[ChiTietDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonThuoc_LoaiThuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[LoaiThuoc] ([MaThuoc])
GO
ALTER TABLE [dbo].[ChiTietDonThuoc] CHECK CONSTRAINT [FK_ChiTietDonThuoc_LoaiThuoc]
GO
ALTER TABLE [dbo].[DonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_DonThuoc_PhieuKham] FOREIGN KEY([MaPK])
REFERENCES [dbo].[PhieuKham] ([MaPK])
GO
ALTER TABLE [dbo].[DonThuoc] CHECK CONSTRAINT [FK_DonThuoc_PhieuKham]
GO
ALTER TABLE [dbo].[PhieuKham]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKham_BenhNhan] FOREIGN KEY([MaBN])
REFERENCES [dbo].[BenhNhan] ([MaSoBN])
GO
ALTER TABLE [dbo].[PhieuKham] CHECK CONSTRAINT [FK_PhieuKham_BenhNhan]
GO
ALTER TABLE [dbo].[PhieuKham]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKham_LoaiBenh] FOREIGN KEY([MaLoaiBenh])
REFERENCES [dbo].[LoaiBenh] ([MaBenh])
GO
ALTER TABLE [dbo].[PhieuKham] CHECK CONSTRAINT [FK_PhieuKham_LoaiBenh]
GO
USE [master]
GO
ALTER DATABASE [QuanLyPhongMach] SET  READ_WRITE 
GO
