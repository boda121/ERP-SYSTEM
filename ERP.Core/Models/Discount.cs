using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Discount
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? DiscountType { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
