using Application.DTOs.Category;

namespace Application.DTOs.Menu;

public class MenuView
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public CategoryView? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
}