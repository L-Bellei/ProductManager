using AutoMapper;
using ProductManager.Domain.Dtos;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Repositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Notifier;
using ProductManager.Domain.Views;

namespace ProductManager.Domain.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper, INotifier notifier) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;
    private readonly INotifier _notifier = notifier;

    public async Task<IReadOnlyList<ProductView>> GetAll()
    {
        var products = await _productRepository.GetAll();

        if (!products.Any())
        {
            _notifier.Handle(new Notification("Não foi possível encontrar nenhum produto registrado", 404));
            
            return [];
        }

        return _mapper
            .Map<IReadOnlyList<ProductView>>(products);
    }

    public async Task<ProductView> Add(NewProductDto newProductDto)
    {
        await _productRepository.Add(_mapper.Map<Product>(newProductDto));

        var productCreated = await _productRepository.GetByName(newProductDto.Name);

        if (productCreated == null)
            _notifier.Handle(new Notification("Não foi possível criar o produto, verifique os dados e tente novamente", 400));

        return _mapper
            .Map<ProductView>(productCreated);
    }
}
