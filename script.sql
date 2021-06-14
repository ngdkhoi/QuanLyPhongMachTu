USE [master]
GO
/****** Object:  Database [QuanLyPhongMach]    Script Date: 6/14/2021 4:22:29 PM ******/
CREATE DATABASE [QuanLyPhongMach]
GO
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
ALTER DATABASE [QuanLyPhongMach] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyPhongMach] SET QUERY_STORE = OFF
GO
USE [QuanLyPhongMach]
GO
/****** Object:  Table [dbo].[BacSi]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BacSi](
	[MaSo] [nvarchar](10) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[ChuyenKhoa] [nvarchar](50) NOT NULL,
	[SoChungChi] [nvarchar](20) NOT NULL,
	[Account] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_BacSi] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoCaoDoanhThuThang]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoDoanhThuThang](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[MaSo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_BaoCaoDoanhThuThang] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoCaoThuoc]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoThuoc](
	[MaSo] [nvarchar](10) NOT NULL,
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
 CONSTRAINT [PK_BaoCaoThuoc] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaSo] [nvarchar](10) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[SoDT] [nvarchar](10) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
 CONSTRAINT [PK_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBaoCaoDoanhThu]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBaoCaoDoanhThu](
	[MaBaoCao] [nvarchar](10) NOT NULL,
	[Ngay] [datetime] NOT NULL,
	[TiLe] [float] NOT NULL,
 CONSTRAINT [PK_ChiTietBaoCaoDoanhThu] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC,
	[Ngay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBaoCaoThuoc]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBaoCaoThuoc](
	[MaBaoCao] [nvarchar](10) NOT NULL,
	[MaThuoc] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[SoLanDung] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietBaoCaoThuoc] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDanhSachKham]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDanhSachKham](
	[NgayKham] [datetime] NOT NULL,
	[BenhNhan] [nvarchar](10) NOT NULL,
	[ThuTu] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDanhSachKham] PRIMARY KEY CLUSTERED 
(
	[NgayKham] ASC,
	[BenhNhan] ASC,
	[ThuTu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonThuoc]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonThuoc](
	[MaDonThuoc] [nvarchar](10) NOT NULL,
	[MaThuoc] [nvarchar](10) NOT NULL,
	[SoLuong] [nvarchar](10) NOT NULL,
	[CachDung] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChiTietDonThuoc] PRIMARY KEY CLUSTERED 
(
	[MaDonThuoc] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuanDoanBenh]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuanDoanBenh](
	[MaPhieuKham] [nvarchar](10) NOT NULL,
	[MaLoaiBenh] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_ChuanDoanBenh] PRIMARY KEY CLUSTERED 
(
	[MaPhieuKham] ASC,
	[MaLoaiBenh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThuNgay]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThuNgay](
	[Ngay] [datetime] NOT NULL,
	[SoBenhNhan] [int] NOT NULL,
	[DoanhThu] [int] NOT NULL,
 CONSTRAINT [PK_DoanhThuNgay] PRIMARY KEY CLUSTERED 
(
	[Ngay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonThuoc]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonThuoc](
	[MaSo] [nvarchar](10) NOT NULL,
	[PhieuKham] [nvarchar](10) NOT NULL,
	[NgayLap] [datetime] NOT NULL,
 CONSTRAINT [PK_DonThuoc] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaSo] [nvarchar](10) NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[TienKham] [int] NOT NULL,
	[TienThuoc] [int] NOT NULL,
	[TongTien] [int] NOT NULL,
	[KhachHang] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiBenh]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBenh](
	[MaSo] [nvarchar](5) NOT NULL,
	[TenBenh] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LoaiBenh] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKham]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKham](
	[MaSo] [nvarchar](10) NOT NULL,
	[NgayKham] [datetime] NOT NULL,
	[HoaDon] [nvarchar](10) NOT NULL,
	[BacSi] [nvarchar](10) NOT NULL,
	[BenhNhan] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PhieuKham] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuyDinh]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyDinh](
	[MaSo] [nvarchar](5) NOT NULL,
	[QuyDinh] [nvarchar](100) NOT NULL,
	[GiaTri] [int] NOT NULL,
 CONSTRAINT [PK_QuyDinh] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thuoc]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thuoc](
	[MaSo] [nvarchar](10) NOT NULL,
	[TenThuoc] [nvarchar](100) NOT NULL,
	[XuatXu] [nvarchar](50) NOT NULL,
	[Gia] [int] NOT NULL,
	[DonVi] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Thuoc] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrieuChung]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrieuChung](
	[MaSo] [nvarchar](5) NOT NULL,
	[MoTa] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TrieuChung] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrieuChungGhiNhan]    Script Date: 6/14/2021 4:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrieuChungGhiNhan](
	[MaPhieuKham] [nvarchar](10) NOT NULL,
	[MaTrieuChung] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_TrieuChungGhiNhan] PRIMARY KEY CLUSTERED 
(
	[MaPhieuKham] ASC,
	[MaTrieuChung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietBaoCaoDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBaoCaoDoanhThu_BaoCaoDoanhThuThang] FOREIGN KEY([MaBaoCao])
REFERENCES [dbo].[BaoCaoDoanhThuThang] ([MaSo])
GO
ALTER TABLE [dbo].[ChiTietBaoCaoDoanhThu] CHECK CONSTRAINT [FK_ChiTietBaoCaoDoanhThu_BaoCaoDoanhThuThang]
GO
ALTER TABLE [dbo].[ChiTietBaoCaoDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBaoCaoDoanhThu_DoanhThuNgay] FOREIGN KEY([Ngay])
REFERENCES [dbo].[DoanhThuNgay] ([Ngay])
GO
ALTER TABLE [dbo].[ChiTietBaoCaoDoanhThu] CHECK CONSTRAINT [FK_ChiTietBaoCaoDoanhThu_DoanhThuNgay]
GO
ALTER TABLE [dbo].[ChiTietBaoCaoThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBaoCaoThuoc_BaoCaoThuoc] FOREIGN KEY([MaBaoCao])
REFERENCES [dbo].[BaoCaoThuoc] ([MaSo])
GO
ALTER TABLE [dbo].[ChiTietBaoCaoThuoc] CHECK CONSTRAINT [FK_ChiTietBaoCaoThuoc_BaoCaoThuoc]
GO
ALTER TABLE [dbo].[ChiTietBaoCaoThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBaoCaoThuoc_Thuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaSo])
GO
ALTER TABLE [dbo].[ChiTietBaoCaoThuoc] CHECK CONSTRAINT [FK_ChiTietBaoCaoThuoc_Thuoc]
GO
ALTER TABLE [dbo].[ChiTietDanhSachKham]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDanhSachKham_BenhNhan] FOREIGN KEY([BenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaSo])
GO
ALTER TABLE [dbo].[ChiTietDanhSachKham] CHECK CONSTRAINT [FK_ChiTietDanhSachKham_BenhNhan]
GO
ALTER TABLE [dbo].[ChiTietDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonThuoc_DonThuoc] FOREIGN KEY([MaDonThuoc])
REFERENCES [dbo].[DonThuoc] ([MaSo])
GO
ALTER TABLE [dbo].[ChiTietDonThuoc] CHECK CONSTRAINT [FK_ChiTietDonThuoc_DonThuoc]
GO
ALTER TABLE [dbo].[ChiTietDonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonThuoc_Thuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaSo])
GO
ALTER TABLE [dbo].[ChiTietDonThuoc] CHECK CONSTRAINT [FK_ChiTietDonThuoc_Thuoc]
GO
ALTER TABLE [dbo].[ChuanDoanBenh]  WITH CHECK ADD  CONSTRAINT [FK_ChuanDoanBenh_Benh] FOREIGN KEY([MaLoaiBenh])
REFERENCES [dbo].[LoaiBenh] ([MaSo])
GO
ALTER TABLE [dbo].[ChuanDoanBenh] CHECK CONSTRAINT [FK_ChuanDoanBenh_Benh]
GO
ALTER TABLE [dbo].[ChuanDoanBenh]  WITH CHECK ADD  CONSTRAINT [FK_ChuanDoanBenh_PhieuKham] FOREIGN KEY([MaPhieuKham])
REFERENCES [dbo].[PhieuKham] ([MaSo])
GO
ALTER TABLE [dbo].[ChuanDoanBenh] CHECK CONSTRAINT [FK_ChuanDoanBenh_PhieuKham]
GO
ALTER TABLE [dbo].[DonThuoc]  WITH CHECK ADD  CONSTRAINT [FK_DonThuoc_PhieuKham] FOREIGN KEY([PhieuKham])
REFERENCES [dbo].[PhieuKham] ([MaSo])
GO
ALTER TABLE [dbo].[DonThuoc] CHECK CONSTRAINT [FK_DonThuoc_PhieuKham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BenhNhan] FOREIGN KEY([KhachHang])
REFERENCES [dbo].[BenhNhan] ([MaSo])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_BenhNhan]
GO
ALTER TABLE [dbo].[PhieuKham]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKham_BacSi] FOREIGN KEY([BacSi])
REFERENCES [dbo].[BacSi] ([MaSo])
GO
ALTER TABLE [dbo].[PhieuKham] CHECK CONSTRAINT [FK_PhieuKham_BacSi]
GO
ALTER TABLE [dbo].[PhieuKham]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKham_BenhNhan] FOREIGN KEY([BenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaSo])
GO
ALTER TABLE [dbo].[PhieuKham] CHECK CONSTRAINT [FK_PhieuKham_BenhNhan]
GO
ALTER TABLE [dbo].[TrieuChungGhiNhan]  WITH CHECK ADD  CONSTRAINT [FK_TrieuChungGhiNhan_PhieuKham] FOREIGN KEY([MaPhieuKham])
REFERENCES [dbo].[PhieuKham] ([MaSo])
GO
ALTER TABLE [dbo].[TrieuChungGhiNhan] CHECK CONSTRAINT [FK_TrieuChungGhiNhan_PhieuKham]
GO
ALTER TABLE [dbo].[TrieuChungGhiNhan]  WITH CHECK ADD  CONSTRAINT [FK_TrieuChungGhiNhan_TrieuChung] FOREIGN KEY([MaTrieuChung])
REFERENCES [dbo].[TrieuChung] ([MaSo])
GO
ALTER TABLE [dbo].[TrieuChungGhiNhan] CHECK CONSTRAINT [FK_TrieuChungGhiNhan_TrieuChung]
GO
USE [master]
GO
ALTER DATABASE [QuanLyPhongMach] SET  READ_WRITE 
GO
