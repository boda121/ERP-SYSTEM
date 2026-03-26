using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<CashierSession> CashierSessions { get; set; } = new List<CashierSession>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<ProductStockPerBranch> ProductStockPerBranches { get; set; } = new List<ProductStockPerBranch>();

    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();

    public virtual ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
}
