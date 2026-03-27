using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class UnitConversion
{
    public int Id { get; set; }
    public int ToUnitId { get; set; }
    public decimal Factor { get; set; }
    public virtual Unit Unit { get; set; } = null!;
}
