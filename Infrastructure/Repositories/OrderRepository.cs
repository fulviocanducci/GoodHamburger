using System.Linq;
using Application.DTOs;
using Application.DTOs.Order;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class OrderRepository(DatabaseContext database) : IOrderRepository
{
    private readonly DatabaseContext database = database;
    public async Task<OrderView> CreateAsync(OrderCreate model)
    {
        var menuIds = model.OrderItems?.Select(i => i.MenuId) ?? Enumerable.Empty<int>();
        List<OrderItem> ordersItems = database
            .Menus
            .Include(c => c.Category!)
            .Where(c => menuIds.Contains(c.Id))
            .Select(m => new OrderItem(0, m.Id, m.Value, m)).ToList();
        Order entity = new(model.Name, 0, ordersItems);
        await database.Orders.AddAsync(entity);
        await database.SaveChangesAsync();
        return entity.Adapt<OrderView>();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        return 
            await database.OrderItems.Where(o => o.OrderId == id).ExecuteDeleteAsync() > 0
            && 
            await database.Orders.Where(o => o.Id == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<OrderView?> GetAsync(int id)
    {
        return await database.Orders
            .Include(o => o.OrdersItems)
                .ThenInclude(s => s.Menu!)
                    .ThenInclude(m => m!.Category)
            .Where(o => o.Id == id)
            .ProjectToType<OrderView>()
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<OrderView>> GetAsync()
    {
        return await database.Orders
            .Include(o => o.OrdersItems)
                .ThenInclude(oi => oi.Menu!)
                    .ThenInclude(m => m!.Category)
            .ProjectToType<OrderView>()
            .ToListAsync();
    }

    public bool IsIdExist(int id)
    {
        return database.Orders.Any(o => o.Id == id);
    }
}
