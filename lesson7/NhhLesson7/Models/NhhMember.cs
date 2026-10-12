using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NhhLesson7.Models
{
    /// <summary>
    /// model class member
    /// 
    /// author Huu Hoanh 
    /// </summary>
    public class NhhMember
    {
        public int Id { get; set; }

        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tài khoản có độ dài từ 3 đến 50 ký tự")]
        public string NhhUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu có độ dài từ 8 đến 100 ký tự")]
        [DataType(DataType.Password)]
        public string NhhPassword { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string NhhEmail { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0")]
        public string NhhPhone { get; set; }
    }
}