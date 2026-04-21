using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC12.Data;
using MVC12.DTOs.Products.Update;

namespace MVC12.ViewComponents
{
    public class UpdateProductSpec : ViewComponent
    {
        private readonly Dbmvc05Context _context;

        public UpdateProductSpec(Dbmvc05Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(UpdateProductDTO dto, int categoryId)
        {
            ViewBag.Cpus = new SelectList(_context.Cpus, "CpuId", "CpuId");
            ViewBag.Gpus = new SelectList(_context.Gpus, "GpuId", "GpuId");
            ViewBag.Rams = new SelectList(_context.Rams, "RamId", "RamId");
            ViewBag.Storages = new SelectList(_context.Storages, "StorageId", "StorageId");
            dto.CategoryId = categoryId;
            return View("Default", dto);
        }
    }
}
