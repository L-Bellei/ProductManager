namespace ProductManager.Domain.Views;

public record ProductView(Guid Id, string Name, string Category, double Price, double DefaultDiscount, int Quantity)
{
}
