using System.ComponentModel.DataAnnotations;

namespace MVC12.DTOs.Products
{
    public class StorageBaseDTO
    {
        [Required(ErrorMessage = "Dung lượng không được để trống")]
        [Range(64, 4096, ErrorMessage = "Dung lượng phải từ 64 đến 4096 GB")]
        [Display(Name = "Dung lượng (GB)")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Loại bộ nhớ không được để trống")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Loại bộ nhớ phải từ 2 đến 50 ký tự")]
        [Display(Name = "Loại bộ nhớ")]
        public string MemoryType { get; set; } = null!;

        [Required(ErrorMessage = "Giao diện không được để trống")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Giao diện phải từ 2 đến 50 ký tự")]
        [Display(Name = "Giao diện")]
        public string InterfaceType { get; set; } = null!;

        [Required(ErrorMessage = "Tốc độ đọc không được để trống")]
        [Range(100, 10000, ErrorMessage = "Tốc độ đọc phải từ 100 đến 10000 MB/s")]
        [Display(Name = "Tốc độ đọc (MB/s)")]
        public int ReadSpeed { get; set; }

        [Required(ErrorMessage = "Tốc độ ghi không được để trống")]
        [Range(100, 10000, ErrorMessage = "Tốc độ ghi phải từ 100 đến 10000 MB/s")]
        [Display(Name = "Tốc độ ghi (MB/s)")]
        public int WriteSpeed { get; set; }
    }
}
