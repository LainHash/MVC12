using MVC12.Models.Products;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Misc;

public partial class Image
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
