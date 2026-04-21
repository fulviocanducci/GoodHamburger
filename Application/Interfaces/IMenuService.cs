using Application.DTOs;
using Application.DTOs.Menu;

namespace Application.Interfaces;

public interface IMenuService
{
    Task<MenuView?> GetAsync(int id);
    Task<Result> DeleteAsync(int id);
    Task<MenuView> CreateAsync(MenuCreate model);
    Task<Result> UpdateAsync(MenuUpdate model);
    Task<IEnumerable<MenuView>> GetAsync();
    Task<IEnumerable<MenuView>> GetAsync(string name);
    bool IsIdExist(int id);
    bool IsIdAndCategoryNameExist(int id, string categoryName);
}
