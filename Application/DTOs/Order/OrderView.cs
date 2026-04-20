namespace Application.DTOs.Order
{
    public class OrderView
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Total { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public List<OrderItemView> OrderItems { get; set; } = new List<OrderItemView>();
    }
}
