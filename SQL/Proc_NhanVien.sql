CREATE or ALTER PROCEDURE proc_NhanVien_ttct -- DONE
(
	@idNV nvarchar(max)
)
AS
BEGIN
	IF EXISTS (SELECT * FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV WHERE NhanVien.idNV = @idNV)
	BEGIN
        -- Lấy thông tin Nhân viên
        SELECT NhanVien.Ho_Ten, NhanVien.NgaySinh, NhanVien.GioiTinh, NhanVien.soDT_NV, NhanVien.DiaChi, NhanVien.TrangThai 
		FROM NhanVien WHERE NhanVien.idNV = @idNV

        -- Lấy thông tin công việc của nhân viên
        SELECT CongViec.idCV , CongViec.TenCV 
		FROM CongViec join NhanVien ON CongViec.idCV = NhanVien.idCV WHERE NhanVien.idNV = @idNV
	END;
END;
GO

CREATE or ALTER PROCEDURE proc_NhanVien_InsertOrUpdate
    @idNV nchar(10),
    @idCV nchar(10) = null,
    @Ho_Ten nvarchar(255),
    @DiaChi nvarchar(255),
    @soDT_NV nvarchar(20),
    @NgaySinh nvarchar(255),
    @GioiTinh nvarchar(255)
AS
BEGIN
    IF (@Ho_Ten = '' OR @DiaChi = '' OR @soDT_NV = '' OR @NgaySinh = '' OR @GioiTinh = '' OR @idCV is null)
    BEGIN
        RAISERROR (N'Bạn chưa nhập đầy đủ thông tin Nhân Viên!', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE idNV = @idNV)
    BEGIN
        -- Bản ghi nhân viên đã tồn tại, thực hiện UPDATE
        UPDATE NhanVien
        SET
            idCV = @idCV,
            Ho_Ten = @Ho_Ten,
            DiaChi = @DiaChi,
            soDT_NV = @soDT_NV,
            NgaySinh = @NgaySinh,
            GioiTinh = @GioiTinh
        WHERE idNV = @idNV;
    END
    ELSE
    BEGIN
        -- Bản ghi nhân viên chưa tồn tại, thực hiện INSERT
        INSERT INTO NhanVien (idNV, idCV, Ho_Ten, DiaChi, soDT_NV, NgaySinh, GioiTinh)
        VALUES (@idNV, @idCV, @Ho_Ten, @DiaChi, @soDT_NV, @NgaySinh, @GioiTinh);
    END;
END;
GO


CREATE or ALTER PROCEDURE proc_NhanVien_XoaNV --DONE
	@idNV NVARCHAR(255)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV WHERE idNV = @idNV AND TenCV = N'Quản lý')
	BEGIN
		UPDATE NhanVien SET TrangThai = 'Non-Active' WHERE idNV = @idNV;
	END;
	ELSE
	BEGIN
		RAISERROR('Không thể Xóa!',16,1);
	END;
END
GO
