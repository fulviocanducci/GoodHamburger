using Application.DTOs.Menu;
using Application.Interfaces;

namespace Application.Services;

public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private readonly IMenuRepository menuRepository = menuRepository;

    public async Task<MenuView> CreateAsync(MenuCreate model)
    {
        return await menuRepository.CreateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await menuRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<MenuView>> GetAsync()
    {
        return await menuRepository.GetAsync();
    }

    public async Task<MenuView?> GetAsync(int id)
    {
        return await menuRepository.GetAsync(id);
    }

    public async Task<bool> UpdateAsync(MenuUpdate model)
    {
        return await menuRepository.UpdateAsync(model);
    }
}
