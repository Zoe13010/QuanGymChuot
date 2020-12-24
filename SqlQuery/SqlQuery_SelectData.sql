-- Xuất toàn bộ thông tin đăng nhập
SELECT * FROM ThongTinDangNhap
GO

-- Xuất mật khẩu MD5 từ tài khoản admin
SELECT Password 
FROM ThongTinDangNhap 
WHERE Username = N'admin'
GO

-- Xuất toàn bộ các gói có sẵn
SELECT * 
FROM GoiDichVu
GO

-- Xuất toàn bộ thông tin người dùng
SELECT * 
FROM ThongTinNguoiDung
GO

-- Xuất toàn bộ quản lý người dùng
SELECT *
FROM QuanLyGiaoDich
GO

-- Xuất toàn bộ quản lý người dùng (Tên thay cho ID)
SELECT B3.ID, B2.Name, B1.Name, B3.ComboRegDate, B3.ComboExpDate
FROM dbo.QuanLyGiaoDich AS B3
	INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID
	INNER JOIN dbo.GoiDichVu AS B1 ON B3.ComboID = B1.ID
GO
