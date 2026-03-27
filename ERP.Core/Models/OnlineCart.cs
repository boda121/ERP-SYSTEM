using System;
using System.Collections.Generic;

namespace ERP.Core.Models;

public partial class OnlineCart
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<OnlineCartItem> OnlineCartItems { get; set; } = new List<OnlineCartItem>();

    public virtual Users? User { get; set; }
}
