USE [Projects - QLChungCu];
GO
ALTER TABLE DichVu ADD GiaTien DECIMAL(18, 0) NULL;
GO
-- 1. Tìm mã Hợp Đồng đang thuê của phòng C9.01
DECLARE @MaHopDong int;
SELECT TOP 1 @MaHopDong = MaHopDong 
FROM HopDong 
WHERE MaCanHo = 'C9.01' AND TrangThai = 1;

-- 2. Tìm mã Dịch Vụ (Ví dụ: "Phí Quản Lý"). 
-- Nếu bạn đặt tên khác (ví dụ "Gửi xe", "Vệ sinh") thì sửa lại chữ trong dấu nháy đơn '...'
DECLARE @MaDV int;
SELECT TOP 1 @MaDV = MaDV 
FROM DichVu 
WHERE TenDV = N'Phí Quản Lý'; 

-- (Nếu chưa có dịch vụ này thì tạo tạm để tránh lỗi)
IF @MaDV IS NULL
BEGIN
    INSERT INTO DichVu (TenDV) VALUES (N'Phí Quản Lý');
    SELECT @MaDV = SCOPE_IDENTITY();
END

-- 3. QUAN TRỌNG NHẤT: CHÈN GIÁ TIỀN VÀO BẢNG SỬ DỤNG
-- Đây chính là bước "khôi phục" dữ liệu bạn bảo đã nhập mà không hiện
IF @MaHopDong IS NOT NULL
BEGIN
    -- Kiểm tra xem đã có chưa, chưa có mới thêm
    IF NOT EXISTS (SELECT * FROM SuDungDichVu WHERE MaHopDong = @MaHopDong AND MaDV = @MaDV)
    BEGIN
        INSERT INTO SuDungDichVu (MaHopDong, MaDV, GiaTien)
        VALUES (@MaHopDong, @MaDV, 200000); -- <--- SỬA SỐ TIỀN Ở ĐÂY NẾU MUỐN
        
        PRINT N'Đã thêm thành công Phí Dịch Vụ vào Database!';
    END
    ELSE
    BEGIN
        -- Nếu có rồi thì cập nhật lại giá tiền cho đúng ý bạn
        UPDATE SuDungDichVu 
        SET GiaTien = 200000 -- <--- SỬA SỐ TIỀN Ở ĐÂY
        WHERE MaHopDong = @MaHopDong AND MaDV = @MaDV;
        
        PRINT N'Đã cập nhật lại giá tiền trong Database!';
    END
END
ELSE
BEGIN
    PRINT N'Lỗi: Phòng C9.01 hiện không có Hợp đồng nào đang hoạt động (TrangThai=1).';
END