using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class StockAdjustment
{
    public int Id { get; set; }

    public int ProductVariantId { get; set; }

    public int BranchId { get; set; }

    public decimal QuantityChanged { get; set; }

    public string? Reason { get; set; }

    public string? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ProductVariantsid { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ProductVariant? ProductVariants { get; set; }

    public virtual AspNetUser? User { get; set; }
}
