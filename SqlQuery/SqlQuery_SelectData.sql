USE QuanGymChuot
GO

-- Xuất toàn bộ thông tin đăng nhập
SELECT * FROM ThongTinDangNhap
GO

-- Xuất MD5 của mật khẩu từ tài khoản admin
SELECT Username, Password 
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

-- Xuất toàn bộ quản lý người dùng (bảng gốc)
SELECT *
FROM QuanLyGiaoDich
GO

-- Xuất toàn bộ quản lý người dùng (thông tin cần thiết)
SELECT B3.ID AS PaymentID,
	   B2.ID AS UserID,
	   B2.Name AS UserName,
	   B1.ID AS PackID,
	   B1.Name AS PackName,
	   B3.PackRegDate AS PackRegDate,
	   B3.PackExpDate AS PackExpDate,
	   CASE WHEN (B3.PackExpDate > GETDATE()) THEN 0 ELSE 1 END AS Expired,
	   B3.Note AS Note
FROM dbo.QuanLyGiaoDich AS B3
INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID
INNER JOIN dbo.GoiDichVu AS B1 ON B3.PackID = B1.ID
ORDER BY B3.PackRegDate DESC
WHERE B2.Name LIKE '%Name%'
GO

USE QuanGymChuot UPDATE QuanLyGiaoDich SET UserID = 1, PackID = 2 WHERE UserID = 1
GO

SELECT ID AS PaymentID
FROM dbo.QuanLyGiaoDich
WHERE UserID = 3 AND PackExpDate > GETDATE()
GO
