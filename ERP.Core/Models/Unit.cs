using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public bool AllowDecimal { get; set; }

    public virtual ICollection<UnitConversion> UnitConversionFromUnits { get; set; } = new List<UnitConversion>();

    public virtual ICollection<UnitConversion> UnitConversionToUnits { get; set; } = new List<UnitConversion>();
}
