using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.DTOs
{
    public class CreateProductDto
    {
        public string? Sku { get; set; }

        public string? Title { get; set; }

        public int CategoryId { get; set; }

        public int UnitId { get; set; }

        public decimal BasePrice { get; set; }

        public virtual ICollection<ProductAttributeDto> ProductAttributes { get; set; } = new List<ProductAttributeDto>();

        public virtual ICollection<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public virtual ICollection<ProductVariantDto> ProductVariants { get; set; } = new List<ProductVariantDto>();
    }
}
