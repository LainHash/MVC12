using MVC12.Models.Products;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Orders;

public partial class InvoiceDetail
{
    public int InvoiceDetailId { get; set; }

    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public int UnitPrice { get; set; }

    public int Quantity { get; set; }

    public float? DiscountPercent { get; set; }

    public int LineTotal { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
