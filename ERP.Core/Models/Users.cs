using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public  class Users : IdentityUser
{
  
    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<CashierSession> CashierSessions { get; set; } = new List<CashierSession>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<OnlineCart> OnlineCarts { get; set; } = new List<OnlineCart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<SalesInvoice> SalesInvoice { get; set; } = new List<SalesInvoice>();

    public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; } = new List<ShippingAddress>();

    public virtual ICollection<SoftDeleteLog> SoftDeleteLogs { get; set; } = new List<SoftDeleteLog>();

    public virtual ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();

}
