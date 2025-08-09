using Microsoft.AspNetCore.Mvc;
using ProductManager.Domain.Dtos;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Services;

namespace ProductManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService, INotifier notifier) : ControllerBase
{
    private readonly IProductService _productService = productService;
    private readonly INotifier _notifier = notifier;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAll();

        return CustomResponse(products);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] NewProductDto product)
    {
        var productCreated = await _productService.Add(product);

        return CustomResponse(productCreated);
    }

    private IActionResult CustomResponse(object? data)
    {
        if (_notifier.HasNotification())
            return BadRequest(new
            {
                Success = false,
                Errors = _notifier.GetNotifications()
                    .Select(msg => msg.Message)
                    .ToList()
            });

        return Ok(data);
    }
}
