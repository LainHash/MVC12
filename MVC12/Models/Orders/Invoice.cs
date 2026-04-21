using MVC12.Models.Customers;
using MVC12.Models.Employees;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Orders;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public Guid InvoiceUuid { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public string? Status { get; set; }

    public int? Subtotal { get; set; }

    public float? DiscountAmount { get; set; }

    public float? TaxAmount { get; set; }

    public int? TotalAmount { get; set; }

    public string? Note { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
