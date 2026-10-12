using System;

namespace HuuHoanhCNTT2
{
    public class HuuHoanhCNTT2MenuManager
    {
        private readonly StudentConsoleView _view;
        private bool _running = true;

        public HuuHoanhCNTT2MenuManager(StudentConsoleView view)
        {
            _view = view;
        }

        public void Run()
        {
            while (_running)
            {
                HienThiMenu();
                Console.Write("Chọn chức năng: ");
                string choice = (Console.ReadLine() ?? "").Trim();
                XuLyLuaChon(choice);
            }

            Console.WriteLine("\nCảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
        }

        private void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("QUẢN LÝ SINH VIÊN: ");
            Console.WriteLine(" 1. Thêm sinh viên");
            Console.WriteLine(" 2. Hiển thị danh sách");
            Console.WriteLine(" 3. Tìm sinh viên theo mã");
            Console.WriteLine(" 4. Tìm gần đúng theo họ tên");
            Console.WriteLine(" 5. Cập nhật sinh viên");
            Console.WriteLine(" 6. Xóa sinh viên");
            Console.WriteLine(" 7. Sắp xếp theo họ tên");
            Console.WriteLine(" 8. Sắp xếp theo điểm trung bình");
            Console.WriteLine(" 9. Hiển thị sinh viên có điểm từ 8 trở lên");
            Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất");
            Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
            Console.WriteLine("12. Thống kê sinh viên theo ngành");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
            Console.WriteLine(" 0. Thoát chương trình");
        }

        private void XuLyLuaChon(string choice)
        {
            switch (choice)
            {
                case "1": _view.ThemSinhVien(); break;
                case "2": _view.HienThiDanhSach(); break;
                case "3": _view.TimTheoMa(); break;
                case "4": _view.TimGanDungTheoHoTen(); break;
                case "5": _view.CapNhatSinhVien(); break;
                case "6": _view.XoaSinhVien(); break;
                case "7": _view.SapXepTheoHoTen(); break;
                case "8": _view.SapXepTheoDiem(); break;
                case "9": _view.HienThiDiemTuTamTroLen(); break;
                case "10": _view.HienThiDiemCaoNhat(); break;
                case "11": _view.TinhDiemTrungBinhToanBo(); break;
                case "12": _view.ThongKeTheoNganh(); break;
                case "13": _view.ThongKeTheoTrangThai(); break;
                case "0": _running = false; break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
