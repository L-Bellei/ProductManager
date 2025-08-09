using ProductManager.Domain.Enums;

namespace ProductManager.Domain.Dtos;

public record NewProductDto(string Name, ECategory Category, double Price, double DefaultDiscount, int Quantity)
{
}
