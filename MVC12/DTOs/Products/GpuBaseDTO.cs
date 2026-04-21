using System.ComponentModel.DataAnnotations;

namespace MVC12.DTOs.Products
{
    public class GpuBaseDTO
    {
        [Required(ErrorMessage = "Dung lượng bộ nhớ không được để trống")]
        [Range(0.5, 48, ErrorMessage = "Dung lượng phải từ 0.5 đến 48 GB")]
        [Display(Name = "Dung lượng bộ nhớ (GB)")]
        public float MemorySize { get; set; }

        [Required(ErrorMessage = "Loại bộ nhớ không được để trống")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Loại bộ nhớ phải từ 2 đến 50 ký tự")]
        [Display(Name = "Loại bộ nhớ")]
        public string MemoryType { get; set; } = null!;

        [Required(ErrorMessage = "Xung nhịp không được để trống")]
        [Range(100, 3000, ErrorMessage = "Xung nhịp phải từ 100 đến 3000 MHz")]
        [Display(Name = "Xung nhịp (MHz)")]
        public int Clock { get; set; }

        [Required(ErrorMessage = "Unified Shader không được để trống")]
        [Range(1, 10000, ErrorMessage = "Unified Shader phải từ 1 đến 10000")]
        [Display(Name = "Unified Shader")]
        public int UnifiedShader { get; set; }

        [Required(ErrorMessage = "TMU không được để trống")]
        [Range(1, 1000, ErrorMessage = "TMU phải từ 1 đến 1000")]
        [Display(Name = "TMU")]
        public int Tmu { get; set; }

        [Required(ErrorMessage = "ROP không được để trống")]
        [Range(1, 1000, ErrorMessage = "ROP phải từ 1 đến 1000")]
        [Display(Name = "ROP")]
        public int Rop { get; set; }

        [Required(ErrorMessage = "Bus không được để trống")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Bus phải từ 2 đến 50 ký tự")]
        [Display(Name = "Bus")]
        public string Bus { get; set; } = null!;

        [Display(Name = "iGPU")]
        public bool? Igpu { get; set; }
    }
}
