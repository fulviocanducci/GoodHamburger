using Application.DTOs;
using Application.DTOs.Order;
using Application.Interfaces;

namespace Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private readonly IOrderRepository orderRepository = orderRepository;
    public async Task<OrderView> CreateAsync(OrderCreate model)
    {
        return await orderRepository.CreateAsync(model);
    }

    public async Task<Result> DeleteAsync(int id)
    {
        return await orderRepository.DeleteAsync(id);
    }

    public async Task<OrderView?> GetAsync(int id)
    {
        return await orderRepository.GetAsync(id);
    }

    public async Task<IEnumerable<OrderView>> GetAsync()
    {
        return await orderRepository.GetAsync();
    }
}
