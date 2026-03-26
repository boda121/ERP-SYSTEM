using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.DTOs
{
    public class ProductAttributeDto
    {
        public string? Name { get; set; }
        public virtual ICollection<ProductAttributeValueDto> ProductAttributeValues { get; set; } = new List<ProductAttributeValueDto>();


    }
}
