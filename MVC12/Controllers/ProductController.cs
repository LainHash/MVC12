using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MVC12.Data;
using MVC12.DTOs.Products.Create;
using MVC12.DTOs.Products.Update;
using MVC12.Helpers.Constants;
using MVC12.Models.Misc;
using MVC12.Models.Products;
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

        public IActionResult Create(int categoryId)
        
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewBag.ImageId = new SelectList(_context.Images, "ImageId", "ImageId");
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");

            ViewBag.Cpus = new SelectList(_context.Cpus, "CpuId", "CpuId");
            ViewBag.Gpus = new SelectList(_context.Gpus, "GpuId", "GpuId");
            ViewBag.Rams = new SelectList(_context.Rams, "RamId", "RamId");
            ViewBag.Storages = new SelectList(_context.Storages, "StorageId", "StorageId");

            ViewBag.SelectedCategory = categoryId;

            var dto = new CreateProductDTO
            {
                CategoryId = categoryId  
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var product = new Product()
            {
                ProductName = dto.ProductName,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId,
                Image = new Image()
                {
                    ImageUrl = string.IsNullOrEmpty(dto.ImageUrl)
                            ? "/img/NotFoundImage.png"
                            : dto.ImageUrl
                }
            };
            var productSku = new ProductSku()
            {
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                Cpu = dto.Cpu != null ? _mapper.Map<Cpu>(dto.Cpu) : null,
                Gpu = dto.Gpu != null ? _mapper.Map<Gpu>(dto.Gpu) : null,
                Ram = dto.Ram != null ? _mapper.Map<Ram>(dto.Ram) : null,
                Storage = dto.Storage != null ? _mapper.Map<Storage>(dto.Storage) : null,
                Laptop = dto.Laptop != null ? new Laptop()
                {
                    LaptopType = dto.Laptop.LaptopType,
                    Os = dto.Laptop.Os,
                    Weight = dto.Laptop.Weight,
                    Length = dto.Laptop.Length,
                    ScreenResolution = dto.Laptop.ScreenResolution,
                    LaptopComponent = new LaptopComponent()
                    {
                        CpuId = dto.Laptop.CpuId,
                        GpuId = dto.Laptop.GpuId,
                        RamId = dto.Laptop.RamId,
                        StorageId = dto.Laptop.StorageId
                    }
                } : null
            };

            product.ProductSku = productSku;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Image)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            var sku = await _context.ProductSkus
                .Include(sk => sk.Laptop)
                    .ThenInclude(l => l.LaptopComponent)
                .Include(sk => sk.Cpu)
                .Include(sk => sk.Gpu)
                .Include(sk => sk.Storage)
                .Include(sk => sk.Ram)
                .FirstOrDefaultAsync(sk => sk.ProductId == id);

            product.ProductSku = sku;

            var dto = _mapper.Map<UpdateProductDTO>(product);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewBag.ImageId = new SelectList(_context.Images, "ImageId", "ImageId");
            ViewBag.ProductSkuId = new SelectList(_context.ProductSkus, "ProductSkuId", "SkuCode");
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");

            ViewBag.Cpus = new SelectList(_context.Cpus, "CpuId", "CpuId");
            ViewBag.Gpus = new SelectList(_context.Gpus, "GpuId", "GpuId");
            ViewBag.Rams = new SelectList(_context.Rams, "RamId", "RamId");
            ViewBag.Storages = new SelectList(_context.Storages, "StorageId", "StorageId");
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProductDTO dto)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Image)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            var sku = await _context.ProductSkus
                .Include(sk => sk.Laptop)
                .ThenInclude(l => l.LaptopComponent)
                .Include(sk => sk.Cpu)
                .Include(sk => sk.Gpu)
                .Include(sk => sk.Storage)
                .Include(sk => sk.Ram)
                .FirstOrDefaultAsync(sk => sk.ProductId == id);


            if (!ModelState.IsValid)
            {
                return View(dto);

            }

            try
            {
                product.ProductName = dto.ProductName;
                product.CategoryId = dto.CategoryId;
                product.SupplierId = dto.SupplierId;
                product.Image = new Image()
                {
                    ImageUrl = string.IsNullOrEmpty(dto.ImageUrl)
                            ? "/img/NotFoundImage.png"
                            : dto.ImageUrl
                };

                sku.UnitPrice = dto.UnitPrice;
                sku.UnitsInStock = dto.UnitsInStock;
                sku.Discontinued = dto.Discontinued;

                switch (product.CategoryId)
                {
                    case 1:
                        if (sku.Laptop != null)
                        {
                            sku.Laptop.LaptopType = dto.Laptop.LaptopType;
                            sku.Laptop.Os = dto.Laptop.Os;
                            sku.Laptop.ScreenResolution = dto.Laptop.ScreenResolution;
                            sku.Laptop.Weight = dto.Laptop.Weight;
                            sku.Laptop.Length = dto.Laptop.Length;

                            sku.Laptop.LaptopComponent.CpuId = dto.Laptop.CpuId;
                            sku.Laptop.LaptopComponent.GpuId = dto.Laptop.GpuId;
                            sku.Laptop.LaptopComponent.StorageId = dto.Laptop.StorageId;
                            sku.Laptop.LaptopComponent.RamId = dto.Laptop.RamId;
                        }
                        break;

                    case 2:
                        if (sku.Cpu != null)
                        {
                            _mapper.Map(dto.Cpu, sku.Cpu);
                        }
                        break;

                    case 3:
                        if (sku.Gpu != null)
                        {
                            _mapper.Map(dto.Gpu, sku.Gpu);
                        }
                        break;

                    case 4:
                        if (sku.Storage != null)
                        {
                            _mapper.Map(dto.Storage, sku.Storage);
                        }
                        break;

                    case 5:
                        if (sku.Ram != null)
                        {
                            _mapper.Map(dto.Ram, sku.Ram);
                        }
                        break;
                }
                product.ProductSku = sku;
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
