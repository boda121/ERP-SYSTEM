using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class ProductStockPerBranch
{
    public int Id { get; set; }

    public int ProductVariantId { get; set; }

    public int BranchId { get; set; } 

    public decimal Quantity { get; set; } 


    public virtual Branch Branch { get; set; } = null!;

    public virtual ProductVariant? ProductVariants { get; set; }
}
