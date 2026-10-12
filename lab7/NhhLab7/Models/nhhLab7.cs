using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NhhLab7.Models

{
    public class nhhLab7
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="this field is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="account must be between 3 and 50 characters")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage ="this field is required")]
        [EmailAddress(ErrorMessage ="please enter a valid email ")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "phone")]
        [Required(ErrorMessage = "this field is required")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "phone must have 10 digits and start with 0")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "address")]
        [Required(ErrorMessage = "this field is required")]
        [StringLength(35, ErrorMessage = "adress must not exceed 35 characters")]
        public string Address { get; set; } = string.Empty;
        [DisplayName("avatar")]
        public string Avatar { get; set; }
        [DisplayName("your birthday")]
        [Required(ErrorMessage ="this field id required")]
        [DataType(dataType:DataType.Date)]
        public DateTime Birthday { get; set; }
        [DisplayName("gender")]
        public string Gender { get; set; }
        [DisplayName("password")]
        [Required(ErrorMessage ="this field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Facebook")]
        [Required(ErrorMessage ="this field is required")]
        [Url(ErrorMessage ="Facebook must be a valid url")]
        [DataType(dataType:DataType.Url)]
        public string Facebook { get; set; }

    }
}
