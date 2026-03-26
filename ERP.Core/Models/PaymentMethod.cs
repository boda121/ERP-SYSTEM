using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
