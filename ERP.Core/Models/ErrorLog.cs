using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? StackTrace { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
