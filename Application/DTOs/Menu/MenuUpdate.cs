namespace Application.DTOs.Menu;

public class MenuUpdate
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
}
