using AutoMapper;
using MVC12.DbVirtualViews;
using MVC12.ViewModels.Products;

namespace MVC12.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ViewProduct, ProductVM>().ReverseMap();
            CreateMap<ViewCpuSpec, CpuVM>().ReverseMap();
            CreateMap<ViewGpuSpec, GpuVM>().ReverseMap();
            CreateMap<ViewRamSpec, RamVM>().ReverseMap();
            CreateMap<ViewStorageSpec, StorageVM>().ReverseMap();
            CreateMap<ViewLaptopSpec, LaptopVM>().ReverseMap();
        }
    }
}
