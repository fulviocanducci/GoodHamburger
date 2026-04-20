using Application.Interfaces;

namespace Application.Validators.Category;

public static class CategoryValidadorAll
{
    public static bool BeUniqueName(string name, ICategoryService? categoryService)
    {
        if (categoryService == null) return false;
        return !categoryService.IsNameExist(name);
    }
}
