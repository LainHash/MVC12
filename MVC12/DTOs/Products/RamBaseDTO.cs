using System.ComponentModel.DataAnnotations;

namespace MVC12.DTOs.Products
{
    public class RamBaseDTO
    {
        [Required(ErrorMessage = "Dung lượng không được để trống")]
        [Range(2, 256, ErrorMessage = "Dung lượng phải từ 2 đến 256 GB")]
        [Display(Name = "Dung lượng (GB)")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Thế hệ không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Thế hệ phải từ 1 đến 50 ký tự")]
        [Display(Name = "Thế hệ")]
        public string Gen { get; set; } = null!;

        [Required(ErrorMessage = "Tốc độ không được để trống")]
        [Range(800, 8000, ErrorMessage = "Tốc độ phải từ 800 đến 8000 MHz")]
        [Display(Name = "Tốc độ (MHz)")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "Kit không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Kit phải từ 1 đến 50 ký tự")]
        [Display(Name = "Kit")]
        public string Kit { get; set; } = null!;
    }
}
