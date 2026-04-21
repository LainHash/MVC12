using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC12.Data;
using MVC12.DTOs.Products.Create;

namespace MVC12.ViewComponents
{
    public class CreateProductSpec : ViewComponent
    {
        private readonly Dbmvc05Context _context;

        public CreateProductSpec(Dbmvc05Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(CreateProductDTO dto, int categoryId)
        {
            ViewBag.Cpus = new SelectList(_context.Cpus, "CpuId", "CpuId");
            ViewBag.Gpus = new SelectList(_context.Gpus, "GpuId", "GpuId");
            ViewBag.Rams = new SelectList(_context.Rams, "RamId", "RamId");
            ViewBag.Storage = new SelectList(_context.Storages, "StorageId", "StorageId");
            dto.CategoryId = categoryId;
            return View("Default", dto);
        }
    }
}
