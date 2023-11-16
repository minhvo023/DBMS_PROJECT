CREATE OR ALTER PROCEDURE proc_PhanCa_Insert
(
    @NgayLam date,
    @idCa NCHAR(10) = NULL,
    @idNV NCHAR(10) = NULL
)
AS
BEGIN
    -- Kiểm tra xem các tham số có giá trị không
    IF @NgayLam IS NOT NULL AND @idCa IS NOT NULL AND @idNV IS NOT NULL
    BEGIN
        -- Kiểm tra xem NgayLam có ở tương lai không
        IF CONVERT(DATE, @NgayLam, 103) > CONVERT(DATE, GETDATE(), 103)
        BEGIN
            -- Thực hiện chèn dữ liệu vào bảng
            INSERT INTO BangPhanCa(NgayLam, idCa, idNV)
            VALUES (@NgayLam, @idCa, @idNV);

            -- Nếu bạn muốn trả về giá trị nào đó, bạn có thể thêm câu lệnh SELECT tại đây
            -- SELECT @@IDENTITY AS 'InsertedID';

            -- Hoặc có thể không cần câu lệnh SELECT nếu không cần trả về giá trị
        END
        ELSE
        BEGIN
            -- Xử lý trường hợp NgayLam không ở tương lai
            RAISERROR('Không thể thêm ca vào ngày ở quá khứ! Vui lòng chọn lại!', 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Xử lý trường hợp các tham số không hợp lệ
        RAISERROR('Các tham số không được để trống.', 16, 1);
    END
END;
GO


CREATE OR ALTER PROCEDURE proc_PhanCa_DiemDanh
(
	
)
AS
BEGIN
    DECLARE @NgayLam DATE;
    SET @NgayLam = GETDATE();

    UPDATE BangPhanCa
    SET TrangThai = N'Done'
    WHERE BangPhanCa.NgayLam = @NgayLam;
END;
GO


CREATE OR ALTER FUNCTION func_PhanCa_TK_Date_Ca
(
    @Ngay NVARCHAR(max) = NULL,
	@Thang NVARCHAR(max) = NULL,
	@Nam NVARCHAR(max) = NULL,
	@CaLam nchar(10) = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT v_phancong.NgayLam, v_phancong.Ho_Ten,v_phancong.idCa,  v_phancong.TrangThai
    FROM v_phancong
    WHERE 
        -- Kiểm tra theo Ngày
        (DAY(NgayLam) = TRY_CAST(@Ngay AS INT) OR @Ngay = '')
        AND
        -- Kiểm tra theo Tháng
        (MONTH(NgayLam) = TRY_CAST(@Thang AS INT) OR @Thang = '')
        AND
        -- Kiểm tra theo Năm
        (YEAR(NgayLam) = TRY_CAST(@Nam AS INT) OR @Nam = '')
		AND
		(idCa = @CaLam)

);
GO


