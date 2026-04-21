using System.ComponentModel.DataAnnotations;

namespace MVC12.DTOs.Products
{
    public class CpuBaseDTO
    {
        [Required(ErrorMessage = "Số nhân không được để trống")]
        [Range(1, 128, ErrorMessage = "Số nhân phải từ 1 đến 128")]
        [Display(Name = "Số nhân")]
        public int Cores { get; set; }

        [Range(1, 256, ErrorMessage = "Số luồng phải từ 1 đến 256")]
        [Display(Name = "Số luồng")]
        public int? Logicals { get; set; }

        [Required(ErrorMessage = "TDP không được để trống")]
        [Range(5, 500, ErrorMessage = "TDP phải từ 5 đến 500")]
        [Display(Name = "TDP (W)")]
        public float Tdp { get; set; }

        [Required(ErrorMessage = "Socket không được để trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Socket phải từ 3 đến 50 ký tự")]
        [Display(Name = "Socket")]
        public string Socket { get; set; } = null!;

        [Required(ErrorMessage = "Tốc độ xung không được để trống")]
        [Range(100, 10000, ErrorMessage = "Tốc độ xung phải từ 100 đến 10000 MHz")]
        [Display(Name = "Tốc độ xung (MHz)")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "Tốc độ Turbo không được để trống")]
        [Range(100, 10000, ErrorMessage = "Tốc độ Turbo phải từ 100 đến 10000 MHz")]
        [Display(Name = "Tốc độ Turbo (MHz)")]
        public int Turbo { get; set; }
    }
}
