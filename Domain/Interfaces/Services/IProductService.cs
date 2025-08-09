using ProductManager.Domain.Dtos;
using ProductManager.Domain.Views;

namespace ProductManager.Domain.Interfaces.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductView>> GetAll();
    Task<ProductView> Add(NewProductDto newProductDto);
}
