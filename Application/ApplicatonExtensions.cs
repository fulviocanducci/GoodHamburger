using Application.Interfaces;
using Application.Services;
using Application.Validators.Menu;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicatonExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<MenuCreateValidator>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMenuService, MenuService>();

        return services;
    }
}
