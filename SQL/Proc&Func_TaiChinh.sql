CREATE OR ALTER PROCEDURE proc_HienThiThongTin
(
    @idNV nvarchar(max) = null, -- ID của nhân viên
    @thang int = null, -- Tháng cần tính lương (ví dụ: 11)
    @thangHD int = null, -- Tháng cần tính tổng hóa đơn (ví dụ: 11)
    @thangDN int = null -- Tháng cần tính tổng đơn nhập (ví dụ: 11)
)
AS
BEGIN
	IF @thang != ''
    BEGIN
        SELECT NgayLam, Ho_Ten, idCa, TrangThai
        FROM v_phancong
        WHERE (MONTH(NgayLam) = TRY_CAST(@Thang AS INT) OR @Thang = '') AND idNV = @idNV;
    END
    ELSE IF @thangHD != ''
    BEGIN
        SELECT * FROM HoaDon WHERE (MONTH(Ngay) = TRY_CAST(@thangHD AS INT) OR @thangHD = '');
    END
    ELSE IF @thangDN != ''
    BEGIN
        SELECT * FROM DonNhap WHERE (MONTH(NgayTao) = TRY_CAST(@thangDN AS INT) OR @thangDN = '');
    END
	ELSE
	BEGIN
		SELECT null;
	END
END
GO

CREATE OR ALTER FUNCTION func_TongSo
(
    @idNV nvarchar(max) = null, -- ID của nhân viên
    @thangNV int = null, -- Tháng cần tính lương ví dụ 11
	@thangHD int = null,
    @thangDN int = null 

)
RETURNS INT -- Điều này tùy thuộc vào định dạng lương của bạn
AS
BEGIN
    DECLARE @Tong INT
	DECLARE @thangDateNV date
	DECLARE @thangDateHD date
	DECLARE @thangDateDN date


    IF (@thangNV != '')
	BEGIN
	    SET @thangDateNV = CAST(CONVERT(varchar(4), YEAR(GETDATE())) + '-' + CAST(@thangNV AS nvarchar(2)) + '-01' AS date)

		SELECT @Tong = count(idCa)
		FROM CongViec
		join NhanVien ON CongViec.idCV = NhanVien.idCV
		join BangPhanCa On NhanVien.idNV = BangPhanCa.idNV
		WHERE NhanVien.idNV = @idNV
		AND BangPhanCa.NgayLam >= @thangDateNV
		AND BangPhanCa.NgayLam < DATEADD(MONTH, 1, @thangDateNV);

		RETURN @Tong;
	END
	ELSE IF (@thangHD != '')
	BEGIN
		SET @thangDateHD = CAST(CONVERT(varchar(4), YEAR(GETDATE())) + '-' + CAST(@thangHD AS nvarchar(2)) + '-01' AS date)
		SELECT @Tong = count(idHD)
		FROM HoaDon
		WHERE 
		HoaDon.Ngay >= @thangDateHD AND
		HoaDon.Ngay < DATEADD(MONTH, 1, @thangDateHD);

		RETURN @Tong;
	END
	ELSE IF (@thangDN != '')
	BEGIN
	    SET @thangDateDN = CAST(CONVERT(varchar(4), YEAR(GETDATE())) + '-' + CAST(@thangDN AS nvarchar(2)) + '-01' AS date)
		SELECT @Tong = count(idDonNhap)
		FROM DonNhap
		WHERE 
		DonNhap.NgayTao >= @thangDateDN AND
		DonNhap.NgayTao < DATEADD(MONTH, 1, @thangDateDN) AND DonNhap.TrangThai = N'Đã Nhận';

		RETURN @Tong;
	END
	RETURN 0;
END
GO


CREATE OR ALTER FUNCTION func_TinhLuong_HD_DN
(
    @idNV nvarchar(max) = null, -- ID của nhân viên
    @thang int = null, -- Tháng cần tính lương (ví dụ: 11)
    @thangHD int = null, -- Tháng cần tính tổng hóa đơn (ví dụ: 11)
    @thangDN int = null -- Tháng cần tính tổng đơn nhập (ví dụ: 11)
)
RETURNS decimal(18, 0) -- Điều này tùy thuộc vào định dạng lương của bạn
AS
BEGIN
    DECLARE @result decimal(18, 0);

    -- Check for the case of calculating salary
    IF (@thang != '')
    BEGIN
        DECLARE @luong decimal(18, 2)
        DECLARE @thangDate date

        -- Chuyển đổi giá trị tháng (int) thành ngày đầu tháng
        SET @thangDate = CAST(CONVERT(varchar(4), YEAR(GETDATE())) + '-' + CAST(@thang AS nvarchar(2)) + '-01' AS date)

        SELECT @luong = COUNT(idCa) * 6 * (
                SELECT LuongTheoGio
                FROM CongViec
                JOIN NhanVien ON CongViec.idCV = NhanVien.idCV
                WHERE NhanVien.idNV = @idNV
            )
        FROM CongViec
        JOIN NhanVien ON CongViec.idCV = NhanVien.idCV
        JOIN BangPhanCa ON NhanVien.idNV = BangPhanCa.idNV
        WHERE NhanVien.idNV = @idNV
            AND BangPhanCa.NgayLam >= @thangDate
            AND BangPhanCa.NgayLam < DATEADD(MONTH, 1, @thangDate);

        SET @result = @luong;
    END
    -- Check for the case of calculating total from HoaDon
    ELSE IF (@thangHD  != '')
    BEGIN
        DECLARE @thangDateHD date

        -- Chuyển đổi giá trị tháng (int) thành ngày đầu tháng
        SET @thangDateHD = CAST(CONVERT(varchar(4), YEAR(GETDATE())) + '-' + CAST(@thangHD AS nvarchar(2)) + '-01' AS date)

        SELECT @result = SUM(TriGiaHD)
        FROM HoaDon
        WHERE HoaDon.Ngay >= @thangDateHD
            AND HoaDon.Ngay < DATEADD(MONTH, 1, @thangDateHD);
    END
    -- Check for the case of calculating total from DonNhap
    ELSE IF (@thangDN  != '')
    BEGIN
        DECLARE @thangDateDN date

        -- Chuyển đổi giá trị tháng (int) thành ngày đầu tháng
        SET @thangDateDN = CAST(CONVERT(varchar(4), YEAR(GETDATE())) + '-' + CAST(@thangDN AS nvarchar(2)) + '-01' AS date)

        SELECT @result = SUM(TriGiaDon)
        FROM DonNhap
        WHERE DonNhap.NgayTao >= @thangDateDN
            AND DonNhap.NgayTao < DATEADD(MONTH, 1, @thangDateDN)
            AND DonNhap.TrangThai = N'Đã Nhận';
    END
    ELSE
    BEGIN
        SET @result = 0; -- Default value when no case matches
    END

    RETURN @result;
END;
GO
