using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.Core.DTOs
{
    public class OrderDto
    {
        public string? UserId { get; set; }
        [NotMapped]
        public string? OrderNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    
    }
}
