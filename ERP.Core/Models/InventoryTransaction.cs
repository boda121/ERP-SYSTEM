using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class InventoryTransaction
{
    public int Id { get; set; }

    public int ProductVariantId { get; set; }

    public int BranchId { get; set; }

    public int TransactionTypeId { get; set; }

    public decimal QuantityChange { get; set; }

    public int? ReferenceId { get; set; }

    public string? UserId { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int? InventoryTransactionTypesid { get; set; }

    public int? ProductVariantsid { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual InventoryTransactionType? InventoryTransactionTypes { get; set; }

    public virtual ProductVariant? ProductVariants { get; set; }

    public virtual AspNetUser? User { get; set; }
}
