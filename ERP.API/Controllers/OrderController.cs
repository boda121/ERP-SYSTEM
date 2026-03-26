using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using ERP.Services.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    public class OrderController : GenericController<Order, OrderDto, OrderDto>
    {
        private readonly OrderService _orderService;
        public OrderController(IService_Layer<Order> context, IMapper mapper,OrderService orderService) : base(context, mapper)
        {
           this._orderService = orderService;
        }

        [HttpPost("AddOrderWithItems")]
        public async Task<IActionResult>addorder(CreateOrderDto dto)
        {
            return Ok(await _orderService.AddOrderitem(dto));
        }

    }
}
