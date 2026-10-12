Thông tin sinh viên
Họ và tên: Nguyễn Hữu Hoành
Mã số sinh viên: 241230736
Môn học: Lập trình ASP.NET Core MVC
Bài tập: Bài tập tự làm - Tài liệu thực hành ASP.NET Core MVC (version 3)
Chủ đề: Tìm hiểu về View - PartialView - ViewComponent - Layout
Mô tả đề bài

Xây dựng giao diện trang chủ cửa hàng bán sản phẩm gồm:

Thanh menu và layout dùng chung, áp dụng mặc định cho toàn bộ project
Danh mục sản phẩm (cột trái) load bằng PartialView
Danh sách "Sản phẩm mới nhất" load bằng Action Index của HomeController
Khung sản phẩm phía dưới load bằng ViewComponent
Công nghệ sử dụng
ASP.NET Core MVC (.NET 8)
Razor View Engine
Bootstrap 5
Cấu trúc project
DemoLabShop/
├── Controllers/
│   ├── HomeController.cs      // Action Index (Sản phẩm mới nhất), About, Contact
│   └── ProductController.cs   // Action Index (Trang danh sách toàn bộ sản phẩm)
├── Models/
│   ├── Category.cs            // Danh mục sản phẩm
│   └── Product.cs             // Sản phẩm
├── ViewComponents/
│   └── HotProductViewComponent.cs   // Component khung sản phẩm nổi bật
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── About.cshtml
│   │   └── Contact.cshtml
│   ├── Product/
│   │   └── Index.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml         // Layout dùng chung
│   │   ├── _CategoryMenu.cshtml   // PartialView danh mục
│   │   └── Components/HotProduct/Default.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml          // Áp dụng _Layout mặc định
└── wwwroot/
    ├── css/site.css
    └── images/products/
Chức năng đã hoàn thành
STT	Yêu cầu	Trạng thái
1	Thiết kế layout mới, áp dụng mặc định toàn project	✅
2	Danh mục bên trái load từ PartialView	✅
3	Sản phẩm mới nhất load từ Action Index (HomeController)	✅
4	Khung sản phẩm phía dưới load từ ViewComponent	✅
5	Menu điều hướng: Trang chủ, Giới thiệu, Liên hệ, Sản phẩm	✅
Hướng dẫn chạy project
Cài đặt .NET 8 SDK
Giải nén project, mở terminal tại thư mục DemoLabShop
Chạy lệnh:
   dotnet restore
   dotnet run
Mở trình duyệt truy cập địa chỉ được in ra (vd: https://localhost:5001)
