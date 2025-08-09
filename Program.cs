using Microsoft.EntityFrameworkCore;
using ProductManager.Configuration;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Repositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Notifier;
using ProductManager.Domain.Services;
using ProductManager.Infra.Contexts;
using ProductManager.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProcuctRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<INotifier, Notifier>();

builder.Services.AddAutoMapperConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
