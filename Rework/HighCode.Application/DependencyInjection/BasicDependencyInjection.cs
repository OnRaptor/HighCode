using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HighCode.Application.DependencyInjection;

public static class BasicDependencyInjection
{
    public static IServiceCollection AddBasicServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<UserRepository>();
        services.AddTransient(typeof(ResponseFactory<>));
        return services;
    }
}