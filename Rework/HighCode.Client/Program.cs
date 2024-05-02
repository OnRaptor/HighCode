using Blazored.LocalStorage;
using HighCode.Client;
using HighCode.Client.HttpHandlers;
using HighCode.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
    config.SnackbarConfiguration.BackgroundBlurred = true;
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
});
builder.Services.AddTransient<TokenHandler>();
var vars = Environment.GetEnvironmentVariables();
builder.Services
    .AddRefitClient<IHighCodeAPI>()
    .AddHttpMessageHandler<TokenHandler>()
    .ConfigureHttpClient(c => c.BaseAddress =
        new Uri(builder.HostEnvironment.IsDevelopment()
            ? "http://localhost:5148"
            : "http://192.168.0.105:5148"));
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<AuthService>();

await builder.Build().RunAsync();