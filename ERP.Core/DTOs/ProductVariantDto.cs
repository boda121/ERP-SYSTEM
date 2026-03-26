using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.DTOs
{
    public class ProductVariantDto
    {

        public string? Sku { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public decimal StockQuantity { get; set; }

        public string? UnitType { get; set; }

    }
}
