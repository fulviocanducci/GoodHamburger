using Application.DTOs;
using Application.DTOs.Category;

namespace Application.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryView?> GetAsync(int id);
    Task<Result> DeleteAsync(int id);
    Task<CategoryView> CreateAsync(CategoryCreate model);
    Task<Result> UpdateAsync(CategoryUpdate model);
    Task<IEnumerable<CategoryView>> GetAsync();
    Task<bool> IsNameExistAsync(string name);
    bool IsNameExist(string name);
    bool IsIdExist(int id);
}
