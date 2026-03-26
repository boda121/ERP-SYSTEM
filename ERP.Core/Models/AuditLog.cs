using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public string? UserId { get; set; } 

    public string? Action { get; set; }

    public string? TableName { get; set; }

    public int? RowId { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public virtual AspNetUser? User { get; set; }
}
