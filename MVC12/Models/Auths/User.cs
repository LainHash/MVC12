using MVC12.Models.Customers;
using MVC12.Models.Employees;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Auths;

public partial class User
{
    public int UserId { get; set; }

    public Guid? UserUuid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int Balance { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
