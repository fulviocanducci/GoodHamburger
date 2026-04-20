namespace Application.DTOs.Order
{
    public class OrderCreate
    {
        public string Name { get; set; } = string.Empty;
        public List<OrderItemCreate> OrderItems { get; set; } = new List<OrderItemCreate>();
    }

    public class OrderItemCreate
    {
        public int MenuId { get; set; }
    }
}
