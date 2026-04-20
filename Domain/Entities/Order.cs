namespace Domain.Entities;

public class Order
{
    public Order(string name, decimal total)
    {
        Name = name;
        Total = total;
        OrdersItems = new HashSet<OrderItem>();
    }

    public Order(int id, string name, decimal total)
    {
        Id = id;
        Name = name;
        Total = total;
        OrdersItems = new HashSet<OrderItem>();
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Total { get; private set; }

    public ICollection<OrderItem> OrdersItems { get; private set; }
}
