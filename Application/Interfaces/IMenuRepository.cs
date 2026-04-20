using Application.DTOs.Menu;

namespace Application.Interfaces;

public interface IMenuRepository
{
    Task<MenuView?> GetAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<MenuView> CreateAsync(MenuCreate model);
    Task<bool> UpdateAsync(MenuUpdate model);
    Task<IEnumerable<MenuView>> GetAsync();
}
