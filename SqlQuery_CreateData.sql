USE QuanGymChuot
GO

-- Tạo dữ liệu mẫu từ bảng ComboPack
-- (các gói có thể mua)
DELETE FROM ComboPack
GO
INSERT INTO ComboPack (Name, Price, DayCount, Info)
VALUES ('Gói 3 ngày', 5000, 3, '(no more information)')
GO
INSERT INTO ComboPack (Name, Price, DayCount, Info)
VALUES ('Gói 7 ngày', 15000, 7, '(no more information)')
GO
INSERT INTO ComboPack (Name, Price, DayCount, Info)
VALUES ('Gói 1 tháng (30 ngày)', 50000, 30, '(no more information)')
GO
INSERT INTO ComboPack (Name, Price, DayCount, Info)
VALUES ('Gói 3 tháng (90 ngày)', 150000, 90, '(no more information)')
GO

-- Tạo dữ liệu mẫu từ bảng UserInfo
-- (người dùng đã đăng ký)
DELETE FROM UserInfo
GO
INSERT INTO UserInfo (Name, Gender, Phone)
VALUES ('Name 1', 1, '0123456789')
GO
INSERT INTO UserInfo (Name, Gender, Phone)
VALUES ('Name 2', 0, '0321323219')
GO
INSERT INTO UserInfo (Name, Gender, Phone)
VALUES ('Name 3', 1, '0382858284')
GO

-- Tạo dữ liệu mẫu từ bảng UserPurchasedPack
-- (các gói mà khách hàng đã mua)
-- Lưu ý: Kiểm tra lại UserID, ComboID để sửa lại truy vấn mẫu này nếu lỗi.
DELETE FROM UserPurchasedPack
GO
INSERT INTO UserPurchasedPack (UserID, ComboID)
VALUES (16, 20)
GO
INSERT INTO UserPurchasedPack (UserID, ComboID)
VALUES (17, 21)
GO
INSERT INTO UserPurchasedPack (UserID, ComboID)
VALUES (18, 22)
GO

-- Tạo dữ liệu mẫu từ bảng LoginManager
-- (tài khoản đăng nhập)
INSERT INTO LoginManager (Username, Password)
-- Tài khoản: admin, mật khẩu: admin
VALUES (N'admin', '21232f297a57a5a743894a0e4a801fc3')
GO

-- Các truy vấn lỗi để check Trigger UserInfo_Check_Add
--  + Check dưới 10 chữ số
INSERT INTO UserInfo (Name, Phone, Gender)
VALUES ('123', '012345678', 1)
GO
--  + Check trên 11 chữ số
INSERT INTO UserInfo (Name, Phone, Gender)
VALUES ('123', '012345678901', 1)
GO
--  + Check không có chữ số 0 ở đầu
INSERT INTO UserInfo (Name, Phone, Gender)
VALUES ('123', '1234567890', 1)
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng LoginManager
DELETE FROM LoginManager
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng UserPurchasedPack
DELETE FROM UserPurchasedPack
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng UserInfo
-- (Bắt buộc phải xóa toàn bộ dữ liệu từ bảng UserPurchasedPack trước)
DELETE FROM UserInfo
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng ComboPack
-- (Bắt buộc phải xóa toàn bộ dữ liệu từ bảng UserPurchasedPack trước)
DELETE FROM ComboPack
GO
