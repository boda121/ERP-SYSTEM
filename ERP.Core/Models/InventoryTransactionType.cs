using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class InventoryTransactionType
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}
