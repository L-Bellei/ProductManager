using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces.Repositories;
using ProductManager.Infra.Contexts;

namespace ProductManager.Infra.Repositories;

public class ProcuctRepository : IProductRepository
{
    private readonly ProductContext _context;
    public ProcuctRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _context.Products.FindAsync(id) ?? throw new KeyNotFoundException("Product not found");
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task Delete(Guid id)
    {
        var product = await GetById(id);

        _context.Products.Remove(product);
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
