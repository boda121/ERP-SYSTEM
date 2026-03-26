using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class SalesInvoice
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public string? UsersId { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Discount { get; set; }

    public decimal Tax { get; set; }

    public decimal GrandTotal { get; set; }

    public string? PaymentStatus { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? Userid { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();

    public virtual AspNetUser? User { get; set; }

    public virtual AspNetUser? Users { get; set; }
}
