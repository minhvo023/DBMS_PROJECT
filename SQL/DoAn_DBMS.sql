create database QuanLyCuaHangDienThoai
GO

use QuanLyCuaHangDienThoai
GO

CREATE TABLE CongViec(
	idCV nchar(10) CONSTRAINT PK_CongViec PRIMARY KEY,
	TenCV nvarchar(100) NOT NULL,
	LuongTheoGio float CONSTRAINT CK_Luong_CV CHECK (LuongTheoGio > 0)
)
GO

insert into CongViec(idCV,TenCV,LuongTheoGio)
values 
('CV_01',N'Nhân viên bán hàng', 30000000),
('CV_02',N'Nhân viên kỹ thuật', 35000000),
('CV_03',N'Quản lý', 1);
GO

CREATE TABLE CaLamViec(
	idCa nchar(10),
	Gio_BatDau time NOT NULL,
	Gio_KetThuc time NOT NUll,
	CONSTRAINT PK_CaLamViec PRIMARY KEY (idCa),
    CONSTRAINT CK_gio_CLV CHECK (Gio_KetThuc > Gio_BatDau)
)
GO

insert into CaLamViec(idCa,Gio_BatDau,Gio_KetThuc)
values
('CA_01','9:00','15:00'),
('CA_02','15:00','21:00');
GO

CREATE TABLE NhanVien(
	idNV nchar(10) CONSTRAINT PK_NhanVien PRIMARY KEY,
	idCV nchar(10) CONSTRAINT FK_NhanVien_CV FOREIGN KEY REFERENCES CongViec(idCV),
	Ho_Ten nvarchar(100) NOT NULL,
	NgaySinh date NOT NULL,
	DiaChi nvarchar(100),
	GioiTinh nvarchar(100),
	soDT_NV nchar(10) NOT NULL,
	HinhAnh image,
	TrangThai nvarchar(max),
	MatKhau nchar(15)
)
GO
insert into NhanVien(idNV,idCV,Ho_Ten,NgaySinh,DiaChi,GioiTinh,soDT_NV)
values
('NV_01','CV_01',N'Nguyễn Văn A', '10/10/1999',N'Quận 1',N'Nam','0345678927'),
('NV_02','CV_01',N'Nguyễn Thị C', '8/8/1998',N'Quận 2',N'Nữ','0346895782'),
('NV_03','CV_02',N'Trần Văn B', '2/02/2000',N'Quận 3',N'Nam','0345457489'),
('NV_04','CV_02',N'Lê văn L', '4/04/2001',N'Quận 4',N'Nam','0386794759'),

('NV_05','CV_03',N'Boss', '3/03/1995',N'Quận 5',N'Nam','0999999999');
GO


CREATE TABLE BangPhanCa(
	idCa nchar(10) CONSTRAINT FK_BangPhanCa_CLV FOREIGN KEY REFERENCES CaLamViec(idCa),
	idNV nchar(10) CONSTRAINT FK_BangPhanCa_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	NgayLam date NOT NULL,
	TrangThai nvarchar(max),
	CONSTRAINT PK_BangPhanCa PRIMARY KEY (idCa, idNV, NgayLam),
)
GO

insert into BangPhanCa(idCa,idNV,NgayLam)
values
('CA_01','NV_01','11/1/2023'),
('CA_01','NV_02','11/1/2023'),
('CA_01','NV_03','11/1/2023'),
('CA_01','NV_04','11/1/2023'),

('CA_02','NV_01','11/1/2023'),
('CA_02','NV_02','11/1/2023'),
('CA_02','NV_03','11/1/2023'),
('CA_02','NV_04','11/1/2023'),

('CA_01','NV_01','11/2/2023'),
('CA_01','NV_02','11/2/2023'),
('CA_01','NV_03','11/2/2023'),
('CA_01','NV_04','11/2/2023'),

('CA_02','NV_01','11/2/2023'),
('CA_02','NV_02','11/2/2023'),
('CA_02','NV_03','11/2/2023'),
('CA_02','NV_04','11/2/2023'),

('CA_01','NV_01','11/3/2023'),
('CA_01','NV_02','11/3/2023'),
('CA_01','NV_03','11/3/2023'),
('CA_01','NV_04','11/3/2023'),

('CA_02','NV_01','11/3/2023'),
('CA_02','NV_03','11/3/2023'),
('CA_02','NV_04','11/3/2023');
GO

CREATE TABLE KhachHang(
	idKH nchar(10) CONSTRAINT PK_KhachHang PRIMARY KEY,
	TenKH nvarchar(100) NOT NULL,
	soDT_KH nchar(10) NOT NULL,
	DiaChi nvarchar(100)
)
GO

insert into KhachHang(idKH,TenKH,soDT_KH, DiaChi)
values 
('KH_01',N'Ngô Thị D','0382357983',N'Hà Nội'),
('KH_02',N'Bá Văn T','0382236793',N'Cà Mau');
GO

CREATE TABLE HoaDon(
	idHD nchar(10) CONSTRAINT PK_HoaDon PRIMARY KEY,
	idNV nchar(10) CONSTRAINT FK_HoaDon_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	idKH nchar(10) CONSTRAINT FK_HoaDon_KH FOREIGN KEY REFERENCES KhachHang(idKH),
	Ngay date NOT NULL,
	TriGiaHD float NOT NULL CONSTRAINT CK_HoaDon CHECK (TriGiaHD > 0),
	TrangThai nvarchar(100) NOT NULL
)
GO

insert into HoaDon(idHD,idNV,idKH,Ngay,TriGiaHD,TrangThai)
values
('HD_01','NV_01','KH_01','11/1/2023',26780000,N'Đã thanh toán'),
('HD_02','NV_02','KH_02','11/3/2023', 36990000,N'Đã thanh toán');
GO

CREATE TABLE HangDienThoai(
	TenHangDT nvarchar(100) CONSTRAINT PK_HangDienThoai PRIMARY KEY,
	NguonGoc nvarchar(100) NOT NULL,
	TrangThai nvarchar(100)
)
GO

insert into HangDienThoai(TenHangDT,NguonGoc,TrangThai)
values
('Samsung',N'Hàn Quốc',N'Đang hoạt động'),
('Apple',N'Mỹ',N'Đang hoạt động'),
('Xiaomi',N'Trung Quốc',N'Đang hoạt động');
GO

CREATE TABLE DienThoai(
	idDienThoai nchar(10) CONSTRAINT PK_DienThoai PRIMARY KEY,
	TenHangDT nvarchar(100) CONSTRAINT FK_DienThoai_HangDT FOREIGN KEY REFERENCES HangDienThoai(TenHangDT),
	TenDienThoai nvarchar(100) NOT NULL,
	SoLuong float NOT NULL,
	MauSac nvarchar(100) NOT NULL,
	DungLuong nchar(10) NOT NULL,
	GiaBan float NOT NULL,
	TrangThai nvarchar(100),
	HinhAnh image,
)
GO

insert into DienThoai(idDienThoai,TenHangDT,TenDienThoai,SoLuong,MauSac,DungLuong,GiaBan,TrangThai)
values
('DT_01','Samsung','Samsung Galaxy A05',13,N'Đen huyền bí','128 GB',3090000,N'Còn hàng'),
('DT_02','Samsung','Samsung Galaxy S23 FE 5G',7,N'Trắng tinh khôi','128 GB',13390000,N'Còn hàng'),

('DT_03','Apple','iPhone 13',10,N'Hồng cánh sen','128 GB',16690000,N'Còn hàng'),
('DT_04','Apple','iPhone 15 Pro',5,N'Titan tự nhiên','128 GB',27790000,N'Còn hàng'),
('DT_05','Apple','iPhone 15 Pro',5,N'Titan đen','512 GB',36990000,N'Còn hàng'),

('DT_06','Xiaomi','Xiaomi Redmi 12',8,N'Bạc','128 GB',3590000,N'Còn hàng'),
('DT_07','Xiaomi','Xiaomi 13T 5G',5,N'Xanh Dương','256 GB',10990000,N'Còn hàng');
GO

CREATE TABLE ChiTietHoaDon(
	idHD nchar(10) CONSTRAINT FK_ChiTietHoaDon_HD FOREIGN KEY REFERENCES HoaDon(idHD),
	idDienThoai nchar(10) CONSTRAINT FK_ChiTietHoaDon_DT FOREIGN KEY REFERENCES DienThoai(idDienThoai),
	SoLuong float NOT NULL,
	DonGia float NOT NULL,
	TongTien float NOT NULL,
	CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (idHD,idDienThoai)
)
GO

insert into ChiTietHoaDon(idHD,idDienThoai,SoLuong,DonGia,TongTien)
values 
('HD_01','DT_02',2,13390000,26780000),
('HD_02','DT_05',1,36990000,36990000);
GO

CREATE TABLE NhaCungCap(
	idNCC nchar(10) CONSTRAINT PK_NhaCungCung PRIMARY KEY,
	TenNCC nvarchar(100) NOT NULL,
	soDT_NCC nchar(10) NOT NULL,
	DiaChiNCC nvarchar(100)
)
GO

insert into NhaCungCap(idNCC,TenNCC,soDT_NCC,DiaChiNCC)
values
('NCC_01',N'FPT Tradinh','0283510010',N'Hà Nội'),
('NCC_02',N'DGW','0355351001',N'Đà Nẵng'),
('NCC_03',N'PET','0995051001',N'TPHCM');
GO

CREATE TABLE DonNhap(
	idDonNhap nchar(10) CONSTRAINT PK_DonNhap PRIMARY KEY,
	idNV nchar(10) CONSTRAINT FK_DonNhap_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	idNCC nchar(10) CONSTRAINT FK_DonNhap_NCC FOREIGN KEY REFERENCES NhaCungCap(idNCC),
	TriGiaDon float NOT NULL,
	NgayTao date NOT NULL,
	TrangThai NVARCHAR(100)
)
GO

insert into DonNhap(idDonNhap,idNV,idNCC,TriGiaDon,NgayTao,TrangThai	)
values
('DN_01','NV_01','NCC_01',82400000,'1/15/2023',N'Đã nhận'),
('DN_02','NV_02','NCC_02',101400000,'5/17/2023',N'Đã nhận'),
('DN_03',NULL,'NCC_03',151540000,'10/23/2023',N'Chưa nhận');
GO

CREATE TABLE ChiTietDonNhap(
	idDonNhap nchar(10) CONSTRAINT FK_ChiTietDonNhap_DN FOREIGN KEY REFERENCES DonNhap(idDonNhap),
	SoLuong float NOT NULL,
	DonGia float NOT NULL,
	TongTien float NOT NULL,
	NgayNhap date,
	idDienThoai nchar(10) CONSTRAINT FK_ChiTietDonNhap_DT FOREIGN KEY REFERENCES DienThoai(idDienThoai),
	CONSTRAINT CK_CTDN CHECK (SoLuong > 0 AND DonGia > 0)
)
GO

insert into ChiTietDonNhap(idDonNhap,idDienThoai,SoLuong,DonGia,TongTien,NgayNhap)
values
('DN_01','DT_01',5,3090000,15450000,'1/22/2023'),
('DN_01','DT_02',5,13390000,66950000,'1/22/2023'),

('DN_02','DT_03',5,16690000,83450000,'5/27/2023'),
('DN_02','DT_06',3,3590000,17950000,'5/27/2023'),

('DN_03','DT_04',2,27790000,55580000,NUll),
('DN_03','DT_05',2,36990000,73980000,NUll),
('DN_03','DT_07',2,10990000,21980000,NUll);
