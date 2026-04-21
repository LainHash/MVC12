namespace MVC12.ViewModels.Products
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public int ProductSkuId { get; set; }
        public int CategoryId { get; set; }

        public int SupplierId { get; set; }
        public string CategoryName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public Guid ProductUuid { get; set; }

        public int UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public bool? Discontinued { get; set; }

        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;

        public LaptopVM? Laptop {  get; set; }
        public CpuVM? Cpu { get; set; }
        public GpuVM? Gpu { get; set; }
        public RamVM? Ram { get; set; }
        public StorageVM? Storage { get; set; }
    }
}
