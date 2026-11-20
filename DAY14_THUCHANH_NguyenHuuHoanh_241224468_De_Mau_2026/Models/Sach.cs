using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenHuuHoanh_241224468.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    [Required(ErrorMessage ="tên sách ko đc để trống")]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage ="Giá ko được để trống")]
    [Range(typeof(decimal), "50", "1000", ErrorMessage = "giá phải nằm trong giới hạn từ 50 đến 1000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp)$", ErrorMessage = "tên file ảnh phải có đuôi .jpg | .jpeg | .png | .webp")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
