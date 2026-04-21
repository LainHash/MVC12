using MVC12.Models.Auths;
using MVC12.Models.Products;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Customers;

public partial class ShoppingCart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? TotalPrice { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
