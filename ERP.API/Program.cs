using AutoMapper;
using ERP.API.Mapping;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using ERP.EF;
using ERP.EF.Repository;
using ERP.Services.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(Optins =>
Optins.UseSqlServer(connectionString,b=> b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
);
// Add services to the container.

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IService_Layer<>), typeof(Service_Layer<>));
builder.Services.AddTransient<IProduct_Service, product_service>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<AuditLog>();
builder.Services.AddScoped<SoftDeleteLog>();
builder.Services.AddScoped<ErrorLog>();
builder.Services.AddScoped<InventoryTransaction>();
builder.Services.AddScoped<PurchaseInvoice>();
builder.Services.AddScoped<PurchaseInvoiceItem>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
// Add Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityApiEndpoints<Users>()
    .AddEntityFrameworkStores<AppDbContext>();
// 👇 1. إضافة الـ JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // تحقق من مصدر التوكن
        ValidateAudience = true, // تحقق من المستهدفين
        ValidateLifetime = true, // تحقق من صلاحية التوكن
        ValidateIssuerSigningKey = true, // تحقق من مفتاح التوقيع
        ValidIssuer = builder.Configuration["Jwt:Issuer"], // من appsettings.json
        ValidAudience = builder.Configuration["Jwt:Audience"], // من appsettings.json
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    };
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // UseSwaggerUI is called only in Development.
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapIdentityApi<Users>();

app.Run();
