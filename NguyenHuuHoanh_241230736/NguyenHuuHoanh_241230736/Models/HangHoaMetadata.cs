using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace NguyenHuuHoanh_241230736.Models
{
    [ModelMetadataType(typeof(HangHoaMetadata))]
    public partial class HangHoa { }

    public class HangHoaMetadata
    {
        [Required(ErrorMessage = "Vui lòng nhập tên hàng")]
        public string? TenHang { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(100, 5000, ErrorMessage = "Giá phải là số trong khoảng 100 đến 5000")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên file ảnh")]
        [RegularExpression(@"^.+\.([jJ][pP][gG]|[pP][nN][gG]|[gG][iI][fF]|[tT][iI][fF][fF])$",
            ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
        public string? Anh { get; set; }
    }
}
