using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC12.Data;
using MVC12.Helpers.Constants;
using MVC12.ViewModels.Products;

namespace MVC12.Controllers
{
    public class ProductController : Controller
    {
        private readonly Dbmvc05Context _context;
        private readonly IMapper _mapper;
        public ProductController(Dbmvc05Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async  Task<IActionResult> Index(string searchString = "", int categoryId = 0, int supplierId = 0, int orderBy = 0)
        {
            var products = await _context.ViewProducts.ToListAsync();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (categoryId > 0)
            {
                products = products.Where(p => p.CategoryId == categoryId).ToList();
            }
            if (supplierId > 0)
            {
                products = products.Where(p => p.SupplierId == supplierId).ToList();
            }

            switch (orderBy)
            {
                case 0:
                    products = products.OrderByDescending(p => p.ProductId).ToList();
                    break;
                case 1:
                    products = products.OrderBy(p => p.ProductId).ToList();
                    break;
                case 2:
                    products = products.OrderBy(p => p.UnitPrice).ToList();
                    break;
                case 3:
                    products = products.OrderByDescending(p => p.UnitPrice).ToList();
                    break;
            }

            var supplierByCategory = _context.Suppliers
                .Where(s => s.Products.Any(p => p.CategoryId == categoryId))
                .ToList();

            ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName", categoryId);
            ViewBag.SupplierId = new SelectList(supplierByCategory, "SupplierId", "CompanyName", supplierId);
            ViewBag.OrderTypes = new SelectList(SortTypes.SortDict, "Key", "Value", orderBy);
            ViewData["CurrentFilter"] = searchString;

            var vm = _mapper.Map<List<ProductVM>>(products);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.ViewProducts
                .FirstOrDefaultAsync(p => p.ProductId == id);

            var vm = _mapper.Map<ProductVM>(product);
            return View(vm);
        }
    }
}
