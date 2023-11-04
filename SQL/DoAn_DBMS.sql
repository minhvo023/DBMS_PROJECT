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
('cv01','Nhân viên bán hàng', 8000000),
('cv02','Nhân viên kỹ thuật', 9000000),
('cv03','Quản lý', 12000000);

CREATE TABLE CaLamViec(
	idCa nchar(10),
	Gio_BatDau time NOT NULL,
	Gio_KetThuc time NOT NUll,
	CHECK (Gio_KetThuc > Gio_BatDau),
	CONSTRAINT PK_CaLamViec PRIMARY KEY (idCa)
)
insert into CaLamViec(idCa,Gio_BatDau,Gio_KetThuc)
values
('ca01','9:00','15:00'),
('ca02','15:00','21:00');

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
('nv01','cv01',N'Nguyễn Văn A', '1999-10-10','abc','Nam','0345678927'),
('nv02','cv01',N'Nguyễn Thị C', '2000-7-8','htd','Nữ','0346895782'),

('nv03','cv02',N'Trần Văn B', '2000-1-18','bcd','Nam','0345457489'),
('nv04','cv02',N'Lê văn L', '2002-1-27','aeg','Nam','0386794759'),

('nv05','cv03',N'Boss', '1997-3-21','vvv','Nam','0999999999');



CREATE TABLE BangPhanCa(
	idCa nchar(10),
	idNV nchar(10) CONSTRAINT FK_BangPhanCa_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	NgayLam date NOT NULL,
	CONSTRAINT PK_BangPhanCa PRIMARY KEY (idCa, idNV, NgayLam),
	CONSTRAINT FK_BangPhanCa_Ca FOREIGN KEY (idCa) REFERENCES CalamViec(idCa)
)
insert into BangPhanCa(idCa,idNV,NgayLam)
values
('ca01','nv01','2023-11-1'),
('ca01','nv02','2023-11-1'),
('ca01','nv03','2023-11-1'),
('ca01','nv04','2023-11-1'),

('ca02','nv01','2023-11-1'),
('ca02','nv02','2023-11-1'),
('ca02','nv03','2023-11-1'),
('ca02','nv04','2023-11-1'),

('ca01','nv01','2023-11-2'),
('ca01','nv02','2023-11-2'),
('ca01','nv03','2023-11-2'),
('ca01','nv04','2023-11-2'),

('ca02','nv01','2023-11-2'),
('ca02','nv02','2023-11-2'),
('ca02','nv03','2023-11-2'),
('ca02','nv04','2023-11-2'),

('ca01','nv01','2023-11-3'),
('ca01','nv02','2023-11-3'),
('ca01','nv03','2023-11-3'),
('ca01','nv04','2023-11-3'),

('ca02','nv01','2023-11-3'),
('ca02','nv02','2023-11-3'),
('ca02','nv03','2023-11-3'),
('ca02','nv04','2023-11-3');

CREATE TABLE KhachHang(
	idKH nchar(10) CONSTRAINT PK_KhachHang PRIMARY KEY,
	TenKH nvarchar(100) NOT NULL,
	soDT_KH nchar(11) NOT NULL check (len(soDT_KH) = 10),
	DiaChi nvarchar(100)
)
insert into KhachHang(idKH,TenKH,soDT_KH, DiaChi)
values 
('kh01','Ngô Thị D','0382357983','ahe'),
('kh02','Bá Văn T','0382236793','tyhe');


CREATE TABLE HoaDon(
	idHD nchar(10) CONSTRAINT PK_HoaDon PRIMARY KEY,
	TrangThai nvarchar(100) NOT NULL,
	Ngay date NOT NULL,
	TriGiaHD float 
)


insert into HoaDon(idHD,Ngay,TriGiaHD,TrangThai)
values
('hd01','Đã thanh toán','2023-11-1',26780000),
('hd02','Đã thanh toán','2023-11-3', 36990000);


CREATE TABLE HangDienThoai(
	TenHangDT nvarchar(100) CONSTRAINT PK_HangDienThoai PRIMARY KEY,
	NguonGoc nvarchar(100) NOT NULL,
	TinhTrang nvarchar(100) NOT NULL
)
insert into HangDienThoai(TenHangDT,NguonGoc,TinhTrang)
values
('Samsung','Hàn Quốc','Đang hoạt động'),
('Apple','Mỹ','Đang hoạt động'),
('Xiaomi','Trung Quốc','Đang hoạt động');

CREATE TABLE DienThoai(
	idDienThoai nchar(10) CONSTRAINT PK_DienThoai PRIMARY KEY,
	TenHangDT nvarchar(100) CONSTRAINT FK_DienThoai_HangDT FOREIGN KEY REFERENCES HangDienThoai(TenHangDT),
	TenDienThoai nvarchar(100) NOT NULL,
	SoLuong float NOT NULL,
	MauSac nvarchar(30) NOT NULL,
	DungLuong nchar(10) NOT NULL,
	GiaBan float NOT NULL CHECK (GiaBan > 0)
)
insert into DienThoai(idDienThoai,TenHangDT,TenDienThoai,SoLuong,MauSac,DungLuong,GiaBan)
values
('dt01','Samsung','Samsung Galaxy A05',13,'Đen huyền bí','128 GB',3090000),
('dt02','Samsung','Samsung Galaxy S23 FE 5G',7,'Trắng tinh khôi','128 GB',13390000),

('dt03','Apple','iPhone 13',10,'Hồng cánh sen','128 GB',16690000),
('dt04','Apple','iPhone 15 Pro',5,'Titan tự nhiên','128 GB',27790000),
('dt05','Apple','iPhone 15 Pro',5,'Titan đen','512 GB',36990000),

('dt06','Xiaomi','Xiaomi Redmi 12',8,'Bạc','128 GB',3590000),
('dt07','Xiaomi','Xiaomi 13T 5G',5,'Xanh Dương','256 GB',10990000);


CREATE TABLE ChiTietHoaDon(
	idHD nchar(10) CONSTRAINT FK_ChiTietHoaDon_HD FOREIGN KEY REFERENCES HoaDon(idHD),
	idDienThoai nchar(10) CONSTRAINT FK_ChiTietHoaDon_DT FOREIGN KEY REFERENCES DienThoai(idDienThoai),
	idNV nchar(10) CONSTRAINT FK_ChiTietHoaDon_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	idKH nchar(10) CONSTRAINT FK_ChiTietHoaDon_KH FOREIGN KEY REFERENCES KhachHang(idKH),
	SoLuong float NOT NULL CHECK (SoLuong > 0),
	DonGia float NOT NULL,
	TongTien float NOT NULL,
	CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (idHD,idDienThoai)
)

insert into ChiTietHoaDon(idHD,idDienThoai,SoLuong,DonGia,TongTien)
values 
('hd01','dt02','nv01','kh01',2,13390000,26780000),
('hd02','dt05','nv02','kh02',1,36990000,36990000);


CREATE TABLE NhaCungCap(
	idNCC nchar(10) CONSTRAINT PK_NhaCungCung PRIMARY KEY,
	TenNCC nvarchar(100) NOT NULL,
	soDT_NCC nchar(11) NOT NULL check (len(soDT_NCC) = 10),
	DiaChiNCC nvarchar(100) NOT NULL
)
insert into NhaCungCap(idNCC,TenNCC,soDT_NCC,DiaChiNCC)
values
('ncc01','FPT Tradinh','0283510010','erh'),
('ncc02','DGW','0355351001','oah'),
('ncc03','PET','0995051001','hdi');

CREATE TABLE DonNhap(
	idDonNhap nchar(10) CONSTRAINT PK_DonNhap PRIMARY KEY,
	idNCC nchar(10) CONSTRAINT FK_DonNhap_NCC FOREIGN KEY REFERENCES NhaCungCap(idNCC),
	TriGiaDon float NOT NULL CHECK (TriGiaDon > 0),
	NgayTao date NOT NULL
)
insert into DonNhap(idDonNhap,idNCC,TriGiaDon,NgayTao)
values
('dn01','ncc01',82400000,'2023-1-15'),
('dn02','ncc02',101400000,'2023-5-17'),
('dn03','ncc03',151540000,'2023-10-23');


CREATE TABLE ChiTietDonNhap(
	idDonNhap nchar(10) CONSTRAINT FK_ChiTietDonNhap_DN FOREIGN KEY REFERENCES DonNhap(idDonNhap),
	idNV nchar(10) CONSTRAINT FK_ChiTietDonNhap_NV FOREIGN KEY REFERENCES NhanVien(idNV),
	SoLuong float NOT NULL CHECK(SoLuong > 0),
	DonGia float NOT NULL,
	TongTien float NOT NULL,
	NgayNhap date,
	TrangThai nvarchar(100) NOT NULL,
	idDienThoai nchar(10) CONSTRAINT FK_ChiTietDonNhap_DT FOREIGN KEY REFERENCES DienThoai(idDienThoai)
	ON UPDATE CASCADE
)
GO

insert into ChiTietDonNhap(idDonNhap,idDienThoai,idNV,SoLuong,DonGia,TongTien,NgayNhap,TrangThai)
values
('dn01','dt01','nv01',5,3090000,15450000,'2023-1-22','Đã nhận'),
('dn01','dt02','nv01',5,13390000,66950000,'2023-1-22','Đã nhận'),

('dn02','dt03','nv02',5,16690000,83450000,'2023-5-27','Đã nhận'),
('dn02','dt06','nv02',3,3590000,17950000,'2023-5-27','Đã nhận'),

('dn03','dt04',NULL,2,27790000,55580000,NUll,'Chưa nhận'),
('dn03','dt05',NULL,2,36990000,73980000,NUll,'Chưa nhận'),
('dn03','dt07',NULL,2,10990000,21980000,NUll,'Chưa nhận');