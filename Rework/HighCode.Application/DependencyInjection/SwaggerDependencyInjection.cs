﻿#region

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

#endregion

namespace HighCode.Application.DependencyInjection;

public static class SwaggerDependencyInjection
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, string title, string version)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc($"v{version}", new OpenApiInfo { Title = $"{title}", Version = $"v{version}" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}