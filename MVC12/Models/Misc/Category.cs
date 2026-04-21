using MVC12.Models.Products;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Misc;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
