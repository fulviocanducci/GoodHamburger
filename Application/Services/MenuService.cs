using Application.Interfaces;

namespace Application.Services;

public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private readonly IMenuRepository menuRepository = menuRepository;
}
