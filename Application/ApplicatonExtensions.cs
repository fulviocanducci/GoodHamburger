using Application.Interfaces;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicatonExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<MenuCreateValidator>();
        services.AddScoped<ICategoryService, CategoryService>();
        
        return services;
    }
}
