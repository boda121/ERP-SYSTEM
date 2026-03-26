using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Coupon
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? DiscountType { get; set; }

    public decimal? Amount { get; set; }

    public decimal? MinOrder { get; set; }

    public decimal? MaxDiscount { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool IsDeleted { get; set; }
}
