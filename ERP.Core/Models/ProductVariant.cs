using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ERP.Core.Models;

public partial class ProductVariant
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Sku { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public decimal StockQuantity { get; set; }

    public string? UnitType { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<OnlineCartItem> OnlineCartItems { get; set; } = new List<OnlineCartItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductStockPerBranch> ProductStockPerBranches { get; set; } = new List<ProductStockPerBranch>();

    public virtual ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();

    public virtual ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();

    public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();

    public virtual ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
}
