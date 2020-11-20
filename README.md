# QuanGymChuot - Đồ án lập trình DUT 2020 - 19.Nh12B
## Về ngôn ngữ truy vấn có cấu trúc (SQL)
Hãy xem nội dung này trên Wikipedia (tiếng Anh): https://en.wikipedia.org/wiki/SQL
## Về đồ án
Đồ án này sẽ sử dụng các kiến thức của cơ sở dữ liệu kết hợp với các lệnh truy vấn trong SQL và lập trình trên C# (dotNET Framework), Java, C++,...
- Ứng dụng vào trình quản lý của một phòng Gym cơ bản.
## Sử dụng các ngôn ngữ, phần mềm hỗ trợ
- C# (dotNET Framework)
- ADO.NET
- Microsoft SQL Server Express
## Tạo các bảng cần thiết trong SQL
Về nội dung và đường dẫn tải xuống 3 file về lệnh truy vấn trong SQL, hãy xem tại commit này:
- https://github.com/Zoe13010/QuanGymChuot/commit/bfc5b5f96a07cf54b1cab47a34c717b2424be4b0

Thứ tự chạy file:
- Lưu ý: Lệnh chạy truy vấn trong Microsoft SQL Server Express là Execute (phím tắt mặc định là F5)
1. Tạo bảng sử dụng SqlQuery_CreateSource.sql: bôi đen toàn bộ và chạy lệnh truy vấn.
2. Tạo dữ liệu mẫu sử dụng SqlQuery_CreateData.sql: bôi đen phần INSERT rồi chạy lệnh truy vấn.
   - Trong khi đó phần DELETE sẽ xóa toàn bộ dữ liệu trong các bảng tương ứng.
3. [Tùy chọn] Xuất dữ liệu mẫu theo yêu cầu tương ứng với file SqlQuery_SelectData.sql: bôi đen toàn bộ hoặc một phần các lệnh cần dùng rồi chạy lệnh truy vấn.
## Các công việc trong project C# (WinForm)
- Cơ bản:
  - [x] Control đăng nhập
  - [x] ListView xem danh sách
- Bảng:
  - ComboPack
    - [x] Thêm
    - [x] Sửa
    - [x] Xóa
    - [ ] Tìm kiếm
    - [x] Làm mới
  - UserInfo
    - [ ] Thêm
    - [ ] Sửa
    - [ ] Xóa
    - [ ] Tìm kiếm
    - [x] Làm mới
  - UserPurchasedPack
    - [ ] Thêm
    - [ ] Sửa
    - [ ] Xóa
    - [ ] Tìm kiếm
    - [x] Làm mới
- Tài khoản:
  - [x] Đổi mật khẩu
  - [x] Đăng xuất
  - Quyền hạn xem tài khoản
    - [x] Full quyền (admin)
    - [ ] Chỉ xem (user)
- [ ] Bộ cài đặt: Tạo bộ cài đặt/gỡ bỏ phần mềm (chỉ làm nếu cần thiết)
## Tài liệu đã sử dụng
- Mã hóa chuỗi ký tự sử dụng MD5: https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
