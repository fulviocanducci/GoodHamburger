namespace Application.DTOs.Menu;

public class MenuCreate
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
}
