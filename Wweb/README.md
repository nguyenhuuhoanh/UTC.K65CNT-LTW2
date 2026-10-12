# BÀI 1 – QUẢN LÝ SINH VIÊN BẰNG OOP (C# .NET 8 Console App)

## Thông tin sinh viên
- **Họ tên:** Nguyễn Hữu Hoành
- **Lớp:** CNTT2K65
- **Khoa:** Công nghệ thông tin

## Mô tả
Chương trình Console quản lý sinh viên, xây dựng bằng C# .NET 8, áp dụng các kiến thức:
- Class và Object
- Constructor
- Property
- Encapsulation
- Static Member
- Nullable Reference Types
- `List<T>`

## Cấu trúc thư mục

```
HuuHoanhCNTT2/                     (root repository)
├── .vs/                           (Visual Studio hidden files)
├── HuuHoanhCNTT2.slnx             (solution file)
├── README.md
└── HuuHoanhCNTT2/                 (project folder)
    ├── HuuHoanhCNTT2.csproj
    ├── Program.cs
    ├── Student.cs
    ├── StudentService.cs
    ├── StudentConsoleView.cs
    └── HuuHoanhCNTT2MenuManager.cs
```

## Mô tả các lớp

| Lớp | Vai trò |
|---|---|
| `Student` | Entity — chứa thông tin sinh viên (encapsulation qua property, static counter đếm số sinh viên đã tạo). |
| `StudentService` | Toàn bộ logic nghiệp vụ: thêm, sửa, xóa, tìm kiếm, sắp xếp, thống kê và validate dữ liệu. |
| `StudentConsoleView` | Nhập/xuất dữ liệu qua Console, gọi xuống `StudentService`. |
| `HuuHoanhCNTT2MenuManager` | Vòng lặp menu chính, điều hướng người dùng tới các chức năng. |
| `Program` | Điểm khởi chạy ứng dụng, khởi tạo dữ liệu mẫu. |

## Thông tin sinh viên quản lý
Mã sinh viên, Họ tên, Ngày sinh, Giới tính, Email, Số điện thoại, Ngành học, Điểm trung bình, Trạng thái học tập.

## Chức năng đã hoàn thành (13/13)
1. Thêm sinh viên
2. Hiển thị danh sách
3. Tìm sinh viên theo mã
4. Tìm gần đúng theo họ tên
5. Cập nhật sinh viên
6. Xóa sinh viên
7. Sắp xếp theo họ tên
8. Sắp xếp theo điểm trung bình
9. Hiển thị sinh viên có điểm từ 8 trở lên
10. Hiển thị sinh viên có điểm cao nhất
11. Tính điểm trung bình toàn bộ sinh viên
12. Thống kê sinh viên theo ngành
13. Thống kê sinh viên theo trạng thái

## Chức năng chưa hoàn thành
Không có — toàn bộ 13 chức năng theo yêu cầu đề bài đã được cài đặt.

## Quy tắc nghiệp vụ đã áp dụng
- Mã sinh viên không được trùng.
- Họ tên không được rỗng.
- Điểm trung bình nằm trong khoảng từ 0 đến 10.
- Email phải đúng định dạng (nếu có nhập).
- Chỉ được cập nhật hoặc xóa khi sinh viên tồn tại.

## Cách chạy chương trình

Yêu cầu: đã cài **.NET 8 SDK**.

```bash
cd HuuHoanhCNTT2
dotnet run
```

Hoặc mở file `HuuHoanhCNTT2.slnx` bằng Visual Studio 2022 (bản hỗ trợ .slnx) rồi nhấn F5.

## Dữ liệu mẫu
Chương trình tự động nạp 5 sinh viên mẫu khi khởi động (trong `Program.cs`) để tiện kiểm thử ngay các chức năng tìm kiếm, sắp xếp, thống kê.

## Xử lý lỗi
Các thao tác nhập liệu và cập nhật đều được bọc `try/catch`, thông báo lỗi rõ ràng bằng tiếng Việt khi:
- Dữ liệu không hợp lệ (rỗng, sai định dạng, điểm ngoài khoảng 0–10).
- Mã sinh viên bị trùng khi thêm mới.
- Không tìm thấy sinh viên khi tìm/sửa/xóa.
