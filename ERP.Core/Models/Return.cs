using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Return
{
    public int Id { get; set; }

    public int SalesInvoiceId { get; set; }

    public string? UserId { get; set; }

    public decimal Total { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();

    public virtual SalesInvoice? SalesInvoices { get; set; }

    public virtual Users? User { get; set; }
}
