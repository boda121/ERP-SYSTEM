using ERP.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.EF
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");
                            j.ToTable("AspNetUserRoles");
                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AUDIT_LOGS");

                entity.HasIndex(e => e.UserId, "IX_AUDIT_LOGS_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.AuditLogs).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("BRANCHES");
            });

            modelBuilder.Entity<CashierSession>(entity =>
            {
                entity.ToTable("CASHIER_SESSIONS");

                entity.HasIndex(e => e.BranchId, "IX_CASHIER_SESSIONS_BranchId");

                entity.HasIndex(e => e.UserId, "IX_CASHIER_SESSIONS_UserId");

                entity.Property(e => e.ClosingAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OpeningAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TotalRefunds).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TotalSales).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch).WithMany(p => p.CashierSessions).HasForeignKey(d => d.BranchId);

                entity.HasOne(d => d.User).WithMany(p => p.CashierSessions).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.HasIndex(e => e.Category1id, "IX_CATEGORIES_CATEGORY1Id");

                entity.Property(e => e.Category1id).HasColumnName("CATEGORY1Id");

                entity.HasOne(d => d.Category1).WithMany(p => p.InverseCategory1).HasForeignKey(d => d.Category1id);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("COUPONS");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MaxDiscount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MinOrder).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("DISCOUNTS");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ERROR_LOGS");
            });

            modelBuilder.Entity<InventoryTransaction>(entity =>
            {
                entity.ToTable("INVENTORY_TRANSACTIONS");

                entity.HasIndex(e => e.BranchId, "IX_INVENTORY_TRANSACTIONS_BranchId");

                entity.HasIndex(e => e.InventoryTransactionTypesid, "IX_INVENTORY_TRANSACTIONS_INVENTORY_TRANSACTION_TYPESId");

                entity.HasIndex(e => e.ProductVariantsid, "IX_INVENTORY_TRANSACTIONS_PRODUCT_VARIANTSId");

                entity.HasIndex(e => e.UserId, "IX_INVENTORY_TRANSACTIONS_UserId");

                entity.Property(e => e.InventoryTransactionTypesid).HasColumnName("INVENTORY_TRANSACTION_TYPESId");
                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.QuantityChange).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch).WithMany(p => p.InventoryTransactions).HasForeignKey(d => d.BranchId);

                entity.HasOne(d => d.InventoryTransactionTypes).WithMany(p => p.InventoryTransactions).HasForeignKey(d => d.InventoryTransactionTypesid);

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.InventoryTransactions).HasForeignKey(d => d.ProductVariantsid);

                entity.HasOne(d => d.User).WithMany(p => p.InventoryTransactions).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<InventoryTransactionType>(entity =>
            {
                entity.ToTable("INVENTORY_TRANSACTION_TYPES");
            });

            modelBuilder.Entity<OnlineCart>(entity =>
            {
                entity.ToTable("ONLINE_CARTS");

                entity.HasIndex(e => e.UserId, "IX_ONLINE_CARTS_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.OnlineCarts).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<OnlineCartItem>(entity =>
            {
                entity.ToTable("ONLINE_CART_ITEMS");

                entity.HasIndex(e => e.OnlineCartsid, "IX_ONLINE_CART_ITEMS_ONLINE_CARTSId");

                entity.HasIndex(e => e.ProductVariantsid, "IX_ONLINE_CART_ITEMS_PRODUCT_VARIANTSId");

                entity.Property(e => e.OnlineCartsid).HasColumnName("ONLINE_CARTSId");
                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.OnlineCarts).WithMany(p => p.OnlineCartItems).HasForeignKey(d => d.OnlineCartsid);

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.OnlineCartItems).HasForeignKey(d => d.ProductVariantsid);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.HasIndex(e => e.ShippingAddressesid, "IX_ORDERS_SHIPPING_ADDRESSESId");

                entity.HasIndex(e => e.UserId, "IX_ORDERS_UserId");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Shipping).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ShippingAddressesid).HasColumnName("SHIPPING_ADDRESSESId");
                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ShippingAddresses).WithMany(p => p.Orders).HasForeignKey(d => d.ShippingAddressesid);

                entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("ORDER_ITEMS");

                entity.HasIndex(e => e.OrderId, "IX_ORDER_ITEMS_OrderId");

                entity.HasIndex(e => e.ProductVariantsid, "IX_ORDER_ITEMS_PRODUCT_VARIANTSId");

                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.OrderItems).HasForeignKey(d => d.ProductVariantsid);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENTS");

                entity.HasIndex(e => e.PaymentMethodsid, "IX_PAYMENTS_PAYMENT_METHODSId");

                entity.HasIndex(e => e.SalesInvoicesid, "IX_PAYMENTS_SALES_INVOICESId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PaymentMethodsid).HasColumnName("PAYMENT_METHODSId");
                entity.Property(e => e.SalesInvoicesid).HasColumnName("SALES_INVOICESId");

                entity.HasOne(d => d.PaymentMethods).WithMany(p => p.Payments).HasForeignKey(d => d.PaymentMethodsid);

                entity.HasOne(d => d.SalesInvoices).WithMany(p => p.Payments).HasForeignKey(d => d.SalesInvoicesid);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PAYMENT_METHODS");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.HasIndex(e => e.CategoryId, "IX_PRODUCTS_CategoryId");

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("PRODUCT_ATTRIBUTES");

                entity.HasIndex(e => e.ProductId, "IX_PRODUCT_ATTRIBUTES_ProductId");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes).HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductAttributeValue>(entity =>
            {
                entity.ToTable("PRODUCT_ATTRIBUTE_VALUES");

                entity.HasIndex(e => e.ProductAttributesid, "IX_PRODUCT_ATTRIBUTE_VALUES_PRODUCT_ATTRIBUTESId");

                entity.Property(e => e.ProductAttributesid).HasColumnName("PRODUCT_ATTRIBUTESId");

                entity.HasOne(d => d.ProductAttributes).WithMany(p => p.ProductAttributeValues).HasForeignKey(d => d.ProductAttributesid);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("PRODUCT_IMAGES");

                entity.HasIndex(e => e.ProductId, "IX_PRODUCT_IMAGES_ProductId");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductStockPerBranch>(entity =>
            {
                entity.ToTable("PRODUCT_STOCK_PER_BRANCH");

                entity.HasIndex(e => e.BranchId, "IX_PRODUCT_STOCK_PER_BRANCH_BranchId");

                entity.HasIndex(e => e.ProductVariantsid, "IX_PRODUCT_STOCK_PER_BRANCH_PRODUCT_VARIANTSId");

                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch).WithMany(p => p.ProductStockPerBranches).HasForeignKey(d => d.BranchId);

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.ProductStockPerBranches).HasForeignKey(d => d.ProductVariantsid);
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.ToTable("PRODUCT_VARIANTS");

                entity.HasIndex(e => e.ProductId, "IX_PRODUCT_VARIANTS_ProductId");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.StockQuantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants).HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<PurchaseInvoice>(entity =>
            {
                entity.ToTable("PURCHASE_INVOICES");

                entity.HasIndex(e => e.SupplierId, "IX_PURCHASE_INVOICES_SupplierId");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseInvoices).HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<PurchaseInvoiceItem>(entity =>
            {
                entity.ToTable("PURCHASE_INVOICE_ITEMS");

                entity.HasIndex(e => e.ProductVariantsid, "IX_PURCHASE_INVOICE_ITEMS_PRODUCT_VARIANTSId");

                entity.HasIndex(e => e.PurchaseInvoicesid, "IX_PURCHASE_INVOICE_ITEMS_PURCHASE_INVOICESId");

                entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.PurchaseInvoicesid).HasColumnName("PURCHASE_INVOICESId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.PurchaseInvoiceItems).HasForeignKey(d => d.ProductVariantsid);

                entity.HasOne(d => d.PurchaseInvoices).WithMany(p => p.PurchaseInvoiceItems).HasForeignKey(d => d.PurchaseInvoicesid);
            });

            modelBuilder.Entity<Return>(entity =>
            {
                entity.ToTable("RETURNS");

                entity.HasIndex(e => e.SalesInvoicesid, "IX_RETURNS_SALES_INVOICESId");

                entity.HasIndex(e => e.UserId, "IX_RETURNS_UserId");

                entity.Property(e => e.SalesInvoicesid).HasColumnName("SALES_INVOICESId");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.SalesInvoices).WithMany(p => p.Returns).HasForeignKey(d => d.SalesInvoicesid);

                entity.HasOne(d => d.User).WithMany(p => p.Returns).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ReturnItem>(entity =>
            {
                entity.ToTable("RETURN_ITEMS");

                entity.HasIndex(e => e.ProductVariantsid, "IX_RETURN_ITEMS_PRODUCT_VARIANTSId");

                entity.HasIndex(e => e.ReturnId, "IX_RETURN_ITEMS_ReturnId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.ReturnItems).HasForeignKey(d => d.ProductVariantsid);

                entity.HasOne(d => d.Return).WithMany(p => p.ReturnItems).HasForeignKey(d => d.ReturnId);
            });

            modelBuilder.Entity<SalesInvoice>(entity =>
            {
                entity.ToTable("SALES_INVOICES");

                entity.HasIndex(e => e.BranchId, "IX_SALES_INVOICES_BranchId");

                entity.HasIndex(e => e.Userid, "IX_SALES_INVOICES_USERId");

                entity.HasIndex(e => e.UsersId, "IX_SALES_INVOICES_UsersId");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Userid).HasColumnName("USERId");

                entity.HasOne(d => d.Branch).WithMany(p => p.SalesInvoices).HasForeignKey(d => d.BranchId);

                entity.HasOne(d => d.User).WithMany(p => p.SalesInvoiceUsers).HasForeignKey(d => d.Userid);

                entity.HasOne(d => d.Users).WithMany(p => p.SalesInvoiceUsersNavigation).HasForeignKey(d => d.UsersId);
            });

            modelBuilder.Entity<SalesInvoiceItem>(entity =>
            {
                entity.ToTable("SALES_INVOICE_ITEMS");

                entity.HasIndex(e => e.ProductVariantsid, "IX_SALES_INVOICE_ITEMS_PRODUCT_VARIANTSId");

                entity.HasIndex(e => e.SalesInvoicesid, "IX_SALES_INVOICE_ITEMS_SALES_INVOICESId");

                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SalesInvoicesid).HasColumnName("SALES_INVOICESId");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.SalesInvoiceItems).HasForeignKey(d => d.ProductVariantsid);

                entity.HasOne(d => d.SalesInvoices).WithMany(p => p.SalesInvoiceItems).HasForeignKey(d => d.SalesInvoicesid);
            });

            modelBuilder.Entity<ShippingAddress>(entity =>
            {
                entity.ToTable("SHIPPING_ADDRESSES");

                entity.HasIndex(e => e.UserId, "IX_SHIPPING_ADDRESSES_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.ShippingAddresses).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SoftDeleteLog>(entity =>
            {
                entity.ToTable("SOFT_DELETE_LOG");

                entity.HasIndex(e => e.UserId, "IX_SOFT_DELETE_LOG_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.SoftDeleteLogs).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<StockAdjustment>(entity =>
            {
                entity.ToTable("STOCK_ADJUSTMENTS");

                entity.HasIndex(e => e.BranchId, "IX_STOCK_ADJUSTMENTS_BranchId");

                entity.HasIndex(e => e.ProductVariantsid, "IX_STOCK_ADJUSTMENTS_PRODUCT_VARIANTSId");

                entity.HasIndex(e => e.UserId, "IX_STOCK_ADJUSTMENTS_UserId");

                entity.Property(e => e.ProductVariantsid).HasColumnName("PRODUCT_VARIANTSId");
                entity.Property(e => e.QuantityChanged).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch).WithMany(p => p.StockAdjustments).HasForeignKey(d => d.BranchId);

                entity.HasOne(d => d.ProductVariants).WithMany(p => p.StockAdjustments).HasForeignKey(d => d.ProductVariantsid);

                entity.HasOne(d => d.User).WithMany(p => p.StockAdjustments).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("SUPPLIERS");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("UNITS");
            });

            modelBuilder.Entity<UnitConversion>(entity =>
            {
                entity.ToTable("UNIT_CONVERSIONS");

                entity.HasIndex(e => e.FromUnitId, "IX_UNIT_CONVERSIONS_FromUnitId");

                entity.HasIndex(e => e.ToUnitId, "IX_UNIT_CONVERSIONS_ToUnitId");

                entity.Property(e => e.Factor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FromUnit).WithMany(p => p.UnitConversionFromUnits)
                    .HasForeignKey(d => d.FromUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUnit).WithMany(p => p.UnitConversionToUnits)
                    .HasForeignKey(d => d.ToUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }

    }}