using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Infra.EntitiesConfiguration;

namespace ProductManager.Infra.Contexts;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new ProductConfiguration());
    }
}
