namespace WebApi;

public static class WebApiExtensions
{
    public static IServiceCollection WebApiConfiguration(this IServiceCollection services)
    {
        services.Configure<RouteOptions>(config =>
        {
            config.LowercaseUrls = true;
        });
        return services;
    }
}
