using MVC12.Models.Customers;
using MVC12.Models.Misc;
using MVC12.Models.Orders;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Products;

public partial class Product
{
    public int ProductId { get; set; }

    public Guid ProductUuid { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public int? ImageId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Image? Image { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ProductSku? ProductSku { get; set; }

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual Supplier Supplier { get; set; } = null!;
}
