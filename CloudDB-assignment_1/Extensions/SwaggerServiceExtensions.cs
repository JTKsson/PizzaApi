﻿using Microsoft.OpenApi.Models;

namespace CloudDB_assignment_1.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "CloudDB API", Version = "v1" });
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Name = "Authorization",
                     Type = SecuritySchemeType.Http,
                     Scheme = "bearer",
                     BearerFormat = "JWT",
                     In = ParameterLocation.Header,
                     Description = "You only need to enter the JWT token, bearer is added automatocally"
                 });
                 c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
             new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                 }
             },
             new string[] {}
        }
    });
             });

            return services;
        }
    }
}
