USE QuanGymChuot
GO

-- Tạo dữ liệu mẫu từ bảng GoiDichVu
-- (các gói có thể mua)
DELETE FROM GoiDichVu
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 3 ngày', 5000, 3, '(no more information)')
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 7 ngày', 15000, 7, '(no more information)')
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 1 tháng (30 ngày)', 50000, 30, '(no more information)')
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 3 tháng (90 ngày)', 150000, 90, '(no more information)')
GO

USE QuanGymChuot INSERT INTO GoiDichVu VALUES (DEFAULT, '1', 2, 3, '4', 1)

-- Tạo dữ liệu mẫu từ bảng ThongTinNguoiDung
-- (người dùng đã đăng ký)
DELETE FROM ThongTinNguoiDung
GO
INSERT INTO ThongTinNguoiDung (Name, Gender, Phone)
VALUES ('Name 1', 1, '0123456789')
GO
INSERT INTO ThongTinNguoiDung (Name, Gender, Phone)
VALUES ('Name 2', 0, '0321323219')
GO
INSERT INTO ThongTinNguoiDung (Name, Gender, Phone)
VALUES ('Name 3', 1, '0382858284')
GO

-- Tạo dữ liệu mẫu từ bảng QuanLyGiaoDich
-- (các gói mà khách hàng đã mua)
-- Lưu ý: Kiểm tra lại UserID, ComboID để sửa lại truy vấn mẫu này nếu lỗi.
DELETE FROM QuanLyGiaoDich
GO
INSERT INTO QuanLyGiaoDich (UserID, ComboID)
VALUES (1, 1)
GO
INSERT INTO QuanLyGiaoDich (UserID, ComboID)
VALUES (2, 2)
GO
INSERT INTO QuanLyGiaoDich (UserID, ComboID)
VALUES (3, 3)
GO

-- Tạo dữ liệu mẫu từ bảng ThongTinDangNhap
-- (tài khoản đăng nhập)
INSERT INTO ThongTinDangNhap (Username, Password)
-- Tài khoản: admin, mật khẩu: admin
VALUES (N'admin', '21232f297a57a5a743894a0e4a801fc3')
GO

INSERT INTO ThongTinDangNhap (Username, Password)
-- Tài khoản: Zoe13010, mật khẩu: cloney1301
VALUES (N'Zoe13010', '201dd8aa46f36287fe71f1149425efa0')
GO

-- =============================================================================================

-- Đổi mật khẩu của tài khoản Zoe13010 thành cloney173741
USE QuanGymChuot UPDATE ThongTinDangNhap SET Password = 'e1fa8626ca7d82402e18ffc0b2b02c98' WHERE Username = N'Zoe13010'

UPDATE ThongTinDangNhap SET Password = '21232f297a57a5a743894a0e4a801fc3' WHERE Username = N'admin' AND Password = '21232f297a57a5a743894a0e4a801fc3'

USE QuanGymChuot DELETE FROM GoiDichVu WHERE ID = 10

-- Các truy vấn lỗi để check Trigger ThongTinNguoiDung_Check_Add
--  + Check dưới 10 chữ số
INSERT INTO ThongTinNguoiDung (Name, Phone, Gender)
VALUES ('123', '012345678', 1)
GO
--  + Check trên 11 chữ số
INSERT INTO ThongTinNguoiDung (Name, Phone, Gender)
VALUES ('123', '012345678901', 1)
GO
--  + Check không có chữ số 0 ở đầu
INSERT INTO ThongTinNguoiDung (Name, Phone, Gender)
VALUES ('123', '1234567890', 1)
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng ThongTinDangNhap
DELETE FROM ThongTinDangNhap
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng QuanLyGiaoDich
DELETE FROM QuanLyGiaoDich
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng ThongTinNguoiDung
-- (Bắt buộc phải xóa toàn bộ dữ liệu từ bảng QuanLyGiaoDich trước)
DELETE FROM ThongTinNguoiDung
GO

-- [Delete] Xóa toàn bộ dữ liệu từ bảng GoiDichVu
-- (Bắt buộc phải xóa toàn bộ dữ liệu từ bảng QuanLyGiaoDich trước)
DELETE FROM GoiDichVu
GO
