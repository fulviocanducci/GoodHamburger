using Application.DTOs.Category;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public sealed class CategoryRepository(DatabaseContext database) : ICategoryRepository
{
    private readonly DatabaseContext database = database;

    public async Task<CategoryView> CreateAsync(CategoryCreate model)
    {
        Category entity = model.Adapt<Category>();
        await database.Categories.AddAsync(entity);
        await database.SaveChangesAsync();
        return entity.Adapt<CategoryView>();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return (await database.Categories.Where(c => c.Id == id).ExecuteDeleteAsync()) > 0;
    }

    public async Task<IEnumerable<CategoryView>> GetAsync()
    {
        return await database.Categories.ProjectToType<CategoryView>().ToListAsync();
    }

    public async Task<CategoryView?> GetAsync(int id)
    {
        return await database.Categories.Where(c => c.Id == id).ProjectToType<CategoryView>().FirstOrDefaultAsync();
    }

    public async Task<bool> IsNameExistAsync(string name)
    {
        return await database.Categories.AnyAsync(c => c.Name == name);
    }

    public async Task<bool> UpdateAsync(CategoryUpdate model)
    {
        Category entity = model.Adapt<Category>();
        database.Entry(entity).State = EntityState.Modified;
        return await database.SaveChangesAsync() > 0;
    }

    public bool IsNameExist(string name)
    {
        return database.Categories.Any(c => c.Name == name);
    }

    public bool IsIdExist(int id)
    {
        return database.Categories.Any(c => c.Id == id);
    }
}
