-- Xuất toàn bộ thông tin đăng nhập
SELECT * FROM LoginManager
GO

-- Xuất mật khẩu MD5 từ tài khoản admin
SELECT Password 
FROM LoginManager 
WHERE Username = N'admin'
GO

-- Xuất toàn bộ các gói có sẵn
SELECT * 
FROM ComboPack
GO

-- Xuất toàn bộ thông tin người dùng
SELECT * 
FROM UserInfo
GO

-- Xuất toàn bộ quản lý người dùng
SELECT *
FROM UserPurchasedPack
GO

-- Xuất toàn bộ quản lý người dùng (Tên thay cho ID)
SELECT B3.ID, B2.Name, B1.Name, B3.ComboRegDate, B3.ComboExpDate
FROM dbo.UserPurchasedPack AS B3
	INNER JOIN dbo.UserInfo AS B2 ON B3.UserID = B2.ID
	INNER JOIN dbo.ComboPack AS B1 ON B3.ComboID = B1.ID
GO
