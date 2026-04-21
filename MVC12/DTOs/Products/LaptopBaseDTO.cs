using System.ComponentModel.DataAnnotations;

namespace MVC12.DTOs.Products
{
    public class LaptopBaseDTO
    {
        [Required(ErrorMessage = "Loại laptop không được để trống")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Loại laptop phải từ 2 đến 100 ký tự")]
        [Display(Name = "Loại laptop")]
        public string LaptopType { get; set; } = null!;

        [Required(ErrorMessage = "Hệ điều hành không được để trống")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Hệ điều hành phải từ 2 đến 100 ký tự")]
        [Display(Name = "Hệ điều hành")]
        public string Os { get; set; } = null!;

        [Required(ErrorMessage = "Độ phân giải màn hình không được để trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Độ phân giải phải từ 3 đến 50 ký tự")]
        [Display(Name = "Độ phân giải màn hình")]
        public string ScreenResolution { get; set; } = null!;

        [Required(ErrorMessage = "Chiều dài không được để trống")]
        [Range(20, 50, ErrorMessage = "Chiều dài phải từ 20 đến 50 cm")]
        [Display(Name = "Chiều dài (cm)")]
        public float Length { get; set; }

        [Required(ErrorMessage = "Cân nặng không được để trống")]
        [Range(1, 5, ErrorMessage = "Cân nặng phải từ 1 đến 5 kg")]
        [Display(Name = "Cân nặng (kg)")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "CPU không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "CPU không hợp lệ")]
        [Display(Name = "CPU")]
        public int CpuId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "GPU không hợp lệ")]
        [Display(Name = "GPU")]
        public int? GpuId { get; set; }

        [Required(ErrorMessage = "RAM không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "RAM không hợp lệ")]
        [Display(Name = "RAM")]
        public int RamId { get; set; }

        [Required(ErrorMessage = "Bộ nhớ không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Bộ nhớ không hợp lệ")]
        [Display(Name = "Bộ nhớ")]
        public int StorageId { get; set; }
    }
}
