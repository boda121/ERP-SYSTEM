using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.DTOs
{
    public class PurchaseInvoiceItemDto
    {
        public int PurchaseInvoiceId { get; set; }

        public int ProductVariantId { get; set; }

        public decimal Quantity { get; set; }

        public decimal CostPrice { get; set; }

    }
}
