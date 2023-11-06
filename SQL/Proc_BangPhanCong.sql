CREATE OR ALTER PROCEDURE proc_BangPhanCa_TK_date
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
