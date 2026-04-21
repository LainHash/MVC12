using MVC12.Models.Auths;
using MVC12.Models.Misc;
using MVC12.Models.Orders;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Customers;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerCode { get; set; } = null!;

    public int Piid { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual PersonalInformation Pi { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
