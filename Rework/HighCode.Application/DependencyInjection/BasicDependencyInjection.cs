#region

using HighCode.Application.Common;
using HighCode.Application.Repositories;
using HighCode.Application.Runners;
using HighCode.Application.Runners.Languages;
using HighCode.Application.Services;
using HighCode.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace HighCode.Application.DependencyInjection;

public static class BasicDependencyInjection
{
    public static IServiceCollection AddBasicServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<UserRepository>();
        services.AddScoped<UserService>();
        services.AddTransient<TaskRepository>();
        services.AddTransient<CommentRepository>();
        services.AddTransient<SolutionRepository>();
        services.AddTransient<ReactionRepository>();
        services.AddTransient<LeaderboardRepository>();
        services.AddTransient<TaskCollectionRepository>();
        services.AddTransient<RatingService>();
        services.AddTransient<StatisticRepository>();
        services.AddTransient<CorrelationContext>();
        services.AddTransient<IRunner, CsharpRunner>();
        services.AddTransient<RunnerFactory>();
        services.AddTransient(typeof(ResponseFactory<>));
        services.AddAutoMapper(typeof(AppMapperProfile));
        return services;
    }
}