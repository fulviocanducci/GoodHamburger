namespace Domain.Entities;
public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }
        Name = name;
    }
}
