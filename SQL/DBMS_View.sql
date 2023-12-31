CREATE or ALTER VIEW v_hoadon
AS
SELECT DISTINCT  HoaDon.idHD,ChiTietHoaDon.idKH,HoaDon.Ngay, HoaDon.TriGiaHD, HoaDon.TrangThai 
FROM HoaDon join ChiTietHoaDon
ON HoaDon.idHD = ChiTietHoaDon.idHD
go

CREATE or ALTER VIEW v_dienthoai
AS
SELECT * FROM DienThoai
go

CREATE or ALTER VIEW v_khachhang
AS
SELECT * FROM KhachHang
go


CREATE or ALTER VIEW v_nhanvien
AS
SELECT NhanVien.idNV, NhanVien.Ho_Ten, NhanVien.soDT_NV, CongViec.TenCV
FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV

