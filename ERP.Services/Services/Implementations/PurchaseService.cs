using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Services.Services.Implementations
{
    public class PurchaseService
    {
    private readonly IUnitOfWork _Context;
        public PurchaseService(IUnitOfWork unitOfWork)
        {
          this._Context = unitOfWork; 
        }

        public async Task<PurchaseInvoiceDto> CreatePurchaseInvoice(PurchaseInvoiceDto purchaseInvoice)
        {
            var purchase= new PurchaseInvoice()
            {
            SupplierId = purchaseInvoice.SupplierId,
            Total= purchaseInvoice.Total,
            };
            _Context.Repository<PurchaseInvoice>().Add(purchase);
            await _Context.Commit();
            var invoiceitem = new PurchaseInvoiceItem();
            foreach (var item in purchaseInvoice.Items)
            {
                invoiceitem.ProductVariantId = item.ProductVariantId;
                invoiceitem.Quantity = item.Quantity;
                invoiceitem.CostPrice = item.CostPrice;
                invoiceitem.PurchaseInvoiceId= item.PurchaseInvoiceId;
                purchase.Total += item.CostPrice * item.Quantity;
                var variant =await _Context.Repository<ProductVariant>().GetByIdAsync(item.ProductVariantId);
                variant.StockQuantity += item.Quantity;
                var inventoryTransaction = new InventoryTransaction
                {
                    ProductVariantId = variant.Id,
                    QuantityChange = item.Quantity,
                    Note = "IN",
                    ReferenceId = purchase.Id,
                    BranchId = 1,
                };
                _Context.Repository<InventoryTransaction>().Add(inventoryTransaction);
            }
            purchase.PurchaseInvoiceItems.Add(invoiceitem); 
          _Context.Repository<PurchaseInvoiceItem>().Add(invoiceitem);
          await _Context.Commit();
            return purchaseInvoice;
        }

    }
}
