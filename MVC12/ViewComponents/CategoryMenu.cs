using Microsoft.AspNetCore.Mvc;
using MVC12.Data;

namespace MVC12.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly Dbmvc05Context _context;

        public CategoryMenu(Dbmvc05Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(string state)
        {
            var categories = _context.Categories
                .Select(c => new ViewModels.CategoryMenuVM
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName,
                    Count = c.Products.Count(p => !p.IsDeleted ?? true)
                })
                .ToList();
            if(state == "hover")
            {
                return View("StateHover", categories);
            }
            return View(categories);
        }
    }
}
