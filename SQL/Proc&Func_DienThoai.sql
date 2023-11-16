CREATE or ALTER PROCEDURE proc_DienThoai_InsertOrUpdate -- DONE
    @idDienThoai nchar(10),
    @TenDienThoai nvarchar(255) = null,
    @TenHangDT nvarchar(255) = null,
    @MauSac nvarchar(255) = null,
    @DungLuong nvarchar(255) = null,
    @GiaBan float = null,
    @SoLuong float = null,
    @TinhTrang nvarchar(255) = null,
    @HinhAnh varbinary(max) = NULL 
AS
BEGIN
	IF(@TenDienThoai = '' OR @TenHangDT = '' OR @MauSac = '' OR @DungLuong = '')
	BEGIN
		RAISERROR (N'Kiểm tra thông tin điện thoại! ',16,1);
		RETURN
	END
	IF( @SoLuong < 0)
	BEGIN
		RAISERROR (N'Kiểm tra thông tin lại Số Lượng! ',16,1);
		RETURN
	END
	IF(@GiaBan <= 0)
	BEGIN
		RAISERROR (N'Kiểm tra thông tin lại Giá! ',16,1);
		RETURN
	END
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

CREATE OR ALTER PROCEDURE proc_DienThoai_Delete --DONE
(
    @idDienThoai NVARCHAR(max)
)
AS
BEGIN
	IF EXISTS (SELECT * FROM DienThoai WHERE idDienThoai = @idDienThoai AND SoLuong = 0)
	BEGIN
		IF NOT EXISTS (SELECT * FROM ChiTietDonNhap join DonNhap ON ChiTietDonNhap.idDonNhap = DonNhap.idDonNhap WHERE idDienThoai = @idDienThoai AND TrangThai = N'Chưa nhận')
		BEGIN
			IF EXISTS (SELECT * FROM ChiTietHoaDon join HoaDon ON ChiTietHoaDon.idHD = HoaDon.idHD WHERE ChiTietHoaDon.idDienThoai = @idDienThoai)
			BEGIN
				UPDATE DienThoai
				SET TrangThai = N'Ngừng Kinh Doanh'
				WHERE idDienThoai = @idDienThoai
			END
			ELSE
		    BEGIN
				DELETE FROM ChiTietDonNhap WHERE idDienThoai = @idDienThoai
				DELETE FROM DienThoai WHERE idDienThoai = @idDienThoai
			END
        END
        ELSE
        BEGIN
			RAISERROR('Điện Thoại đang được nhập về!', 16, 1);
			RETURN
        END
    END
    ELSE
    BEGIN
		RAISERROR('Điện Thoại này vẫn còn hàng!', 16, 1);
		RETURN
    END
END;
GO


CREATE or ALTER PROCEDURE proc_DienThoai_ThemGioHang -- DONE
(
	@idDienThoai nvarchar(max) = null,
	@SoLuong int = null
)
AS
BEGIN
	IF EXISTS ( SELECT * FROM DienThoai WHERE idDienThoai = @idDienThoai AND SoLuong = 0)
	BEGIN
		RAISERROR('Hết Hàng!', 16, 1);
		RETURN
	END;
	IF @idDienThoai is not null and @SoLuong > 0
	BEGIN
		DECLARE @so_luong_ton int;

		-- Lấy số lượng tồn kho của điện thoại
		SELECT @so_luong_ton = DienThoai.SoLuong
		FROM DienThoai
		WHERE idDienThoai = @idDienThoai;

		-- Kiểm tra nếu @so_luong lớn hơn số lượng tồn kho
		IF @SoLuong <= @so_luong_ton
		BEGIN
			-- Truy vấn thông tin sản phẩm nếu điều kiện hợp lệ
			SELECT DienThoai.idDienThoai, DienThoai.TenDienThoai, DienThoai.GiaBan, @SoLuong AS SoLuong
			FROM DienThoai
			WHERE DienThoai.idDienThoai = @idDienThoai;
		END;
		ELSE
		BEGIN
			RAISERROR('Vượt quá số lượng cho phép!', 16, 1);
			RETURN
		END;
	END;
	ELSE
	BEGIN
		RAISERROR('None', 16, 1);
		RETURN
	END;
END;
GO

------------ FUNCTION ----------------------
CREATE OR ALTER FUNCTION func_DienThoai_TK_TenDT -- DONE
(
	@ten_dt NVARCHAR(max) = null
)
RETURNS TABLE
AS 
RETURN
(
	SELECT *
	FROM DienThoai
	WHERE TenDienThoai LIKE '%' + @ten_dt + '%'
);
GO


CREATE OR ALTER FUNCTION func_DienThoai_TK_Hang_Gia -- DONE
(
	 @hang_dt NVARCHAR(max) = null,
	 @giaban NVARCHAR(max) = null
)
RETURNS TABLE
AS
RETURN
(
    WITH ResultTable AS
    (
        SELECT *
        FROM DienThoai
    )
    SELECT *
    FROM ResultTable
    WHERE
    (
        (@hang_dt IS NOT NULL AND @hang_dt != '' AND TenHangDT LIKE '%' + @hang_dt)
        OR
        @hang_dt = ''
    )
    AND
    (
        (
            @giaban = '< 10tr' AND GiaBan < 10000000
        )
        OR
        (
            @giaban = 'Từ 10tr - 25tr' AND GiaBan <= 25000000 AND GiaBan >= 10000000
        )
        OR
        (
            @giaban = '> 25tr' AND GiaBan > 25000000
        )
        OR
        @giaban = ''
    )
);
GO


CREATE OR ALTER FUNCTION func_DienThoai_idMAX()
RETURNS NCHAR(10)
AS
BEGIN
	DECLARE @maxId NCHAR(10)
	SELECT @maxId = MAX(idDienThoai) FROM DienThoai
	RETURN @maxId
END
GO
