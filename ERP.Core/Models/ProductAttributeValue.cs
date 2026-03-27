using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public class ProductAttributeValue
{
    public int Id { get; set; }

    public int ProductAttributeId { get; set; }

    public string? Value { get; set; }

    public bool IsDeleted { get; set; }
    public virtual ProductAttribute? ProductAttributes { get; set; }
}
