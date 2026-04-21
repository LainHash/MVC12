using System.ComponentModel.DataAnnotations;

namespace MVC12.ViewModels
{
    public class CategoryMenuVM
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        public string Name { get; set; } = null!;

        [Display(Name = "Số lượng")]
        public int Count { get; set; } = 0;
    }
}
