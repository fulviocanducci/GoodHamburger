namespace Domain.Entities;

public class OrderItem
{
    public OrderItem(int orderId, int menuId, decimal value)
    {
        OrderId = orderId;
        MenuId = menuId;
        Value = value;
    }

    public OrderItem(int id, int orderId, int menuId, decimal value )
    {
        Id = id;
        OrderId = orderId;
        MenuId = menuId;
        Value = value;
    }

    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public Order? Order { get; private set; }
    public int MenuId { get; private set; }
    public Menu? Menu { get; private set; }
    public decimal Value { get; private set; }

}
