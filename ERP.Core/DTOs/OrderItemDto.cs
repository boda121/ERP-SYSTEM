using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.DTOs
{
    public class OrderItemDto
    {
        public decimal Quantity { get; set; }
        public int ProductVariantsid { get; set; }
    }
}
