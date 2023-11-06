create DATABASE [QuanLyCuaHangDienThoai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCuaHangDienThoai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QuanLyCuaHangDienThoai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyCuaHangDienThoai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QuanLyCuaHangDienThoai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCuaHangDienThoai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyCuaHangDienThoai', N'ON'
GO
ALTER DATABASE [QuanLyCuaHangDienThoai] SET QUERY_STORE = OFF
GO
USE [QuanLyCuaHangDienThoai]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [QuanLyCuaHangDienThoai]
GO

CREATE TABLE CongViec(
	idCV nchar(10) CONSTRAINT PK_CongViec PRIMARY KEY,
	TenCV nvarchar(100) NOT NULL,
	Luong float check (luong>0)
)

insert into CongViec(idCV,TenCV,Luong)
values 
('CV_01',N'Nhân viên bán hàng', 8000000),
('CV_02',N'Nhân viên kỹ thuật', 9000000),
('CV_03',N'Quản lý', 12000000);

CREATE TABLE CaLamViec(
	idCa nchar(10),
	Gio_BatDau time NOT NULL,
	Gio_KetThuc time NOT NUll,
	CHECK (Gio_KetThuc > Gio_BatDau),
	CONSTRAINT PK_CaLamViec PRIMARY KEY (idCa)
)
insert into CaLamViec(idCa,Gio_BatDau,Gio_KetThuc)
values
('CA_01','9:00','15:00'),
('CA_02','15:00','21:00');

CREATE TABLE NhanVien(
	idNV nchar(10) CONSTRAINT PK_NhanVien PRIMARY KEY,
	idCV nchar(10) CONSTRAINT FK_NhanVien_CV FOREIGN KEY REFERENCES CongViec(idCV),
	Ho_Ten nvarchar(100) NOT NULL,
	NgaySinh date check(DATEDIFF(year, NgaySinh, GETDATE())>=18),
	DiaChi nvarchar(100),
	GioiTinh nvarchar(4),
	soDT_NV nchar(11) check (len(soDT_NV) = 10)
)
insert into NhanVien(idNV,idCV,Ho_Ten,NgaySinh,DiaChi,GioiTinh,soDT_NV)
values
('NV_01','CV_01',N'Nguyễn Văn A', '1999-10-10',N'Quận 1',N'Nam','0345678927'),
('NV_02','CV_01',N'Nguyễn Thị C', '2000-7-8',N'Quận 2',N'Nữ','0346895782'),

('NV_03','CV_02',N'Trần Văn B', '2000-1-18',N'Quận 3',N'Nam','0345457489'),
('NV_04','CV_02',N'Lê văn L', '2002-1-27',N'Quận 4',N'Nam','0386794759'),

('NV_05','CV_03',N'Boss', '1997-3-21',N'Quận 5',N'Nam','0999999999');



CREATE TABLE BangPhanCa(
	idCa nchar(10),
	idNV nchar(10) CONSTRAINT FK_BangPhanCa_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	NgayLam date NOT NULL,
	CONSTRAINT PK_BangPhanCa PRIMARY KEY (idCa, idNV, NgayLam),
	CONSTRAINT FK_BangPhanCa_Ca FOREIGN KEY (idCa) REFERENCES CalamViec(idCa)
)
insert into BangPhanCa(idCa,idNV,NgayLam)
values
('CA_01','NV_01','2023-11-1'),
('CA_01','NV_02','2023-11-1'),
('CA_01','NV_03','2023-11-1'),
('CA_01','NV_04','2023-11-1'),

('CA_02','NV_01','2023-11-1'),
('CA_02','NV_02','2023-11-1'),
('CA_02','NV_03','2023-11-1'),
('CA_02','NV_04','2023-11-1'),

('CA_01','NV_01','2023-11-2'),
('CA_01','NV_02','2023-11-2'),
('CA_01','NV_03','2023-11-2'),
('CA_01','NV_04','2023-11-2'),

('CA_02','NV_01','2023-11-2'),
('CA_02','NV_02','2023-11-2'),
('CA_02','NV_03','2023-11-2'),
('CA_02','NV_04','2023-11-2'),

('CA_01','NV_01','2023-11-3'),
('CA_01','NV_02','2023-11-3'),
('CA_01','NV_03','2023-11-3'),
('CA_01','NV_04','2023-11-3'),

('CA_02','NV_01','2023-11-3'),
('CA_02','NV_02','2023-11-3'),
('CA_02','NV_03','2023-11-3'),
('CA_02','NV_04','2023-11-3');

CREATE TABLE KhachHang(
	idKH nchar(10) CONSTRAINT PK_KhachHang PRIMARY KEY,
	TenKH nvarchar(100) NOT NULL,
	soDT_KH nchar(11) NOT NULL check (len(soDT_KH) = 10),
	DiaChi nvarchar(100)
)
insert into KhachHang(idKH,TenKH,soDT_KH, DiaChi)
values 
('KH_01',N'Ngô Thị D','0382357983',N'Hà Nội'),
('KH_02',N'Bá Văn T','0382236793',N'Cà Mau');


CREATE TABLE HoaDon(
	idHD nchar(10) CONSTRAINT PK_HoaDon PRIMARY KEY,
	idNV nchar(10) CONSTRAINT FK_HoaDon_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	idKH nchar(10) CONSTRAINT FK_HoaDon_KH FOREIGN KEY REFERENCES KhachHang(idKH),
	TrangThai nvarchar(100) NOT NULL,
	Ngay date NOT NULL,
	TriGiaHD float 
)


insert into HoaDon(idHD,idNV,idKH,Ngay,TriGiaHD,TrangThai)
values
('HD_01','NV_01','KH_01','2023-11-1',26780000,N'Đã thanh toán'),
('HD_02','NV_02','KH_02','2023-11-3', 36990000,N'Đã thanh toán');


CREATE TABLE HangDienThoai(
	TenHangDT nvarchar(100) CONSTRAINT PK_HangDienThoai PRIMARY KEY,
	NguonGoc nvarchar(100) NOT NULL,
	TrangThai nvarchar(100) NOT NULL
)
insert into HangDienThoai(TenHangDT,NguonGoc,TrangThai)
values
('Samsung',N'Hàn Quốc',N'Đang hoạt động'),
('Apple',N'Mỹ',N'Đang hoạt động'),
('Xiaomi',N'Trung Quốc',N'Đang hoạt động');

CREATE TABLE DienThoai(
	idDienThoai nchar(10) CONSTRAINT PK_DienThoai PRIMARY KEY,
	TenHangDT nvarchar(100) CONSTRAINT FK_DienThoai_HangDT FOREIGN KEY REFERENCES HangDienThoai(TenHangDT),
	TenDienThoai nvarchar(100) NOT NULL,
	SoLuong float NOT NULL,
	MauSac nvarchar(30) NOT NULL,
	DungLuong nchar(10) NOT NULL,
	GiaBan float NOT NULL CHECK (GiaBan > 0),
	TrangThai nvarchar(max),
	HinhAnh image
)
insert into DienThoai(idDienThoai,TenHangDT,TenDienThoai,SoLuong,MauSac,DungLuong,GiaBan,TrangThai,HinhAnh)
values
('DT_01','Samsung','Samsung Galaxy A05',13,N'Đen huyền bí','128 GB',3090000,N'Còn hàng',null),
('DT_02','Samsung','Samsung Galaxy S23 FE 5G',7,N'Trắng tinh khôi','128 GB',13390000,N'Còn hàng',null),

('DT_03','Apple','iPhone 13',10,N'Hồng cánh sen','128 GB',16690000,N'Còn hàng',null),
('DT_04','Apple','iPhone 15 Pro',5,N'Titan tự nhiên','128 GB',27790000,N'Còn hàng',null),
('DT_05','Apple','iPhone 15 Pro',5,N'Titan đen','512 GB',36990000,N'Còn hàng',null),

('DT_06','Xiaomi','Xiaomi Redmi 12',8,N'Bạc','128 GB',3590000,N'Còn hàng',null),
('DT_07','Xiaomi','Xiaomi 13T 5G',5,N'Xanh Dương','256 GB',10990000,N'Còn hàng',null);


CREATE TABLE ChiTietHoaDon(
	idHD nchar(10) CONSTRAINT FK_ChiTietHoaDon_HD FOREIGN KEY REFERENCES HoaDon(idHD),
	idDienThoai nchar(10) CONSTRAINT FK_ChiTietHoaDon_DT FOREIGN KEY REFERENCES DienThoai(idDienThoai),
	SoLuong float NOT NULL CHECK (SoLuong > 0),
	DonGia float NOT NULL,
	TongTien float NOT NULL,
	CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (idHD,idDienThoai)
)

insert into ChiTietHoaDon(idHD,idDienThoai,SoLuong,DonGia,TongTien)
values 
('HD_01','DT_02',2,13390000,26780000),
('HD_02','DT_05',1,36990000,36990000);


CREATE TABLE NhaCungCap(
	idNCC nchar(10) CONSTRAINT PK_NhaCungCung PRIMARY KEY,
	TenNCC nvarchar(100) NOT NULL,
	soDT_NCC nchar(11) NOT NULL check (len(soDT_NCC) = 10),
	DiaChiNCC nvarchar(100) NOT NULL
)
insert into NhaCungCap(idNCC,TenNCC,soDT_NCC,DiaChiNCC)
values
('NCC_01',N'FPT Tradinh','0283510010',N'Hà Nội'),
('NCC_02',N'DGW','0355351001',N'Đà Nẵng'),
('NCC_03',N'PET','0995051001',N'TPHCM');

CREATE TABLE DonNhap(
	idDonNhap nchar(10) CONSTRAINT PK_DonNhap PRIMARY KEY,
	idNCC nchar(10) CONSTRAINT FK_DonNhap_NCC FOREIGN KEY REFERENCES NhaCungCap(idNCC),
	TriGiaDon float NOT NULL CHECK (TriGiaDon > 0),
	NgayTao date NOT NULL,
	TrangThai NVARCHAR(max)
)
insert into DonNhap(idDonNhap,idNCC,TriGiaDon,NgayTao,TrangThai	)
values
('DN_01','NCC_01',82400000,'2023-1-15',N'Đã nhận'),
('DN_02','NCC_02',101400000,'2023-5-17',N'Đã nhận'),
('DN_03','NCC_03',151540000,'2023-10-23',N'Chưa nhận');


CREATE TABLE ChiTietDonNhap(
	idDonNhap nchar(10) CONSTRAINT FK_ChiTietDonNhap_DN FOREIGN KEY REFERENCES DonNhap(idDonNhap),
	idNV nchar(10) CONSTRAINT FK_ChiTietDonNhap_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	SoLuong float NOT NULL CHECK(SoLuong > 0),
	DonGia float NOT NULL,
	TongTien float NOT NULL,
	NgayNhap date,
	idDienThoai nchar(10) CONSTRAINT FK_ChiTietDonNhap_DT FOREIGN KEY REFERENCES DienThoai(idDienThoai)
)
GO

insert into ChiTietDonNhap(idDonNhap,idDienThoai,idNV,SoLuong,DonGia,TongTien,NgayNhap)
values
('DN_01','DT_01','NV_01',5,3090000,15450000,'2023-1-22'),
('DN_01','DT_02','NV_01',5,13390000,66950000,'2023-1-22'),

('DN_02','DT_03','NV_02',5,16690000,83450000,'2023-5-27'),
('DN_02','DT_06','NV_02',3,3590000,17950000,'2023-5-27'),

('DN_03','DT_04',NULL,2,27790000,55580000,NUll),
('DN_03','DT_05',NULL,2,36990000,73980000,NUll),
('DN_03','DT_07',NULL,2,10990000,21980000,NUll)
go
-- Tạo trigger INSTEAD OF DELETE trên bảng HoaDon
CREATE or ALTER TRIGGER InsteadOfDeleteHoaDon
ON HoaDon
INSTEAD OF DELETE
AS
BEGIN
    -- Tạo bảng tạm thời lưu danh sách các id của hóa đơn bị xóa
    DECLARE @DeletedHDIDs TABLE (idHD nvarchar(max));

    -- Lấy danh sách các id của hóa đơn bị xóa và lưu vào bảng tạm thời
    INSERT INTO @DeletedHDIDs (idHD)
    SELECT idHD FROM deleted;

    -- Cập nhật lại số lượng bảng điện thoại bằng truy vấn lồng nhau
    UPDATE DienThoai
    SET SoLuong = DienThoai.SoLuong + D.SoLuong
    FROM DienThoai
    INNER JOIN (
        SELECT idHD, idDienThoai, SUM(SoLuong) AS SoLuong
        FROM ChiTietHoaDon
        WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs)
        GROUP BY idHD, idDienThoai
    ) AS D ON DienThoai.idDienThoai = D.idDienThoai;

	-- Tiếp theo, xóa chi tiết hóa đơn liên quan
    DELETE FROM ChiTietHoaDon
	WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);

    -- Tiếp theo, xóa hóa đơn
    DELETE FROM HoaDon
    WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);

	/*UPDATE HoaDon
	Set TrangThai = N'Đơn Đã Hủy'
	WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);*/
END; 
GO


CREATE or ALTER TRIGGER KiemTraTenKH
ON KhachHang
AFTER INSERT, UPDATE
AS
BEGIN
	-- Kiểm tra số điện thoại vừa thêm có bị trùng lặp
	IF EXISTS ( SELECT * FROM inserted i WHERE EXISTS (SELECT *FROM KhachHang k WHERE k.TenKH = i.TenKH AND k.idKH <> i.idKH ))
	BEGIN
	-- Nếu trùng thì rollback
		ROLLBACK;
	END
END
GO


CREATE OR ALTER TRIGGER UpdateTrangThaiDienThoai
ON DienThoai
AFTER INSERT, UPDATE
AS
BEGIN
	-- Cập nhật trạng thái dựa trên số lượng
	UPDATE DienThoai
	SET TrangThai = CASE
		WHEN SoLuong = 0 THEN N'Hết hàng'
		ELSE N'Còn hàng'
		END
	WHERE DienThoai.idDienThoai IN (SELECT idDienThoai FROM inserted);

	-- Kiểm tra và ngăn chặn cập nhật sai
	IF (SELECT COUNT(*) FROM inserted WHERE SoLuong < 0 OR GiaBan < 0) > 0 
	begin
		RAISERROR ('THÔNG TIN VỀ GIÁ HOẶC SỐ LƯỢNG KHÔNG CHÍNH XÁC', 0, 0)
		ROLLBACK;
	END;
END;
GO


CREATE TRIGGER DeleteCustomer
ON KhachHang
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @idKH NVARCHAR(max)

    -- Lấy danh sách các khách hàng bị xóa từ bảng xóa ảo (deleted)
    SELECT @idKH = idKH
    FROM deleted

    -- Kiểm tra xem khách hàng có đơn hàng đang tồn tại không
    IF EXISTS (SELECT 1 FROM HoaDon WHERE idKH = @idKH)
    BEGIN
        RAISERROR('Không thể xóa khách hàng có đơn hàng đang tồn tại.', 16, 1)
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        -- Nếu không có đơn hàng nào, thực hiện xóa khách hàng
        DELETE FROM KhachHang WHERE idKH = @idKH
    END
END
GO

use QuanLyCuaHangDienThoai
go
-- PROC LIÊN QUAN ĐẾN ĐIỆN THOẠI
CREATE or ALTER PROCEDURE proc_TimKiemHangGiaDT
(
	 @hang_dt NVARCHAR(max),
	 @giaban NVARCHAR(max)
)
AS
BEGIN
	IF @hang_dt != '0' and @giaban != '0'
	BEGIN
		IF @giaban = '< 10tr'
			BEGIN
				SELECT *
				FROM DienThoai
				WHERE GiaBan < 10000000 and TenHangDT LIKE '%' + @hang_dt
			END;
		IF @giaban = 'Từ 10tr - 25tr'
			BEGIN
				SELECT *
				FROM DienThoai
				WHERE GiaBan <= 25000000 and GiaBan >= 10000000 and TenHangDT LIKE '%' + @hang_dt
			END;
		IF @giaban = '> 25tr'
			BEGIN
				SELECT *
				FROM DienThoai
				WHERE GiaBan > 25000000 and TenHangDT LIKE '%' + @hang_dt
			END;
	END;
	ELSE
	BEGIN
		IF @hang_dt != '0'
		BEGIN
			SELECT *
			FROM DienThoai
			WHERE TenHangDT LIKE '%' + @hang_dt
		END;

		ELSE IF @giaban != '0'
		BEGIN
			IF @giaban = '< 10tr'
				BEGIN
					SELECT *
					FROM DienThoai
					WHERE GiaBan < 10000000 
				END;
			IF @giaban = 'Từ 10tr - 25tr'
				BEGIN
					SELECT *
					FROM DienThoai
					WHERE GiaBan <= 25000000 and GiaBan >= 10000000 
				END;
			IF @giaban = '> 25tr'
				BEGIN
					SELECT *
					FROM DienThoai
					WHERE GiaBan > 25000000 
				END;
		END;

		ELSE
		BEGIN
			SELECT *
			FROM DienThoai
		END;

	END;
END;
GO

CREATE or ALTER PROCEDURE proc_TimKiemTenDT
(
	@ten_dt NVARCHAR(max)
)
AS 
BEGIN
	IF @ten_dt is not null
	BEGIN
		SELECT *
		FROM DienThoai
		WHERE TenDienThoai LIKE '%' + @ten_dt + '%';
	END;
	ELSE
	BEGIN
		SELECT *
		FROM DienThoai
	END;
END;
GO


CREATE or ALTER PROCEDURE proc_InsertOrUpdateDienThoai
    @idDienThoai nchar(10),
    @TenDienThoai nvarchar(255),
    @TenHangDT nvarchar(255),
    @MauSac nvarchar(255),
    @DungLuong nvarchar(255),
    @GiaBan float,
    @SoLuong float,
    @TinhTrang nvarchar(255),
    @HinhAnh varbinary(max) = NULL -- Thêm giá trị mặc định là NULL cho tham số @HinhAnh
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DienThoai WHERE idDienThoai = @idDienThoai)
    BEGIN
        -- Bản ghi đã tồn tại, thực hiện UPDATE
        UPDATE DienThoai
        SET
            TenDienThoai = @TenDienThoai,
            TenHangDT = @TenHangDT,
            MauSac = @MauSac,
            DungLuong = @DungLuong,
            GiaBan = @GiaBan,
            SoLuong = @SoLuong,
            TrangThai = @TinhTrang,
            HinhAnh = @HinhAnh
        WHERE idDienThoai = @idDienThoai;
    END
    ELSE
    BEGIN
        -- Bản ghi chưa tồn tại, thực hiện INSERT
        INSERT INTO DienThoai (idDienThoai, TenDienThoai, TenHangDT, MauSac, DungLuong, GiaBan, SoLuong, TrangThai, HinhAnh)
        VALUES (@idDienThoai, @TenDienThoai, @TenHangDT, @MauSac, @DungLuong, @GiaBan, @SoLuong, @TinhTrang, @HinhAnh);
    END;
END;
GO


CREATE OR ALTER PROCEDURE proc_XoaDienThoai
(
    @idDienThoai NVARCHAR(max)
)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM ChiTietDonNhap join DonNhap ON ChiTietDonNhap.idDonNhap = DonNhap.idDonNhap WHERE idDienThoai = @idDienThoai AND TrangThai = 'Chưa nhận')
    BEGIN
        IF EXISTS (SELECT 1 FROM DienThoai WHERE idDienThoai = @idDienThoai AND SoLuong = 0)
        BEGIN
            DELETE FROM DienThoai WHERE idDienThoai = @idDienThoai;
        END
        ELSE
        BEGIN
            RAISERROR('Không thể xóa điện thoại vì vẫn còn hàng trong kho.', 16, 1);
        END
    END
    ELSE
    BEGIN
        RAISERROR('Hàng đang được nhập về.', 16, 1);
    END
END;
GO



-- PROC LIÊN QUAN ĐẾN HÓA ĐƠN
CREATE OR ALTER PROCEDURE proc_ChiTietHoaDon
(
    @id_hoadon nvarchar(max)
)
AS
BEGIN
    IF @id_hoadon IS NOT NULL
    BEGIN
        -- Lấy thông tin Khách hàng
        SELECT DISTINCT KhachHang.idKH, KhachHang.TenKH, KhachHang.soDT_KH, KhachHang.DiaChi
        FROM KhachHang, HoaDon
        WHERE HoaDon.idKH = KhachHang.idKH AND HoaDon.idHD = @id_hoadon;

        -- Lấy thông tin Nhân viên
        SELECT DISTINCT NhanVien.idNV, NhanVien.Ho_Ten, CongViec.TenCV
        FROM NhanVien
        JOIN CongViec ON NhanVien.idCV = CongViec.idCV
        JOIN HoaDon ON HoaDon.idNV = NhanVien.idNV
        WHERE HoaDon.idHD = @id_hoadon;

        -- Lấy thông tin Điện thoại
        SELECT DienThoai.idDienThoai, DienThoai.TenDienThoai, DienThoai.TenHangDT, DienThoai.MauSac, DienThoai.DungLuong, DienThoai.GiaBan, ChiTietHoaDon.SoLuong
        FROM DienThoai, ChiTietHoaDon
        WHERE ChiTietHoaDon.idDienThoai = DienThoai.idDienThoai AND ChiTietHoaDon.idHD = @id_hoadon;
    END;
END;
GO

CREATE OR ALTER PROCEDURE proc_TimKiemHoaDon_date_and_status
(
    @date nvarchar(max),
    @status nvarchar(max)
)
AS
BEGIN
    IF @date IS NOT NULL AND @status IS NOT NULL
    BEGIN
        SELECT *
        FROM HoaDon
        WHERE HoaDon.Ngay = @date AND HoaDon.TrangThai = @status;
    END
    ELSE IF @date IS NOT NULL
    BEGIN
        SELECT *
        FROM HoaDon
        WHERE HoaDon.Ngay = @date;
    END
    ELSE IF @status IS NOT NULL
    BEGIN
        SELECT *
        FROM HoaDon
        WHERE HoaDon.TrangThai = @status;
    END
END;
GO

CREATE OR ALTER PROCEDURE proc_timkiemphancong_ca
(
    @date date,
	@tencv nvarchar(max)
)
AS
BEGIN
    IF @date IS NOT NULL and @tencv IS NOT NULL
    BEGIN
        SELECT BangPhanCa.idCa, NhanVien.Ho_Ten, CongViec.TenCV, CaLamViec.Gio_BatDau, CaLamViec.Gio_KetThuc, BangPhanCa.NgayLam
        FROM BangPhanCa join NhanVien ON BangPhanCa.idNV = NhanVien.idNV join CongViec ON NhanVien.idCV = CongViec.idCV join CaLamViec on BangPhanCa.idCa = CaLamViec.idCa
        WHERE BangPhanCa.NgayLam = @date and TenCV LIKE '%' + @tencv + '%';
    END
	ELSE IF @tencv is NULL
	BEGIN 
		SELECT BangPhanCa.idCa, NhanVien.Ho_Ten, CongViec.TenCV, CaLamViec.Gio_BatDau, CaLamViec.Gio_KetThuc, BangPhanCa.NgayLam
        FROM BangPhanCa join NhanVien ON BangPhanCa.idNV = NhanVien.idNV join CongViec ON NhanVien.idCV = CongViec.idCV join CaLamViec on BangPhanCa.idCa = CaLamViec.idCa
        WHERE BangPhanCa.NgayLam = @date
	END
END;
go

create or alter procedure proc_themgiohang
(
	@id_dt nvarchar(max),
	@so_luong int
)
as
begin
	-- Kiểm tra nếu @so_luong lớn hơn số lượng tồn kho của điện thoại
	if @id_dt is not null and @so_luong > 0
	begin
		DECLARE @so_luong_ton int;

		-- Lấy số lượng tồn kho của điện thoại
		SELECT @so_luong_ton = DienThoai.SoLuong
		FROM DienThoai
		WHERE idDienThoai = @id_dt;

		-- Kiểm tra nếu @so_luong lớn hơn số lượng tồn kho
		if @so_luong <= @so_luong_ton
		begin
			-- Truy vấn thông tin sản phẩm nếu điều kiện hợp lệ
			SELECT DienThoai.idDienThoai, DienThoai.TenDienThoai, DienThoai.GiaBan, @so_luong AS SoLuong
			FROM DienThoai
			WHERE DienThoai.idDienThoai = @id_dt;
		end;
	end;
end;
GO



-- PROC LIÊN QUAN ĐẾN KHÁCH HÀNG
create or alter procedure proc_timkiemkhachhang_sdt
(
	@sdt varchar(max)
)
as
begin
	if @sdt is not null
	begin
		SELECT *
		FROM KhachHang
		WHERE KhachHang.soDT_KH LIKE '%' + @sdt + '%'
	end;
	else
	begin
		SELECT *
		FROM KhachHang
	end;
end;
GO


create or alter procedure proc_lichsumuahang
(
	@id_kh nvarchar(max)
)
as
begin
	if @id_kh is not null
	begin
		SELECT HoaDon.idHD, HoaDon.Ngay,DienThoai.TenDienThoai,DienThoai.MauSac,DienThoai.DungLuong,ChiTietHoaDon.SoLuong,ChiTietHoaDon.TongTien
		FROM KhachHang 
		join HoaDon ON KhachHang.idKH = HoaDon.idKH 
		join ChiTietHoaDon ON HoaDon.idHD = ChiTietHoaDon.idHD
		join DienThoai ON DienThoai.idDienThoai = ChiTietHoaDon.idDienThoai
		WHERE KhachHang.idKH = @id_kh
	end;
end;
GO

CREATE or ALTER PROCEDURE proc_InsertOrUpdateKhachHang
    @idKH nchar(10),
    @TenKH nvarchar(255),
    @DiaChi nvarchar(255),
    @soDT_KH nvarchar(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KhachHang WHERE idKH = @idKH)
    BEGIN
        -- Bản ghi khách hàng đã tồn tại, thực hiện UPDATE
        UPDATE KhachHang
        SET
            TenKH = @TenKH,
            DiaChi = @DiaChi,
            soDT_KH = @soDT_KH
        WHERE idKH = @idKH;
    END
    ELSE
    BEGIN
        -- Bản ghi khách hàng chưa tồn tại, thực hiện INSERT
        INSERT INTO KhachHang (idKH, TenKH, DiaChi, soDT_KH)
        VALUES (@idKH, @TenKH, @DiaChi, @soDT_KH);
    END;
END;
GO


-- PROC LIÊN QUAN ĐẾN NHÂN VIÊN
create or alter procedure proc_chitietthongtin_nv
(
	@id_nv nvarchar(max)
)
as
begin
	if @id_nv is not null
	begin
		SELECT *
		FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV
		WHERE NhanVien.idNV = @id_nv
	end;
end;
GO

CREATE or ALTER VIEW v_khachhang
AS
SELECT * FROM KhachHang

go
CREATE or ALTER VIEW v_nhanvien
AS
SELECT NhanVien.idNV, NhanVien.Ho_Ten, NhanVien.soDT_NV, CongViec.TenCV
FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV

go
CREATE or ALTER VIEW v_hoadon
AS
SELECT HoaDon.idHD, NhanVien.Ho_Ten as "Tên nhân viên", KhachHang.TenKH as "Tên khách hàng", HoaDon.TriGiaHD, HoaDon.Ngay, HoaDon.TrangThai
FROM NhanVien join HoaDon ON NhanVien.idNV = HoaDon.idNV join KhachHang ON KhachHang.idKH = HoaDon.idKH
go
CREATE or ALTER VIEW v_phancong
AS
SELECT BangPhanCa.idCa, NhanVien.Ho_Ten, CongViec.TenCV, CaLamViec.Gio_BatDau, CaLamViec.Gio_KetThuc, BangPhanCa.NgayLam
FROM BangPhanCa join NhanVien ON BangPhanCa.idNV = NhanVien.idNV join CongViec ON NhanVien.idCV = CongViec.idCV join CaLamViec on BangPhanCa.idCa = CaLamViec.idCa

