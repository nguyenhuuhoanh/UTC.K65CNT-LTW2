using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HuuHoanhCNTT2
{
    public class StudentService
    {
        private readonly List<Student> _students = new List<Student>();

        private static readonly Regex EmailRegex =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public IReadOnlyList<Student> GetAll() => _students.AsReadOnly();
        public void AddStudent(Student student)
        {
            ValidateStudent(student);

            if (_students.Any(s => s.MaSV.Equals(student.MaSV, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Mã sinh viên '{student.MaSV}' đã tồn tại.");

            _students.Add(student);
        }
        public Student? FindByMaSV(string maSV)
        {
            return _students.FirstOrDefault(
                s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }
        public List<Student> FindByHoTenGanDung(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<Student>();

            return _students
                .Where(s => s.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public bool UpdateStudent(string maSV, Action<Student> updateAction)
        {
            var student = FindByMaSV(maSV);
            if (student == null) return false;
            var backup = CloneStudent(student);

            updateAction(student);

            try
            {
                ValidateStudent(student);
            }
            catch
            {
                RestoreStudent(student, backup);
                throw;
            }

            return true;
        }
        public bool DeleteStudent(string maSV)
        {
            var student = FindByMaSV(maSV);
            if (student == null) return false;

            _students.Remove(student);
            return true;
        }
        public List<Student> SortByHoTen(bool ascending = true)
        {
            return ascending
                ? _students.OrderBy(s => s.HoTen, StringComparer.OrdinalIgnoreCase).ToList()
                : _students.OrderByDescending(s => s.HoTen, StringComparer.OrdinalIgnoreCase).ToList();
        }
        public List<Student> SortByDiemTrungBinh(bool ascending = true)
        {
            return ascending
                ? _students.OrderBy(s => s.DiemTrungBinh).ToList()
                : _students.OrderByDescending(s => s.DiemTrungBinh).ToList();
        }

        public List<Student> GetStudentsWithDiemTuTamTroLen()
        {
            return _students.Where(s => s.DiemTrungBinh >= 8.0).ToList();
        }
        public List<Student> GetStudentsWithDiemCaoNhat()
        {
            if (_students.Count == 0) return new List<Student>();

            double max = _students.Max(s => s.DiemTrungBinh);
            return _students.Where(s => Math.Abs(s.DiemTrungBinh - max) < 0.0001).ToList();
        }
        public double GetDiemTrungBinhToanBo()
        {
            return _students.Count == 0 ? 0 : _students.Average(s => s.DiemTrungBinh);
        }
        public Dictionary<string, int> ThongKeTheoNganh()
        {
            return _students
                .GroupBy(s => s.NganhHoc)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public Dictionary<StudentStatus, int> ThongKeTheoTrangThai()
        {
            return _students
                .GroupBy(s => s.TrangThaiHocTap)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        private void ValidateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentException("Sinh viên không được null.");

            if (string.IsNullOrWhiteSpace(student.MaSV))
                throw new ArgumentException("Mã sinh viên không được rỗng.");

            if (string.IsNullOrWhiteSpace(student.HoTen))
                throw new ArgumentException("Họ tên không được rỗng.");

            if (student.DiemTrungBinh < 0 || student.DiemTrungBinh > 10)
                throw new ArgumentException("Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");

            if (!string.IsNullOrWhiteSpace(student.Email) && !EmailRegex.IsMatch(student.Email))
                throw new ArgumentException("Email không đúng định dạng.");
        }

        private static Student CloneStudent(Student s)
        {
            return new Student(
                s.MaSV, s.HoTen, s.NgaySinh, s.GioiTinh, s.NganhHoc,
                s.DiemTrungBinh, s.TrangThaiHocTap, s.Email, s.SoDienThoai);
        }

        private static void RestoreStudent(Student target, Student backup)
        {
            target.HoTen = backup.HoTen;
            target.NgaySinh = backup.NgaySinh;
            target.GioiTinh = backup.GioiTinh;
            target.NganhHoc = backup.NganhHoc;
            target.DiemTrungBinh = backup.DiemTrungBinh;
            target.TrangThaiHocTap = backup.TrangThaiHocTap;
            target.Email = backup.Email;
            target.SoDienThoai = backup.SoDienThoai;
        }
    }
}
