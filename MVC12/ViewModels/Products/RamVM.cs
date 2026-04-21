namespace MVC12.ViewModels.Products
{
    public class RamVM
    {
        public int RamId { get; set; }
        public int ProductSkuId { get; set; }

        public string RamName { get; set; } = null!;

        public int RamCapacity { get; set; }

        public string Gen { get; set; } = null!;

        public int RamSpeed { get; set; }

        public string Kit { get; set; } = null!;
    }
}
