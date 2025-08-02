using ProductManager.Domain.Enums;

namespace ProductManager.Domain.Entities;

public class Product(string name, ECategory category, double price, double defaultDiscount, int quantity)
{
    public Guid Id { get; }
    public string Name { get; private set; } = name;
    public ECategory Category { get; private set; } = category;
    public double Price { get; private set; } = price;
    public double DefaultDiscount { get; private set; } = defaultDiscount;
    public int Quantity { get; private set; } = quantity;

    public void UpdatePrice(double newPrice)
    {
        if (newPrice < 0)
            throw new ArgumentException("Price cannot be negative.");
        Price = newPrice;
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentException("Quantity cannot be negative.");
        Quantity = newQuantity;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be empty or whitespace.");
        Name = newName;
    }

    public void UpdateCategory(ECategory newCategory)
    {
        Category = newCategory;
    }
}
