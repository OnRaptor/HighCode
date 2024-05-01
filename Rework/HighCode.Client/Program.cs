using Blazored.LocalStorage;
using HighCode.Client;
using HighCode.Client.HttpHandlers;
using HighCode.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddTransient<TokenHandler>();
builder.Services
    .AddRefitClient<IHighCodeAPI>()
    .AddHttpMessageHandler<TokenHandler>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5148"));
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<AuthService>();

await builder.Build().RunAsync();