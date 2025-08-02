using ProductManager.Domain.Entities;

namespace ProductManager.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product> GetById(Guid id);
    Task<IEnumerable<Product>> GetAll();
    Task Add(Product product);
    Task Update(Product product);
    Task Delete(Guid id);
    Task Commit();
}
