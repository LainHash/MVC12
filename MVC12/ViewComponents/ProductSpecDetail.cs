using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC12.Data;
using MVC12.ViewModels.Products;

namespace MVC12.ViewComponents
{
    public class ProductSpecDetail : ViewComponent
    {
        private readonly Dbmvc05Context _context;
        private readonly IMapper _mapper;

        public ProductSpecDetail(Dbmvc05Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var product = await _context.ViewProducts.FirstOrDefaultAsync(p => p.ProductId == productId);

            var vm = _mapper.Map<ProductVM>(product);

            vm.Cpu = _mapper.Map<CpuVM>(await _context.ViewCpuSpecs.FirstOrDefaultAsync(c => c.ProductSkuId == vm.ProductSkuId));
            vm.Gpu = _mapper.Map<GpuVM>(await _context.ViewGpuSpecs.FirstOrDefaultAsync(g => g.ProductSkuId == vm.ProductSkuId));
            vm.Ram = _mapper.Map<RamVM>(await _context.ViewRamSpecs.FirstOrDefaultAsync(r => r.ProductSkuId == vm.ProductSkuId));
            vm.Storage = _mapper.Map<StorageVM>(await _context.ViewStorageSpecs.FirstOrDefaultAsync(s => s.ProductSkuId == vm.ProductSkuId));
            vm.Laptop = _mapper.Map<LaptopVM>(await _context.ViewLaptopSpecs.FirstOrDefaultAsync(l => l.ProductSkuId == vm.ProductSkuId));

            if (product == null)
                return Content("Không tìm thấy sản phẩm");

            return View("Default", vm);
        }
    }
}
