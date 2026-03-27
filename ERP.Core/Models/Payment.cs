using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int SalesInvoiceId { get; set; }

    public int PaymentMethodId { get; set; }

    public decimal Amount { get; set; }

    public string? TransactionRef { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual PaymentMethod? PaymentMethods { get; set; }

    public virtual SalesInvoice? SalesInvoices { get; set; }
}
