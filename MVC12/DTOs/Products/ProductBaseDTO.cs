using System.ComponentModel.DataAnnotations;

namespace MVC12.DTOs.Products
{
    public class ProductBaseDTO
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Tên sản phẩm phải từ 3 đến 200 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Danh mục không hợp lệ")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nhà cung cấp không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Nhà cung cấp không hợp lệ")]
        [Display(Name = "Nhà cung cấp")]
        public int SupplierId { get; set; }

        [Url(ErrorMessage = "URL hình ảnh không hợp lệ")]
        [Display(Name = "Hình ảnh")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Giá phải là số dương")]
        [Display(Name = "Giá")]
        public int UnitPrice { get; set; }

        [Required(ErrorMessage = "Số lượng tồn kho không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là số không âm")]
        [Display(Name = "Số lượng tồn kho")]
        public int UnitsInStock { get; set; }

        [Display(Name = "Ngừng sản xuất")]
        public bool? Discontinued { get; set; }
    }
}
