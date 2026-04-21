using Application.DTOs.Category;
using Application.DTOs.Order;
using Domain.Entities;
using Mapster;

namespace Infrastructure;

public class MapsterConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryCreate>()
            .Map(dest => dest.Name, src => src.Name);

        config.NewConfig<Category, CategoryUpdate>()
              .Map(dest => dest.Name, src => src.Name)
              .Map(dest => dest.Id, src => src.Id);

        config.NewConfig <Order, OrderView>()
            .Map(dest => dest.OrderItems, src => src.OrdersItems);   
        config.NewConfig<OrderItem, OrderItemView>()
            .Map(dest => dest.MenuName, src => src.Menu!.Name);
    }
}
