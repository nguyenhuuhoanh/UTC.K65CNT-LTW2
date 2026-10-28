using System.ComponentModel.DataAnnotations;

namespace Lab03.Models
{
    public class Student
    {
        public int Id { get; set; } //Mã sinh viên

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ {2} đến {1} ký tự")]
        [Display(Name = "Họ và tên")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có đuôi gmail.com (ví dụ: ten@gmail.com)")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ {2} đến {1} ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phải chọn ngành học")]
        [Display(Name = "Ngành học")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Phải chọn giới tính")]
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ chính quy")]
        public bool IsRegular { get; set; } //true: chính quy, false: phi chính quy

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1963-01-01", "2005-12-31",
            ParseLimitsInInvariantCulture = true,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Phải nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phải nhập điểm")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ {1} đến {2}")]
        [Display(Name = "Điểm")]
        public double? Grade { get; set; }
    }
}
