using System;

namespace HuuHoanhCNTT2
{
    public enum StudentStatus
    {
        DangHoc,
        BaoLuu,
        ThoiHoc,
        TotNghiep
    }
    public class Student
    {
        private static int _totalCreated = 0;
        public static int TotalCreated => _totalCreated;

        public string MaSV { get; private set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string? Email { get; set; }         
        public string? SoDienThoai { get; set; }     
        public string NganhHoc { get; set; }
        public double DiemTrungBinh { get; set; }
        public StudentStatus TrangThaiHocTap { get; set; }

        public Student(
            string maSV,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string nganhHoc,
            double diemTrungBinh,
            StudentStatus trangThaiHocTap = StudentStatus.DangHoc,
            string? email = null,
            string? soDienThoai = null)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            NganhHoc = nganhHoc;
            DiemTrungBinh = diemTrungBinh;
            TrangThaiHocTap = trangThaiHocTap;
            Email = email;
            SoDienThoai = soDienThoai;

            _totalCreated++;
        }

        public override string ToString()
        {
            string email = Email ?? "(chưa có)";
            string sdt = SoDienThoai ?? "(chưa có)";
            return $"{MaSV,-8} | {HoTen,-25} | {NgaySinh:dd/MM/yyyy} | {GioiTinh,-5} | " +
                   $"{NganhHoc,-15} | {DiemTrungBinh,5:0.00} | {TrangThaiHocTap,-10} | {email,-25} | {sdt}";
        }
    }
}
