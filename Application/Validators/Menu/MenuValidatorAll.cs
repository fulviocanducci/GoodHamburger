using Application.Interfaces;

namespace Application.Validators.Menu;

public static class MenuValidatorAll
{
    public static bool CategoryIdExists(int categoryId, ICategoryService _categoryService)
    {
        return _categoryService.IsIdExist(categoryId);
    }
}