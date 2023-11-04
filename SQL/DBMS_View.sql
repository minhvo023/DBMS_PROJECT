

CREATE or ALTER VIEW v_khachhang
AS
SELECT * FROM KhachHang
go


CREATE or ALTER VIEW v_nhanvien
AS
SELECT NhanVien.idNV, NhanVien.Ho_Ten, NhanVien.soDT_NV, CongViec.TenCV
FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV

