using Application.DTOs;
using Application.DTOs.Menu;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MenuRepository(DatabaseContext database) : IMenuRepository
{
    private readonly DatabaseContext database = database;

    public async Task<MenuView> CreateAsync(MenuCreate model)
    {
        Menu entity = model.Adapt<Menu>();
        await database.Menus.AddAsync(entity);
        await database.SaveChangesAsync();
        database.Entry(entity).Reference(m => m.Category).Load();
        return entity.Adapt<MenuView>();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        return await database.Menus.Where(m => m.Id == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<IEnumerable<MenuView>> GetAsync()
    {
        return await database.Menus.Include(m => m.Category)
            .ProjectToType<MenuView>().ToListAsync();
    }

    public async Task<MenuView?> GetAsync(int id)
    {
        return await database.Menus.Where(m => m.Id == id)
            .Include(m => m.Category)
            .ProjectToType<MenuView>().FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<MenuView>> GetAsync(string name)
    {
        return await database.Menus
            .AsNoTracking()
            .Where(m => m.Name.Contains(name))
                .Include(m => m.Category)
            .ProjectToType<MenuView>().ToListAsync();
    }

    public bool IsIdExist(int id)
    {
        return database.Menus.Any(m => m.Id == id);
    }

    public async Task<Result> UpdateAsync(MenuUpdate model)
    {
        Menu entity = model.Adapt<Menu>();
        database.Entry(entity).State = EntityState.Modified;
        return await database.SaveChangesAsync() > 0;
    }
}
