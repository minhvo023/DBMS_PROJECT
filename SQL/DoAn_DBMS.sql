create database QuanLyCuaHangDienThoai

use QuanLyCuaHangDienThoai
go

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
	TrangThai nvarchar(max)
)
insert into DienThoai(idDienThoai,TenHangDT,TenDienThoai,SoLuong,MauSac,DungLuong,GiaBan,TrangThai)
values
('DT_01','Samsung','Samsung Galaxy A05',13,N'Đen huyền bí','128 GB',3090000,N'Còn hàng'),
('DT_02','Samsung','Samsung Galaxy S23 FE 5G',7,N'Trắng tinh khôi','128 GB',13390000,N'Còn hàng'),

('DT_03','Apple','iPhone 13',10,N'Hồng cánh sen','128 GB',16690000,N'Còn hàng'),
('DT_04','Apple','iPhone 15 Pro',5,N'Titan tự nhiên','128 GB',27790000,N'Còn hàng'),
('DT_05','Apple','iPhone 15 Pro',5,N'Titan đen','512 GB',36990000,N'Còn hàng'),

('DT_06','Xiaomi','Xiaomi Redmi 12',8,N'Bạc','128 GB',3590000,N'Còn hàng'),
('DT_07','Xiaomi','Xiaomi 13T 5G',5,N'Xanh Dương','256 GB',10990000,N'Còn hàng');


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
('DN_03','DT_07',NULL,2,10990000,21980000,NUll);