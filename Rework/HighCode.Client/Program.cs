using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HighCode.Client;
using HighCode.Client.Services;
using Refit;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services
    .AddRefitClient<IHighCodeAPI>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5148"));

await builder.Build().RunAsync();