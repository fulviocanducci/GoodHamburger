using Application.DTOs;
using Application.DTOs.Order;

namespace Application.Interfaces;

public interface IOrderRepository
{
    Task<OrderView?> GetAsync(int id);
    Task<IEnumerable<OrderView>> GetAsync();
    Task<OrderView> CreateAsync(OrderCreate model);
    Task<Result> DeleteAsync(int id);
    //Task<bool> UpdateAsync(OrderUpdate model);
    bool IsIdExist(int id);
}