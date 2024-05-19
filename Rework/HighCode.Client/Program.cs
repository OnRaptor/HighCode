using Blazored.LocalStorage;
using HighCode.Client;
using HighCode.Client.HttpHandlers;
using HighCode.Client.Services;
using HighCode.Domain.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddAuthorizationCore(opts =>
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
    opts.AddPolicy("UnAuthOnly", policy =>
        policy.RequireAssertion(assert => !assert.User.Identity.IsAuthenticated));

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
//builder.Services.AddCascadingAuthenticationState(); https://github.com/dotnet/aspnetcore/issues/53075

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
    config.SnackbarConfiguration.BackgroundBlurred = true;
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
});
builder.Services.AddTransient<ServerErrorHttpHandler>();
builder.Services.AddTransient<TokenHttpHandler>();
builder.Services
    .AddRefitClient<IHighCodeAPI>()
    .AddHttpMessageHandler<ServerErrorHttpHandler>()
    .AddHttpMessageHandler<TokenHttpHandler>()
    .ConfigureHttpClient(c => c.BaseAddress =
        new Uri(builder.HostEnvironment.IsDevelopment()
            ? "http://localhost:5148"
            : "http://94.232.191.189:5148"));

builder.Services.AddBlazoredLocalStorageAsSingleton();

await builder.Build().RunAsync();