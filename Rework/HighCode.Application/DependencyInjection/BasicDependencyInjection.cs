#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Runners;
using HighCode.Application.Runners.Languages;
using HighCode.Application.Services;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace HighCode.Application.DependencyInjection;

public static class BasicDependencyInjection
{
    public static IServiceCollection AddBasicServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<TaskRepository>();
        services.AddScoped<SolutionRepository>();
        services.AddTransient<CorrelationContext>();
        services.AddTransient<IRunner, CsharpRunner>();
        services.AddTransient<RunnerFactory>();
        services.AddTransient(typeof(ResponseFactory<>));
        return services;
    }
}