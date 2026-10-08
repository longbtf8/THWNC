using System.ComponentModel.DataAnnotations;

namespace MVC04.Models;

public class Product
{
    [Display(Name = "Mã mặt hàng")]
    [Required(ErrorMessage = "Vui lòng nhập mã mặt hàng")]
    [Range(1, int.MaxValue, ErrorMessage = "Mã mặt hàng phải lớn hơn 0")]
    public int ProductID { get; set; }

    [Display(Name = "Tên mặt hàng")]
    public string ProductName { get; set; } = string.Empty;

    [Display(Name = "Ảnh đại diện")]
    public string ImageURL { get; set; } = string.Empty;

    [Display(Name = "Đơn giá")]
    [Required(ErrorMessage = "Vui lòng nhập đơn giá")]
    [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0")]
    public decimal ProductPrice { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }
}
