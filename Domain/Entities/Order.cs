using Shared.Constants;

namespace Domain.Entities;
public class Order
{
    public Order(string name, decimal total)
    {
        Name = name;
        Total = total;
        OrdersItems = new HashSet<OrderItem>();
    }

    public Order(string name, decimal total, ICollection<OrderItem> orderItems)
    {
        Name = name;
        Total = total;
        OrdersItems = orderItems;
        CalculateDiscount();
    }

    public Order(int id, string name, decimal total, ICollection<OrderItem> orderItems)
    {
        Id = id;
        Name = name;
        Total = total;
        OrdersItems = orderItems;
        CalculateDiscount();
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Total { get; private set; }
    public int Discount { get; private set; }
    public ICollection<OrderItem> OrdersItems { get; private set; }

    public void CalculateDiscount()
    {
        decimal totalForItems = OrdersItems.Sum(i => i.Value);
        bool hasSandwich = OrdersItems.Any(x => x.Menu != null && x.Menu.Category != null && x.Menu.Category.Name.Contains(MenuConstant.SandwichCategory));
        bool hasPotatoes = OrdersItems.Any(x => x.Menu != null && x.Menu.Category != null && x.Menu.Category.Name.Contains(MenuConstant.PotatoesCategory));
        bool hasDrink = OrdersItems.Any(x => x.Menu != null && x.Menu.Category != null && x.Menu.Category.Name.Contains(MenuConstant.DrinkCategory));
        decimal discount = 0;
        if (hasSandwich && hasPotatoes && hasDrink)
        {
            discount = 0.20m;
        }
        else if (hasSandwich && hasDrink)
        {
            discount = 0.15m;
        }
        else if (hasSandwich && hasPotatoes)
        {
            discount = 0.10m;
        }
        Discount = (int)(discount * 100);
        Total = totalForItems * (1 - discount);
    }
}
