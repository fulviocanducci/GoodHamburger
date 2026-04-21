using Application.DTOs;
using Application.DTOs.Menu;

namespace Application.Interfaces;

public interface IMenuRepository
{
    Task<MenuView?> GetAsync(int id);
    Task<Result> DeleteAsync(int id);
    Task<MenuView> CreateAsync(MenuCreate model);
    Task<Result> UpdateAsync(MenuUpdate model);
    Task<IEnumerable<MenuView>> GetAsync();
}
