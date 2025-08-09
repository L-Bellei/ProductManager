using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces.Repositories;
using ProductManager.Infra.Contexts;

namespace ProductManager.Infra.Repositories;

public class ProcuctRepository(ProductContext context) : IProductRepository
{
    private readonly ProductContext _context = context;

    public async Task<Product?> GetById(Guid id) => await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(prd => prd.Id == id);

    public async Task<Product?> GetByName(string name) => await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(prd => prd.Name == name);

    public async Task<IEnumerable<Product>> GetAll() => await _context.Products
            .AsNoTracking()
            .ToListAsync();

    public async Task Add(Product product) => await _context.Products
        .AddAsync(product);

    public void Update(Product product) => _context.Products
        .Update(product);

    public void Delete(Product product) => _context.Products
        .Remove(product);

    public async Task Commit() => await _context
        .SaveChangesAsync();
}
