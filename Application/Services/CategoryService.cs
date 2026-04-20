using Application.DTOs.Category;
using Application.Interfaces;

namespace Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository categoryRepository = categoryRepository;

    public async Task<CategoryView> CreateAsync(CategoryCreate model)
    {
        return await categoryRepository.CreateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await categoryRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CategoryView>> GetAsync()
    {
        return await categoryRepository.GetAsync();
    }

    public async Task<CategoryView?> GetAsync(int id)
    {
        return await categoryRepository.GetAsync(id);
    }

    public async Task<bool> IsNameExistAsync(string name)
    {
        return await categoryRepository.IsNameExistAsync(name);
    }

    public async Task<bool> UpdateAsync(CategoryUpdate model)
    {
        return await categoryRepository.UpdateAsync(model);
    }

    public bool IsNameExist(string name)
    {
        return categoryRepository.IsNameExist(name);
    }

    public bool IsIdExist(int id)
    {
        return categoryRepository.IsIdExist(id);
    }
}
