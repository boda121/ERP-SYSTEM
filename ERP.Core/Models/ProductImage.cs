using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Url { get; set; }

    public bool IsMain { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;
}
