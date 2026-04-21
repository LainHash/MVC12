namespace MVC12.DTOs.Products.Update
{
    public class UpdateProductDTO : ProductBaseDTO
    {
        public UpdateLaptopDTO? Laptop { get; set; }
        public UpdateCpuDTO? Cpu { get; set; }
        public UpdateGpuDTO? Gpu { get; set; }
        public UpdateStorageDTO? Storage { get; set; }
        public UpdateRamDTO? Ram { get; set; }
    }
}
