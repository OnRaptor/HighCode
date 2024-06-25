using Blazored.LocalStorage;
using HighCode.Client.HttpHandlers;
using HighCode.Client.Services;
using HighCode.Domain.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using Refit;

namespace HighCode.Client;

public static class Startup
{
    public static IServiceCollection InitServices(this IServiceCollection services, bool isDevelopment)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        services.AddAuthorizationCore(opts =>
        {
            opts.AddPolicy("AllAuthNotBanned", policy =>
            {
                policy
                    .RequireAuthenticatedUser()
                    .RequireAssertion(assert => !assert.User.IsInRole("Banned"));
            });
            opts.AddPolicy("StaffOnly", policy =>
            {
                policy
                    .RequireAuthenticatedUser()
                    .RequireRole("Moderator", "Administrator");
            });
            //возможно не нужна
            opts.AddPolicy("UserOnly", policy =>
                policy.RequireRole("User"));

            opts.AddPolicy("DeleteCommentAccess",
                policy =>
                {
                    policy
                        .RequireAuthenticatedUser()
                        .Combine(opts.GetPolicy("AllAuthNotBanned"))
                        .RequireAssertion(assert
                            => ((CommentDTO)assert.Resource).IsMine || assert.User.IsInRole("Moderator") ||
                               assert.User.IsInRole("Administrator"));
                });
        });
        //services.AddCascadingAuthenticationState(); https://github.com/dotnet/aspnetcore/issues/53075

        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
            config.SnackbarConfiguration.BackgroundBlurred = true;
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.VisibleStateDuration = 3000;
        });
        services.AddTransient<ServerErrorHttpHandler>();
        services.AddTransient<TokenHttpHandler>();

        services
            .AddRefitClient<IHighCodeAPI>()
            .AddHttpMessageHandler<ServerErrorHttpHandler>()
            .AddHttpMessageHandler<TokenHttpHandler>()
            //.ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5148"));
            .ConfigureHttpClient(c => c.BaseAddress =
                new Uri(isDevelopment
                    ? "http://localhost:5148"
                    : "http://94.232.191.189:5148"));

        services.AddBlazoredLocalStorageAsSingleton();
        return services;
    }
}