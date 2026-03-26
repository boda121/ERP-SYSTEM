using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public  class SalesInvoiceItem
{
    public int Id { get; set; }

    public int SalesInvoiceId { get; set; }

    public int ProductVariantId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }

    public int? ProductVariantsid { get; set; }

    public int? SalesInvoicesid { get; set; }

    public virtual ProductVariant? ProductVariants { get; set; }

    public virtual SalesInvoice? SalesInvoices { get; set; }
}
