using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class PurchaseInvoice
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public string? InvoiceNumber { get; set; } = new Random().Next().ToString();

    public DateTime Date { get; set; } = DateTime.Now;

    public decimal Total { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}
