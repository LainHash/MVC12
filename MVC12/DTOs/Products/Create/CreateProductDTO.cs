using MVC12.Models.Misc;

namespace MVC12.DTOs.Products.Create
{
    public class CreateProductDTO : ProductBaseDTO
    { 
        public CreateCpuDTO? Cpu { get; set; }
        public CreateGpuDTO? Gpu { get; set; }
        public CreateStorageDTO? Storage { get; set; }
        public CreateRamDTO? Ram { get; set; }
        public CreateLaptopDTO? Laptop { get; set; }
    }
}
