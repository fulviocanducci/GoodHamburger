using Application.DTOs.Order;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<OrderView?> GetAsync(int id);
    Task<IEnumerable<OrderView>> GetAsync();
    Task<OrderView> CreateAsync(OrderCreate model);
    Task<bool> DeleteAsync(int id);
    //Task<bool> UpdateAsync(OrderUpdate model);
}

public interface IOrderRepository
{
    Task<OrderView?> GetAsync(int id);
    Task<IEnumerable<OrderView>> GetAsync();
    Task<OrderView> CreateAsync(OrderCreate model);
    Task<bool> DeleteAsync(int id);
    //Task<bool> UpdateAsync(OrderUpdate model);
}