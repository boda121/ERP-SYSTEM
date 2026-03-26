using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class CashierSession
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int BranchId { get; set; }

    public decimal OpeningAmount { get; set; }

    public decimal? ClosingAmount { get; set; }

    public decimal TotalSales { get; set; }

    public decimal TotalRefunds { get; set; }

    public DateTime OpenedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual AspNetUser? User { get; set; }
}
