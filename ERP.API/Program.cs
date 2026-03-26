using ERP.Core.Interfaces;
using ERP.EF;
using ERP.EF.Repository;
using Microsoft.EntityFrameworkCore;
using ERP.Services.Services.Implementations;
using ERP.Core.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
}); 
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
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
builder.Services.AddEndpointsApiExplorer();
// Add Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(Optins =>
Optins.UseSqlServer(connectionString,b=> b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
);
builder.Services.AddAutoMapper(typeof(Program));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
