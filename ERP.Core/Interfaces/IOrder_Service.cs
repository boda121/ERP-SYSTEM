using ERP.Core.DTOs;
using ERP.Core.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.Interfaces
{
    public interface IOrder_Service 
    {
        Task<ApiResponse<Order, IEnumerable<OrderDto>>> getall();
        Task<ApiResponse<Order, OrderDto>> GetById(int id);
        Task<ApiResponse<Order, OrderDto>> AddOrderitem(CreateOrderDto entity);
        Task<ApiResponse<Order, OrderDto>> Update(int id, OrderDto entity);
        Task<ApiResponse<Order, OrderDto>> Delete(int id);
        Task<ApiResponse<Order, OrderDto>> Recovry(int id);
    }
}
