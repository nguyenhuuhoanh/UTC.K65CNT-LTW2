using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace NHHoanh241230726.Models;

[ModelMetadataType(typeof(TaiSanMetadata))]
public partial class TaiSan { }

public class TaiSanMetadata
{
    [Display(Name = "Mã tài sản")]
    public int MaTs { get; set; }

    [Display(Name = "Loại tài sản")]
    public int MaLoai { get; set; }

    [Display(Name = "Tên tài sản")]
    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    public string TenTs { get; set; } = null!;

    [Display(Name = "Nguyên giá (triệu đồng)")]
    [Required(ErrorMessage = "Nguyên giá không được để trống")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000 (triệu đồng)")]
    public decimal? NguyenGia { get; set; }

    [Display(Name = "Tên file ảnh")]
    [FileExtensions(Extensions = "jpg,jpeg,png,webp",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }
}
