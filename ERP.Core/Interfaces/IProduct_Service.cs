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
        public Task<CreateProductDto> Add([FromForm] CreateProductDto prod);
        public Task<IEnumerable<productDto>> GetAllProductsAsync();
        public Task<productDto> GetByID(int id);
        public Task<CreateProductDto> update(int id, CreateProductDto product);
        public  Task<string> DeleteProduct(int id);
        public  Task<string> RecovryProduct(int id);



    }
}
