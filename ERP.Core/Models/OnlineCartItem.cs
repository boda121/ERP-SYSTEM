using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class OnlineCartItem
{
    public int Id { get; set; }

    public int OnlineCartId { get; set; }

    public int ProductVariantId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int? OnlineCartsid { get; set; }

    public int? ProductVariantsid { get; set; }

    public virtual OnlineCart? OnlineCarts { get; set; }

    public virtual ProductVariant? ProductVariants { get; set; }
}
