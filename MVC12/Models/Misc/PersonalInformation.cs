using MVC12.Models.Customers;
using MVC12.Models.Employees;
using System;
using System.Collections.Generic;

namespace MVC12.Models.Misc;

public partial class PersonalInformation
{
    public int Piid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly Dob { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string CitizenIdentityCard { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
