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
		RAISERROR (N'Bạn chưa nhập thông tin điện thoại! ',16,1);
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
	IF @SoLuong = 0
	BEGIN
		SET @TinhTrang = N'Hết hàng';
	END
	IF @SoLuong > 0
	BEGIN
		SET @TinhTrang = N'Còn hàng';
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
    IF NOT EXISTS (SELECT * FROM ChiTietDonNhap join DonNhap ON ChiTietDonNhap.idDonNhap = DonNhap.idDonNhap WHERE idDienThoai = @idDienThoai AND TrangThai = N'Chưa nhận')
    BEGIN
        IF EXISTS (SELECT * FROM DienThoai WHERE idDienThoai = @idDienThoai AND SoLuong = 0)
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
			RAISERROR('Điện Thoại này vẫn còn hàng!', 16, 1);
			RETURN
        END
    END
    ELSE
    BEGIN
        RAISERROR('Điện Thoại đang được nhập về!', 16, 1);
		RETURN
    END
END;
GO


CREATE or ALTER PROCEDURE proc_DienThoai_TK_Hang_Gia
(
	 @hang_dt NVARCHAR(max) = null,
	 @giaban NVARCHAR(max) = null
)
AS
BEGIN
	IF (@hang_dt != '' and @giaban != '')
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
		IF @hang_dt != ''
		BEGIN
			SELECT *
			FROM DienThoai
			WHERE TenHangDT LIKE '%' + @hang_dt
		END;

		ELSE IF @giaban != ''
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

CREATE or ALTER PROCEDURE proc_DienThoai_TK_TenDT -- DONE
(
	@ten_dt NVARCHAR(max) = null
)
AS 
BEGIN
	IF EXISTS (SELECT * FROM DienThoai WHERE TenDienThoai LIKE '%' + @ten_dt + '%')
	BEGIN
		SELECT *
		FROM DienThoai
		WHERE TenDienThoai LIKE '%' + @ten_dt + '%';
	END;
	ELSE
	BEGIN
		RAISERROR('Không tìm thấy!',16,1)
	END;
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