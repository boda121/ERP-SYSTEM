using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ERP.Services.Services.Implementations
{
    public class OrderService
    {
        private readonly IUnitOfWork _Context;
        public OrderService(IUnitOfWork unit) 
        {
        this._Context = unit;
        }

        public async Task<CreateOrderDto?> AddOrderitem(CreateOrderDto orderDto)
        {
            if (orderDto.OrderItems == null || !orderDto.OrderItems.Any())
                return null;

            var SalesItems = new List<SalesInvoiceItem>();
            var variantsDict = new Dictionary<int, ProductVariant>();

            // 🔹 1. Load + Validation مرة واحدة
            foreach (var item in orderDto.OrderItems)
            {
                var variant = await _Context.Repository<ProductVariant>()
                    .GetByIdAsync(item.ProductVariantsid);

                if (variant == null || variant.IsDeleted == true)
                    return null;

                if (variant.StockQuantity < item.Quantity)
                    return null;

                variantsDict[item.ProductVariantsid] = variant;
            }

            // 🔹 2. Create Order
            var ord = new Order
            {
                Status = "Pending",
                SubTotal = 0
            };

            _Context.order.Add(ord);
            await _Context.Commit(); // علشان ناخد Id

            // 🔹 3. Process Items
            foreach (var item in orderDto.OrderItems)
            {
                var variant = variantsDict[item.ProductVariantsid];

                var itemTotal = item.Quantity * variant.Price;

                var orditem = new OrderItem
                {
                    OrderId = ord.Id,
                    ProductVariantId = variant.Id,
                    Quantity = item.Quantity,
                    UnitPrice = variant.Price
                };

                ord.SubTotal += itemTotal;
                variant.StockQuantity -= item.Quantity;

                _Context.Repository<OrderItem>().Add(orditem);

                var inventory = new InventoryTransaction
                {
                    ProductVariantId = variant.Id,
                    QuantityChange = -item.Quantity,
                    Note = "OUT",
                    ReferenceId = ord.Id,
                    BranchId = 1
                };
                _Context.Repository<InventoryTransaction>().Add(inventory);

                var invoiceItem = new SalesInvoiceItem
                {
                    ProductVariantId = variant.Id,
                    Quantity = item.Quantity,
                    UnitPrice = variant.Price,
                    Total = itemTotal
                };

                SalesItems.Add(invoiceItem);
                _Context.Repository<SalesInvoiceItem>().Add(invoiceItem);
            }

            // 🔹 4. Totals
            ord.Shipping = 50;
            ord.Tax = 10;
            ord.GrandTotal = ord.SubTotal + ord.Shipping + ord.Tax;
            ord.Discount = ord.GrandTotal * 0.01m;

            // 🔹 5. Audit
            var audit = new AuditLog
            {
                Action = "Insert Order",
                TableName = "Orders",
                RowId = ord.Id,
            };
            _Context.Repository<AuditLog>().Add(audit);

            // 🔹 6. Invoice
            var salesInvoice = new SalesInvoice
            {
                BranchId = 1,
                GrandTotal = ord.GrandTotal,
                Tax = ord.Tax,
                Discount = ord.Discount,
                SubTotal = ord.SubTotal,
                SalesInvoiceItems = SalesItems,
                PaymentStatus = "Cash"
            };

             _Context.Repository<SalesInvoice>().Add(salesInvoice);

            await _Context.Commit();
            return orderDto;
        }

    }
}
