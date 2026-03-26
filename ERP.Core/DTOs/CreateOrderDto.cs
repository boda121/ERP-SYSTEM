using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.Core.DTOs
{
    public class CreateOrderDto
    {
        public string? UserId { get; set; }
        [NotMapped]
        public string? OrderNumber { get; } = new Random().Next().ToString();
       

        public List<OrderItemDto>? OrderItems { get; set; }
    }
}
