using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class PurchaseInvoiceItem
{
    public int Id { get; set; }

    public int PurchaseInvoiceId { get; set; }

    public int ProductVariantId { get; set; }

    public decimal Quantity { get; set; }

    public decimal CostPrice { get; set; }

    public virtual ProductVariant? ProductVariants { get; set; }

    public virtual PurchaseInvoice? PurchaseInvoices { get; set; }
}
