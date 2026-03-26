using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class Order
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? ShippingAddressId { get; set; }

    public string? OrderNumber { get; set; } 

    public decimal SubTotal { get; set; }

    public decimal Shipping { get; set; }

    public decimal Discount { get; set; }

    public decimal Tax { get; set; }

    public decimal GrandTotal { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsDeleted { get; set; }

    public int? ShippingAddressesid { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ShippingAddress? ShippingAddresses { get; set; }

    public virtual AspNetUser? User { get; set; }
}
