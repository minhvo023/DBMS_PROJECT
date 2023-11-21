-- Tạo trigger INSTEAD OF DELETE trên bảng HoaDon
CREATE or ALTER TRIGGER HoaDon_InsteadOfDelete --DONE
ON HoaDon
INSTEAD OF DELETE
AS
BEGIN
    -- Tạo bảng tạm thời lưu danh sách các id của hóa đơn bị xóa
    DECLARE @DeletedHD TABLE (idHD nchar(10));

    -- Lấy danh sách các id của hóa đơn bị xóa và lưu vào bảng tạm thời
    INSERT INTO @DeletedHD (idHD)
    SELECT idHD FROM deleted;

    -- Cập nhật lại số lượng bảng điện thoại bằng truy vấn lồng nhau
    UPDATE DienThoai
    SET SoLuong = DienThoai.SoLuong + D.SoLuong
    FROM DienThoai
    INNER JOIN (
        SELECT idHD, idDienThoai, SUM(SoLuong) AS SoLuong
        FROM ChiTietHoaDon
        WHERE idHD IN (SELECT idHD FROM @DeletedHD)
        GROUP BY idHD, idDienThoai
    ) AS D ON DienThoai.idDienThoai = D.idDienThoai;

	-- Tiếp theo, xóa chi tiết hóa đơn liên quan
    DELETE FROM ChiTietHoaDon
	WHERE idHD IN (SELECT idHD FROM @DeletedHD);

    -- Tiếp theo, xóa hóa đơn
    DELETE FROM HoaDon
    WHERE idHD IN (SELECT idHD FROM @DeletedHD);
END; 
GO


CREATE or ALTER TRIGGER KhachHang_KiemTra_TenKH_sdtKH --DONE
ON KhachHang
AFTER INSERT
AS
BEGIN
	IF EXISTS ( SELECT * FROM inserted i WHERE EXISTS (SELECT *FROM KhachHang k WHERE k.TenKH = i.TenKH AND k.idKH <> i.idKH))
	BEGIN
	-- Nếu trùng thì rollback
		ROLLBACK;
		RAISERROR('Tên Khách Hàng đã tồn tại!', 16,1)
	END
	IF EXISTS ( SELECT * FROM inserted i WHERE EXISTS (SELECT *FROM KhachHang k WHERE k.soDT_KH = i.soDT_KH AND k.idKH <> i.idKH))
	BEGIN
	-- Nếu trùng thì rollback
		ROLLBACK;
		RAISERROR('Số Điện Thoại Khách Hàng đã tồn tại!', 16,1)
	END
END
GO


CREATE OR ALTER TRIGGER NhanVien_KiemTra_Tuoi
ON NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS ( SELECT 1 FROM inserted i WHERE DATEDIFF(YEAR, CAST(i.NgaySinh AS DATE), GETDATE()) < 18)
    BEGIN
        -- Nếu tuổi nhân viên dưới 18, thực hiện ROLLBACK và hiển thị thông báo lỗi
        ROLLBACK;
        RAISERROR('Nhân Viên phải lớn hơn hoặc bằng 18 tuổi!', 16, 1);
    END
	-- Kiểm tra số điện thoại nhân viên
    IF EXISTS ( SELECT 1 FROM inserted i WHERE LEN(i.soDT_NV) <> 10 )
    BEGIN
        -- Nếu số điện thoại không có đúng 10 số, thực hiện ROLLBACK và hiển thị thông báo lỗi
        ROLLBACK;
        RAISERROR('Số Điện Thoại Nhân Viên sai định dạng!', 16, 1);
    END
END;
GO

CREATE OR ALTER TRIGGER NhanVien_CapNhap_TrangThai_MatKhau
ON NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM NhanVien INNER JOIN inserted i ON NhanVien.idNV = i.idNV WHERE i.TrangThai IS NULL OR NhanVien.TrangThai = N'Non-Active')
    BEGIN
		UPDATE NhanVien
		SET TrangThai = N'Active', MatKhau = '123456'
		FROM NhanVien
		INNER JOIN inserted i ON NhanVien.idNV = i.idNV
	END
	ELSE IF EXISTS (SELECT * FROM NhanVien INNER JOIN inserted i ON NhanVien.idNV = i.idNV WHERE NhanVien.MatKhau is not null)
    BEGIN
        UPDATE NhanVien
        SET MatKhau = i.MatKhau
        FROM NhanVien
        INNER JOIN inserted i ON NhanVien.idNV = i.idNV;
    END
	ELSE
	BEGIN
		UPDATE NhanVien
		SET TrangThai = N'Non-Active', MatKhau = NULL
		FROM NhanVien
		INNER JOIN inserted i ON NhanVien.idNV = i.idNV


		DECLARE @userName nvarchar(10);
		SET @userName = (SELECT idNV FROM inserted);
		-- Drop user
        EXEC('DROP USER ' + @userName);

        -- Drop login
        EXEC('DROP LOGIN ' + @userName);
	END
END;
GO


CREATE OR ALTER TRIGGER DienThoai_KiemTra_TrangThai --DONE
ON DienThoai
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra nếu có ít nhất một bản ghi có TrangThai là 'Ngừng Kinh Doanh'
    IF EXISTS (SELECT 1 FROM inserted WHERE TrangThai = N'Ngừng Kinh Doanh')
    BEGIN
        UPDATE DienThoai
        SET TrangThai = N'Ngừng Kinh Doanh'
        FROM DienThoai
        INNER JOIN inserted ON DienThoai.idDienThoai = inserted.idDienThoai
        WHERE inserted.TrangThai = N'Ngừng Kinh Doanh';
    END
    ELSE
    BEGIN
        -- Kiểm tra nếu có ít nhất một bản ghi có SoLuong > 0
        IF EXISTS (SELECT 1 FROM inserted WHERE SoLuong > 0)
        BEGIN
            UPDATE DienThoai
            SET TrangThai = N'Còn hàng'
            FROM DienThoai
            INNER JOIN inserted ON DienThoai.idDienThoai = inserted.idDienThoai
            WHERE inserted.SoLuong > 0;
        END
        ELSE
        BEGIN
			UPDATE DienThoai
            SET TrangThai = N'Hết hàng'
            FROM DienThoai
            INNER JOIN inserted ON DienThoai.idDienThoai = inserted.idDienThoai;
        END
    END
END
GO


CREATE OR ALTER TRIGGER NhanVien_TaoTaiKhoanSQL ON NhanVien
AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON;

    DECLARE @userName nchar(10), @passWord nchar(15), @idNV nchar(10), @idCV nchar(10);
    DECLARE @sqlString nvarchar(2000);

    -- Create a cursor to iterate over the inserted rows
    DECLARE cursorNhanVien CURSOR FOR
        SELECT idNV FROM inserted;

    OPEN cursorNhanVien;

    -- Fetch the first row from the cursor
    FETCH NEXT FROM cursorNhanVien INTO @idNV;

    -- Loop through the cursor
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Generate unique username based on idNV
        SET @userName = @idNV;

        -- Create login
        SET @sqlString = 'CREATE LOGIN [' + @userName + '] WITH PASSWORD=''123456'', DEFAULT_DATABASE=[QuanLyCuaHangDienThoai], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF';
        EXEC (@sqlString);

        -- Create user
        SET @sqlString = 'CREATE USER ' + @userName + ' FOR LOGIN ' + @userName;
        EXEC (@sqlString);

        -- Get idCV for role assignment
        SELECT @idCV = idCV FROM NhanVien WHERE idNV = @idNV;

        -- Assign role based on idCV
        IF (@idCV = 'CV_03')
            SET @sqlString = 'ALTER SERVER ROLE sysadmin ADD MEMBER ' + @userName;
        ELSE  
            SET @sqlString = 'ALTER ROLE NhanVien ADD MEMBER ' + @userName;

        -- Execute role assignment
        EXEC (@sqlString);

        -- Fetch the next row from the cursor
        FETCH NEXT FROM cursorNhanVien INTO @idNV;
    END;

    -- Close and deallocate the cursor
    CLOSE cursorNhanVien;
    DEALLOCATE cursorNhanVien;
END;
