using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ParentId { get; set; }

    public bool IsDeleted { get; set; }

    public int? Category1id { get; set; }

    public virtual Category? Category1 { get; set; }

    public virtual ICollection<Category> InverseCategory1 { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
