namespace Application.DTOs.Order
{
    public class OrderItemView
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public decimal Value { get; set; } = 0;
    }
}
