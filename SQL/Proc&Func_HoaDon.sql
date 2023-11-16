
CREATE or ALTER PROCEDURE proc_HoaDon_Insert -- DONE
    @idHD nchar(10),
    @idNV nvarchar(255) = null,
    @idKH nvarchar(255) = null,
	@idDienThoai nvarchar(255) = null,
    @Ngay date,
    @TriGiaHD float = null,
    @TrangThai nvarchar(255) = N'Hoàn Thành',
    @SoLuong float = null,
    @DonGia float = null,
    @TongTien float = null
AS
BEGIN
	IF(@idNV = '')
	BEGIN
		RAISERROR (N'Bạn chưa nhập thông tin Nhân Viên! ',16,1);
		RETURN
	END
	IF(@idKH = '')
	BEGIN
		RAISERROR (N'Bạn chưa nhập thông tin Khách Hàng! ',16,1);
		RETURN
	END
	IF(@idDienThoai = '')
	BEGIN
		RAISERROR (N'Bạn chưa nhập thông tin Điện Thoại! ',16,1);
		RETURN
	END
	IF NOT EXISTS (SELECT * FROM HoaDon WHERE idHD = @idHD)
	BEGIN
		INSERT INTO HoaDon(idHD, idNV, idKH, Ngay, TriGiaHD, TrangThai)
        VALUES (@idHD, @idNV, @idKH, @Ngay, @TriGiaHD, @TrangThai);

		INSERT INTO ChiTietHoaDon(idHD, idDienThoai, SoLuong, DonGia, TongTien)
        VALUES (@idHD, @idDienThoai, @SoLuong, @DonGia, @TongTien);

		UPDATE DienThoai
		SET SoLuong = DienThoai.SoLuong - @SoLuong 
		WHERE idDienThoai = @idDienThoai
	END
    ELSE
    BEGIN
        -- Bản ghi đã tồn tại, thực hiện UPDATE
        UPDATE HoaDon
        SET
            idHD = @idHD,
            idNV = @idNV,
            idKH = @idKH,
            Ngay = @Ngay,
            TriGiaHD = @TriGiaHD,
            TrangThai = @TrangThai
        WHERE idHD = @idHD;

		INSERT INTO ChiTietHoaDon(idHD, idDienThoai, SoLuong, DonGia, TongTien)
        VALUES (@idHD, @idDienThoai, @SoLuong, @DonGia, @TongTien);

		UPDATE DienThoai
		SET SoLuong = DienThoai.SoLuong - @SoLuong
		WHERE idDienThoai = @idDienThoai
    END
END;
GO

CREATE or ALTER PROCEDURE proc_HoaDon_Delete --DONE  
(
	 @idHD nchar(10),
	 @PhanQuyen int
)
AS
BEGIN
	IF (@PhanQuyen = 1)
	BEGIN
		DELETE FROM HoaDon
		WHERE idHD = @idHD
	END
	ELSE
	BEGIN
		UPDATE HoaDon
		SET TrangThai = N'Đã Hủy'
		WHERE idHD = @idHD
	END
END
GO


CREATE OR ALTER PROCEDURE proc_HoaDon_ChiTietHoaDon --DONE
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


CREATE OR ALTER FUNCTION func_HoaDon_TK_DateVaTrangThai
(
    @Ngay NVARCHAR(max) = NULL,
	@Thang NVARCHAR(max) = NULL,
	@Nam NVARCHAR(max) = NULL,
	@TrangThai NVARCHAR(max) = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM HoaDon
    WHERE
        -- Kiểm tra theo Ngày
        (DAY(Ngay) = TRY_CAST(@Ngay AS INT) OR @Ngay = '')
        AND
        -- Kiểm tra theo Tháng
        (MONTH(Ngay) = TRY_CAST(@Thang AS INT) OR @Thang = '')
        AND
        -- Kiểm tra theo Năm
        (YEAR(Ngay) = TRY_CAST(@Nam AS INT) OR @Nam = '')
		AND
		-- Kiểm tra theo Trạng thái
        (@TrangThai = N'Tất Cả' OR TrangThai = @TrangThai OR @TrangThai IS NULL)

);
GO


CREATE OR ALTER FUNCTION func_HoaDon_idMAX()
RETURNS NCHAR(10)
AS
BEGIN
	DECLARE @maxId NCHAR(10)
	SELECT @maxId = MAX(idHD) FROM HoaDon
	RETURN @maxId
END
GO


CREATE OR ALTER FUNCTION func_HoaDon_TongSL
(
	@idHD nchar(10)
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @TongSL INT
	SELECT @TongSL = SUM(SoLuong)
	FROM ChiTietHoaDon WHERE idHD = @idHD
	RETURN @TongSL
END
GO
