#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace HighCode.Application.DependencyInjection;

public static class BasicDependencyInjection
{
    public static IServiceCollection AddBasicServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<UserRepository>();
        services.AddScoped<TaskRepository>();
        services.AddScoped<SolutionRepository>();
        services.AddHttpContextAccessor();
        services.AddTransient<CorrelationContext>();
        services.AddTransient(typeof(ResponseFactory<>));
        return services;
    }
}