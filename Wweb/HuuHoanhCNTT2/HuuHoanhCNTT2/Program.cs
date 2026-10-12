using System;

namespace HuuHoanhCNTT2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Quản lý sinh viên - HuuHoanhCNTT2";

            var service = new StudentService();
            SeedDuLieuMau(service);

            var view = new StudentConsoleView(service);
            var menu = new HuuHoanhCNTT2MenuManager(view);

            menu.Run();
        }
        private static void SeedDuLieuMau(StudentService service)
        {
            service.AddStudent(new Student(
                "SV001", "Nguyễn Hữu Hoành", new DateTime(2003, 5, 12), "Nam",
                "Công nghệ thông tin", 8.5, StudentStatus.DangHoc,
                "hoanhnh@example.com", "0901234567"));

            service.AddStudent(new Student(
                "SV002", "Trần Thị Bích", new DateTime(2004, 2, 20), "Nữ",
                "Công nghệ thông tin", 7.2, StudentStatus.DangHoc,
                "bichtt@example.com", "0902345678"));

            service.AddStudent(new Student(
                "SV003", "Lê Văn Cường", new DateTime(2002, 11, 3), "Nam",
                "Kỹ thuật phần mềm", 9.1, StudentStatus.DangHoc,
                "cuonglv@example.com", null));

            service.AddStudent(new Student(
                "SV004", "Phạm Thị Dung", new DateTime(2003, 8, 30), "Nữ",
                "An toàn thông tin", 6.4, StudentStatus.BaoLuu,
                null, "0904567890"));

            service.AddStudent(new Student(
                "SV005", "Hoàng Văn Em", new DateTime(2001, 1, 15), "Nam",
                "Công nghệ thông tin", 9.1, StudentStatus.TotNghiep,
                "emhv@example.com", "0905678901"));
        }
    }
}
