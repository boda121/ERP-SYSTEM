using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class ReturnItem
{
    public int Id { get; set; }

    public int ReturnId { get; set; }

    public int ProductVariantId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Amount { get; set; }

    public virtual ProductVariant? ProductVariants { get; set; }

    public virtual Return Return { get; set; } = null!;
}
