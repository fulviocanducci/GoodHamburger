namespace Domain.Entities;

public class Menu
{
    public Menu(string name, int categoryId, decimal value)
    {
        Name = name;
        CategoryId = categoryId;
        Value = value;
        OrdersItems = new HashSet<OrderItem>();
    }

    public Menu(int id, string name, int categoryId, decimal value)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Value = value;
        OrdersItems = new HashSet<OrderItem>();
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int CategoryId { get; private set; }
    public decimal Value { get; private set; }
    public Category? Category { get; private set; }

    public ICollection<OrderItem> OrdersItems { get; private set; }
}
