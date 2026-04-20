using Application.DTOs.Category;
using Domain.Entities;
using Mapster;

namespace Infrastructure
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryCreate>()
                .Map(dest => dest.Name, src => src.Name);

            config.NewConfig<Category, CategoryUpdate>()
                  .Map(dest => dest.Name, src => src.Name)
                  .Map(dest => dest.Id, src => src.Id);
        }
    }
}
