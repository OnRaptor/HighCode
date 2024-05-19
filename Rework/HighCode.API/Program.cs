#region

using System.Text.Json;
using System.Text.Json.Serialization;
using HighCode.API.Filters;
using HighCode.Application.ApiHandlers.Command.Auth;
using HighCode.Application.DependencyInjection;
using HighCode.Infrastructure;
using Microsoft.EntityFrameworkCore;

#endregion

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger("HighCode API", "1");
builder.Services
    .AddControllers(options => { options.Filters.Add<DefaultModelStateFilter>(); })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly);
});

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AllAuthNotBanned", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(assert => !assert.User.IsInRole("Banned"));
    })
    .AddPolicy("StaffOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Moderator", "Administrator");
    });
builder.Services.AddAppAuthentication();
builder.Services.AddBasicServices();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(config =>
{
    config.AllowAnyOrigin();
    config.AllowAnyHeader();
    config.AllowAnyMethod();
});
app.MapControllers();
app.Run();