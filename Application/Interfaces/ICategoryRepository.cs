using Application.DTOs.Category;

namespace Application.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryView?> GetAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<CategoryView> CreateAsync(CategoryCreate model);
    Task<bool> UpdateAsync(CategoryUpdate model);
    Task<IEnumerable<CategoryView>> GetAllAsync();
    Task<bool> IsNameExistAsync(string name);
    bool IsNameExist(string name);
}
