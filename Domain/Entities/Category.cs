namespace Domain.Entities;
public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public virtual ICollection<Menu> Menus { get; private set; }
    public Category(string name)
    {
        Menus = new HashSet<Menu>();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }
        Name = name;
    }

    public Category(int id, string name)
    {
        Menus = new HashSet<Menu>();
        Id = id;
        Name = name;
    }
}
