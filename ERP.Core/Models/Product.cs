using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Sku { get; set; }

    public string? Title { get; set; }

    public int CategoryId { get; set; }

    public int UnitId { get; set; }

    public decimal BasePrice { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
