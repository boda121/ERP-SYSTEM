using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.EF.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BRANCHES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCHES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CATEGORY1Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CATEGORIES_CATEGORIES_CATEGORY1Id",
                        column: x => x.CATEGORY1Id,
                        principalTable: "CATEGORIES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "COUPONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DISCOUNTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISCOUNTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ERROR_LOGS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR_LOGS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY_TRANSACTION_TYPES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_TRANSACTION_TYPES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT_METHODS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_METHODS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UNITS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowDecimal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNITS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUDIT_LOGS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowId = table.Column<int>(type: "int", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_LOGS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUDIT_LOGS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ONLINE_CARTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ONLINE_CARTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ONLINE_CARTS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SHIPPING_ADDRESSES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPING_ADDRESSES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHIPPING_ADDRESSES_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SOFT_DELETE_LOG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOFT_DELETE_LOG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOFT_DELETE_LOG_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CASHIER_SESSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OpeningAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRefunds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpenedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASHIER_SESSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CASHIER_SESSIONS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CASHIER_SESSIONS_BRANCHES_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BRANCHES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALES_INVOICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USERId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_INVOICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SALES_INVOICES_AspNetUsers_USERId",
                        column: x => x.USERId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SALES_INVOICES_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SALES_INVOICES_BRANCHES_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BRANCHES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PURCHASE_INVOICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_INVOICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PURCHASE_INVOICES_SUPPLIERS_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UNIT_CONVERSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUnitId = table.Column<int>(type: "int", nullable: false),
                    ToUnitId = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIT_CONVERSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UNIT_CONVERSIONS_UNITS_FromUnitId",
                        column: x => x.FromUnitId,
                        principalTable: "UNITS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UNIT_CONVERSIONS_UNITS_ToUnitId",
                        column: x => x.ToUnitId,
                        principalTable: "UNITS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SHIPPING_ADDRESSESId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDERS_SHIPPING_ADDRESSES_SHIPPING_ADDRESSESId",
                        column: x => x.SHIPPING_ADDRESSESId,
                        principalTable: "SHIPPING_ADDRESSES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAYMENT_METHODSId = table.Column<int>(type: "int", nullable: true),
                    SALES_INVOICESId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_PAYMENT_METHODS_PAYMENT_METHODSId",
                        column: x => x.PAYMENT_METHODSId,
                        principalTable: "PAYMENT_METHODS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PAYMENTS_SALES_INVOICES_SALES_INVOICESId",
                        column: x => x.SALES_INVOICESId,
                        principalTable: "SALES_INVOICES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RETURNS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SALES_INVOICESId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RETURNS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RETURNS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RETURNS_SALES_INVOICES_SALES_INVOICESId",
                        column: x => x.SALES_INVOICESId,
                        principalTable: "SALES_INVOICES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_ATTRIBUTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_ATTRIBUTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_ATTRIBUTES_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_IMAGES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_IMAGES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_IMAGES_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_VARIANTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_VARIANTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VARIANTS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_ATTRIBUTE_VALUES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductAttributeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PRODUCT_ATTRIBUTESId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_ATTRIBUTE_VALUES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_ATTRIBUTE_VALUES_PRODUCT_ATTRIBUTES_PRODUCT_ATTRIBUTESId",
                        column: x => x.PRODUCT_ATTRIBUTESId,
                        principalTable: "PRODUCT_ATTRIBUTES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY_TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    QuantityChange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    INVENTORY_TRANSACTION_TYPESId = table.Column<int>(type: "int", nullable: true),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_TRANSACTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INVENTORY_TRANSACTIONS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_INVENTORY_TRANSACTIONS_BRANCHES_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BRANCHES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVENTORY_TRANSACTIONS_INVENTORY_TRANSACTION_TYPES_INVENTORY_TRANSACTION_TYPESId",
                        column: x => x.INVENTORY_TRANSACTION_TYPESId,
                        principalTable: "INVENTORY_TRANSACTION_TYPES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_INVENTORY_TRANSACTIONS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ONLINE_CART_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnlineCartId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ONLINE_CARTSId = table.Column<int>(type: "int", nullable: true),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ONLINE_CART_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ONLINE_CART_ITEMS_ONLINE_CARTS_ONLINE_CARTSId",
                        column: x => x.ONLINE_CARTSId,
                        principalTable: "ONLINE_CARTS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ONLINE_CART_ITEMS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEMS_ORDERS_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEMS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_STOCK_PER_BRANCH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_STOCK_PER_BRANCH", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_STOCK_PER_BRANCH_BRANCHES_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BRANCHES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_STOCK_PER_BRANCH_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PURCHASE_INVOICE_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true),
                    PURCHASE_INVOICESId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_INVOICE_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PURCHASE_INVOICE_ITEMS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PURCHASE_INVOICE_ITEMS_PURCHASE_INVOICES_PURCHASE_INVOICESId",
                        column: x => x.PURCHASE_INVOICESId,
                        principalTable: "PURCHASE_INVOICES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RETURN_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RETURN_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RETURN_ITEMS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RETURN_ITEMS_RETURNS_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "RETURNS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALES_INVOICE_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true),
                    SALES_INVOICESId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_INVOICE_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SALES_INVOICE_ITEMS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SALES_INVOICE_ITEMS_SALES_INVOICES_SALES_INVOICESId",
                        column: x => x.SALES_INVOICESId,
                        principalTable: "SALES_INVOICES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "STOCK_ADJUSTMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    QuantityChanged = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PRODUCT_VARIANTSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_ADJUSTMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STOCK_ADJUSTMENTS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_STOCK_ADJUSTMENTS_BRANCHES_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BRANCHES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STOCK_ADJUSTMENTS_PRODUCT_VARIANTS_PRODUCT_VARIANTSId",
                        column: x => x.PRODUCT_VARIANTSId,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AUDIT_LOGS_UserId",
                table: "AUDIT_LOGS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CASHIER_SESSIONS_BranchId",
                table: "CASHIER_SESSIONS",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CASHIER_SESSIONS_UserId",
                table: "CASHIER_SESSIONS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_CATEGORY1Id",
                table: "CATEGORIES",
                column: "CATEGORY1Id");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_TRANSACTIONS_BranchId",
                table: "INVENTORY_TRANSACTIONS",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_TRANSACTIONS_INVENTORY_TRANSACTION_TYPESId",
                table: "INVENTORY_TRANSACTIONS",
                column: "INVENTORY_TRANSACTION_TYPESId");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_TRANSACTIONS_PRODUCT_VARIANTSId",
                table: "INVENTORY_TRANSACTIONS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_TRANSACTIONS_UserId",
                table: "INVENTORY_TRANSACTIONS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ONLINE_CART_ITEMS_ONLINE_CARTSId",
                table: "ONLINE_CART_ITEMS",
                column: "ONLINE_CARTSId");

            migrationBuilder.CreateIndex(
                name: "IX_ONLINE_CART_ITEMS_PRODUCT_VARIANTSId",
                table: "ONLINE_CART_ITEMS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_ONLINE_CARTS_UserId",
                table: "ONLINE_CARTS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEMS_OrderId",
                table: "ORDER_ITEMS",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEMS_PRODUCT_VARIANTSId",
                table: "ORDER_ITEMS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SHIPPING_ADDRESSESId",
                table: "ORDERS",
                column: "SHIPPING_ADDRESSESId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_UserId",
                table: "ORDERS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_PAYMENT_METHODSId",
                table: "PAYMENTS",
                column: "PAYMENT_METHODSId");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_SALES_INVOICESId",
                table: "PAYMENTS",
                column: "SALES_INVOICESId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_ATTRIBUTE_VALUES_PRODUCT_ATTRIBUTESId",
                table: "PRODUCT_ATTRIBUTE_VALUES",
                column: "PRODUCT_ATTRIBUTESId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_ATTRIBUTES_ProductId",
                table: "PRODUCT_ATTRIBUTES",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGES_ProductId",
                table: "PRODUCT_IMAGES",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_STOCK_PER_BRANCH_BranchId",
                table: "PRODUCT_STOCK_PER_BRANCH",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_STOCK_PER_BRANCH_PRODUCT_VARIANTSId",
                table: "PRODUCT_STOCK_PER_BRANCH",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VARIANTS_ProductId",
                table: "PRODUCT_VARIANTS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASE_INVOICE_ITEMS_PRODUCT_VARIANTSId",
                table: "PURCHASE_INVOICE_ITEMS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASE_INVOICE_ITEMS_PURCHASE_INVOICESId",
                table: "PURCHASE_INVOICE_ITEMS",
                column: "PURCHASE_INVOICESId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASE_INVOICES_SupplierId",
                table: "PURCHASE_INVOICES",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RETURN_ITEMS_PRODUCT_VARIANTSId",
                table: "RETURN_ITEMS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_RETURN_ITEMS_ReturnId",
                table: "RETURN_ITEMS",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_RETURNS_SALES_INVOICESId",
                table: "RETURNS",
                column: "SALES_INVOICESId");

            migrationBuilder.CreateIndex(
                name: "IX_RETURNS_UserId",
                table: "RETURNS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_INVOICE_ITEMS_PRODUCT_VARIANTSId",
                table: "SALES_INVOICE_ITEMS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_INVOICE_ITEMS_SALES_INVOICESId",
                table: "SALES_INVOICE_ITEMS",
                column: "SALES_INVOICESId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_INVOICES_BranchId",
                table: "SALES_INVOICES",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_INVOICES_USERId",
                table: "SALES_INVOICES",
                column: "USERId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_INVOICES_UsersId",
                table: "SALES_INVOICES",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPPING_ADDRESSES_UserId",
                table: "SHIPPING_ADDRESSES",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SOFT_DELETE_LOG_UserId",
                table: "SOFT_DELETE_LOG",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_ADJUSTMENTS_BranchId",
                table: "STOCK_ADJUSTMENTS",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_ADJUSTMENTS_PRODUCT_VARIANTSId",
                table: "STOCK_ADJUSTMENTS",
                column: "PRODUCT_VARIANTSId");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_ADJUSTMENTS_UserId",
                table: "STOCK_ADJUSTMENTS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UNIT_CONVERSIONS_FromUnitId",
                table: "UNIT_CONVERSIONS",
                column: "FromUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UNIT_CONVERSIONS_ToUnitId",
                table: "UNIT_CONVERSIONS",
                column: "ToUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "CASHIER_SESSIONS");

            migrationBuilder.DropTable(
                name: "COUPONS");

            migrationBuilder.DropTable(
                name: "DISCOUNTS");

            migrationBuilder.DropTable(
                name: "ERROR_LOGS");

            migrationBuilder.DropTable(
                name: "INVENTORY_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "ONLINE_CART_ITEMS");

            migrationBuilder.DropTable(
                name: "ORDER_ITEMS");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "PRODUCT_ATTRIBUTE_VALUES");

            migrationBuilder.DropTable(
                name: "PRODUCT_IMAGES");

            migrationBuilder.DropTable(
                name: "PRODUCT_STOCK_PER_BRANCH");

            migrationBuilder.DropTable(
                name: "PURCHASE_INVOICE_ITEMS");

            migrationBuilder.DropTable(
                name: "RETURN_ITEMS");

            migrationBuilder.DropTable(
                name: "SALES_INVOICE_ITEMS");

            migrationBuilder.DropTable(
                name: "SOFT_DELETE_LOG");

            migrationBuilder.DropTable(
                name: "STOCK_ADJUSTMENTS");

            migrationBuilder.DropTable(
                name: "UNIT_CONVERSIONS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "INVENTORY_TRANSACTION_TYPES");

            migrationBuilder.DropTable(
                name: "ONLINE_CARTS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PAYMENT_METHODS");

            migrationBuilder.DropTable(
                name: "PRODUCT_ATTRIBUTES");

            migrationBuilder.DropTable(
                name: "PURCHASE_INVOICES");

            migrationBuilder.DropTable(
                name: "RETURNS");

            migrationBuilder.DropTable(
                name: "PRODUCT_VARIANTS");

            migrationBuilder.DropTable(
                name: "UNITS");

            migrationBuilder.DropTable(
                name: "SHIPPING_ADDRESSES");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "SALES_INVOICES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BRANCHES");

            migrationBuilder.DropTable(
                name: "CATEGORIES");
        }
    }
}
