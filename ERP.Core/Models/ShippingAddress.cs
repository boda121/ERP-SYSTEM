using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class ShippingAddress
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? AddressLine { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Users? User { get; set; }
}
