using System;
using System.Collections.Generic;
using System.Globalization;

namespace HuuHoanhCNTT2
{
    public class StudentConsoleView
    {
        private readonly StudentService _service;

        public StudentConsoleView(StudentService service)
        {
            _service = service;
        }
        public void ThemSinhVien()
        {
            Console.WriteLine("\n--- THÊM SINH VIÊN ---");
            try
            {
                Console.Write("Mã sinh viên: ");
                string maSV = Console.ReadLine() ?? "";

                Console.Write("Họ tên: ");
                string hoTen = Console.ReadLine() ?? "";

                DateTime ngaySinh = NhapNgay("Ngày sinh (dd/MM/yyyy): ");

                Console.Write("Giới tính: ");
                string gioiTinh = Console.ReadLine() ?? "";

                Console.Write("Email (có thể để trống): ");
                string emailInput = Console.ReadLine() ?? "";
                string? email = string.IsNullOrWhiteSpace(emailInput) ? null : emailInput;

                Console.Write("Số điện thoại (có thể để trống): ");
                string sdtInput = Console.ReadLine() ?? "";
                string? sdt = string.IsNullOrWhiteSpace(sdtInput) ? null : sdtInput;

                Console.Write("Ngành học: ");
                string nganhHoc = Console.ReadLine() ?? "";

                double diemTB = NhapSo("Điểm trung bình (0-10): ");

                StudentStatus trangThai = NhapTrangThai();

                var student = new Student(maSV, hoTen, ngaySinh, gioiTinh, nganhHoc,
                    diemTB, trangThai, email, sdt);

                _service.AddStudent(student);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thêm sinh viên thành công!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                HienThiLoi(ex.Message);
            }
        }
        public void HienThiDanhSach(IReadOnlyList<Student>? list = null)
        {
            var data = list ?? _service.GetAll();

            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
            if (data.Count == 0)
            {
                Console.WriteLine("(Danh sách rỗng)");
                return;
            }

            Console.WriteLine($"{"Mã SV",-8} | {"Họ tên",-25} | {"Ngày sinh",-10} | {"GT",-5} | " +
                               $"{"Ngành",-15} | {"Điểm",5} | {"Trạng thái",-10} | {"Email",-25} | SĐT");
            Console.WriteLine(new string('-', 130));

            foreach (var s in data)
                Console.WriteLine(s.ToString());

            Console.WriteLine($"Tổng số: {data.Count} sinh viên.");
        }
        public void TimTheoMa()
        {
            Console.Write("\nNhập mã sinh viên cần tìm: ");
            string maSV = Console.ReadLine() ?? "";

            var student = _service.FindByMaSV(maSV);
            if (student == null)
                HienThiLoi($"Không tìm thấy sinh viên có mã '{maSV}'.");
            else
                HienThiDanhSach(new List<Student> { student });
        }
        public void TimGanDungTheoHoTen()
        {
            Console.Write("\nNhập từ khóa họ tên: ");
            string keyword = Console.ReadLine() ?? "";

            var result = _service.FindByHoTenGanDung(keyword);
            HienThiDanhSach(result);
        }
        public void CapNhatSinhVien()
        {
            Console.Write("\nNhập mã sinh viên cần cập nhật: ");
            string maSV = Console.ReadLine() ?? "";

            var existing = _service.FindByMaSV(maSV);
            if (existing == null)
            {
                HienThiLoi($"Không tìm thấy sinh viên có mã '{maSV}'.");
                return;
            }

            Console.WriteLine("Thông tin hiện tại: " + existing);
            Console.WriteLine("Nhập thông tin mới (Enter để giữ nguyên giá trị cũ).");

            try
            {
                _service.UpdateStudent(maSV, s =>
                {
                    Console.Write($"Họ tên [{s.HoTen}]: ");
                    string hoTen = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(hoTen)) s.HoTen = hoTen;

                    Console.Write($"Ngành học [{s.NganhHoc}]: ");
                    string nganh = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(nganh)) s.NganhHoc = nganh;

                    Console.Write($"Điểm trung bình [{s.DiemTrungBinh}]: ");
                    string diemInput = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(diemInput) &&
                        double.TryParse(diemInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double diem))
                        s.DiemTrungBinh = diem;

                    Console.Write($"Email [{s.Email ?? "(chưa có)"}]: ");
                    string email = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(email)) s.Email = email;

                    Console.Write($"Số điện thoại [{s.SoDienThoai ?? "(chưa có)"}]: ");
                    string sdt = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(sdt)) s.SoDienThoai = sdt;

                    Console.Write($"Trạng thái [{s.TrangThaiHocTap}] (1.DangHoc 2.BaoLuu 3.ThoiHoc 4.TotNghiep, Enter=giữ nguyên): ");
                    string trangThaiInput = Console.ReadLine() ?? "";
                    switch (trangThaiInput.Trim())
                    {
                        case "1": s.TrangThaiHocTap = StudentStatus.DangHoc; break;
                        case "2": s.TrangThaiHocTap = StudentStatus.BaoLuu; break;
                        case "3": s.TrangThaiHocTap = StudentStatus.ThoiHoc; break;
                        case "4": s.TrangThaiHocTap = StudentStatus.TotNghiep; break;
                    }
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cập nhật thành công!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                HienThiLoi(ex.Message);
            }
        }
        public void XoaSinhVien()
        {
            Console.Write("\nNhập mã sinh viên cần xóa: ");
            string maSV = Console.ReadLine() ?? "";

            Console.Write($"Bạn có chắc chắn muốn xóa sinh viên '{maSV}'? (y/n): ");
            string confirm = Console.ReadLine() ?? "";
            if (!confirm.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Đã hủy thao tác xóa.");
                return;
            }

            bool ok = _service.DeleteStudent(maSV);
            if (ok)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Xóa sinh viên thành công!");
                Console.ResetColor();
            }
            else
            {
                HienThiLoi($"Không tìm thấy sinh viên có mã '{maSV}'.");
            }
        }
        public void SapXepTheoHoTen()
        {
            Console.Write("\nSắp xếp tăng dần? (y/n): ");
            bool asc = (Console.ReadLine() ?? "y").Trim().Equals("y", StringComparison.OrdinalIgnoreCase);
            HienThiDanhSach(_service.SortByHoTen(asc));
        }
        public void SapXepTheoDiem()
        {
            Console.Write("\nSắp xếp tăng dần? (y/n): ");
            bool asc = (Console.ReadLine() ?? "y").Trim().Equals("y", StringComparison.OrdinalIgnoreCase);
            HienThiDanhSach(_service.SortByDiemTrungBinh(asc));
        }
        public void HienThiDiemTuTamTroLen()
        {
            HienThiDanhSach(_service.GetStudentsWithDiemTuTamTroLen());
        }
        public void HienThiDiemCaoNhat()
        {
            HienThiDanhSach(_service.GetStudentsWithDiemCaoNhat());
        }
        public void TinhDiemTrungBinhToanBo()
        {
            double avg = _service.GetDiemTrungBinhToanBo();
            Console.WriteLine($"\nĐiểm trung bình toàn bộ sinh viên: {avg:0.00}");
        }
        public void ThongKeTheoNganh()
        {
            var thongKe = _service.ThongKeTheoNganh();
            Console.WriteLine("\n--- THỐNG KÊ SINH VIÊN THEO NGÀNH ---");
            if (thongKe.Count == 0)
            {
                Console.WriteLine("(Không có dữ liệu)");
                return;
            }
            foreach (var kv in thongKe)
                Console.WriteLine($"{kv.Key,-20}: {kv.Value} sinh viên");
        }
        public void ThongKeTheoTrangThai()
        {
            var thongKe = _service.ThongKeTheoTrangThai();
            Console.WriteLine("\n--- THỐNG KÊ SINH VIÊN THEO TRẠNG THÁI ---");
            if (thongKe.Count == 0)
            {
                Console.WriteLine("(Không có dữ liệu)");
                return;
            }
            foreach (var kv in thongKe)
                Console.WriteLine($"{kv.Key,-15}: {kv.Value} sinh viên");
        }
        private DateTime NhapNgay(string label)
        {
            while (true)
            {
                Console.Write(label);
                string input = Console.ReadLine() ?? "";
                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime result))
                    return result;

                Console.WriteLine("Định dạng ngày không hợp lệ, vui lòng nhập lại (dd/MM/yyyy).");
            }
        }

        private double NhapSo(string label)
        {
            while (true)
            {
                Console.Write(label);
                string input = Console.ReadLine() ?? "";
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                    return result;

                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập lại một số.");
            }
        }

        private StudentStatus NhapTrangThai()
        {
            Console.WriteLine("Trạng thái học tập: 1.DangHoc  2.BaoLuu  3.ThoiHoc  4.TotNghiep");
            Console.Write("Chọn (mặc định 1): ");
            string input = (Console.ReadLine() ?? "").Trim();

            return input switch
            {
                "2" => StudentStatus.BaoLuu,
                "3" => StudentStatus.ThoiHoc,
                "4" => StudentStatus.TotNghiep,
                _ => StudentStatus.DangHoc,
            };
        }

        private void HienThiLoi(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lỗi: " + message);
            Console.ResetColor();
        }
    }
}
