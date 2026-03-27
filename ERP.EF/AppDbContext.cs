using ERP.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.EF
{
    public class AppDbContext : IdentityDbContext<Users>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<CashierSession> CashierSessions { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Coupon> Coupons { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

        public virtual DbSet<InventoryTransactionType> InventoryTransactionTypes { get; set; }

        public virtual DbSet<OnlineCart> OnlineCarts { get; set; }

        public virtual DbSet<OnlineCartItem> OnlineCartItems { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<ProductStockPerBranch> ProductStockPerBranches { get; set; }

        public virtual DbSet<ProductVariant> ProductVariants { get; set; }

        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }

        public virtual DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }

        public virtual DbSet<Return> Returns { get; set; }

        public virtual DbSet<ReturnItem> ReturnItems { get; set; }

        public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }

        public virtual DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }

        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }

        public virtual DbSet<SoftDeleteLog> SoftDeleteLogs { get; set; }

        public virtual DbSet<StockAdjustment> StockAdjustments { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<UnitConversion> UnitConversions { get; set; }


    }
}