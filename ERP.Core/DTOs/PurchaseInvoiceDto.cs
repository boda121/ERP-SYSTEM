using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.DTOs
{
    public class PurchaseInvoiceDto
    {
        public int SupplierId { get; set; }
        public decimal Total { get; set; }
        public List<PurchaseInvoiceItemDto> Items { get; set; } = new List<PurchaseInvoiceItemDto>();


    }
}
