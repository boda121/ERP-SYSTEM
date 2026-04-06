using ERP.Core.DTOs;
using ERP.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.Interfaces
{
   public interface  IProduct_Service
    {
         Task<ApiResponse<Product,productDto>> Add([FromForm] CreateProductDto prod);
         Task<ApiResponse<Product, IEnumerable<productDto>>> GetAllProductsAsync();
         Task<ApiResponse<Product, productDto>> GetByID(int id);
         Task<ApiResponse<Product, productDto>> update(int id, CreateProductDto product);
         Task<ApiResponse<Product, productDto>> DeleteProduct(int id);
         Task<ApiResponse<Product, productDto>> RecovryProduct(int id);



    }
}
